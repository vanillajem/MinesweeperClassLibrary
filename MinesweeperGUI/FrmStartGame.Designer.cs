namespace MinesweeperGUI
{
    partial class FrmStartGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStartGame));
            btnPlay = new Button();
            lblTitle = new Label();
            lblInstructions = new Label();
            lblSizeText = new Label();
            trkSize = new TrackBar();
            lblSizeValue = new Label();
            grpDifficulty = new GroupBox();
            rdoHard = new RadioButton();
            rdoMedium = new RadioButton();
            rdoEasy = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)trkSize).BeginInit();
            grpDifficulty.SuspendLayout();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.Black;
            btnPlay.FlatStyle = FlatStyle.Popup;
            btnPlay.ForeColor = Color.Yellow;
            btnPlay.Location = new Point(450, 391);
            btnPlay.Margin = new Padding(5, 4, 5, 4);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(185, 70);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Black;
            lblTitle.Font = new Font("Gill Sans Ultra Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Yellow;
            lblTitle.Location = new Point(355, 22);
            lblTitle.Margin = new Padding(5, 0, 5, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(424, 50);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Play Minesweeper";
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.BackColor = Color.Black;
            lblInstructions.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInstructions.ForeColor = Color.Yellow;
            lblInstructions.Location = new Point(240, 326);
            lblInstructions.Margin = new Padding(5, 0, 5, 0);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(623, 44);
            lblInstructions.TabIndex = 2;
            lblInstructions.Text = "Click Play to start the game !";
            // 
            // lblSizeText
            // 
            lblSizeText.BackColor = Color.Black;
            lblSizeText.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold);
            lblSizeText.ForeColor = Color.Yellow;
            lblSizeText.Location = new Point(44, 147);
            lblSizeText.Margin = new Padding(5, 0, 5, 0);
            lblSizeText.Name = "lblSizeText";
            lblSizeText.Size = new Size(239, 40);
            lblSizeText.TabIndex = 3;
            lblSizeText.Text = "Board Size";
            // 
            // trkSize
            // 
            trkSize.AccessibleRole = AccessibleRole.Alert;
            trkSize.BackColor = Color.Black;
            trkSize.Cursor = Cursors.NoMove2D;
            trkSize.Location = new Point(44, 191);
            trkSize.Margin = new Padding(5, 4, 5, 4);
            trkSize.Maximum = 20;
            trkSize.Minimum = 5;
            trkSize.Name = "trkSize";
            trkSize.Size = new Size(495, 69);
            trkSize.TabIndex = 4;
            trkSize.Value = 10;
            trkSize.Scroll += trkSize_Scroll;
            // 
            // lblSizeValue
            // 
            lblSizeValue.BackColor = Color.Black;
            lblSizeValue.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold);
            lblSizeValue.ForeColor = Color.Yellow;
            lblSizeValue.Location = new Point(311, 147);
            lblSizeValue.Margin = new Padding(5, 0, 5, 0);
            lblSizeValue.Name = "lblSizeValue";
            lblSizeValue.Size = new Size(65, 40);
            lblSizeValue.TabIndex = 5;
            lblSizeValue.Text = "10";
            // 
            // grpDifficulty
            // 
            grpDifficulty.BackColor = Color.Black;
            grpDifficulty.Controls.Add(rdoHard);
            grpDifficulty.Controls.Add(rdoMedium);
            grpDifficulty.Controls.Add(rdoEasy);
            grpDifficulty.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDifficulty.ForeColor = Color.Yellow;
            grpDifficulty.Location = new Point(694, 113);
            grpDifficulty.Margin = new Padding(5, 4, 5, 4);
            grpDifficulty.Name = "grpDifficulty";
            grpDifficulty.Padding = new Padding(5, 4, 5, 4);
            grpDifficulty.Size = new Size(510, 180);
            grpDifficulty.TabIndex = 6;
            grpDifficulty.TabStop = false;
            grpDifficulty.Text = "Difficulty";
            // 
            // rdoHard
            // 
            rdoHard.AutoSize = true;
            rdoHard.Location = new Point(10, 120);
            rdoHard.Margin = new Padding(5, 4, 5, 4);
            rdoHard.Name = "rdoHard";
            rdoHard.Size = new Size(149, 48);
            rdoHard.TabIndex = 2;
            rdoHard.TabStop = true;
            rdoHard.Text = "Hard";
            rdoHard.UseVisualStyleBackColor = true;
            // 
            // rdoMedium
            // 
            rdoMedium.AutoSize = true;
            rdoMedium.Location = new Point(10, 78);
            rdoMedium.Margin = new Padding(5, 4, 5, 4);
            rdoMedium.Name = "rdoMedium";
            rdoMedium.Size = new Size(192, 48);
            rdoMedium.TabIndex = 1;
            rdoMedium.TabStop = true;
            rdoMedium.Text = "Medium";
            rdoMedium.UseVisualStyleBackColor = true;
            // 
            // rdoEasy
            // 
            rdoEasy.AutoSize = true;
            rdoEasy.Location = new Point(10, 38);
            rdoEasy.Margin = new Padding(5, 4, 5, 4);
            rdoEasy.Name = "rdoEasy";
            rdoEasy.Size = new Size(134, 48);
            rdoEasy.TabIndex = 0;
            rdoEasy.TabStop = true;
            rdoEasy.Text = "Easy";
            rdoEasy.UseVisualStyleBackColor = true;
            // 
            // FrmStartGame
            // 
            AutoScaleDimensions = new SizeF(17F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Background1;
            ClientSize = new Size(1281, 609);
            Controls.Add(grpDifficulty);
            Controls.Add(lblSizeValue);
            Controls.Add(trkSize);
            Controls.Add(lblSizeText);
            Controls.Add(lblInstructions);
            Controls.Add(lblTitle);
            Controls.Add(btnPlay);
            Cursor = Cursors.NoMove2D;
            Font = new Font("Showcard Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            Name = "FrmStartGame";
            Text = "Start Game";
            ((System.ComponentModel.ISupportInitialize)trkSize).EndInit();
            grpDifficulty.ResumeLayout(false);
            grpDifficulty.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlay;
        private Label lblTitle;
        private Label lblInstructions;
        private Label lblSizeText;
        private TrackBar trkSize;
        private Label lblSizeValue;
        private GroupBox grpDifficulty;
        private RadioButton rdoHard;
        private RadioButton rdoMedium;
        private RadioButton rdoEasy;
    }
}