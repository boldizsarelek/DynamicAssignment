using System;
using System.Collections.Generic;
using System.Linq;
using Google.OrTools.LinearSolver;

namespace DynamicAssignment
{
	public class Assignment
	{
        //Assignment data
        public List<Applicant> Applicants;
        public List<Receiver> Receivers;
        public List<DynamicConstraint> DynamicConstraints;
        public List<Application> Applications;

        //Properties for assignment
        private string solverType; //Select OR-tools supported solver
        private bool applicantOptimal;
        private bool receiverOptimal;
        private bool groupEnvyness;
        private bool assignEach;

        //OR-Tools classes
        private Solver solver;
        private Variable[,] variables; //to be deleted
        private Constraint constraint;
        private Objective objective;

        //nested dictionary, first key is the applicant's ID, second is the receiver's ID
        private Dictionary<int, Dictionary<int, Variable>> variables2;
       

        public Assignment(List<Applicant> applicants, List<Receiver> receivers)
        {
            Applicants = applicants;
            Receivers = receivers;
        }


        //Select solver to use
        public void SetSolver(string solver)
        {
            solverType = solver;
            this.solver = Solver.CreateSolver(solver);
        }

        //Set envyness to everyone or subgroups
        public void SetGroupEnvyness(bool groupEnvyness)
        {
            this.groupEnvyness = groupEnvyness;
        }


        //Applicant optimal assignment
        public void SetApplicantOptimal()
        {
            applicantOptimal = true;
            receiverOptimal = false;
        }

        //Receiver optimal assignment
        public void SetReceiverOptimal()
        {
            applicantOptimal = false;
            receiverOptimal = true;
        }

        //Set if every applicant should be assigned
        public void AssignEach(bool assignEach)
        {
            this.assignEach = assignEach;
        }

        //Run solver and receive results
        public Solver.ResultStatus Solve()
        {
            CreateVariables();
            CreateConstraints();
            CreateObjective();
            Solver.ResultStatus resultStatus = solver.Solve();
            return resultStatus;
        }

        
        //Create variables for solver
        private void CreateVariables()
        {
            for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
            {
                for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                {
                    variables[applicantIndex, receiverIndex] = solver.MakeBoolVar($"x{applicantIndex}_{receiverIndex}");
                }
            }


            //with dictionary

            foreach (Application application in Applications)
            {
                variables2[application.applicantPreference][application.receiverPreference] = solver.MakeBoolVar($"x{application.applicant.ID}_{application.receiver.ID}");
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
                    for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
                    {

                        Constraint constraint = solver.MakeConstraint(1, 1, $"applicant_{applicantIndex}");
                        for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                        {
                            constraint.SetCoefficient(variables[applicantIndex, receiverIndex], 1);
                        }
                    }


                    //with dictionary

                    foreach (Applicant applicant in Applicants)
                    {
                        Constraint constraint = solver.MakeConstraint(1, 1, $"applicant_{applicant.ID}");
                        foreach (Receiver receiver in Receivers)
                        {
                            constraint.SetCoefficient(variables2[applicant.ID][receiver.ID], 1);
                        }
                    }
                }
                else
                {
                    for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
                    {

                        Constraint constraint = solver.MakeConstraint(0, 1, $"applicant_{applicantIndex}");
                        for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                        {
                            constraint.SetCoefficient(variables[applicantIndex, receiverIndex], 1);
                        }


                    }


                    //with dictionary

                    foreach (Applicant applicant in Applicants)
                    {
                        Constraint constraint = solver.MakeConstraint(0, 1, $"applicant_{applicant.ID}");
                        foreach (Receiver receiver in Receivers)
                        {
                            constraint.SetCoefficient(variables2[applicant.ID][receiver.ID], 1);
                        }
                    }
                }

            }

            void CreateReceiverBoundaries()
            {
                //jobs' boundaries
                for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                {
                    int minLimit = Receivers[receiverIndex].MinimumCapacity;
                    int maxLimit = Receivers[receiverIndex].MaximumCapacity;

                    Constraint constraint = solver.MakeConstraint(minLimit, maxLimit, "");
                    for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
                    {
                        constraint.SetCoefficient(variables[applicantIndex, receiverIndex], 1);
                    }
                }


                //with dictionary

                foreach (Receiver receiver in Receivers)
                {
                    int minLimit = receiver.MinimumCapacity;
                    int maxLimit = receiver.MaximumCapacity;

                    Constraint constraint = solver.MakeConstraint(minLimit, maxLimit, "");
                    foreach (Applicant applicant in Applicants)
                    {
                        constraint.SetCoefficient(variables2[applicant.ID][receiver.ID], 1);
                    }
                }
            }

            void CreateStabilityConstraints()
            {
                //stability limitations //todo:check compatibility with Dictionary 
                if (groupEnvyness)
                {

                    //iterating over dynamic constraints
                    for (int constraintIndex = 0; constraintIndex < DynamicConstraints.Count; constraintIndex++)
                    {
                        //iterating over applicants
                        for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
                        {

                            //iterating over receivers
                            for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                            {

                                //checking applicants points at receiver
                                int applicantpoint = Receivers[receiverIndex].Preferences[applicantIndex];


                                //searching for applicants who has less points at the same subgroup
                                List<Applicant> worseApplicants = new List<Applicant>();
                                for (int applicantIndex2 = 0; applicantIndex2 < Applicants.Count; applicantIndex2++)
                                {
                                    if (Receivers[receiverIndex].Preferences[applicantIndex2] < applicantpoint && DynamicConstraints[constraintIndex].Data[applicantIndex2] == DynamicConstraints[constraintIndex].Data[applicantIndex])
                                    {
                                        worseApplicants.Add(Applicants[applicantIndex2]);
                                    }
                                }


                                //Creating constraint for envy freeness
                                foreach (Applicant worseApplicant in worseApplicants)
                                {
                                    Constraint constraint = solver.MakeConstraint();
                                    constraint.SetLb(0);

                                    for (int receiverIndex2 = 0; receiverIndex2 <= receiverIndex; receiverIndex2++)
                                    {
                                        constraint.SetCoefficient(variables[applicantIndex, receiverIndex2], 1);

                                    }
                                    constraint.SetCoefficient(variables[worseApplicant.ID, receiverIndex], -1);
                                }
                            }
                        }
                    }
                }

                //with dictionary






                else
                {

                    //iterating over applicants
                    for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
                    {

                        //iterating over receivers
                        for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                        {

                            //checking applicants points at receiver
                            int applicantpoint = Receivers[receiverIndex].Preferences[applicantIndex];


                            //searching for applicants who has less points
                            List<Applicant> worseApplicants = new List<Applicant>();
                            for (int applicantIndex2 = 0; applicantIndex2 < Applicants.Count; applicantIndex2++)
                            {

                                if (Receivers[receiverIndex].Preferences[applicantIndex2] < applicantpoint)
                                {
                                    worseApplicants.Add(Applicants[applicantIndex2]);
                                }
                            }


                            //Creating constraint for envy freeness
                            foreach (Applicant worseApplicant in worseApplicants)
                            {
                                Constraint constraint = solver.MakeConstraint();
                                constraint.SetLb(0);

                                for (int receiverIndex2 = 0; receiverIndex2 <= receiverIndex; receiverIndex2++)
                                {
                                    constraint.SetCoefficient(variables[applicantIndex, receiverIndex2], 1);

                                }
                                constraint.SetCoefficient(variables[worseApplicant.ID, receiverIndex], -1);
                            }

                        }
                    }


                    //with Dictionary
                    foreach (Applicant applicant in Applicants)
                    {
                        foreach (Receiver receiver in Receivers)
                        {
                            int applicantPoints = (from application in Applications
                                                   where application.applicant.ID == applicant.ID
                                                   && application.receiver.ID == receiver.ID
                                                   select application.receiverPreference).FirstOrDefault();


                            int applicantPreference = (from application in Applications
                                                       where application.applicant.ID == applicant.ID
                                                       && application.receiver.ID == receiver.ID
                                                       select application.applicantPreference).FirstOrDefault();

                            List<Applicant> worseApplicants = (from application in Applications
                                                               where application.receiverPreference < applicantPoints
                                                               select application.applicant).ToList();

                            foreach (Applicant worseApplicant in worseApplicants)
                            {
                                Constraint constraint = solver.MakeConstraint();
                                constraint.SetLb(0);

                                List<Receiver> betterReceivers = (from application in Applications
                                                                  where application.applicantPreference > applicantPreference
                                                                  select application.receiver).ToList();

                                foreach (Receiver betterReceiver in Receivers)
                                {
                                    constraint.SetCoefficient(variables2[applicant.ID][betterReceiver.ID], 1);
                                }
                                constraint.SetCoefficient(variables2[worseApplicant.ID][receiver.ID], 1);
                            }
                        }
                    }

                }
            }

            void CreateDynamicConstraints()
            {
                //Dynamic constraints

                for (int constraintIndex = 0; constraintIndex < DynamicConstraints.Count; constraintIndex++)
                {
                    switch (DynamicConstraints[constraintIndex].BoundType)
                    {
                        case DynamicConstraint.ConstraintType.LessThan:
                            for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                            {
                                int maximum = DynamicConstraints[constraintIndex].GetLowerBound();

                                Constraint constraint = solver.MakeConstraint(0, maximum, "");
                                Constraint constraint2 = solver.MakeConstraint(0, maximum, "");
                                for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
                                {
                                    if (DynamicConstraints[constraintIndex].Data[applicantIndex])
                                    {
                                        constraint.SetCoefficient(variables[applicantIndex, receiverIndex], 1);
                                    }
                                    else
                                    {
                                        constraint2.SetCoefficient(variables[applicantIndex, receiverIndex], 1);
                                    }
                                }
                            }
                            break;

                        case DynamicConstraint.ConstraintType.MoreThan:
                            for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                            {
                                int minimum = DynamicConstraints[constraintIndex].GetUpperBound();

                                Constraint constraint = solver.MakeConstraint();
                                constraint.SetLb(minimum);
                                Constraint constraint2 = solver.MakeConstraint();
                                constraint2.SetLb(minimum);

                                for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
                                {
                                    if (DynamicConstraints[constraintIndex].Data[applicantIndex])
                                    {
                                        constraint.SetCoefficient(variables[applicantIndex, receiverIndex], 1);
                                    }
                                    else
                                    {
                                        constraint2.SetCoefficient(variables[applicantIndex, receiverIndex], 1);
                                    }
                                }
                            }
                            break;

                        case DynamicConstraint.ConstraintType.Between:
                            for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                            {
                                int maximum = DynamicConstraints[constraintIndex].GetLowerBound();
                                int minimum = DynamicConstraints[constraintIndex].GetUpperBound();

                                Constraint constraint = solver.MakeConstraint(minimum, maximum, "");
                                Constraint constraint2 = solver.MakeConstraint(minimum, maximum, "");

                                for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
                                {
                                    if (DynamicConstraints[constraintIndex].Data[applicantIndex])
                                    {
                                        constraint.SetCoefficient(variables[applicantIndex, receiverIndex], 1);
                                    }
                                    else
                                    {
                                        constraint2.SetCoefficient(variables[applicantIndex, receiverIndex], 1);
                                    }
                                }
                            }
                            break;

                        default:



                            break;
                    }
                }


                //with dictionary

                foreach (DynamicConstraint dynamicConstraint in DynamicConstraints)
                {
                    switch (dynamicConstraint.BoundType)
                    {
                        case DynamicConstraint.ConstraintType.LessThan:
                            foreach (Receiver receiver in Receivers)
                            {
                                int maximum = dynamicConstraint.GetUpperBound();
                                Constraint constraint = solver.MakeConstraint(0, maximum, "");
                                Constraint constraint2 = solver.MakeConstraint(0, maximum, "");

                                foreach (Applicant applicant in Applicants)
                                {
                                    if (dynamicConstraint.Data[applicant.ID])
                                    {
                                        constraint.SetCoefficient(variables2[applicant.ID][receiver.ID], 1);
                                    }
                                    else
                                    {
                                        constraint2.SetCoefficient(variables2[applicant.ID][receiver.ID], 1);

                                    }
                                }
                            }
                            break;
                        case DynamicConstraint.ConstraintType.MoreThan:
                            foreach (Receiver receiver in Receivers)
                            {
                                int minimum = dynamicConstraint.GetLowerBound();
                                Constraint constraint = solver.MakeConstraint();
                                constraint.SetLb(minimum);
                                Constraint constraint2 = solver.MakeConstraint();
                                constraint.SetLb(minimum);

                                foreach (Applicant applicant in Applicants)
                                {
                                    if (dynamicConstraint.Data[applicant.ID])
                                    {
                                        constraint.SetCoefficient(variables2[applicant.ID][receiver.ID], 1);
                                    }
                                    else
                                    {
                                        constraint2.SetCoefficient(variables2[applicant.ID][receiver.ID], 1);
                                    }
                                }
                            }
                            break;
                        case DynamicConstraint.ConstraintType.Between:
                            foreach (Receiver receiver in Receivers)
                            {
                                int maximum = dynamicConstraint.GetUpperBound();
                                int minimum = dynamicConstraint.GetUpperBound();
                                Constraint constraint = solver.MakeConstraint(minimum, maximum, "");
                                Constraint constraint2 = solver.MakeConstraint(minimum, maximum, "");

                                foreach (Applicant applicant in Applicants)
                                {
                                    if (dynamicConstraint.Data[applicant.ID])
                                    {
                                        constraint.SetCoefficient(variables2[applicant.ID][receiver.ID], 1);
                                    }
                                    else
                                    {
                                        constraint2.SetCoefficient(variables2[applicant.ID][receiver.ID], 1);

                                    }
                                }
                            }
                            break;
                    }


                }
            }
        }

        private void CreateObjective()
        {


            if (applicantOptimal)
            {
                for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
                {
                    for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                    {
                        int preference = (from application in Applications
                                         where Applicants[applicantIndex].ID == application.applicant.ID
                                          && Receivers[receiverIndex].ID == application.receiver.ID
                                         select application.applicantPreference).FirstOrDefault();

                       objective.SetCoefficient(variables[applicantIndex, receiverIndex], preference);
                    }
                }


                //with dictionary

               foreach (Application application in Applications)
                {
                    int preference = application.applicantPreference;
                    objective.SetCoefficient(variables2[application.applicant.ID][application.receiver.ID], preference);
                }

                objective.SetMinimization();
            }



            else
            {
                for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
                {
                    for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                    {
                        int preference = (from application in Applications
                                          where Applicants[applicantIndex].ID == application.applicant.ID
                                           && Receivers[receiverIndex].ID == application.receiver.ID
                                          select application.receiverPreference).FirstOrDefault();

                        objective.SetCoefficient(variables[applicantIndex, receiverIndex], preference);
                    }
                }

                //with dictionary

                foreach (Application application in Applications)
                {
                    int preference = application.receiverPreference;
                    objective.SetCoefficient(variables2[application.applicant.ID][application.receiver.ID], preference);
                }

                objective.SetMaximization();
                           
            }
        }
	}
}

