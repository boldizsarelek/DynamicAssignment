using DynamicAssignment;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formsapp_Thesis
{
    public class AssignmentPackage
    {
        static public Assignment Assignment;
        static public AssignmentResult AssignmentResult;
        public void Solve()
        {
            AssignmentResult =  Assignment.Solve();           
        }
        public AssignmentPackage()
        {
            readLocalData();            
        }
        
        private void readLocalData()
        {
            List<Applicant> applicants = new List<Applicant>();
            StreamReader reader = new StreamReader("Data/Applicant.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(',');
                Applicant applicant = new Applicant(
                    applicantID: Convert.ToInt32(line[0]),
                    applicantName: line[1]);
                applicants.Add(applicant);
            }
            reader.Close();

            List<Receiver> receivers = new List<Receiver>();
            reader = new StreamReader("Data/Receiver.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(',');
                Receiver receiver = new Receiver(
                    receiverID: Convert.ToInt32(line[0]),
                    receiverName: line[1],
                    minimumCapacity: Convert.ToInt32(line[2]),
                    maximumCapacity: Convert.ToInt32(line[3]));
                receivers.Add(receiver);
            }
            reader.Close();

            List<DynamicConstraint> constraints = new List<DynamicConstraint>();
            reader = new StreamReader("Data/Constraint.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(',');
                DynamicConstraint constraint = new DynamicConstraint(
                    constraintID: Convert.ToInt32(line[0]),

                    constraintName: line[3]);
                constraints.Add(constraint);
            }
            reader.Close();

            List<ApplicantReceiver> applicantReceivers = new List<ApplicantReceiver>();
            reader = new StreamReader("Data/ApplicantReceiver.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(',');
                int applicantID = Convert.ToInt32(line[1]);
                int receiverID = Convert.ToInt32(line[2]);

                Applicant applicant = (from a in applicants
                                       where a.ApplicantID == applicantID
                                       select a).FirstOrDefault();

                Receiver receiver = (from r in receivers
                                     where r.ReceiverID == receiverID
                                     select r).FirstOrDefault();

                ApplicantReceiver applicantReceiver = new ApplicantReceiver(
                    applicantReceiverID: Convert.ToInt32(line[0]),
                    applicant: applicant,
                    receiver: receiver,
                    applicantPreference: Convert.ToInt32(line[3]),
                    receiverPoints: Convert.ToInt32(line[4]));

                applicantReceivers.Add(applicantReceiver);
            }
            reader.Close();

            List<ApplicantDynamicConstraint> applicantConstraints = new List<ApplicantDynamicConstraint>();
            reader = new StreamReader("Data/ApplicantConstraint.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(',');
                int applicantID = Convert.ToInt32(line[1]);
                int constraintID = Convert.ToInt32(line[2]);

                Applicant applicant = (from a in applicants
                                       where a.ApplicantID == applicantID
                                       select a).FirstOrDefault();

                DynamicConstraint constraint = (from c in constraints
                                                                  where c.ConstraintID == constraintID
                                                                  select c).FirstOrDefault();

                ApplicantDynamicConstraint applicantConstraint = new ApplicantDynamicConstraint(
                    constraintID: Convert.ToInt32(line[0]),
                    applicant: applicant,
                    constraint: constraint,
                    applicantData: Convert.ToBoolean(Convert.ToInt32(line[3]))
                    );
                applicantConstraints.Add(applicantConstraint);
            }
            reader.Close();


            List<ReceiverDynamicConstraint> receiverConstraints = new List<ReceiverDynamicConstraint>();
            reader = new StreamReader("Data/ReceiverConstraint.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(';');
                int receiverID = Convert.ToInt32(line[1]);
                int constraintID = Convert.ToInt32(line[2]);

                Receiver receiver = (from a in receivers
                                     where a.ReceiverID == receiverID
                                     select a).FirstOrDefault();

                DynamicConstraint constraint = (from c in constraints
                                                                  where c.ConstraintID == constraintID
                                                                  select c).FirstOrDefault();

                ReceiverDynamicConstraint receiverConstraint = new ReceiverDynamicConstraint(
                    receiverConstraintID: Convert.ToInt32(line[0]),
                    receiver: receiver,
                    dynamicConstraint: constraint,
                    lowerBound: Convert.ToInt32(line[3]),
                    upperBound: Convert.ToInt32(line[4])
                    );
                receiverConstraints.Add(receiverConstraint);
            }
            reader.Close();

            Assignment = new Assignment(
                applicants: applicants,
                receivers: receivers,
                applicantReceivers: applicantReceivers,
                constraints: constraints,
                applicantConstraints: applicantConstraints,
                solverType2: Google.OrTools.LinearSolver.Solver.OptimizationProblemType.GLOP_LINEAR_PROGRAMMING,
                groupEnvyness: false) ;
            Assignment.ReceiverDynamicConstraints = receiverConstraints;

            List<ExpandoObject> dynamicApplicants = new List<ExpandoObject>();
            foreach (Applicant applicant in applicants)
            {
                List<ApplicantDynamicConstraint> applicantDynamicConstraints = (from adc in applicantConstraints
                                                                                where adc.Applicant == applicant
                                                                                select adc).ToList();


            }
        }
        
    }
}
