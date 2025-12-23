namespace MinesweeperGUI
{
    partial class FrmGameForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGameForm));
            pnlBoard = new Panel();
            lblStatus = new Label();
            btnRestart = new Button();
            lblScoreText = new Label();
            lblScoreValue = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            lblTimeValue = new Label();
            lblTimeText = new Label();
            SuspendLayout();
            // 
            // pnlBoard
            // 
            pnlBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBoard.BackColor = Color.Transparent;
            pnlBoard.BorderStyle = BorderStyle.FixedSingle;
            pnlBoard.Font = new Font("Showcard Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlBoard.Location = new Point(26, 18);
            pnlBoard.Margin = new Padding(4, 3, 4, 3);
            pnlBoard.Name = "pnlBoard";
            pnlBoard.Size = new Size(874, 941);
            pnlBoard.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Black;
            lblStatus.Font = new Font("Showcard Gothic", 18F);
            lblStatus.ForeColor = Color.Yellow;
            lblStatus.Location = new Point(1021, 18);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(393, 44);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status: In Progress";
            // 
            // btnRestart
            // 
            btnRestart.BackColor = Color.Black;
            btnRestart.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold);
            btnRestart.ForeColor = Color.Yellow;
            btnRestart.Location = new Point(1303, 361);
            btnRestart.Margin = new Padding(4, 3, 4, 3);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(293, 69);
            btnRestart.TabIndex = 1;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = false;
            // 
            // lblScoreText
            // 
            lblScoreText.AutoSize = true;
            lblScoreText.BackColor = Color.Black;
            lblScoreText.Font = new Font("Showcard Gothic", 18F);
            lblScoreText.ForeColor = Color.Yellow;
            lblScoreText.Location = new Point(1021, 76);
            lblScoreText.Margin = new Padding(4, 0, 4, 0);
            lblScoreText.Name = "lblScoreText";
            lblScoreText.Size = new Size(148, 44);
            lblScoreText.TabIndex = 2;
            lblScoreText.Text = "Score :";
            // 
            // lblScoreValue
            // 
            lblScoreValue.AutoSize = true;
            lblScoreValue.BackColor = Color.Black;
            lblScoreValue.Font = new Font("Showcard Gothic", 18F);
            lblScoreValue.ForeColor = Color.Yellow;
            lblScoreValue.Location = new Point(1193, 76);
            lblScoreValue.Margin = new Padding(4, 0, 4, 0);
            lblScoreValue.Name = "lblScoreValue";
            lblScoreValue.Size = new Size(40, 44);
            lblScoreValue.TabIndex = 3;
            lblScoreValue.Text = "0";
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // lblTimeValue
            // 
            lblTimeValue.AutoSize = true;
            lblTimeValue.BackColor = Color.Black;
            lblTimeValue.Font = new Font("Showcard Gothic", 18F);
            lblTimeValue.ForeColor = Color.Yellow;
            lblTimeValue.Location = new Point(1193, 155);
            lblTimeValue.Margin = new Padding(4, 0, 4, 0);
            lblTimeValue.Name = "lblTimeValue";
            lblTimeValue.Size = new Size(40, 44);
            lblTimeValue.TabIndex = 4;
            lblTimeValue.Text = "0";
            // 
            // lblTimeText
            // 
            lblTimeText.AutoSize = true;
            lblTimeText.BackColor = Color.Black;
            lblTimeText.Font = new Font("Showcard Gothic", 18F);
            lblTimeText.ForeColor = Color.Yellow;
            lblTimeText.Location = new Point(1021, 155);
            lblTimeText.Margin = new Padding(4, 0, 4, 0);
            lblTimeText.Name = "lblTimeText";
            lblTimeText.Size = new Size(123, 44);
            lblTimeText.TabIndex = 5;
            lblTimeText.Text = "Time :";
            // 
            // FrmGameForm
            // 
            AutoScaleDimensions = new SizeF(13F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1625, 971);
            Controls.Add(lblTimeText);
            Controls.Add(lblTimeValue);
            Controls.Add(lblScoreValue);
            Controls.Add(lblScoreText);
            Controls.Add(btnRestart);
            Controls.Add(lblStatus);
            Controls.Add(pnlBoard);
            Cursor = Cursors.NoMove2D;
            DoubleBuffered = true;
            Font = new Font("Showcard Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmGameForm";
            Text = "MINESWEEPER";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlBoard;
        private Label lblStatus;
        private Button btnRestart;
        private Label lblScoreText;
        private Label lblScoreValue;
        private System.Windows.Forms.Timer gameTimer;
        private Label lblTimeValue;
        private Label lblTimeText;
    }
}
