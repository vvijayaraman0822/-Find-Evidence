namespace ScanAnalyzers
{
    partial class HubForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HubForm));
            this.EvidenceCollectionButton = new System.Windows.Forms.Button();
            this.InstructionsTextBox = new System.Windows.Forms.TextBox();
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.evidenceGroupBox = new System.Windows.Forms.GroupBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.bloodAnalyzerRadioButton = new System.Windows.Forms.RadioButton();
            this.dnaAnalyzerRadioButton = new System.Windows.Forms.RadioButton();
            this.fiberAnalyzerRadioButton = new System.Windows.Forms.RadioButton();
            this.fingerprintRadioButton = new System.Windows.Forms.RadioButton();
            this.evidenceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EvidenceCollectionButton
            // 
            this.EvidenceCollectionButton.Location = new System.Drawing.Point(49, 64);
            this.EvidenceCollectionButton.Name = "EvidenceCollectionButton";
            this.EvidenceCollectionButton.Size = new System.Drawing.Size(155, 27);
            this.EvidenceCollectionButton.TabIndex = 3;
            this.EvidenceCollectionButton.Text = "Evidence Collection";
            this.EvidenceCollectionButton.UseVisualStyleBackColor = true;
            this.EvidenceCollectionButton.Click += new System.EventHandler(this.EvidenceCollectionButton_Click);
            // 
            // InstructionsTextBox
            // 
            this.InstructionsTextBox.BackColor = System.Drawing.Color.PowderBlue;
            this.InstructionsTextBox.Location = new System.Drawing.Point(419, 47);
            this.InstructionsTextBox.Multiline = true;
            this.InstructionsTextBox.Name = "InstructionsTextBox";
            this.InstructionsTextBox.Size = new System.Drawing.Size(241, 260);
            this.InstructionsTextBox.TabIndex = 4;
            this.InstructionsTextBox.Text = resources.GetString("InstructionsTextBox.Text");
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Location = new System.Drawing.Point(446, 18);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(167, 15);
            this.InstructionLabel.TabIndex = 5;
            this.InstructionLabel.Text = "Instructions to play the game!";
            // 
            // evidenceGroupBox
            // 
            this.evidenceGroupBox.BackColor = System.Drawing.Color.PowderBlue;
            this.evidenceGroupBox.Controls.Add(this.enterButton);
            this.evidenceGroupBox.Controls.Add(this.bloodAnalyzerRadioButton);
            this.evidenceGroupBox.Controls.Add(this.dnaAnalyzerRadioButton);
            this.evidenceGroupBox.Controls.Add(this.fiberAnalyzerRadioButton);
            this.evidenceGroupBox.Controls.Add(this.fingerprintRadioButton);
            this.evidenceGroupBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evidenceGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.evidenceGroupBox.Location = new System.Drawing.Point(33, 158);
            this.evidenceGroupBox.Name = "evidenceGroupBox";
            this.evidenceGroupBox.Size = new System.Drawing.Size(200, 225);
            this.evidenceGroupBox.TabIndex = 7;
            this.evidenceGroupBox.TabStop = false;
            this.evidenceGroupBox.Text = "Types of Evidence";
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(108, 199);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(75, 23);
            this.enterButton.TabIndex = 4;
            this.enterButton.Text = "ENTER";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // bloodAnalyzerRadioButton
            // 
            this.bloodAnalyzerRadioButton.AutoSize = true;
            this.bloodAnalyzerRadioButton.Location = new System.Drawing.Point(16, 173);
            this.bloodAnalyzerRadioButton.Name = "bloodAnalyzerRadioButton";
            this.bloodAnalyzerRadioButton.Size = new System.Drawing.Size(112, 20);
            this.bloodAnalyzerRadioButton.TabIndex = 3;
            this.bloodAnalyzerRadioButton.TabStop = true;
            this.bloodAnalyzerRadioButton.Text = "Blood Analyzer";
            this.bloodAnalyzerRadioButton.UseVisualStyleBackColor = true;
            // 
            // dnaAnalyzerRadioButton
            // 
            this.dnaAnalyzerRadioButton.AutoSize = true;
            this.dnaAnalyzerRadioButton.Location = new System.Drawing.Point(16, 129);
            this.dnaAnalyzerRadioButton.Name = "dnaAnalyzerRadioButton";
            this.dnaAnalyzerRadioButton.Size = new System.Drawing.Size(106, 20);
            this.dnaAnalyzerRadioButton.TabIndex = 2;
            this.dnaAnalyzerRadioButton.TabStop = true;
            this.dnaAnalyzerRadioButton.Text = "DNA Analyzer";
            this.dnaAnalyzerRadioButton.UseVisualStyleBackColor = true;
            // 
            // fiberAnalyzerRadioButton
            // 
            this.fiberAnalyzerRadioButton.AutoSize = true;
            this.fiberAnalyzerRadioButton.Location = new System.Drawing.Point(16, 86);
            this.fiberAnalyzerRadioButton.Name = "fiberAnalyzerRadioButton";
            this.fiberAnalyzerRadioButton.Size = new System.Drawing.Size(109, 20);
            this.fiberAnalyzerRadioButton.TabIndex = 1;
            this.fiberAnalyzerRadioButton.TabStop = true;
            this.fiberAnalyzerRadioButton.Text = "Fiber Analyzer";
            this.fiberAnalyzerRadioButton.UseVisualStyleBackColor = true;
            // 
            // fingerprintRadioButton
            // 
            this.fingerprintRadioButton.AutoSize = true;
            this.fingerprintRadioButton.Location = new System.Drawing.Point(16, 44);
            this.fingerprintRadioButton.Name = "fingerprintRadioButton";
            this.fingerprintRadioButton.Size = new System.Drawing.Size(145, 20);
            this.fingerprintRadioButton.TabIndex = 0;
            this.fingerprintRadioButton.TabStop = true;
            this.fingerprintRadioButton.Text = "Finger Print Analyzer";
            this.fingerprintRadioButton.UseVisualStyleBackColor = true;
            // 
            // HubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(717, 407);
            this.Controls.Add(this.evidenceGroupBox);
            this.Controls.Add(this.InstructionLabel);
            this.Controls.Add(this.InstructionsTextBox);
            this.Controls.Add(this.EvidenceCollectionButton);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "HubForm";
            this.Text = "HubForm";
            this.evidenceGroupBox.ResumeLayout(false);
            this.evidenceGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button EvidenceCollectionButton;
        private System.Windows.Forms.TextBox InstructionsTextBox;
        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.GroupBox evidenceGroupBox;
        private System.Windows.Forms.RadioButton bloodAnalyzerRadioButton;
        private System.Windows.Forms.RadioButton dnaAnalyzerRadioButton;
        private System.Windows.Forms.RadioButton fiberAnalyzerRadioButton;
        private System.Windows.Forms.RadioButton fingerprintRadioButton;
        private System.Windows.Forms.Button enterButton;
    }
}