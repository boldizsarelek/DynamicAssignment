namespace WindowsFormsApp_Thesis
{
    partial class ResultPanel
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecxeiverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlockingPair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.ApplicantName,
            this.ReceiverID,
            this.RecxeiverName,
            this.BlockingPair});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1362, 462);
            this.dataGridView1.TabIndex = 0;
            // 
            // StudentID
            // 
            this.StudentID.HeaderText = "Hallgató azonosító";
            this.StudentID.MinimumWidth = 10;
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            this.StudentID.Width = 200;
            // 
            // ApplicantName
            // 
            this.ApplicantName.HeaderText = "Hallgató neve";
            this.ApplicantName.MinimumWidth = 10;
            this.ApplicantName.Name = "ApplicantName";
            this.ApplicantName.ReadOnly = true;
            this.ApplicantName.Width = 200;
            // 
            // ReceiverID
            // 
            this.ReceiverID.HeaderText = "Munkahely azonosítója";
            this.ReceiverID.MinimumWidth = 10;
            this.ReceiverID.Name = "ReceiverID";
            this.ReceiverID.ReadOnly = true;
            this.ReceiverID.Width = 200;
            // 
            // RecxeiverName
            // 
            this.RecxeiverName.HeaderText = "Munkahely neve";
            this.RecxeiverName.MinimumWidth = 10;
            this.RecxeiverName.Name = "RecxeiverName";
            this.RecxeiverName.ReadOnly = true;
            this.RecxeiverName.Width = 200;
            // 
            // BlockingPair
            // 
            this.BlockingPair.HeaderText = "Blokkoló pár";
            this.BlockingPair.MinimumWidth = 10;
            this.BlockingPair.Name = "BlockingPair";
            this.BlockingPair.ReadOnly = true;
            this.BlockingPair.Width = 200;
            // 
            // ResultPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "ResultPanel";
            this.Size = new System.Drawing.Size(1362, 463);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecxeiverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlockingPair;
    }
}
