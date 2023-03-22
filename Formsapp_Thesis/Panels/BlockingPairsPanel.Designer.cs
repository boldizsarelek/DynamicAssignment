namespace Formsapp_Thesis
{
    partial class BlockingPairsPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            BlockingApplicantID = new DataGridViewTextBoxColumn();
            BlockingApplicantName = new DataGridViewTextBoxColumn();
            BlockingReceiverID = new DataGridViewTextBoxColumn();
            BlockingReceiverName = new DataGridViewTextBoxColumn();
            BlockedApplicantID = new DataGridViewTextBoxColumn();
            BlockedApplicantName = new DataGridViewTextBoxColumn();
            BlockedReceiverID = new DataGridViewTextBoxColumn();
            BlockedReceiverName = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { BlockingApplicantID, BlockingApplicantName, BlockingReceiverID, BlockingReceiverName, BlockedApplicantID, BlockedApplicantName, BlockedReceiverID, BlockedReceiverName });
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1076, 533);
            dataGridView1.TabIndex = 0;
            // 
            // BlockingApplicantID
            // 
            BlockingApplicantID.HeaderText = "Blokkoló hallgató azonosító";
            BlockingApplicantID.MinimumWidth = 6;
            BlockingApplicantID.Name = "BlockingApplicantID";
            BlockingApplicantID.ReadOnly = true;
            BlockingApplicantID.Width = 125;
            // 
            // BlockingApplicantName
            // 
            BlockingApplicantName.HeaderText = "Blokkoló Hallgató név";
            BlockingApplicantName.MinimumWidth = 6;
            BlockingApplicantName.Name = "BlockingApplicantName";
            BlockingApplicantName.ReadOnly = true;
            BlockingApplicantName.Width = 125;
            // 
            // BlockingReceiverID
            // 
            BlockingReceiverID.HeaderText = "Blokkoló munkahely azonosító";
            BlockingReceiverID.MinimumWidth = 6;
            BlockingReceiverID.Name = "BlockingReceiverID";
            BlockingReceiverID.ReadOnly = true;
            BlockingReceiverID.Width = 125;
            // 
            // BlockingReceiverName
            // 
            BlockingReceiverName.HeaderText = "Blokkoló munkahely neve";
            BlockingReceiverName.MinimumWidth = 6;
            BlockingReceiverName.Name = "BlockingReceiverName";
            BlockingReceiverName.ReadOnly = true;
            BlockingReceiverName.Width = 125;
            // 
            // BlockedApplicantID
            // 
            BlockedApplicantID.HeaderText = "Blokkolt hallgató azonosítója";
            BlockedApplicantID.MinimumWidth = 6;
            BlockedApplicantID.Name = "BlockedApplicantID";
            BlockedApplicantID.ReadOnly = true;
            BlockedApplicantID.Width = 125;
            // 
            // BlockedApplicantName
            // 
            BlockedApplicantName.HeaderText = "Blokkolt hallgató neve";
            BlockedApplicantName.MinimumWidth = 6;
            BlockedApplicantName.Name = "BlockedApplicantName";
            BlockedApplicantName.ReadOnly = true;
            BlockedApplicantName.Width = 125;
            // 
            // BlockedReceiverID
            // 
            BlockedReceiverID.HeaderText = "Blokkolt munkahely azonosítója";
            BlockedReceiverID.MinimumWidth = 6;
            BlockedReceiverID.Name = "BlockedReceiverID";
            BlockedReceiverID.ReadOnly = true;
            BlockedReceiverID.Width = 125;
            // 
            // BlockedReceiverName
            // 
            BlockedReceiverName.HeaderText = "Blokkolt munkahely neve";
            BlockedReceiverName.MinimumWidth = 6;
            BlockedReceiverName.Name = "BlockedReceiverName";
            BlockedReceiverName.ReadOnly = true;
            BlockedReceiverName.Width = 125;
            // 
            // BlockingPairsPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Name = "BlockingPairsPanel";
            Size = new Size(1186, 539);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn BlockingApplicantID;
        private DataGridViewTextBoxColumn BlockingApplicantName;
        private DataGridViewTextBoxColumn BlockingReceiverID;
        private DataGridViewTextBoxColumn BlockingReceiverName;
        private DataGridViewTextBoxColumn BlockedApplicantID;
        private DataGridViewTextBoxColumn BlockedApplicantName;
        private DataGridViewTextBoxColumn BlockedReceiverID;
        private DataGridViewTextBoxColumn BlockedReceiverName;
    }
}
