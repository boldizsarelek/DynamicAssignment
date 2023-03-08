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
    public partial class ResultForm : Form
    {
        public ResultForm(AssignmentResult result)
        {
            InitializeComponent();
            ResultPanel rp = new ResultPanel(result.Pairs);
            panel1.Controls.Add(rp);
            statusLabel.Text = result.Result;
            objectiveSumLabel.Text = result.ObjectiveSum.ToString();
            blockingPairsLabel.Text = result.BlockingPairs.Count.ToString();

        }
    }
}
