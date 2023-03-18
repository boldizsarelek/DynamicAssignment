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
    public partial class ReceiverConstraints : Form
    {
        public ReceiverConstraints(int id)
        {
            InitializeComponent();
            dataGridView1.DataSource = (from rc in DynamicAssignment.Assignment.ReceiverDynamicConstraints
                                        where rc.Receiver.ReceiverID == id
                                        select new
                                        {
                                            rc.DynamicConstraint.ConstraintName,
                                            rc.LowerBound,
                                            rc.UpperBound
                                        }).ToList();

        }
    }
}
