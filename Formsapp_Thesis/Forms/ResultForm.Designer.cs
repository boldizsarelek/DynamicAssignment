namespace Formsapp_Thesis
{
    partial class ResultForm
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
            panel1 = new Panel();
            label2 = new Label();
            statusLabel = new Label();
            objectiveSumLabel = new Label();
            label5 = new Label();
            blockingPairsLabel = new Label();
            label7 = new Label();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            blockingPairsRadio = new RadioButton();
            pairsRadio = new RadioButton();
            label4 = new Label();
            wallTimeLabel = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(15, 120);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1726, 786);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(32, 934);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(182, 30);
            label2.TabIndex = 2;
            label2.Text = "Párosítás státusza:";
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(338, 934);
            statusLabel.Margin = new Padding(4, 0, 4, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(68, 30);
            statusLabel.TabIndex = 3;
            statusLabel.Text = "label3";
            // 
            // objectiveSumLabel
            // 
            objectiveSumLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            objectiveSumLabel.AutoSize = true;
            objectiveSumLabel.Location = new Point(338, 984);
            objectiveSumLabel.Margin = new Padding(4, 0, 4, 0);
            objectiveSumLabel.Name = "objectiveSumLabel";
            objectiveSumLabel.Size = new Size(68, 30);
            objectiveSumLabel.TabIndex = 5;
            objectiveSumLabel.Text = "label4";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(32, 984);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(196, 30);
            label5.TabIndex = 4;
            label5.Text = "Célfüggvény értéke:";
            // 
            // blockingPairsLabel
            // 
            blockingPairsLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            blockingPairsLabel.AutoSize = true;
            blockingPairsLabel.Location = new Point(338, 1038);
            blockingPairsLabel.Margin = new Padding(4, 0, 4, 0);
            blockingPairsLabel.Name = "blockingPairsLabel";
            blockingPairsLabel.Size = new Size(68, 30);
            blockingPairsLabel.TabIndex = 7;
            blockingPairsLabel.Text = "label6";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(32, 1038);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(272, 30);
            label7.TabIndex = 6;
            label7.Text = "Blokkoló párosítások száma:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(1522, 934);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(219, 134);
            button1.TabIndex = 8;
            button1.Text = "CSV exportálása";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(1306, 939);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(207, 129);
            button2.TabIndex = 9;
            button2.Text = "Lp file másolása vágólapra";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(blockingPairsRadio);
            groupBox1.Controls.Add(pairsRadio);
            groupBox1.Location = new Point(18, 18);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(394, 93);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Párosítás";
            // 
            // blockingPairsRadio
            // 
            blockingPairsRadio.AutoSize = true;
            blockingPairsRadio.Location = new Point(178, 39);
            blockingPairsRadio.Margin = new Padding(4);
            blockingPairsRadio.Name = "blockingPairsRadio";
            blockingPairsRadio.Size = new Size(174, 34);
            blockingPairsRadio.TabIndex = 1;
            blockingPairsRadio.Text = "Blokkoló párok";
            blockingPairsRadio.UseVisualStyleBackColor = true;
            // 
            // pairsRadio
            // 
            pairsRadio.AutoSize = true;
            pairsRadio.Checked = true;
            pairsRadio.Location = new Point(14, 39);
            pairsRadio.Margin = new Padding(4);
            pairsRadio.Name = "pairsRadio";
            pairsRadio.Size = new Size(142, 34);
            pairsRadio.TabIndex = 0;
            pairsRadio.TabStop = true;
            pairsRadio.Text = "Párosítások";
            pairsRadio.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(483, 934);
            label4.Name = "label4";
            label4.Size = new Size(149, 30);
            label4.TabIndex = 11;
            label4.Text = "Megoldási idő:";
            // 
            // wallTimeLabel
            // 
            wallTimeLabel.AutoSize = true;
            wallTimeLabel.Location = new Point(696, 934);
            wallTimeLabel.Name = "wallTimeLabel";
            wallTimeLabel.Size = new Size(68, 30);
            wallTimeLabel.TabIndex = 12;
            wallTimeLabel.Text = "label3";
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1760, 1082);
            Controls.Add(wallTimeLabel);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(blockingPairsLabel);
            Controls.Add(label7);
            Controls.Add(objectiveSumLabel);
            Controls.Add(label5);
            Controls.Add(statusLabel);
            Controls.Add(label2);
            Controls.Add(panel1);
            Margin = new Padding(4);
            Name = "ResultForm";
            Text = "Form2";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label statusLabel;
        private Label objectiveSumLabel;
        private Label label5;
        private Label blockingPairsLabel;
        private Label label7;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
        private RadioButton blockingPairsRadio;
        private RadioButton pairsRadio;
        private Label label4;
        private Label wallTimeLabel;
    }
}