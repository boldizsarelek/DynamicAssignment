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
    public partial class ResultPanel : UserControl
    {
        private class Result
        {
            public string ApplicantName { get; set; }
            public string ReceiverName { get; set; }
            public int ApplicantID { get; set; }
            public int ReceiverID { get; set; }
            public int ApplicantPreference { get; set; }
            public int ReceiverPoints { get; set; }
        }

        public DataGridView dataGridView { get { return dataGridView1; } }
        public ResultPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            dataGridView1.DataSource = (from p in AssignmentPackage.AssignmentResult.Pairs
                                       select new {p.Applicant.ApplicantID, p.Receiver.ReceiverID, p.Applicant.ApplicantName, p.Receiver.ReceiverName, p.ApplicantPreference, p.ReceiverPoints}).ToList();
            dataGridView1.Dock = DockStyle.Fill;
        }
    }
}
