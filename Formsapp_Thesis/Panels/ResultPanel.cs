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
        public ResultPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            dataGridView1.DataSource = AssignmentPackage.AssignmentResult.Pairs;
            dataGridView1.Dock = DockStyle.Fill;
        }
    }
}
