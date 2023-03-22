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
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(10, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(1151, 524);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(21, 623);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 2;
            label2.Text = "Párosítás státusza:";
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(225, 623);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(50, 20);
            statusLabel.TabIndex = 3;
            statusLabel.Text = "label3";
            // 
            // objectiveSumLabel
            // 
            objectiveSumLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            objectiveSumLabel.AutoSize = true;
            objectiveSumLabel.Location = new Point(225, 656);
            objectiveSumLabel.Name = "objectiveSumLabel";
            objectiveSumLabel.Size = new Size(50, 20);
            objectiveSumLabel.TabIndex = 5;
            objectiveSumLabel.Text = "label4";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(21, 656);
            label5.Name = "label5";
            label5.Size = new Size(139, 20);
            label5.TabIndex = 4;
            label5.Text = "Célfüggvény értéke:";
            // 
            // blockingPairsLabel
            // 
            blockingPairsLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            blockingPairsLabel.AutoSize = true;
            blockingPairsLabel.Location = new Point(225, 692);
            blockingPairsLabel.Name = "blockingPairsLabel";
            blockingPairsLabel.Size = new Size(50, 20);
            blockingPairsLabel.TabIndex = 7;
            blockingPairsLabel.Text = "label6";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(21, 692);
            label7.Name = "label7";
            label7.Size = new Size(196, 20);
            label7.TabIndex = 6;
            label7.Text = "Blokkoló párosítások száma:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(1015, 623);
            button1.Name = "button1";
            button1.Size = new Size(146, 89);
            button1.TabIndex = 8;
            button1.Text = "CSV exportálása";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(871, 626);
            button2.Name = "button2";
            button2.Size = new Size(138, 86);
            button2.TabIndex = 9;
            button2.Text = "Lp file másolása vágólapra";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(blockingPairsRadio);
            groupBox1.Controls.Add(pairsRadio);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(263, 62);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Párosítás";
            // 
            // blockingPairsRadio
            // 
            blockingPairsRadio.AutoSize = true;
            blockingPairsRadio.Location = new Point(119, 26);
            blockingPairsRadio.Name = "blockingPairsRadio";
            blockingPairsRadio.Size = new Size(130, 24);
            blockingPairsRadio.TabIndex = 1;
            blockingPairsRadio.Text = "Blokkoló párok";
            blockingPairsRadio.UseVisualStyleBackColor = true;
            
            // 
            // pairsRadio
            // 
            pairsRadio.AutoSize = true;
            pairsRadio.Checked = true;
            pairsRadio.Location = new Point(9, 26);
            pairsRadio.Name = "pairsRadio";
            pairsRadio.Size = new Size(104, 24);
            pairsRadio.TabIndex = 0;
            pairsRadio.TabStop = true;
            pairsRadio.Text = "Párosítások";
            pairsRadio.UseVisualStyleBackColor = true;
            
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 721);
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
    }
}