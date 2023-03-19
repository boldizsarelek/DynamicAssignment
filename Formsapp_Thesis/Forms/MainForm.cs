using DynamicAssignment;
using System.Dynamic;
using Google.OrTools.LinearSolver;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Formsapp_Thesis
{
    public partial class MainForm : Form
    {        
        public MainForm()
        {
            InitializeComponent();
            AssignmentPackage.ReadLocalData();
            ApplicantsPanel ap = new ApplicantsPanel();
            panel1.Controls.Add(ap);
            applicantRadio.CheckedChanged += Groupbox1_CheckChange;
            receiverRadio.CheckedChanged += Groupbox1_CheckChange;
            List<string> solvers = new List<string>();
            solvers.Add("SCIP");
            solvers.Add("GLOP");
            solvers.Add("GLPK");
            comboBox1.DataSource = solvers;
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
            string solverType = comboBox1.SelectedItem as string;
            AssignmentPackage.Assignment.GroupEnvyness = groupEnvyness;
            AssignmentPackage.Assignment.ApplicantOptimal = applicantOptimal;
            AssignmentPackage.Assignment.AssignEach = assignEach;
            AssignmentPackage.Assignment.SolverType = solverType;
            AssignmentPackage.Solve();        
            ResultForm rf = new ResultForm();
            rf.ShowDialog();

        }
    }
}