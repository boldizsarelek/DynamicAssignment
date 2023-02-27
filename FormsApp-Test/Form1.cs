using DynamicAssignment;

namespace FormsApp_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Applicant> applicants = new List<Applicant>();
            List<Receiver> receivers= new List<Receiver>();
            Applicant applicant = new Applicant(1, "Teszt");
            Applicant applicant2 = new Applicant(1, "Teszt2");
            Assignment assignment = new Assignment(applicants, receivers);

            applicants.Add(applicant);
            applicants.Add(applicant2);
            bindingSource1.DataSource= applicants;
            dataGridView1.DataSource = applicants;
        }
    }
}