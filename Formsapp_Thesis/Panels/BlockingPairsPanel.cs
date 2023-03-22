
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
    public partial class BlockingPairsPanel : UserControl
    {
        public BlockingPairsPanel()
        {
            InitializeComponent();
            dataGridView1.DataSource = from bp in AssignmentPackage.AssignmentResult.BlockingPairs
                                       select new 
                                       {
                                           BlockingApplicantID = bp.BlockingApplication.Applicant.ApplicantID,
                                           BlockingApplicantName = bp.BlockingApplication.Applicant.ApplicantName,
                                           BlockingReceiverID = bp.BlockingApplication.Receiver.ReceiverID,
                                           BlockingReceiverName = bp.BlockingApplication.Receiver.ReceiverName,
                                           BlockedApplicantID = bp.BlockedApplication.Applicant.ApplicantID,
                                           BlockedApplicantName = bp.BlockedApplication.Applicant.ApplicantName,
                                           BlockedReceiverID = bp.BlockedApplication.Receiver.ReceiverID,
                                           BlockedReceiverName = bp.BlockedApplication.Receiver.ReceiverName
                                       };
            Dock = DockStyle.Fill;
            dataGridView1.Dock = DockStyle.Fill;
        }
    }
}
