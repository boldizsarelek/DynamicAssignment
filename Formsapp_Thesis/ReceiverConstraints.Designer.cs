namespace Formsapp_Thesis
{
    partial class ReceiverConstraints
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            ConstraintName = new DataGridViewTextBoxColumn();
            LowerBound = new DataGridViewTextBoxColumn();
            UpperBound = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ConstraintName, LowerBound, UpperBound });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(776, 267);
            dataGridView1.TabIndex = 0;
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
            // LowerBound
            // 
            LowerBound.DataPropertyName = "LowerBound";
            LowerBound.HeaderText = "Alsó korlát";
            LowerBound.MinimumWidth = 6;
            LowerBound.Name = "LowerBound";
            LowerBound.ReadOnly = true;
            LowerBound.Width = 125;
            // 
            // UpperBound
            // 
            UpperBound.DataPropertyName = "UpperBound";
            UpperBound.HeaderText = "Felső korlát";
            UpperBound.MinimumWidth = 6;
            UpperBound.Name = "UpperBound";
            UpperBound.ReadOnly = true;
            UpperBound.Width = 125;
            // 
            // ReceiverConstraints
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "ReceiverConstraints";
            Text = "ReceiverConstraints";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ConstraintName;
        private DataGridViewTextBoxColumn LowerBound;
        private DataGridViewTextBoxColumn UpperBound;
    }
}