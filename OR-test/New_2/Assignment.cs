using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Google.OrTools.LinearSolver;

namespace DynamicAssignment
{
	public class Assignment
	{
        //Assignment data
        public List<Applicant> Applicants; //Applicant Data (id, name)
        public List<Receiver> Receivers; // Receiver Data (id, name, min, max)
        public List<DynamicConstraint> DynamicConstraints; // Dynamic Constraint properties
        public List<ApplicantReceiver> ApplicantReceivers; // Application preferences
        public List<ApplicantDynamicConstraint> ApplicantConstraints; // Constraint Data (bool)

        //Properties for assignment
        static public string solverType; //Select OR-tools supported solver
        static public bool applicantOptimal;
        static public bool groupEnvyness;
        static public bool assignEach;
        static public bool UseDynamicConstraints;

        //OR-Tools classes
        private Solver solver;
        

        //nested dictionary, first key is the applicant, second is receiver
        private Dictionary<Applicant, Dictionary<Receiver, Variable>> variables = new Dictionary<Applicant, Dictionary<Receiver, Variable>>();
        private List<Variable> blockingPairs = new List<Variable>();


        //redesign!
        public Assignment(List<Applicant> applicants, 
            List<Receiver> receivers, 
            List<ApplicantReceiver> applicantReceivers, 
            List<DynamicConstraint> constraints = null, 
            List<ApplicantDynamicConstraint> applicantConstraints = null, 
            string solverType = "SCIP", 
            bool applicantOptimal = true, 
            bool groupEnvyness = true, 
            bool assignEach = true,
            bool useDynamicConstraints = true)
        {
            Applicants = applicants;
            Receivers = receivers;
            ApplicantReceivers = applicantReceivers;
            DynamicConstraints = constraints;
            ApplicantConstraints = applicantConstraints;

            Assignment.solverType = solverType;
            Assignment.applicantOptimal = applicantOptimal;
            Assignment.groupEnvyness = groupEnvyness;
            Assignment.assignEach = assignEach;
            Assignment.UseDynamicConstraints = useDynamicConstraints;
        }

        public void RemoveApplicant(Applicant applicant)
        {

            //Removing from applications
            foreach(ApplicantReceiver application in ApplicantReceivers)
            {
                if (application.Applicant == applicant)
                {
                    ApplicantReceivers.Remove(application);
                }
            }
                  
            //Removing from Dynamic constraints
            foreach (ApplicantDynamicConstraint dnData in ApplicantConstraints)
            {
                if (dnData.Applicant == applicant)
                {
                    ApplicantConstraints.Remove(dnData);
                }
            }

            //Removing from Applicants
            Applicants.Remove(applicant);
        }

        public void RemoveReceiver(Receiver receiver)
        {
            foreach (ApplicantReceiver application in ApplicantReceivers)
            {
                if (application.Receiver == receiver)
                {
                    ApplicantReceivers.Remove(application);
                }
            }

            Receivers.Remove(receiver);
        }

        public void RemoveDynamicConstraint(DynamicConstraint dC)
        {
            foreach (ApplicantDynamicConstraint dnData in ApplicantConstraints)
            {
                if (dnData.DynamicConstraint == dC)
                {
                    ApplicantConstraints.Remove(dnData);
                }
            }
            DynamicConstraints.Remove(dC);
        }

        public void AddApplicant(Applicant applicant, ApplicantReceiver[] applications = null, ApplicantDynamicConstraint[] aDC = null)
        {
            if ((applications != null && applications.Length != Receivers.Count) || (aDC != null && aDC.Length != DynamicConstraints.Count))
            {  
                return;
            }
            else
            {

                foreach (ApplicantReceiver application in applications)
                {
                    ApplicantReceivers.Add(application);
                }


                foreach (ApplicantDynamicConstraint applicantDynamicConstraint in aDC)
                {
                    ApplicantConstraints.Add(applicantDynamicConstraint);
                }

            }
        }

        public void AddReceiver(Receiver receiver, ApplicantReceiver[] applications = null)
        {
            if (applications != null && applications.Length != Applicants.Count)
            {

                return;
            }
            else
            {
                Receivers.Add(receiver);

                foreach (ApplicantReceiver application in applications)
                {
                    ApplicantReceivers.Add(application);
                }
            }
        }

        public void AddDynamicConstraint(DynamicConstraint dC, ApplicantDynamicConstraint[] aDC)
        {
            if (aDC.Length != Applicants.Count)
            {
                return;
            }
            else
            {
                DynamicConstraints.Add(dC);

                foreach (ApplicantDynamicConstraint adc in aDC)
                {
                    ApplicantConstraints.Add(adc);
                }
            }
        }

        public void AddApplication()
        {

        }

        public void RemoveApplication()
        {

        }


        //Run solver and receive results
        public Solver.ResultStatus Solve()
        {
            
            InvokeSolver();
            CreateVariables();
            CreateConstraints();
            CreateObjective();

            string lpFile = solver.ExportModelAsLpFormat(false);

            Console.WriteLine(lpFile);

            Solver.ResultStatus resultStatus = solver.Solve();

            foreach (Applicant applicant in Applicants)
            {
                foreach (Receiver receiver in Receivers)
                {
                    if (variables[applicant][receiver].SolutionValue() > 0.5)
                    {
                        //Console.WriteLine($"Student {applicant.ApplicantName} assigned to job {receiver.ReceiverName}");
                        Console.WriteLine($"{applicant.ApplicantID}    {receiver.ReceiverID}");
                    }
                    else
                    {
                        //Console.WriteLine($"Student {i} NOT assigned to job {j}");
                    }
                }
            }
            foreach (Variable variable in blockingPairs)
            {
                if(variable.SolutionValue() > 0.5)
                {
                    Console.WriteLine(variable.Name());
                }
            }
            return resultStatus;
        }
        private void InvokeSolver()
        {
            //invoking solver
            solver = Solver.CreateSolver(solverType);
            if (solver is null)
            {
                return;
            }
        }

        //Create variables for solver
        private void CreateVariables()

        {
            foreach (Applicant applicant in Applicants)
            {
                
                List<ApplicantReceiver> applications = (from ar in ApplicantReceivers
                                                        where 
                                                        ar.Applicant == applicant
                                                        select ar).ToList();

                Dictionary<Receiver, Variable> innerDict = new Dictionary<Receiver, Variable>();

                foreach (ApplicantReceiver applicantReceiver in applications)
                {    
                    innerDict.Add(
                        applicantReceiver.Receiver,
                        solver.MakeBoolVar($"X{applicantReceiver.Applicant.ApplicantID}_{applicantReceiver.Receiver.ReceiverID}")
                        );
                  
                }
                variables.Add(applicant, innerDict);
                
            }
        }

        //Create constraints for solver
        private void CreateConstraints()
        {
            CreateApplicantBoundaries();

            CreateReceiverBoundaries();

            CreateDynamicConstraints();

            CreateStabilityConstraints();

            void CreateApplicantBoundaries()
            {         
                //Applicant's boundaires (1 applicant can be assigned to maximum one place)
                if (assignEach)
                {
                    foreach (Applicant applicant in Applicants)
                    {
                        Constraint constraint = solver.MakeConstraint(1, 1, $"Applicant_{applicant.ApplicantID}");
                        foreach (Receiver receiver in Receivers)
                        {                            
                            constraint.SetCoefficient(variables[applicant][receiver], 1);
                        }
                    }
                }
                else
                {
                    
                    foreach (Applicant applicant in Applicants)
                    {
                        Constraint constraint = solver.MakeConstraint(0, 1, $"Applicant_{applicant.ApplicantID}");
                        foreach (Receiver receiver in Receivers)
                        {                            
                            constraint.SetCoefficient(variables[applicant][receiver], 1);
                        }
                    }
                }

            }

            void CreateReceiverBoundaries()
            {
                foreach (Receiver receiver in Receivers)
                {
                    int minLimit = receiver.MinimumCapacity;
                    int maxLimit = receiver.MaximumCapacity;

                    Constraint constraint = solver.MakeConstraint(minLimit, maxLimit, $"Receiver_{receiver.ReceiverID}");
                    foreach (Applicant applicant in Applicants)
                    {                 
                        constraint.SetCoefficient(variables[applicant][receiver], 1);
                    }
                }
            }

            void CreateStabilityConstraints()
            {             
                if (groupEnvyness)
                {       
                    if (applicantOptimal)
                    {
                        foreach (Applicant applicant in Applicants)
                        {
                            foreach (Receiver receiver in Receivers)
                            {
                                int applicantPoints = (from application in ApplicantReceivers
                                                       where application.Applicant.ApplicantID == applicant.ApplicantID
                                                       && application.Receiver.ReceiverID == receiver.ReceiverID
                                                       select application.ReceiverPoints).FirstOrDefault();

                                int applicantPreference = (from application in ApplicantReceivers
                                                           where application.Applicant.ApplicantID == applicant.ApplicantID
                                                           && application.Receiver.ReceiverID == receiver.ReceiverID
                                                           select application.ApplicantPreference).FirstOrDefault();

                                List<bool> applicantGroup = (from dc in ApplicantConstraints
                                                                          where dc.Applicant == applicant
                                                                          select dc.ApplicantData).ToList();


                                //applicants in the same group with worse applications points to the receiver
                                List<Applicant> worseApplicants = (from application in ApplicantReceivers
                                                                   where application.ReceiverPoints < applicantPoints
                                                                   && application.Receiver.ReceiverID == receiver.ReceiverID
                                                                   select application.Applicant).ToList();

                                //receivers that are prefered more by the applicant
                                List<Receiver> betterReceivers = (from application in ApplicantReceivers
                                                                  where application.ApplicantPreference < applicantPreference
                                                                  && application.Applicant.ApplicantID == applicant.ApplicantID
                                                                  select application.Receiver).ToList();

                                foreach (Applicant worseApplicant in worseApplicants)
                                {
                                    Constraint constraint = solver.MakeConstraint();
                                    constraint.SetLb(0);

                                    foreach (Receiver betterReceiver in betterReceivers)
                                    {                                      
                                        constraint.SetCoefficient(variables[applicant][betterReceiver], 1);
                                    }                                    
                                    constraint.SetCoefficient(variables[worseApplicant][receiver], -1);
                                    blockingPairs.Add(solver.MakeBoolVar($"B{applicant.ApplicantID}_{worseApplicant.ApplicantID}_{receiver.ReceiverID}"));
                                }
                            }
                        }
                    }
                    else
                    {

                    }
                }
                else
                {                   
                    if (applicantOptimal)
                    {
                        foreach (Applicant applicant in Applicants)
                        {
                            foreach (Receiver receiver in Receivers)
                            {
                                int applicantPoints = (from application in ApplicantReceivers
                                                       where application.Applicant.ApplicantID == applicant.ApplicantID
                                                       && application.Receiver.ReceiverID == receiver.ReceiverID
                                                       select application.ReceiverPoints).FirstOrDefault();



                                int applicantPreference = (from application in ApplicantReceivers
                                                           where application.Applicant.ApplicantID == applicant.ApplicantID
                                                           && application.Receiver.ReceiverID == receiver.ReceiverID
                                                           select application.ApplicantPreference).FirstOrDefault();

                                //applicants with worse applications points to the receiver
                                List<Applicant> worseApplicants = (from application in ApplicantReceivers
                                                                   where application.ReceiverPoints < applicantPoints
                                                                   && application.Receiver.ReceiverID == receiver.ReceiverID
                                                                   select application.Applicant).ToList();

                                //receivers that are prefered more by the applicant
                                List<Receiver> betterReceivers = (from application in ApplicantReceivers
                                                                  where application.ApplicantPreference < applicantPreference
                                                                  && application.Applicant.ApplicantID == applicant.ApplicantID
                                                                  select application.Receiver).ToList();

                                foreach (Applicant worseApplicant in worseApplicants)
                                {
                                    Google.OrTools.LinearSolver.Constraint constraint = solver.MakeConstraint();
                                    constraint.SetLb(0);


                                    constraint.SetCoefficient(variables[applicant][receiver], 1);
                                    foreach (Receiver betterReceiver in betterReceivers)
                                    {                                        
                                        constraint.SetCoefficient(variables[applicant][betterReceiver], 1);
                                        
                                    }                                    
                                    constraint.SetCoefficient(variables[worseApplicant][receiver], -1);
                                    blockingPairs.Add(solver.MakeBoolVar($"B{applicant.ApplicantID}_{worseApplicant.ApplicantID}_{receiver.ReceiverID}"));
                                    constraint.SetCoefficient(blockingPairs[blockingPairs.Count - 1], 1);
                                }
                            }
                        }
                    }

                    else
                    {
                        foreach(Receiver receiver in Receivers)
                        {
                            foreach (Applicant applicant in Applicants)
                            {


                                int applicantPreference = (from application in ApplicantReceivers
                                                           where application.Applicant.ApplicantID == applicant.ApplicantID
                                                           && application.Receiver.ReceiverID == receiver.ReceiverID
                                                           select application.ApplicantPreference).FirstOrDefault();


                                int applicantPoints = (from application in ApplicantReceivers
                                                       where application.Applicant.ApplicantID == applicant.ApplicantID
                                                       && application.Receiver.ReceiverID == receiver.ReceiverID
                                                       select application.ReceiverPoints).FirstOrDefault();



                                //receivers that are
                                List<Receiver> worseReceivers = (from application in ApplicantReceivers
                                                                   where application.ApplicantPreference > applicantPreference
                                                                   && application.Applicant.ApplicantID == applicant.ApplicantID
                                                                   select application.Receiver).ToList();

                                //applicants, that are prefered more by the receiver
                                List<Applicant> betterApplicants = (from application in ApplicantReceivers
                                                                   where application.ReceiverPoints > applicantPreference
                                                                   && application.Receiver.ReceiverID == receiver.ReceiverID
                                                                   select application.Applicant).ToList();

                                foreach (Receiver worseReceiver in worseReceivers)
                                {
                                    Constraint constraint = solver.MakeConstraint();
                                    constraint.SetLb(0);

                                    foreach (Applicant betterApplicant in betterApplicants)
                                    {
                                        constraint.SetCoefficient(variables[betterApplicant][receiver], 1);
                                    }
                                    constraint.SetCoefficient(variables[applicant][worseReceiver], -1);
                                }
                            }
                        }
                    }
                }
            }

            void CreateDynamicConstraints()
            {
                if(UseDynamicConstraints)
                {
                    //iterating over Constraints
                    foreach (DynamicConstraint dynamicConstraint in DynamicConstraints)
                    {
                        foreach (Receiver receiver in Receivers)
                        {
                            int maximum = dynamicConstraint.UpperBound;
                            int minimum = dynamicConstraint.LowerBound;
                            Constraint constraint = solver.MakeConstraint(minimum, maximum, $"{dynamicConstraint.ConstraintName}_{receiver.ReceiverID}");

                            List<ApplicantDynamicConstraint> applicantConstraints = (from ac in ApplicantConstraints
                                                                        where ac.DynamicConstraint == dynamicConstraint
                                                                        select ac).ToList();

                            List<Applicant> applicants = (from ar in ApplicantReceivers
                                                          where ar.Receiver == receiver
                                                          join ac in applicantConstraints on ar.Applicant equals ac.Applicant
                                                          where ac.ApplicantData == true
                                                          select ar.Applicant).ToList();

                            foreach (Applicant applicant in applicants)
                            {
                                constraint.SetCoefficient(variables[applicant][receiver], 1);
                            }

                        }
                    }
                }
            }
        }

        private void CreateObjective()
        {
            Objective objective = solver.Objective();
            if (applicantOptimal)
            { 
               foreach (ApplicantReceiver application in ApplicantReceivers)
                {
                    int preference = application.ApplicantPreference;
                    objective.SetCoefficient(variables[application.Applicant][application.Receiver], preference);
                }

                foreach (var blockgingPair in blockingPairs)
                {
                    objective.SetCoefficient(blockgingPair, 100);
                }

                objective.SetMinimization();
            }

            else
            {
                foreach (ApplicantReceiver application in ApplicantReceivers)
                {
                    int points = application.ReceiverPoints;
                    
                    objective.SetCoefficient(variables[application.Applicant][application.Receiver], points);
                }

                foreach (var blockgingPair in blockingPairs)
                {
                    objective.SetCoefficient(blockgingPair, -100);
                }

                objective.SetMaximization();                          
            }
        }
	}
}

