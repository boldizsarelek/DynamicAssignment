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

namespace Formsapp_Thesis
{
    public partial class ReceiversPanel : UserControl
    {
        public ReceiversPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            dataGridView1.DataSource = AssignmentPackage.Assignment.Receivers;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int selectedReceiver;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedReceiver = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                List<ReceiverDynamicConstraint> constraints = AssignmentPackage.Assignment.GetReceiverDynamicConstraintsByReceiverID(selectedReceiver);
                dataGridView2.DataSource = (from c in constraints select new { c.DynamicConstraint.ConstraintName, c.LowerBound, c.UpperBound }).ToList();

                List<ApplicantReceiver> applications = AssignmentPackage.Assignment.GetApplicantReceiversByReceiverID(selectedReceiver);
                dataGridView3.DataSource = (from a in applications select new { a.Applicant.ApplicantID, a.Applicant.ApplicantName, a.ReceiverPoints }).ToList();
            }

        }
    }
}
