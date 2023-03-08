﻿using DynamicAssignment;
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
        public ResultForm(AssignmentResult result)
        {
            InitializeComponent();
            ResultPanel rp = new ResultPanel(result.Pairs);
            panel1.Controls.Add(rp);
            label5.Text = result.Result;
            label6.Text = result.ObjectiveSum.ToString();
            label7.Text = result.BlockingPairs.Count.ToString();

        }
    }
}
