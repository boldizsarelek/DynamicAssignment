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
        public ResultForm()
        {
            InitializeComponent();
            ResultPanel rp = new ResultPanel();
            panel1.Controls.Add(rp);
            statusLabel.Text = AssignmentPackage.AssignmentResult.Result;
            objectiveSumLabel.Text = AssignmentPackage.AssignmentResult.ObjectiveSum.ToString();
            blockingPairsLabel.Text = AssignmentPackage.AssignmentResult.BlockingPairs.Count.ToString();

            pairsRadio.CheckedChanged += GroupBox1_Checkchange;
            blockingPairsRadio.CheckedChanged += GroupBox1_Checkchange;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(AssignmentPackage.AssignmentResult.LpFile);
        }

        
        private void GroupBox1_Checkchange(object? sender, EventArgs e)
        {
            panel1.Controls.Clear();
            if (sender == pairsRadio)
            {
                ResultPanel rp = new ResultPanel();
                panel1.Controls.Add(rp);
            }

            else if (sender == blockingPairsRadio)
            {
                BlockingPairsPanel bp = new BlockingPairsPanel();
                panel1.Controls.Add(bp);
            }
        }
    }
}
