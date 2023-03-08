using DynamicAssignment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.OrTools;

namespace WindowsFormsApp_Thesis
{
    public partial class Form1 : Form
    {
        ThesisEntities1 context = new ThesisEntities1();
        Assignment assignment;
         
        public Form1()
        {
            InitializeComponent();     
            Solve();

            bindingSource1.DataSource = context.Applicant.ToList();

        }

        void Solve()
        { 
            var applicantTmp = (from p in context.Applicant
                                select p).ToList();
            List<DynamicAssignment.Applicant> applicants = new List<DynamicAssignment.Applicant>();
            for (int i = 0; i < applicantTmp.Count; i++)
            {
                DynamicAssignment.Applicant applicant = new DynamicAssignment.Applicant(applicantTmp[i].ApplicantID, applicantTmp[i].ApplicantName);

                applicants.Add(applicant);
            }


            var receiverTmp = (from p in context.Receiver
                               select p).ToList();
            List<DynamicAssignment.Receiver> receivers = new List<DynamicAssignment.Receiver>();
            for (int i = 0; i < receiverTmp.Count; i++)
            {
                DynamicAssignment.Receiver receiver = new DynamicAssignment.Receiver(
                    receiverID: receiverTmp[i].ReceiverID, 
                    receiverName: receiverTmp[i].ReceiverName, 
                    minimumCapacity: receiverTmp[i].MinimumCapacity,
                    maximumCapacity: receiverTmp[i].MaximumCapacity);

                receivers.Add(receiver);
            }


            var applicantReceiverTmp = (from p in context.ApplicantReceiver
                                        select p).ToList();
            List<DynamicAssignment.ApplicantReceiver> applicantReceivers = new List<DynamicAssignment.ApplicantReceiver>();
            for (int i = 0; i < applicantReceiverTmp.Count; i++)
            {
                DynamicAssignment.ApplicantReceiver receiver = new DynamicAssignment.ApplicantReceiver(
                    applicantReceiverID: applicantReceiverTmp[i].ApplicantReceiverID,
                    applicant: (from a in applicants
                                where a.ApplicantID == applicantReceiverTmp[i].ApplicantID
                                select a).FirstOrDefault(),
                    receiver: (from r in receivers
                               where r.ReceiverID == applicantReceiverTmp[i].ReceiverID
                               select r).FirstOrDefault(),
                    applicantPreference: applicantReceiverTmp[i].ApplicantPreference,
                    receiverPoints: applicantReceiverTmp[i].ReceiverPoints
                    );

                applicantReceivers.Add(receiver);
            }

            var constraintTmp = (from p in context.Constraint
                                 select p).ToList();
            List<DynamicAssignment.DynamicConstraint> constraints = new List<DynamicAssignment.DynamicConstraint>();
            for (int i = 0; i < constraintTmp.Count; i++)
            {
                DynamicAssignment.DynamicConstraint constraint = new DynamicAssignment.DynamicConstraint(
                    constraintID: constraintTmp[i].ConstraintID,
                    constraintName: constraintTmp[i].ConstraintName);
                constraints.Add(constraint);
            }

            var receiverConstrainttmp = (from p in context.ReceiverConstraint
                                         select p).ToList();
            List<ReceiverDynamicConstraint> receiverDynamicConstraints = new List<ReceiverDynamicConstraint>();
            for (int i = 0; i < receiverConstrainttmp.Count; i++)
            {
                DynamicAssignment.ReceiverDynamicConstraint rc = new DynamicAssignment.ReceiverDynamicConstraint(
                    receiverConstraintID: receiverConstrainttmp[i].ReceiverConstraintID,
                    receiver: (from r in receivers
                               where r.ReceiverID == receiverConstrainttmp[i].ReceiverID
                               select r).FirstOrDefault(),
                    dynamicConstraint: (from dc in constraints
                                        where dc.ConstraintID == receiverConstrainttmp[i].ConstraintID
                                        select dc).FirstOrDefault(),
                    lowerBound: receiverConstrainttmp[i].LowerBound,
                    upperBound: receiverConstrainttmp[i].UpperBound);
                receiverDynamicConstraints.Add(rc);
            }

            var applicantConstraintTmp = (from p in context.ApplicantConstraint
                                          select p).ToList();
            List<DynamicAssignment.ApplicantDynamicConstraint> applicantConstraints = new List<DynamicAssignment.ApplicantDynamicConstraint>();
            for (int i = 0; i < applicantConstraintTmp.Count; i++)
            {
                DynamicAssignment.ApplicantDynamicConstraint applicantConstraint = new DynamicAssignment.ApplicantDynamicConstraint(
                    constraintID: applicantConstraintTmp[i].ConstraintID,
                    applicant: (from a in applicants
                                where a.ApplicantID == applicantConstraintTmp[i].ApplicantID
                                select a).FirstOrDefault(),
                    constraint: (from c in constraints
                                        where c.ConstraintID == applicantConstraintTmp[i].ConstraintID
                                        select c).FirstOrDefault(),
                    applicantData: applicantConstraintTmp[i].ApplicantData);

            }

            bool assignAll = radioButtonAssignAll.Checked;
            bool groupEnvyness = radioButtonGroupEnvyness.Checked;
            bool applicantOptimal = radioButtonApplicantOptimal.Checked;

            assignment = new Assignment(                                          
                applicants: applicants,
                receivers: receivers,
                applicantReceivers: applicantReceivers,
                constraints: constraints,
                applicantConstraints: applicantConstraints,
                applicantOptimal: applicantOptimal,
                groupEnvyness: groupEnvyness,
                assignEach: assignAll
                );
            assignment.ReceiverDynamicConstraints = receiverDynamicConstraints;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            Solve();
            AssignmentResult result = assignment.Solve();

            ResultForm rf = new ResultForm(result);
            rf.ShowDialog();
            
        }
    }
}
