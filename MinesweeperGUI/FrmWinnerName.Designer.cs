namespace MinesweeperGUI
{
    partial class FrmWinnerName
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
            lblName = new Label();
            lblScoreValue = new Label();
            label2 = new Label();
            txtName = new TextBox();
            btnOk = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Black;
            lblName.Font = new Font("Gill Sans Ultra Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.Yellow;
            lblName.Location = new Point(45, 53);
            lblName.Margin = new Padding(5, 0, 5, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(986, 50);
            lblName.TabIndex = 2;
            lblName.Text = "Congratulations you win. Enter your name.";
            // 
            // lblScoreValue
            // 
            lblScoreValue.AutoSize = true;
            lblScoreValue.BackColor = Color.Black;
            lblScoreValue.Font = new Font("Gill Sans Ultra Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScoreValue.ForeColor = Color.Yellow;
            lblScoreValue.Location = new Point(512, 205);
            lblScoreValue.Margin = new Padding(5, 0, 5, 0);
            lblScoreValue.Name = "lblScoreValue";
            lblScoreValue.Size = new Size(53, 50);
            lblScoreValue.TabIndex = 3;
            lblScoreValue.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Gill Sans Ultra Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Yellow;
            label2.Location = new Point(304, 205);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(174, 50);
            label2.TabIndex = 4;
            label2.Text = "Score :";
            // 
            // txtName
            // 
            txtName.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(367, 119);
            txtName.Name = "txtName";
            txtName.Size = new Size(328, 52);
            txtName.TabIndex = 5;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.Black;
            btnOk.FlatStyle = FlatStyle.Popup;
            btnOk.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOk.ForeColor = Color.Yellow;
            btnOk.Location = new Point(731, 119);
            btnOk.Margin = new Padding(5, 4, 5, 4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(185, 70);
            btnOk.TabIndex = 6;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOkClick;
            // 
            // FrmWinnerName
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 450);
            Controls.Add(btnOk);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(lblScoreValue);
            Controls.Add(lblName);
            Name = "FrmWinnerName";
            Text = "FrmWinnerName";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblScoreValue;
        private Label label2;
        private TextBox txtName;
        private Button btnOk;
    }
}