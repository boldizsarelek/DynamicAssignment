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
    public partial class ReceiversPanel : UserControl
    {
        public ReceiversPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            dataGridView1.DataSource = DynamicAssignment.Assignment.Receivers;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedReceiver = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            ReceiverConstraints rc = new ReceiverConstraints(selectedReceiver);
            rc.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int selectedReceiver;
            try
            {
                selectedReceiver = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                dataGridView2.DataSource = (from rc in DynamicAssignment.Assignment.ReceiverDynamicConstraints
                                            where rc.Receiver.ReceiverID == selectedReceiver
                                            select new
                                            {
                                                rc.DynamicConstraint.ConstraintName,
                                                rc.LowerBound,
                                                rc.UpperBound
                                            }).ToList();
            }
            catch (Exception)
            {


            }
        }
    }
}
