

using DynamicAssignment;

namespace Formsapp_Thesis
{
    public partial class Form1 : Form
    {
        Assignment assignment;
        AssignmentResult assignmentResult;
        public Form1()
        {
            InitializeComponent();


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

            List<DynamicAssignment.DynamicConstraint> constraints = new List<DynamicAssignment.DynamicConstraint>();
            reader = new StreamReader("Data/Constraint.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(',');
                DynamicAssignment.DynamicConstraint constraint = new DynamicAssignment.DynamicConstraint(
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

                DynamicAssignment.DynamicConstraint constraint = (from c in constraints
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

                DynamicAssignment.DynamicConstraint constraint = (from c in constraints
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

            assignment = new Assignment(
                applicants: applicants,
                receivers: receivers,
                applicantReceivers: applicantReceivers,
                constraints: constraints,
                applicantConstraints: applicantConstraints,
                groupEnvyness: false);
            assignment.ReceiverDynamicConstraints = receiverConstraints;

            assignmentResult = assignment.Solve();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResultForm rf = new ResultForm(assignmentResult);
            rf.ShowDialog();
        }
    }
}