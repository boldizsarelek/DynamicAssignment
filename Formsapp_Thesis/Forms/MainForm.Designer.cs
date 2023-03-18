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
            groupBox1.Location = new Point(6, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(954, 68);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lista";
            // 
            // receiverRadio
            // 
            receiverRadio.AutoSize = true;
            receiverRadio.Location = new Point(115, 26);
            receiverRadio.Name = "receiverRadio";
            receiverRadio.Size = new Size(116, 24);
            receiverRadio.TabIndex = 1;
            receiverRadio.Text = "Munkahelyek";
            receiverRadio.UseVisualStyleBackColor = true;
            // 
            // applicantRadio
            // 
            applicantRadio.AutoSize = true;
            applicantRadio.Checked = true;
            applicantRadio.Location = new Point(14, 26);
            applicantRadio.Name = "applicantRadio";
            applicantRadio.Size = new Size(95, 24);
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
            groupBox2.Location = new Point(6, 693);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(198, 94);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Optimalizálás";
            // 
            // ReceiverOptimalRadio
            // 
            ReceiverOptimalRadio.AutoSize = true;
            ReceiverOptimalRadio.Location = new Point(14, 56);
            ReceiverOptimalRadio.Name = "ReceiverOptimalRadio";
            ReceiverOptimalRadio.Size = new Size(169, 24);
            ReceiverOptimalRadio.TabIndex = 1;
            ReceiverOptimalRadio.Text = "Munkahely-optimális";
            ReceiverOptimalRadio.UseVisualStyleBackColor = true;
            // 
            // applicantOptimalRadio
            // 
            applicantOptimalRadio.AutoSize = true;
            applicantOptimalRadio.Checked = true;
            applicantOptimalRadio.Location = new Point(14, 26);
            applicantOptimalRadio.Name = "applicantOptimalRadio";
            applicantOptimalRadio.Size = new Size(143, 24);
            applicantOptimalRadio.TabIndex = 0;
            applicantOptimalRadio.TabStop = true;
            applicantOptimalRadio.Text = "Hallgó-optimális";
            applicantOptimalRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox3.Controls.Add(dontAssignEachRadio);
            groupBox3.Controls.Add(assignEachRadio);
            groupBox3.Location = new Point(210, 693);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(288, 94);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Hozzárendelés";
            // 
            // dontAssignEachRadio
            // 
            dontAssignEachRadio.AutoSize = true;
            dontAssignEachRadio.Location = new Point(14, 56);
            dontAssignEachRadio.Name = "dontAssignEachRadio";
            dontAssignEachRadio.Size = new Size(264, 24);
            dontAssignEachRadio.TabIndex = 1;
            dontAssignEachRadio.Text = "Ne minden hallgató kapjon munkát";
            dontAssignEachRadio.UseVisualStyleBackColor = true;
            // 
            // assignEachRadio
            // 
            assignEachRadio.AutoSize = true;
            assignEachRadio.Checked = true;
            assignEachRadio.Location = new Point(14, 26);
            assignEachRadio.Name = "assignEachRadio";
            assignEachRadio.Size = new Size(241, 24);
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
            groupBox4.Location = new Point(504, 693);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(195, 94);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Irigység";
            // 
            // groupEnvynessRadio
            // 
            groupEnvynessRadio.AutoSize = true;
            groupEnvynessRadio.Location = new Point(14, 56);
            groupEnvynessRadio.Name = "groupEnvynessRadio";
            groupEnvynessRadio.Size = new Size(153, 24);
            groupEnvynessRadio.TabIndex = 1;
            groupEnvynessRadio.Text = "Homogén irigység";
            groupEnvynessRadio.UseVisualStyleBackColor = true;
            // 
            // noGroupEnvynessRadio
            // 
            noGroupEnvynessRadio.AutoSize = true;
            noGroupEnvynessRadio.Checked = true;
            noGroupEnvynessRadio.Location = new Point(14, 26);
            noGroupEnvynessRadio.Name = "noGroupEnvynessRadio";
            noGroupEnvynessRadio.Size = new Size(157, 24);
            noGroupEnvynessRadio.TabIndex = 0;
            noGroupEnvynessRadio.TabStop = true;
            noGroupEnvynessRadio.Text = "Heterogén irigység";
            noGroupEnvynessRadio.UseVisualStyleBackColor = true;
            // 
            // pairButton
            // 
            pairButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pairButton.Location = new Point(966, 693);
            pairButton.Name = "pairButton";
            pairButton.Size = new Size(419, 94);
            pairButton.TabIndex = 3;
            pairButton.Text = "Párosítás";
            pairButton.UseVisualStyleBackColor = true;
            pairButton.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(6, 77);
            panel1.Name = "panel1";
            panel1.Size = new Size(1379, 610);
            panel1.TabIndex = 4;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox5.Controls.Add(comboBox1);
            groupBox5.Location = new Point(710, 703);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(250, 84);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "Solver típusa";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(30, 34);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(195, 28);
            comboBox1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1397, 799);
            Controls.Add(groupBox5);
            Controls.Add(panel1);
            Controls.Add(pairButton);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
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