﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Schema;
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
        public List<ReceiverDynamicConstraint> ReceiverDynamicConstraints;

     
        //Properties for assignment
        private string solverType;
        public bool ApplicantOptimal;
        public bool GroupEnvyness;
        public bool AssignEach;
        public string SolverType
        {
            get
            { return solverType; }
            set
            {
                solverType = value;
                switch (value)
                {
                    case "SCIP":
                        solverType2 = Solver.OptimizationProblemType.SCIP_MIXED_INTEGER_PROGRAMMING;
                        break;
                    case "SAT":
                        solverType2 = Solver.OptimizationProblemType.SAT_INTEGER_PROGRAMMING;
                        break;
                    case "BOP":
                        solverType2 = Solver.OptimizationProblemType.BOP_INTEGER_PROGRAMMING;
                        break;
                    case "CBC":
                        solverType2 = Solver.OptimizationProblemType.CBC_MIXED_INTEGER_PROGRAMMING;
                        break;
                    default:
                        break;
                }

            }
        }

        //OR-Tools classes
        private Solver solver;
        private Solver.OptimizationProblemType solverType2;

        //nested dictionary, first key is the applicant, second is receiver
        private Dictionary<Applicant, Dictionary<Receiver, Variable>> variables = new Dictionary<Applicant, Dictionary<Receiver, Variable>>();
        private List<BlockingPair> BlockingPairs2 = new List<BlockingPair>();

        public Assignment(List<Applicant> applicants,
            List<Receiver> receivers,
            List<ApplicantReceiver> applicantReceivers,
            List<DynamicConstraint> constraints = null,
            List<ApplicantDynamicConstraint> applicantConstraints = null,
            List<ReceiverDynamicConstraint> receiverDynamicConstraints = null,
            string solverType = "SCIP",
            bool applicantOptimal = true,
            bool groupEnvyness = true,
            bool assignEach = true)
        {
            Applicants = applicants;
            Receivers = receivers;
            ApplicantReceivers = applicantReceivers;
            DynamicConstraints = constraints;
            ApplicantConstraints = applicantConstraints;
            ReceiverDynamicConstraints = receiverDynamicConstraints;
            SolverType = solverType;
            ApplicantOptimal = applicantOptimal;
            GroupEnvyness = groupEnvyness;
            AssignEach = assignEach;
            validateData();
        }

        public void RemoveApplicant(Applicant applicant)
        {

            //Removing from applications
            foreach (ApplicantReceiver application in ApplicantReceivers)
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

            foreach (ReceiverDynamicConstraint receiverDynamicConstraint in ReceiverDynamicConstraints)
            {
                if (receiverDynamicConstraint.Receiver == receiver)
                {
                    ReceiverDynamicConstraints.Remove(receiverDynamicConstraint);
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

        public void ChangePreferenceNumberByID(int applicantID, int receiverID, bool moveUp)
        {
            List<ApplicantReceiver> applications = (from ar in ApplicantReceivers
                                                    where ar.Applicant.ApplicantID == applicantID
                                                    orderby ar.ApplicantPreference ascending
                                                    select ar).ToList();

            ApplicantReceiver applicantReceiver = (from a in applications
                                                   where a.Receiver.ReceiverID == receiverID
                                                   select a).FirstOrDefault();

            int applicationIndex = applications.IndexOf(applicantReceiver);
            int applicantReceiverIndex = ApplicantReceivers.IndexOf(applicantReceiver);
            int applicantPreference = applicantReceiver.ApplicantPreference;

            if (moveUp)
            {
                if (applicationIndex == 0) return;
                else
                {
                    ApplicantReceiver applicantReceiver2 = applications[applicationIndex - 1];
                    int applicantReceiverIndex2 = ApplicantReceivers.IndexOf(applicantReceiver2);
                    ApplicantReceivers[applicantReceiverIndex].ApplicantPreference = applicantReceiver2.ApplicantPreference;
                    ApplicantReceivers[applicantReceiverIndex2].ApplicantPreference = applicantPreference;
                }
            }

            else
            {
                if (applicationIndex == applications.Count - 1) return;
                else
                {
                    ApplicantReceiver applicantReceiver2 = applications[applicationIndex + 1];
                    int applicantReceiverIndex2 = ApplicantReceivers.IndexOf(applicantReceiver2);
                    ApplicantReceivers[applicantReceiverIndex].ApplicantPreference = applicantReceiver2.ApplicantPreference;
                    ApplicantReceivers[applicantReceiverIndex2].ApplicantPreference = applicantPreference;
                }
            }

        }

        public List<ReceiverDynamicConstraint> GetReceiverDynamicConstraintsByReceiverID(int receiverID)
        {
            List<ReceiverDynamicConstraint> receiverDynamicConstraints = (from rdc in ReceiverDynamicConstraints
                                                                          where rdc.Receiver.ReceiverID == receiverID
                                                                          select rdc).ToList();
            return receiverDynamicConstraints;
        }

        public List<ApplicantReceiver> GetApplicantReceiversByApplicantID(int applicantID)
        {
            List<ApplicantReceiver> applicantReceivers = (from ar in ApplicantReceivers
                                                          where ar.Applicant.ApplicantID == applicantID
                                                          select ar).ToList();
            return applicantReceivers;
        }

        public List<ApplicantReceiver> GetApplicantReceiversByReceiverID(int receiverID)
        {
            List<ApplicantReceiver> applicantReceivers = (from ar in ApplicantReceivers
                                                          where ar.Receiver.ReceiverID == receiverID
                                                          select ar).ToList();
            return applicantReceivers;
        }

        public List<ApplicantDynamicConstraint> GetApplicantDynamicConstraintsByApplicantID(int applicantID)
        {
            List<ApplicantDynamicConstraint> applicantDynamicConstraints = (from adc in ApplicantConstraints
                                                                            where adc.Applicant.ApplicantID == applicantID
                                                                            select adc).ToList();
            return applicantDynamicConstraints;
        }

        //Run solver and receive results
        public AssignmentResult Solve()
        {
            validateData();
            variables.Clear();
            
            BlockingPairs2.Clear();
            solver?.Clear();



            InvokeSolver();
            CreateVariables();
            CreateConstraints();
            CreateObjective();


            //string lpFile = solver.ExportModelAsLpFormat(false);
            //Console.WriteLine(lpFile);

            Solver.ResultStatus resultStatus = solver.Solve();

            string result = resultStatus.ToString();
            List<ApplicantReceiver> pairs = new List<ApplicantReceiver>();
            List<BlockingPair> blockingPairs = new List<BlockingPair>();
            int objectiveSum = 0;


            foreach (Applicant applicant in Applicants)
            {
                foreach (Receiver receiver in Receivers)
                {
                    if (variables[applicant][receiver].SolutionValue() > 0.5)
                    {
                        ApplicantReceiver pair = (from ar in ApplicantReceivers
                                                  where ar.Applicant == applicant && ar.Receiver == receiver
                                                  select ar).FirstOrDefault();

                        pairs.Add(pair);
                        //Console.WriteLine(variables[applicant][receiver].Name());
                        if (ApplicantOptimal)
                        {
                            objectiveSum += (from ar in ApplicantReceivers
                                             where ar.Applicant == applicant &&
                                             ar.Receiver == receiver
                                             select ar.ApplicantPreference).FirstOrDefault();
                        }
                        else
                        {
                            objectiveSum += (from ar in ApplicantReceivers
                                             where ar.Applicant == applicant &&
                                             ar.Receiver == receiver
                                             select ar.ReceiverPoints).FirstOrDefault();
                        }
                    }
                }
            }
            foreach (BlockingPair pair in BlockingPairs2)
            {
                if (pair.Variable.SolutionValue() > 0.5)
                {
                    if (ApplicantOptimal)
                    {
                        objectiveSum += 100;
                    }
                    else
                    {
                        objectiveSum -= 100;
                    }
                    blockingPairs.Add(pair);
                    //Console.WriteLine(pair.Variable.Name());
                }
            }

            AssignmentResult assignmentResult = new AssignmentResult(
                result: result,
                pairs: pairs,
                blockingPairs: blockingPairs,
                objectiveSum: objectiveSum,
                lpFile: solver.ExportModelAsLpFormat(false),
                wallTime: solver.WallTime());
            return assignmentResult;
        }

        private void validateData()
        {
            //throw new NotImplementedException();
        }

        private void InvokeSolver()
        {
            //invoking solver

            solver = new Solver("Solver", solverType2);
            //solver.EnableOutput();
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
                if (AssignEach)
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
                if (GroupEnvyness)
                {
                    if (ApplicantOptimal)
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

                                List<ApplicantDynamicConstraint> applicantGroup = (from ac in ApplicantConstraints
                                                                                   where ac.Applicant == applicant
                                                                                   orderby ac.DynamicConstraint.ConstraintID
                                                                                   select ac).ToList();

                                bool[] applicantGroupBool = new bool[applicantGroup.Count];
                                int index = 0;
                                foreach (var ag in applicantGroup)
                                {
                                    applicantGroupBool[index] = ag.ApplicantData;
                                    index++;
                                }

                                //applicants in the same group with worse applications points to the receiver
                                List<Applicant> worseApplicants = (from application in ApplicantReceivers
                                                                   where application.ReceiverPoints < applicantPoints
                                                                   && application.Receiver.ReceiverID == receiver.ReceiverID
                                                                   select application.Applicant).ToList();

                                List<Applicant> worseApplicantsSameGroup = new List<Applicant>();

                                //Only the worse applicants in the same group
                                foreach (Applicant wa in worseApplicants)
                                {
                                    index = 0;
                                    bool[] worseApplicantGroupBool = new bool[applicantGroup.Count()];
                                    List<ApplicantDynamicConstraint> worseApplicantGroup = (from ac in ApplicantConstraints
                                                                                            where ac.Applicant == wa
                                                                                            orderby ac.DynamicConstraint.ConstraintID
                                                                                            select ac).ToList();
                                    foreach (var wag in worseApplicantGroup)
                                    {
                                        worseApplicantGroupBool[index] = wag.ApplicantData;
                                        index++;
                                    }

                                    int count = 0;
                                    for (int i = 0; i < applicantGroupBool.Length; i++)
                                    {
                                        if (worseApplicantGroupBool[i] == applicantGroupBool[i])
                                        {
                                            count++;
                                        }
                                    }
                                    if (count == applicantGroupBool.Length) worseApplicantsSameGroup.Add(wa);

                                }

                                //receivers that are prefered more by the applicant
                                List<Receiver> betterReceivers = (from application in ApplicantReceivers
                                                                  where application.ApplicantPreference < applicantPreference
                                                                  && application.Applicant.ApplicantID == applicant.ApplicantID
                                                                  select application.Receiver).ToList();

                                foreach (Applicant worseApplicant in worseApplicantsSameGroup)
                                {
                                    Constraint constraint = solver.MakeConstraint();
                                    constraint.SetLb(0);

                                    constraint.SetCoefficient(variables[applicant][receiver], 1);

                                    foreach (Receiver betterReceiver in betterReceivers)
                                    {
                                        constraint.SetCoefficient(variables[applicant][betterReceiver], 1);
                                    }

                                    constraint.SetCoefficient(variables[worseApplicant][receiver], -1);

                                    BlockingPair bp = new BlockingPair();
                                    bp.BlockedApplication = (from application in ApplicantReceivers
                                                             where application.Applicant == applicant
                                                             && application.Receiver == receiver
                                                             select application).FirstOrDefault();

                                    bp.BlockingApplication = (from application in ApplicantReceivers
                                                              where application.Applicant == worseApplicant
                                                              && application.Receiver == receiver
                                                              select application).FirstOrDefault();

                                    bp.Variable = solver.MakeBoolVar($"B{applicant.ApplicantID}_{receiver.ReceiverID}_{worseApplicant.ApplicantID}_{receiver.ReceiverID}");
                                    BlockingPairs2.Add(bp);

                                    constraint.SetCoefficient(BlockingPairs2[BlockingPairs2.Count - 1].Variable, 1);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Receiver receiver in Receivers)
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

                                List<ApplicantDynamicConstraint> applicantGroup = (from ac in ApplicantConstraints
                                                                                   where ac.Applicant == applicant
                                                                                   orderby ac.DynamicConstraint.ConstraintID
                                                                                   select ac).ToList();

                                bool[] applicantGroupBool = new bool[applicantGroup.Count];
                                int index = 0;
                                foreach (var ag in applicantGroup)
                                {
                                    applicantGroupBool[index] = ag.ApplicantData;
                                    index++;
                                }


                                //applicants, that are prefered more by the receiver
                                List<Applicant> betterApplicants = (from application in ApplicantReceivers
                                                                    where application.ReceiverPoints > applicantPoints
                                                                    && application.Receiver.ReceiverID == receiver.ReceiverID
                                                                    select application.Applicant).ToList();

                                List<Applicant> betterApplicantsSameGroup = new List<Applicant>();

                                foreach (Applicant ba in betterApplicants)
                                {
                                    index = 0;
                                    bool[] betterApplicantGroupBool = new bool[applicantGroup.Count];
                                    List<ApplicantDynamicConstraint> betterApplicantGroup = (from ac in ApplicantConstraints
                                                                                             where ac.Applicant == ba
                                                                                             orderby ac.DynamicConstraint.ConstraintID
                                                                                             select ac).ToList();
                                    foreach (var bag in betterApplicantGroup)
                                    {
                                        betterApplicantGroupBool[index] = bag.ApplicantData;
                                        index++;

                                    }

                                    int count = 0;
                                    for (int i = 0; i < applicantGroupBool.Length; i++)
                                    {
                                        if (betterApplicantGroupBool[i] == applicantGroupBool[i])
                                        {
                                            count++;
                                        }
                                        if (count == applicantGroupBool.Length) betterApplicantsSameGroup.Add(ba);
                                    }
                                }

                                //applicant's less prefered receivers
                                List<Receiver> worseReceivers = (from application in ApplicantReceivers
                                                                 where application.ApplicantPreference > applicantPreference
                                                                 && application.Applicant.ApplicantID == applicant.ApplicantID
                                                                 select application.Receiver).ToList();


                                if (betterApplicantsSameGroup.Count > 0)
                                {
                                    foreach (Receiver worseReceiver in worseReceivers)
                                    {
                                        Constraint constraint = solver.MakeConstraint();
                                        constraint.SetLb(0);

                                        constraint.SetCoefficient(variables[applicant][receiver], 1);
                                        foreach (Applicant betterApplicant in betterApplicantsSameGroup)
                                        {
                                            constraint.SetCoefficient(variables[betterApplicant][receiver], 1);
                                        }


                                        BlockingPair bp = new BlockingPair();

                                        bp.BlockedApplication = (from application in ApplicantReceivers
                                                                 where application.Applicant == applicant
                                                                 && application.Receiver == receiver
                                                                 select application).FirstOrDefault();

                                        bp.BlockingApplication = (from application in ApplicantReceivers
                                                                  where application.Applicant == applicant
                                                                  && application.Receiver == worseReceiver
                                                                  select application).FirstOrDefault();

                                        bp.Variable = solver.MakeBoolVar($"B{applicant.ApplicantID}_{receiver.ReceiverID}_{applicant.ApplicantID}_{worseReceiver.ReceiverID}");

                                        BlockingPairs2.Add(bp);
                                        constraint.SetCoefficient(BlockingPairs2[BlockingPairs2.Count - 1].Variable, 1);
                                        constraint.SetCoefficient(variables[applicant][worseReceiver], -1);
                                    }
                                }
                                
                            }
                        }
                    }
                }
                else
                {
                    if (ApplicantOptimal)
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
                                    Constraint constraint = solver.MakeConstraint();
                                    constraint.SetLb(0);


                                    constraint.SetCoefficient(variables[applicant][receiver], 1);
                                    foreach (Receiver betterReceiver in betterReceivers)
                                    {
                                        constraint.SetCoefficient(variables[applicant][betterReceiver], 1);

                                    }

                                    BlockingPair bp = new BlockingPair();

                                    bp.BlockedApplication = (from application in ApplicantReceivers
                                                             where application.Applicant == applicant
                                                             && application.Receiver == receiver
                                                             select application).FirstOrDefault();

                                    bp.BlockingApplication = (from application in ApplicantReceivers
                                                              where application.Applicant == worseApplicant
                                                              && application.Receiver == receiver
                                                              select application).FirstOrDefault();

                                    bp.Variable = solver.MakeBoolVar($"B{applicant.ApplicantID}_{receiver.ReceiverID}_{worseApplicant.ApplicantID}_{receiver.ReceiverID}");
                                    BlockingPairs2.Add(bp);
                                    constraint.SetCoefficient(BlockingPairs2[BlockingPairs2.Count - 1].Variable, 1);
                                    constraint.SetCoefficient(variables[worseApplicant][receiver], -1);
                                }
                            }
                        }
                    }

                    else
                    {
                        foreach (Receiver receiver in Receivers)
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



                                //receivers that are in a lower position in the applicants preference list
                                List<Receiver> worseReceivers = (from application in ApplicantReceivers
                                                                 where application.ApplicantPreference > applicantPreference
                                                                 && application.Applicant.ApplicantID == applicant.ApplicantID
                                                                 select application.Receiver).ToList();

                                //applicants, that are prefered more by the receiver
                                List<Applicant> betterApplicants = (from application in ApplicantReceivers
                                                                    where application.ReceiverPoints > applicantPoints
                                                                    && application.Receiver.ReceiverID == receiver.ReceiverID
                                                                    select application.Applicant).ToList();

                                if (betterApplicants.Count > 0)
                                {
                                    foreach (Receiver worseReceiver in worseReceivers)
                                    {
                                        Constraint constraint = solver.MakeConstraint();
                                        constraint.SetLb(0);

                                        constraint.SetCoefficient(variables[applicant][receiver], 1);
                                        foreach (Applicant betterApplicant in betterApplicants)
                                        {
                                            constraint.SetCoefficient(variables[betterApplicant][receiver], 1);
                                        }

                                        BlockingPair bp = new BlockingPair();

                                        bp.BlockedApplication = (from application in ApplicantReceivers
                                                                 where application.Applicant == applicant
                                                                 && application.Receiver == receiver
                                                                 select application).FirstOrDefault();

                                        bp.BlockingApplication = (from application in ApplicantReceivers
                                                                  where application.Applicant == applicant
                                                                  && application.Receiver == worseReceiver
                                                                  select application).FirstOrDefault();

                                        bp.Variable = solver.MakeBoolVar($"B{applicant.ApplicantID}_{receiver.ReceiverID}_{applicant.ApplicantID}_{worseReceiver.ReceiverID}");
                                        BlockingPairs2.Add(bp);
                                        constraint.SetCoefficient(variables[applicant][worseReceiver], -1);
                                        constraint.SetCoefficient(BlockingPairs2[BlockingPairs2.Count - 1].Variable, 1);
                                    }
                                }                           
                            }
                        }
                    }
                }
            }

            void CreateDynamicConstraints()
            {

                //iterating over Constraints
                foreach (DynamicConstraint dynamicConstraint in DynamicConstraints)
                {
                    foreach (Receiver receiver in Receivers)
                    {
                        int minimum = (from rdc in ReceiverDynamicConstraints
                                       where rdc.Receiver == receiver &&
                                       rdc.DynamicConstraint == dynamicConstraint
                                       select rdc.LowerBound).FirstOrDefault();
                        int maximum = (from rdc in ReceiverDynamicConstraints
                                       where rdc.Receiver == receiver &&
                                       rdc.DynamicConstraint == dynamicConstraint
                                       select rdc.UpperBound).FirstOrDefault();

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

        private void CreateObjective()
        {
            Objective objective = solver.Objective();
            if (ApplicantOptimal)
            {
                foreach (ApplicantReceiver application in ApplicantReceivers)
                {
                    int preference = application.ApplicantPreference;
                    objective.SetCoefficient(variables[application.Applicant][application.Receiver], preference);
                }

                foreach (var blockgingPair in BlockingPairs2)
                {
                    objective.SetCoefficient(blockgingPair.Variable, 100);
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

                foreach (var blockgingPair in BlockingPairs2)
                {
                    objective.SetCoefficient(blockgingPair.Variable, -100);
                }

                objective.SetMaximization();
            }
        }
    }
}

