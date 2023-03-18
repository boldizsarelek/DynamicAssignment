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
            listBox1.DataSource = DynamicAssignment.Assignment.Applicants;
            listBox1.DisplayMember = "ApplicantName";
            listBox1.ValueMember = "ApplicantID";
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

        }

        private void ListBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var data = (from ac in DynamicAssignment.Assignment.ApplicantConstraints
                        where ac.Applicant.ApplicantID == (int)listBox1.SelectedValue
                        select new
                        {
                            ac.DynamicConstraint.ConstraintName,
                            ac.ApplicantData
                        }).ToList();

            dataGridView2.DataSource = data;

            var applications = (from ar in DynamicAssignment.Assignment.ApplicantReceivers
                                where ar.Applicant.ApplicantID == (int)listBox1.SelectedValue
                                orderby ar.ApplicantPreference ascending
                                select new
                                {
                                    ar.ApplicantPreference,
                                    ar.Receiver.ReceiverName,
                                    ar.ReceiverPoints
                                }
                        ).ToList();
            dataGridView1.DataSource = applications;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
