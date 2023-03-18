using DynamicAssignment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formsapp_Thesis
{
    public partial class ApplicantsPanel : UserControl
    {
        public ApplicantsPanel()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
            listBox1.DataSource = AssignmentPackage.Assignment.Applicants;
            listBox1.DisplayMember = "ApplicantName";
            listBox1.ValueMember = "ApplicantID";
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

        }

        private void ListBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            updateData();
        }

        private void updateData()
        {
            int applicantID = (int)listBox1.SelectedValue;
            List<ApplicantReceiver> applicantReceivers = new List<ApplicantReceiver>();
            List<ApplicantDynamicConstraint> applicantDynamicConstraints = new List<ApplicantDynamicConstraint>();
            applicantReceivers = AssignmentPackage.Assignment.GetApplicantReceiversByApplicantID(applicantID);
            applicantDynamicConstraints = AssignmentPackage.Assignment.GetApplicantDynamicConstraintsByApplicantID(applicantID);
            dataGridView1.DataSource = (from ar in applicantReceivers
                                        orderby ar.ApplicantPreference ascending
                                        select new { ar.ApplicantPreference, ar.Receiver.ReceiverID, ar.Receiver.ReceiverName }).ToList();
            dataGridView2.DataSource = (from adc in applicantDynamicConstraints
                                        select new { adc.DynamicConstraint.ConstraintName, adc.ApplicantData }).ToList();
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            int applicantID = (int)listBox1.SelectedValue;
            int selectedRow = (int)dataGridView1.SelectedRows[0].Index;
            int receiverID = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
            AssignmentPackage.Assignment.ChangePreferenceNumberByID(applicantID, receiverID, true);

            updateData();
            if (selectedRow != 0)
            {
                dataGridView1.Rows[0].Selected = false;
                dataGridView1.Rows[selectedRow - 1].Selected = true;
            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            int applicantID = (int)listBox1.SelectedValue;
            int selectedRow = (int)dataGridView1.SelectedRows[0].Index;
            int receiverID = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
            AssignmentPackage.Assignment.ChangePreferenceNumberByID(applicantID, receiverID, false);


            updateData();
            if (selectedRow != dataGridView1.RowCount - 1)
            {
                dataGridView1.Rows[0].Selected = false;
                dataGridView1.Rows[selectedRow + 1].Selected = true;
            }
            else
            {
                dataGridView1.Rows[0].Selected = false;
                dataGridView1.Rows[selectedRow].Selected = true;
            }
        }
    }
}
