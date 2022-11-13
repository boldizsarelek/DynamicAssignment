using System;
using System.Collections.Generic;
using Google.OrTools.LinearSolver;

namespace DynamicAssignment
{
	public class Assignment
	{
        //Assignment data
        public List<Applicant> Applicants;
        public List<Receiver> Receivers;
        public List<DynamicConstraint> DynamicConstraints;

        //Properties for assignment
        private string solverType;
        private bool applicantOptimal;
        private bool receiverOptimal;
        private bool groupEnvyness;
        private bool assignEach;

        //OR-Tools classes
        private Solver solver;
        private Variable[,] variables;
        private Constraint constraint;
        private Objective objective;
        
       

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
        public void SetAssignEach(bool assignEach)
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
        }

        //Create constraints for solver
        private void CreateConstraints()
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
            }
            
            


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
                                if(DynamicConstraints[constraintIndex].Data[applicantIndex])
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
                        objective.SetCoefficient(variables[applicantIndex, receiverIndex], Applicants[applicantIndex].Preferences[receiverIndex]);
                    }
                }
                objective.SetMinimization();
            }
            else
            {
                if (applicantOptimal)
                {
                    for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
                    {
                        for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                        {
                            objective.SetCoefficient(variables[applicantIndex, receiverIndex], Applicants[applicantIndex].Preferences[receiverIndex]);
                        }
                    }
                    objective.SetMinimization();
                }
                else
                {
                    for (int applicantIndex = 0; applicantIndex < Applicants.Count; applicantIndex++)
                    {
                        for (int receiverIndex = 0; receiverIndex < Receivers.Count; receiverIndex++)
                        {
                            objective.SetCoefficient(variables[applicantIndex, receiverIndex], Receivers[applicantIndex].Preferences[applicantIndex]);
                        }
                    }
                    objective.SetMaximization();
                }              
            }
        }
	}
}

