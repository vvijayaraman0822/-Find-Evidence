namespace ScanAnalyzers
{
    partial class FindSampleGame
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
            this.SubGuessButton = new System.Windows.Forms.Button();
            this.guessLabel = new System.Windows.Forms.Label();
            this.guessTextBoxRows = new System.Windows.Forms.TextBox();
            this.labelRow = new System.Windows.Forms.Label();
            this.labelColumn = new System.Windows.Forms.Label();
            this.guessTextBoxColumn = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.ColumnsLabel = new System.Windows.Forms.Label();
            this.RowsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SubGuessButton
            // 
            this.SubGuessButton.Location = new System.Drawing.Point(453, 163);
            this.SubGuessButton.Name = "SubGuessButton";
            this.SubGuessButton.Size = new System.Drawing.Size(141, 27);
            this.SubGuessButton.TabIndex = 1;
            this.SubGuessButton.Text = "Submit Guess";
            this.SubGuessButton.UseVisualStyleBackColor = true;
            this.SubGuessButton.Click += new System.EventHandler(this.SubGuessButton_Click);
            // 
            // guessLabel
            // 
            this.guessLabel.AutoSize = true;
            this.guessLabel.Location = new System.Drawing.Point(276, 114);
            this.guessLabel.Name = "guessLabel";
            this.guessLabel.Size = new System.Drawing.Size(85, 15);
            this.guessLabel.TabIndex = 3;
            this.guessLabel.Text = "Enter a Guess?";
            // 
            // guessTextBoxRows
            // 
            this.guessTextBoxRows.Location = new System.Drawing.Point(402, 105);
            this.guessTextBoxRows.Name = "guessTextBoxRows";
            this.guessTextBoxRows.Size = new System.Drawing.Size(67, 24);
            this.guessTextBoxRows.TabIndex = 4;
            // 
            // labelRow
            // 
            this.labelRow.AutoSize = true;
            this.labelRow.Location = new System.Drawing.Point(420, 47);
            this.labelRow.Name = "labelRow";
            this.labelRow.Size = new System.Drawing.Size(29, 15);
            this.labelRow.TabIndex = 6;
            this.labelRow.Text = "Row";
            // 
            // labelColumn
            // 
            this.labelColumn.AutoSize = true;
            this.labelColumn.Location = new System.Drawing.Point(566, 47);
            this.labelColumn.Name = "labelColumn";
            this.labelColumn.Size = new System.Drawing.Size(50, 15);
            this.labelColumn.TabIndex = 7;
            this.labelColumn.Text = "Column";
            // 
            // guessTextBoxColumn
            // 
            this.guessTextBoxColumn.Location = new System.Drawing.Point(559, 105);
            this.guessTextBoxColumn.Name = "guessTextBoxColumn";
            this.guessTextBoxColumn.Size = new System.Drawing.Size(73, 24);
            this.guessTextBoxColumn.TabIndex = 9;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(472, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(39, 15);
            this.TitleLabel.TabIndex = 10;
            this.TitleLabel.Text = "label1";
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(317, 165);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 11;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // LogoPictureBox
            // 
            //this.LogoPictureBox.Image = global::ScanAnalyzers.Properties.Resources.MagniGlass;
            this.LogoPictureBox.Location = new System.Drawing.Point(0, -2);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(238, 131);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPictureBox.TabIndex = 12;
            this.LogoPictureBox.TabStop = false;
            // 
            // ColumnsLabel
            // 
            this.ColumnsLabel.AutoSize = true;
            this.ColumnsLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnsLabel.Location = new System.Drawing.Point(225, 205);
            this.ColumnsLabel.Name = "ColumnsLabel";
            this.ColumnsLabel.Size = new System.Drawing.Size(58, 20);
            this.ColumnsLabel.TabIndex = 13;
            this.ColumnsLabel.Text = "label1";
            // 
            // RowsLabel
            // 
            this.RowsLabel.AutoSize = true;
            this.RowsLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RowsLabel.Location = new System.Drawing.Point(205, 225);
            this.RowsLabel.Name = "RowsLabel";
            this.RowsLabel.Size = new System.Drawing.Size(58, 20);
            this.RowsLabel.TabIndex = 14;
            this.RowsLabel.Text = "label2";
            // 
            // FindSampleGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(717, 485);
            this.Controls.Add(this.RowsLabel);
            this.Controls.Add(this.ColumnsLabel);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.guessTextBoxColumn);
            this.Controls.Add(this.labelColumn);
            this.Controls.Add(this.labelRow);
            this.Controls.Add(this.guessTextBoxRows);
            this.Controls.Add(this.guessLabel);
            this.Controls.Add(this.SubGuessButton);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FindSampleGame";
            this.Text = "ScanAnalyzer";
            this.Shown += new System.EventHandler(this.FindSampleGame_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SubGuessButton;
        private System.Windows.Forms.Label guessLabel;
        private System.Windows.Forms.TextBox guessTextBoxRows;
        private System.Windows.Forms.Label labelRow;
        private System.Windows.Forms.Label labelColumn;
        private System.Windows.Forms.TextBox guessTextBoxColumn;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Label ColumnsLabel;
        private System.Windows.Forms.Label RowsLabel;
    }
}

