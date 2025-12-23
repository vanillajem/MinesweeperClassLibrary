using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




// milestone-5 
namespace MinesweeperGUI
{
    public partial class FrmWinnerName : Form
    {

        public string WinnerName { get; private set; } = string.Empty;
        public FrmWinnerName(int finalScore)
        {
            InitializeComponent();
            lblScoreValue.Text = finalScore.ToString();
        }


        private void btnOkClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Enter a name");
                return;
            }

            WinnerName = txtName.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
