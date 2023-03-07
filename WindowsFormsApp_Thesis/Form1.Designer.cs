namespace WindowsFormsApp_Thesis
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.radioButtonApplicantOptimal = new System.Windows.Forms.RadioButton();
            this.radioButtonReceiverOptimal = new System.Windows.Forms.RadioButton();
            this.radioButtonNoGroupEnvyness = new System.Windows.Forms.RadioButton();
            this.radioButtonGroupEnvyness = new System.Windows.Forms.RadioButton();
            this.radioButtonAssignAll = new System.Windows.Forms.RadioButton();
            this.radioButtonDontAssignAll = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButtonStudents = new System.Windows.Forms.RadioButton();
            this.radioButtonJobs = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButtonApplicantOptimal
            // 
            this.radioButtonApplicantOptimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonApplicantOptimal.AutoSize = true;
            this.radioButtonApplicantOptimal.Checked = true;
            this.radioButtonApplicantOptimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.radioButtonApplicantOptimal.Location = new System.Drawing.Point(6, 39);
            this.radioButtonApplicantOptimal.Name = "radioButtonApplicantOptimal";
            this.radioButtonApplicantOptimal.Size = new System.Drawing.Size(210, 29);
            this.radioButtonApplicantOptimal.TabIndex = 1;
            this.radioButtonApplicantOptimal.TabStop = true;
            this.radioButtonApplicantOptimal.Text = "Hallgató-kedvező";
            this.radioButtonApplicantOptimal.UseVisualStyleBackColor = true;
            // 
            // radioButtonReceiverOptimal
            // 
            this.radioButtonReceiverOptimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonReceiverOptimal.AutoSize = true;
            this.radioButtonReceiverOptimal.Location = new System.Drawing.Point(6, 74);
            this.radioButtonReceiverOptimal.Name = "radioButtonReceiverOptimal";
            this.radioButtonReceiverOptimal.Size = new System.Drawing.Size(236, 29);
            this.radioButtonReceiverOptimal.TabIndex = 2;
            this.radioButtonReceiverOptimal.TabStop = true;
            this.radioButtonReceiverOptimal.Text = "Munkahely-kedvező";
            this.radioButtonReceiverOptimal.UseVisualStyleBackColor = true;
            // 
            // radioButtonNoGroupEnvyness
            // 
            this.radioButtonNoGroupEnvyness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonNoGroupEnvyness.AutoSize = true;
            this.radioButtonNoGroupEnvyness.Location = new System.Drawing.Point(0, 74);
            this.radioButtonNoGroupEnvyness.Name = "radioButtonNoGroupEnvyness";
            this.radioButtonNoGroupEnvyness.Size = new System.Drawing.Size(183, 29);
            this.radioButtonNoGroupEnvyness.TabIndex = 4;
            this.radioButtonNoGroupEnvyness.Text = "Csoportonként";
            this.radioButtonNoGroupEnvyness.UseVisualStyleBackColor = true;
            // 
            // radioButtonGroupEnvyness
            // 
            this.radioButtonGroupEnvyness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonGroupEnvyness.AutoSize = true;
            this.radioButtonGroupEnvyness.Checked = true;
            this.radioButtonGroupEnvyness.Location = new System.Drawing.Point(0, 39);
            this.radioButtonGroupEnvyness.Name = "radioButtonGroupEnvyness";
            this.radioButtonGroupEnvyness.Size = new System.Drawing.Size(139, 29);
            this.radioButtonGroupEnvyness.TabIndex = 5;
            this.radioButtonGroupEnvyness.TabStop = true;
            this.radioButtonGroupEnvyness.Text = "Összesen";
            this.radioButtonGroupEnvyness.UseVisualStyleBackColor = true;
            // 
            // radioButtonAssignAll
            // 
            this.radioButtonAssignAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonAssignAll.AutoSize = true;
            this.radioButtonAssignAll.Checked = true;
            this.radioButtonAssignAll.Location = new System.Drawing.Point(6, 39);
            this.radioButtonAssignAll.Name = "radioButtonAssignAll";
            this.radioButtonAssignAll.Size = new System.Drawing.Size(245, 29);
            this.radioButtonAssignAll.TabIndex = 6;
            this.radioButtonAssignAll.TabStop = true;
            this.radioButtonAssignAll.Text = "Nem lehet pár nélküli";
            this.radioButtonAssignAll.UseVisualStyleBackColor = true;
            // 
            // radioButtonDontAssignAll
            // 
            this.radioButtonDontAssignAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonDontAssignAll.AutoSize = true;
            this.radioButtonDontAssignAll.Location = new System.Drawing.Point(6, 74);
            this.radioButtonDontAssignAll.Name = "radioButtonDontAssignAll";
            this.radioButtonDontAssignAll.Size = new System.Drawing.Size(202, 29);
            this.radioButtonDontAssignAll.TabIndex = 7;
            this.radioButtonDontAssignAll.Text = "Lehet pár nélküli";
            this.radioButtonDontAssignAll.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(842, 659);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(388, 118);
            this.button1.TabIndex = 10;
            this.button1.Text = "Párosítás";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButtonStudents
            // 
            this.radioButtonStudents.AutoSize = true;
            this.radioButtonStudents.Checked = true;
            this.radioButtonStudents.Location = new System.Drawing.Point(6, 29);
            this.radioButtonStudents.Name = "radioButtonStudents";
            this.radioButtonStudents.Size = new System.Drawing.Size(133, 29);
            this.radioButtonStudents.TabIndex = 11;
            this.radioButtonStudents.TabStop = true;
            this.radioButtonStudents.Text = "Hallgatók";
            this.radioButtonStudents.UseVisualStyleBackColor = true;
            // 
            // radioButtonJobs
            // 
            this.radioButtonJobs.AutoSize = true;
            this.radioButtonJobs.Location = new System.Drawing.Point(181, 29);
            this.radioButtonJobs.Name = "radioButtonJobs";
            this.radioButtonJobs.Size = new System.Drawing.Size(171, 29);
            this.radioButtonJobs.TabIndex = 12;
            this.radioButtonJobs.Text = "Munkahelyek";
            this.radioButtonJobs.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(964, 511);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 78);
            this.button2.TabIndex = 13;
            this.button2.Text = "Vissza";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.radioButtonApplicantOptimal);
            this.groupBox1.Controls.Add(this.radioButtonReceiverOptimal);
            this.groupBox1.Location = new System.Drawing.Point(18, 659);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 118);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kedvezőség";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.radioButtonNoGroupEnvyness);
            this.groupBox2.Controls.Add(this.radioButtonGroupEnvyness);
            this.groupBox2.Location = new System.Drawing.Point(301, 659);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 118);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Irigység";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.radioButtonAssignAll);
            this.groupBox3.Controls.Add(this.radioButtonDontAssignAll);
            this.groupBox3.Location = new System.Drawing.Point(520, 659);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 118);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pár nélküli hallgatók";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonStudents);
            this.groupBox4.Controls.Add(this.radioButtonJobs);
            this.groupBox4.Location = new System.Drawing.Point(18, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(358, 72);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(13, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 414);
            this.panel1.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 789);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.RadioButton radioButtonApplicantOptimal;
        private System.Windows.Forms.RadioButton radioButtonReceiverOptimal;
        private System.Windows.Forms.RadioButton radioButtonNoGroupEnvyness;
        private System.Windows.Forms.RadioButton radioButtonGroupEnvyness;
        private System.Windows.Forms.RadioButton radioButtonAssignAll;
        private System.Windows.Forms.RadioButton radioButtonDontAssignAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonStudents;
        private System.Windows.Forms.RadioButton radioButtonJobs;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
    }
}

