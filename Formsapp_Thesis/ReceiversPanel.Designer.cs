namespace Formsapp_Thesis
{
    partial class ReceiversPanel
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
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            ReceiverID = new DataGridViewTextBoxColumn();
            ReceiverName = new DataGridViewTextBoxColumn();
            LowerBound = new DataGridViewTextBoxColumn();
            UpperBound = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            ConstraintName = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridView3 = new DataGridView();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            ReceiverPoints = new DataGridViewTextBoxColumn();
            ApplicantPreference = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.Location = new Point(304, 489);
            button2.Name = "button2";
            button2.Size = new Size(936, 58);
            button2.TabIndex = 2;
            button2.Text = "Szerkesztés";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(1246, 488);
            button3.Name = "button3";
            button3.Size = new Size(301, 58);
            button3.TabIndex = 3;
            button3.Text = "Törlés";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button4.Location = new Point(3, 488);
            button4.Name = "button4";
            button4.Size = new Size(295, 59);
            button4.TabIndex = 4;
            button4.Text = "Új munkahely";
            button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ReceiverID, ReceiverName, LowerBound, UpperBound });
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(566, 479);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
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
            // ReceiverName
            // 
            ReceiverName.DataPropertyName = "ReceiverName";
            ReceiverName.HeaderText = "Munkahely neve";
            ReceiverName.MinimumWidth = 6;
            ReceiverName.Name = "ReceiverName";
            ReceiverName.ReadOnly = true;
            ReceiverName.Width = 125;
            // 
            // LowerBound
            // 
            LowerBound.DataPropertyName = "MinimumCapacity";
            LowerBound.HeaderText = "Minimum létszám";
            LowerBound.MinimumWidth = 6;
            LowerBound.Name = "LowerBound";
            LowerBound.ReadOnly = true;
            LowerBound.Width = 125;
            // 
            // UpperBound
            // 
            UpperBound.DataPropertyName = "MaximumCapacity";
            UpperBound.HeaderText = "Maximum létszám";
            UpperBound.MinimumWidth = 6;
            UpperBound.Name = "UpperBound";
            UpperBound.ReadOnly = true;
            UpperBound.Width = 125;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { ConstraintName, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dataGridView2.Location = new Point(575, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(426, 479);
            dataGridView2.TabIndex = 6;
            // 
            // ConstraintName
            // 
            ConstraintName.DataPropertyName = "ConstraintName";
            ConstraintName.HeaderText = "Tulajdonság";
            ConstraintName.MinimumWidth = 6;
            ConstraintName.Name = "ConstraintName";
            ConstraintName.ReadOnly = true;
            ConstraintName.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "LowerBound";
            dataGridViewTextBoxColumn1.HeaderText = "Minimum létszám";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "UpperBound";
            dataGridViewTextBoxColumn2.HeaderText = "Maximum létszám";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, ReceiverPoints, ApplicantPreference });
            dataGridView3.Location = new Point(1007, 3);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.RowTemplate.Height = 29;
            dataGridView3.Size = new Size(529, 479);
            dataGridView3.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "ApplicantName";
            dataGridViewTextBoxColumn3.HeaderText = "Hallgató";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 125;
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
            // ApplicantPreference
            // 
            ApplicantPreference.DataPropertyName = "ApplicantPreference";
            ApplicantPreference.HeaderText = "Hallgató preferenciája";
            ApplicantPreference.MinimumWidth = 6;
            ApplicantPreference.Name = "ApplicantPreference";
            ApplicantPreference.ReadOnly = true;
            ApplicantPreference.Width = 125;
            // 
            // ReceiversPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Name = "ReceiversPanel";
            Size = new Size(1539, 550);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ReceiverID;
        private DataGridViewTextBoxColumn ReceiverName;
        private DataGridViewTextBoxColumn LowerBound;
        private DataGridViewTextBoxColumn UpperBound;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn ConstraintName;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn ReceiverPoints;
        private DataGridViewTextBoxColumn ApplicantPreference;
    }
}
