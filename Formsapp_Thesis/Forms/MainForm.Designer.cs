namespace Formsapp_Thesis
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            receiverRadio = new RadioButton();
            applicantRadio = new RadioButton();
            groupBox2 = new GroupBox();
            ReceiverOptimalRadio = new RadioButton();
            applicantOptimalRadio = new RadioButton();
            groupBox3 = new GroupBox();
            dontAssignEachRadio = new RadioButton();
            assignEachRadio = new RadioButton();
            groupBox4 = new GroupBox();
            groupEnvynessRadio = new RadioButton();
            noGroupEnvynessRadio = new RadioButton();
            pairButton = new Button();
            panel1 = new Panel();
            groupBox5 = new GroupBox();
            comboBox1 = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(receiverRadio);
            groupBox1.Controls.Add(applicantRadio);
            groupBox1.Location = new Point(9, 6);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(1431, 102);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lista";
            // 
            // receiverRadio
            // 
            receiverRadio.AutoSize = true;
            receiverRadio.Location = new Point(172, 39);
            receiverRadio.Margin = new Padding(4, 4, 4, 4);
            receiverRadio.Name = "receiverRadio";
            receiverRadio.Size = new Size(161, 34);
            receiverRadio.TabIndex = 1;
            receiverRadio.Text = "Munkahelyek";
            receiverRadio.UseVisualStyleBackColor = true;
            // 
            // applicantRadio
            // 
            applicantRadio.AutoSize = true;
            applicantRadio.Checked = true;
            applicantRadio.Location = new Point(21, 39);
            applicantRadio.Margin = new Padding(4, 4, 4, 4);
            applicantRadio.Name = "applicantRadio";
            applicantRadio.Size = new Size(126, 34);
            applicantRadio.TabIndex = 0;
            applicantRadio.TabStop = true;
            applicantRadio.Text = "Hallgatók";
            applicantRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(ReceiverOptimalRadio);
            groupBox2.Controls.Add(applicantOptimalRadio);
            groupBox2.Location = new Point(9, 1040);
            groupBox2.Margin = new Padding(4, 4, 4, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 4, 4, 4);
            groupBox2.Size = new Size(297, 141);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Optimalizálás";
            // 
            // ReceiverOptimalRadio
            // 
            ReceiverOptimalRadio.AutoSize = true;
            ReceiverOptimalRadio.Location = new Point(21, 84);
            ReceiverOptimalRadio.Margin = new Padding(4, 4, 4, 4);
            ReceiverOptimalRadio.Name = "ReceiverOptimalRadio";
            ReceiverOptimalRadio.Size = new Size(232, 34);
            ReceiverOptimalRadio.TabIndex = 1;
            ReceiverOptimalRadio.Text = "Munkahely-optimális";
            ReceiverOptimalRadio.UseVisualStyleBackColor = true;
            // 
            // applicantOptimalRadio
            // 
            applicantOptimalRadio.AutoSize = true;
            applicantOptimalRadio.Checked = true;
            applicantOptimalRadio.Location = new Point(21, 39);
            applicantOptimalRadio.Margin = new Padding(4, 4, 4, 4);
            applicantOptimalRadio.Name = "applicantOptimalRadio";
            applicantOptimalRadio.Size = new Size(208, 34);
            applicantOptimalRadio.TabIndex = 0;
            applicantOptimalRadio.TabStop = true;
            applicantOptimalRadio.Text = "Hallgató-optimális";
            applicantOptimalRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox3.Controls.Add(dontAssignEachRadio);
            groupBox3.Controls.Add(assignEachRadio);
            groupBox3.Location = new Point(315, 1040);
            groupBox3.Margin = new Padding(4, 4, 4, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 4, 4, 4);
            groupBox3.Size = new Size(432, 141);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Hozzárendelés";
            // 
            // dontAssignEachRadio
            // 
            dontAssignEachRadio.AutoSize = true;
            dontAssignEachRadio.Location = new Point(21, 84);
            dontAssignEachRadio.Margin = new Padding(4, 4, 4, 4);
            dontAssignEachRadio.Name = "dontAssignEachRadio";
            dontAssignEachRadio.Size = new Size(366, 34);
            dontAssignEachRadio.TabIndex = 1;
            dontAssignEachRadio.Text = "Ne minden hallgató kapjon munkát";
            dontAssignEachRadio.UseVisualStyleBackColor = true;
            // 
            // assignEachRadio
            // 
            assignEachRadio.AutoSize = true;
            assignEachRadio.Checked = true;
            assignEachRadio.Location = new Point(21, 39);
            assignEachRadio.Margin = new Padding(4, 4, 4, 4);
            assignEachRadio.Name = "assignEachRadio";
            assignEachRadio.Size = new Size(334, 34);
            assignEachRadio.TabIndex = 0;
            assignEachRadio.TabStop = true;
            assignEachRadio.Text = "Minden hallgató kapjon munkát";
            assignEachRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox4.Controls.Add(groupEnvynessRadio);
            groupBox4.Controls.Add(noGroupEnvynessRadio);
            groupBox4.Location = new Point(756, 1040);
            groupBox4.Margin = new Padding(4, 4, 4, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4, 4, 4, 4);
            groupBox4.Size = new Size(292, 141);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Irigység";
            // 
            // groupEnvynessRadio
            // 
            groupEnvynessRadio.AutoSize = true;
            groupEnvynessRadio.Location = new Point(21, 84);
            groupEnvynessRadio.Margin = new Padding(4, 4, 4, 4);
            groupEnvynessRadio.Name = "groupEnvynessRadio";
            groupEnvynessRadio.Size = new Size(208, 34);
            groupEnvynessRadio.TabIndex = 1;
            groupEnvynessRadio.Text = "Csoportos irigység";
            groupEnvynessRadio.UseVisualStyleBackColor = true;
            // 
            // noGroupEnvynessRadio
            // 
            noGroupEnvynessRadio.AutoSize = true;
            noGroupEnvynessRadio.Checked = true;
            noGroupEnvynessRadio.Location = new Point(21, 39);
            noGroupEnvynessRadio.Margin = new Padding(4, 4, 4, 4);
            noGroupEnvynessRadio.Name = "noGroupEnvynessRadio";
            noGroupEnvynessRadio.Size = new Size(165, 34);
            noGroupEnvynessRadio.TabIndex = 0;
            noGroupEnvynessRadio.TabStop = true;
            noGroupEnvynessRadio.Text = "Teljes irigység";
            noGroupEnvynessRadio.UseVisualStyleBackColor = true;
            // 
            // pairButton
            // 
            pairButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pairButton.Location = new Point(1449, 1040);
            pairButton.Margin = new Padding(4, 4, 4, 4);
            pairButton.Name = "pairButton";
            pairButton.Size = new Size(628, 141);
            pairButton.TabIndex = 3;
            pairButton.Text = "Párosítás";
            pairButton.UseVisualStyleBackColor = true;
            pairButton.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(9, 116);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(2068, 915);
            panel1.TabIndex = 4;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox5.Controls.Add(comboBox1);
            groupBox5.Location = new Point(1065, 1054);
            groupBox5.Margin = new Padding(4, 4, 4, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(4, 4, 4, 4);
            groupBox5.Size = new Size(375, 126);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "Solver típusa";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(45, 51);
            comboBox1.Margin = new Padding(4, 4, 4, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(290, 38);
            comboBox1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2096, 1198);
            Controls.Add(groupBox5);
            Controls.Add(panel1);
            Controls.Add(pairButton);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "MainForm";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton receiverRadio;
        private RadioButton applicantRadio;
        private GroupBox groupBox2;
        private RadioButton ReceiverOptimalRadio;
        private RadioButton applicantOptimalRadio;
        private GroupBox groupBox3;
        private RadioButton dontAssignEachRadio;
        private RadioButton assignEachRadio;
        private GroupBox groupBox4;
        private RadioButton groupEnvynessRadio;
        private RadioButton noGroupEnvynessRadio;
        private Button pairButton;
        private Panel panel1;
        private GroupBox groupBox5;
        private ComboBox comboBox1;
    }
}