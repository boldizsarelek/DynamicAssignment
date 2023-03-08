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
        }
        public ResultPanel(Dictionary<DynamicAssignment.Applicant, DynamicAssignment.Receiver> pairs)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            List<Result> results = new List<Result>();
            foreach (var pair in pairs)
            {
                Result result = new Result();
                result.ApplicantID = pair.Key.ApplicantID;
                result.ApplicantName = pair.Key.ApplicantName;
                result.ReceiverID = pair.Value.ReceiverID;
                result.ReceiverName = pair.Value.ReceiverName;
                results.Add(result);
            }

            dataGridView1.DataSource = results;
            dataGridView1.Dock = DockStyle.Fill;


        }
    }
}
