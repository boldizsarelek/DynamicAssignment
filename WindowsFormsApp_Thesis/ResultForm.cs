using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Thesis
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
            ResultPanel rp = new ResultPanel();
            panel1.Controls.Add(rp);
        }
    }
}
