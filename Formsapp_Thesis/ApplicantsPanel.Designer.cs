namespace Formsapp_Thesis
{
    partial class ApplicantsPanel
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
            dataGridView2 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            listBox1 = new ListBox();
            dataGridView1 = new DataGridView();
            ApplicantPreference = new DataGridViewTextBoxColumn();
            ReceiverName = new DataGridViewTextBoxColumn();
            ReceiverPoints = new DataGridViewTextBoxColumn();
            moveUpButton = new Button();
            moveDownButton = new Button();
            button7 = new Button();
            button8 = new Button();
            ConstraintName = new DataGridViewTextBoxColumn();
            ApplicantData = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { ConstraintName, ApplicantData });
            dataGridView2.Location = new Point(355, 38);
            dataGridView2.Margin = new Padding(2);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 72;
            dataGridView2.RowTemplate.Height = 37;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(355, 444);
            dataGridView2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(354, 495);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(356, 62);
            button1.TabIndex = 2;
            button1.Text = "Új tulajdonság felvétele";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.Location = new Point(355, 631);
            button2.Name = "button2";
            button2.Size = new Size(355, 62);
            button2.TabIndex = 3;
            button2.Text = "Tulajdonság törlése";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.Location = new Point(2, 495);
            button3.Name = "button3";
            button3.Size = new Size(351, 62);
            button3.TabIndex = 4;
            button3.Text = "Új hallgató felvétele";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button4.Location = new Point(2, 631);
            button4.Name = "button4";
            button4.Size = new Size(351, 62);
            button4.TabIndex = 5;
            button4.Text = "Hallgató törlése";
            button4.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(0, 38);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(351, 444);
            listBox1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ApplicantPreference, ReceiverName, ReceiverPoints });
            dataGridView1.Location = new Point(715, 38);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(431, 444);
            dataGridView1.TabIndex = 7;
            // 
            // ApplicantPreference
            // 
            ApplicantPreference.DataPropertyName = "ApplicantPreference";
            ApplicantPreference.HeaderText = "Sorszám";
            ApplicantPreference.MinimumWidth = 6;
            ApplicantPreference.Name = "ApplicantPreference";
            ApplicantPreference.ReadOnly = true;
            ApplicantPreference.Width = 125;
            // 
            // ReceiverName
            // 
            ReceiverName.DataPropertyName = "ReceiverName";
            ReceiverName.HeaderText = "Munkahely";
            ReceiverName.MinimumWidth = 6;
            ReceiverName.Name = "ReceiverName";
            ReceiverName.ReadOnly = true;
            ReceiverName.Width = 125;
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
            // moveUpButton
            // 
            moveUpButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            moveUpButton.Location = new Point(715, 493);
            moveUpButton.Name = "moveUpButton";
            moveUpButton.Size = new Size(219, 62);
            moveUpButton.TabIndex = 8;
            moveUpButton.Text = "↑";
            moveUpButton.UseVisualStyleBackColor = true;
            moveUpButton.Click += button5_Click;
            // 
            // moveDownButton
            // 
            moveDownButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            moveDownButton.Location = new Point(933, 493);
            moveDownButton.Name = "moveDownButton";
            moveDownButton.Size = new Size(213, 62);
            moveDownButton.TabIndex = 9;
            moveDownButton.Text = "↓";
            moveDownButton.UseVisualStyleBackColor = true;
            moveDownButton.Click += button6_Click;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button7.Location = new Point(2, 563);
            button7.Name = "button7";
            button7.Size = new Size(351, 62);
            button7.TabIndex = 10;
            button7.Text = "Hallgató szerkesztése";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button8.Location = new Point(355, 562);
            button8.Name = "button8";
            button8.Size = new Size(355, 62);
            button8.TabIndex = 11;
            button8.Text = "Tulajdonság szerkesztése";
            button8.UseVisualStyleBackColor = true;
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
            // ApplicantData
            // 
            ApplicantData.DataPropertyName = "ApplicantData";
            ApplicantData.HeaderText = "Érték";
            ApplicantData.MinimumWidth = 6;
            ApplicantData.Name = "ApplicantData";
            ApplicantData.ReadOnly = true;
            ApplicantData.Width = 125;
            // 
            // ApplicantsPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(moveDownButton);
            Controls.Add(moveUpButton);
            Controls.Add(dataGridView1);
            Controls.Add(listBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView2);
            Margin = new Padding(2);
            Name = "ApplicantsPanel";
            Size = new Size(1155, 696);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ListBox listBox1;
        private DataGridView dataGridView1;
        private Button moveUpButton;
        private Button moveDownButton;
        private Button button7;
        private Button button8;
        private DataGridViewTextBoxColumn ApplicantPreference;
        private DataGridViewTextBoxColumn ReceiverName;
        private DataGridViewTextBoxColumn ReceiverPoints;
        private DataGridViewTextBoxColumn ConstraintName;
        private DataGridViewTextBoxColumn ApplicantData;
    }
}
