namespace Formsapp_Thesis
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
            dataGridView1 = new DataGridView();
            ApplicantID = new DataGridViewTextBoxColumn();
            ReceiverID = new DataGridViewTextBoxColumn();
            ApplicantName = new DataGridViewTextBoxColumn();
            ReceiverName = new DataGridViewTextBoxColumn();
            ApplicantPreference = new DataGridViewTextBoxColumn();
            ReceiverPoints = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ApplicantID, ReceiverID, ApplicantName, ReceiverName, ApplicantPreference, ReceiverPoints });
            dataGridView1.Location = new Point(17, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(900, 419);
            dataGridView1.TabIndex = 0;
            // 
            // ApplicantID
            // 
            ApplicantID.DataPropertyName = "ApplicantID";
            ApplicantID.HeaderText = "Hallgató azonosítója";
            ApplicantID.MinimumWidth = 6;
            ApplicantID.Name = "ApplicantID";
            ApplicantID.ReadOnly = true;
            ApplicantID.Width = 125;
            // 
            // ReceiverID
            // 
            ReceiverID.DataPropertyName = "ReceiverID";
            ReceiverID.HeaderText = "Munkahely azonosítója";
            ReceiverID.MinimumWidth = 6;
            ReceiverID.Name = "ReceiverID";
            ReceiverID.ReadOnly = true;
            ReceiverID.Width = 125;
            // 
            // ApplicantName
            // 
            ApplicantName.DataPropertyName = "ApplicantName";
            ApplicantName.HeaderText = "Hallgató neve";
            ApplicantName.MinimumWidth = 6;
            ApplicantName.Name = "ApplicantName";
            ApplicantName.ReadOnly = true;
            ApplicantName.Width = 125;
            // 
            // ReceiverName
            // 
            ReceiverName.DataPropertyName = "ReceiverName";
            ReceiverName.HeaderText = "Munkahely neve";
            ReceiverName.MinimumWidth = 6;
            ReceiverName.Name = "ReceiverName";
            ReceiverName.ReadOnly = true;
            ReceiverName.Width = 125;
            // 
            // ApplicantPreference
            // 
            ApplicantPreference.DataPropertyName = "ApplicantPreference";
            ApplicantPreference.HeaderText = "Preferencia";
            ApplicantPreference.MinimumWidth = 6;
            ApplicantPreference.Name = "ApplicantPreference";
            ApplicantPreference.ReadOnly = true;
            ApplicantPreference.Width = 125;
            // 
            // ReceiverPoints
            // 
            ReceiverPoints.DataPropertyName = "ReceiverPoints";
            ReceiverPoints.HeaderText = "Pontszám";
            ReceiverPoints.MinimumWidth = 6;
            ReceiverPoints.Name = "ReceiverPoints";
            ReceiverPoints.ReadOnly = true;
            ReceiverPoints.Width = 125;
            // 
            // ResultPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Name = "ResultPanel";
            Size = new Size(943, 459);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ApplicantID;
        private DataGridViewTextBoxColumn ReceiverID;
        private DataGridViewTextBoxColumn ApplicantName;
        private DataGridViewTextBoxColumn ReceiverName;
        private DataGridViewTextBoxColumn ApplicantPreference;
        private DataGridViewTextBoxColumn ReceiverPoints;
    }
}
