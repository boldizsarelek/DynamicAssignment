using DynamicAssignment;
using System.Dynamic;
using Google.OrTools.LinearSolver;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Formsapp_Thesis
{
    public partial class Form1 : Form
    {
        Assignment assignment;
        AssignmentResult assignmentResult;
        public Form1()
        {
            InitializeComponent();
            DynamicAssignment m = new DynamicAssignment();
            ApplicantsPanel ap = new ApplicantsPanel();
            panel1.Controls.Add(ap);
            applicantRadio.CheckedChanged += Groupbox1_CheckChange;
            receiverRadio.CheckedChanged += Groupbox1_CheckChange;
            comboBox1.DataSource = Enum.GetValues(typeof(Solver.OptimizationProblemType))
                                     .Cast<Solver.OptimizationProblemType>()
                                     .ToList();


        }

        private void Groupbox1_CheckChange(object? sender, EventArgs e)
        {
            panel1.Controls.Clear();
            if (sender == applicantRadio)
            {
                ApplicantsPanel ap = new ApplicantsPanel();
                panel1.Controls.Add(ap);
            }

            else if (sender == receiverRadio)
            {
                ReceiversPanel rp = new ReceiversPanel();
                panel1.Controls.Add(rp);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            bool groupEnvyness = groupEnvynessRadio.Checked;
            bool applicantOptimal = applicantOptimalRadio.Checked;
            bool assignEach = assignEachRadio.Checked;

            Assignment.assignEach = assignEach;
            Assignment.applicantOptimal = applicantOptimal;
            Assignment.groupEnvyness = groupEnvyness;


            DynamicAssignment.AssignmentResult = DynamicAssignment.Assignment.Solve();
            ResultForm rf = new ResultForm(assignmentResult);
            rf.ShowDialog();

        }
    }
}