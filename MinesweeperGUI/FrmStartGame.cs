using MinesweeperClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MinesweeperClassLibrary.Models;


namespace MinesweeperGUI
{
    public partial class FrmStartGame : Form
    {
        public FrmStartGame()
        {
            InitializeComponent();

            this.BackgroundImage = Properties.Resources.Background1;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            int size = trkSize.Value;

            DifficultyLevel difficulty = DifficultyLevel.Medium;
            if (rdoEasy.Checked) difficulty = DifficultyLevel.Easy;
            else if (rdoHard.Checked) difficulty = DifficultyLevel.Hard;

            FrmGameForm gameForm = new FrmGameForm(size, difficulty);
            gameForm.Show();
            this.Hide(); ;
        }

        private void trkSize_Scroll(object sender, EventArgs e)
        {
            lblSizeValue.Text = trkSize.Value.ToString();
        }
    }
}
