using MinesweeperClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;

// milestone-5 

namespace MinesweeperGUI
{
    public partial class FrmHighScores : Form
    {
        private const string FILE_NAME = "highscores.txt";
        private readonly string _filePath;
        private readonly string filePath =
    Path.Combine(Application.StartupPath, "highscores.txt");


        private List<GameStat> stats = new List<GameStat>();

        // Use this when you just want to open the form (no new score)
        public FrmHighScores()
        {
            InitializeComponent();

            _filePath = Path.Combine(Application.StartupPath, FILE_NAME);

            SetupGrid();
            LoadStatsFromFile();
            SortTrimRenumber();
            SaveTop10ToFile();      // keeps file cleaned up
            RefreshGrid();
        }

        // Use this when you want to add a new win + show highscores
        public FrmHighScores(string name, int score, int gameTimeSeconds) : this()
        {
            AddNewWin(name, score, gameTimeSeconds);
        }

        private void SetupGrid()
        {
            dgvScores.AutoGenerateColumns = true;
            dgvScores.ReadOnly = true;
            dgvScores.AllowUserToAddRows = false;
            dgvScores.AllowUserToDeleteRows = false;
            dgvScores.MultiSelect = false;
            dgvScores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvScores.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void RefreshGrid()
        {
            dgvScores.DataSource = null;
            dgvScores.DataSource = stats;

            // Hide Id column if you don’t want it showing
            if (dgvScores.Columns["Id"] != null)
                dgvScores.Columns["Id"].Visible = false;

            // Friendly column titles
            if (dgvScores.Columns["Name"] != null)
                dgvScores.Columns["Name"].HeaderText = "Name";

            if (dgvScores.Columns["Score"] != null)
                dgvScores.Columns["Score"].HeaderText = "Score";

            if (dgvScores.Columns["GameTime"] != null)
                dgvScores.Columns["GameTime"].HeaderText = "Time (s)";

            // Auto size columns so it fills nicely
            dgvScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AddNewWin(string name, int score, int gameTimeSeconds)
        {
            // Don’t let delimiter break the file
            name = (name ?? "").Replace("|", "").Trim();
            if (string.IsNullOrWhiteSpace(name))
                name = "Unknown";

            stats.Add(new GameStat
            {
                Id = 0, // will be renumbered after sorting
                Name = name,
                Score = score,
                GameTime = gameTimeSeconds
            });

            SortTrimRenumber();
            SaveTop10ToFile();
            RefreshGrid();
        }

        private void SortTrimRenumber()
        {
            // Score desc, Time asc (faster is better)
            stats = stats
                .OrderByDescending(s => s.Score)
                .ThenBy(s => s.GameTime)
                .Take(10)
                .ToList();

            // Renumber Id 1..10 (rank)
            for (int i = 0; i < stats.Count; i++)
                stats[i].Id = i + 1;
        }

        private void LoadStatsFromFile()
        {
            stats.Clear();

            if (!File.Exists(_filePath))
                return;

            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Name|Score|Time
                string[] parts = line.Split('|');
                if (parts.Length != 3)
                    continue;

                string name = parts[0].Trim();

                if (!int.TryParse(parts[1], out int score))
                    continue;

                if (!int.TryParse(parts[2], out int time))
                    continue;

                stats.Add(new GameStat
                {
                    Id = 0, // renumber later
                    Name = name,
                    Score = score,
                    GameTime = time
                });
            }
        }

        private void SaveTop10ToFile()
        {
            // Make sure folder exists (StartupPath does, but safe anyway)
            var lines = stats.Select(s => $"{s.Name}|{s.Score}|{s.GameTime}").ToArray();
            File.WriteAllLines(_filePath, lines);
        }

        private void btnOkClick(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save clicked");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var s in stats)
                {
                    writer.WriteLine($"{s.Name}|{s.Score}|{s.GameTime}");
                }
            }

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("No high score file found.");
                return;
            }

            stats.Clear();

            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split('|');
                if (parts.Length != 3) continue;

                stats.Add(new GameStat
                {
                    Name = parts[0],
                    Score = int.Parse(parts[1]),
                    GameTime = int.Parse(parts[2])
                });
            }

            // keep top 10 (Score desc, Time asc)
            stats = stats
                .OrderByDescending(s => s.Score)
                .ThenBy(s => s.GameTime)
                .Take(10)
                .ToList();

            RefreshGrid();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stats = stats.OrderBy(s => s.Name).ToList();
            RefreshGrid();
        }

        private void byScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stats = stats.OrderByDescending(s => s.Score).ToList();
            RefreshGrid();
        }
    }
}

