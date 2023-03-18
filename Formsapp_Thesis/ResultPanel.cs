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
        public ResultPanel(Dictionary<global::DynamicAssignment.Applicant, global::DynamicAssignment.Receiver> pairs)
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

                var application = (from ar in DynamicAssignment.Assignment.ApplicantReceivers
                                   where ar.Applicant == pair.Key && ar.Receiver == pair.Value
                                   select ar).FirstOrDefault();

                result.ApplicantPreference = application.ApplicantPreference;
                result.ReceiverPoints = application.ReceiverPoints;
                results.Add(result);
            }

            dataGridView1.DataSource = results;
            dataGridView1.Dock = DockStyle.Fill;


        }
    }
}
