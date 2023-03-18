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
            label1 = new Label();
            label2 = new Label();
            statusLabel = new Label();
            objectiveSumLabel = new Label();
            label5 = new Label();
            blockingPairsLabel = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(10, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(778, 295);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 6);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 1;
            label1.Text = "Párosítások";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(21, 352);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 2;
            label2.Text = "Párosítás státusza:";
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(225, 352);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(50, 20);
            statusLabel.TabIndex = 3;
            statusLabel.Text = "label3";
            // 
            // objectiveSumLabel
            // 
            objectiveSumLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            objectiveSumLabel.AutoSize = true;
            objectiveSumLabel.Location = new Point(225, 385);
            objectiveSumLabel.Name = "objectiveSumLabel";
            objectiveSumLabel.Size = new Size(50, 20);
            objectiveSumLabel.TabIndex = 5;
            objectiveSumLabel.Text = "label4";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(21, 385);
            label5.Name = "label5";
            label5.Size = new Size(139, 20);
            label5.TabIndex = 4;
            label5.Text = "Célfüggvény értéke:";
            // 
            // blockingPairsLabel
            // 
            blockingPairsLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            blockingPairsLabel.AutoSize = true;
            blockingPairsLabel.Location = new Point(225, 421);
            blockingPairsLabel.Name = "blockingPairsLabel";
            blockingPairsLabel.Size = new Size(50, 20);
            blockingPairsLabel.TabIndex = 7;
            blockingPairsLabel.Text = "label6";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(21, 421);
            label7.Name = "label7";
            label7.Size = new Size(196, 20);
            label7.TabIndex = 6;
            label7.Text = "Blokkoló párosítások száma:";
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(blockingPairsLabel);
            Controls.Add(label7);
            Controls.Add(objectiveSumLabel);
            Controls.Add(label5);
            Controls.Add(statusLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "ResultForm";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label statusLabel;
        private Label objectiveSumLabel;
        private Label label5;
        private Label blockingPairsLabel;
        private Label label7;
    }
}