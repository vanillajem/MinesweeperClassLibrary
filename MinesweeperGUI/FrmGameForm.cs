using System;
using System.Drawing;
using System.Windows.Forms;
using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;

namespace MinesweeperGUI
{
    public partial class FrmGameForm : Form
    {
        private BoardModel _board;
        private BoardService _service;
        private Button[,] _buttons;
        private int secondsElapsed = 0;
        
        public FrmGameForm(int size, DifficultyLevel difficulty)
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.Background;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;
            pnlBoard.BackColor = Color.Transparent;


            // Create business logic + board
            _service = new BoardService();
            _board = new BoardModel(size, difficulty);
            _buttons = new Button[size, size];

            // Setup game data
            // _service.SetupBombs(_board);
            _service.CountBombsNearby(_board);

            // Build UI + paint initial state
            BuildBoardUI();
            UpdateButtons();
        }

        /// <summary>
        /// Creates a grid of WinForms Buttons and puts them into pnlBoard.
        /// Each button stores its row/col in Tag.
        /// </summary>
        private void BuildBoardUI()
        {
            pnlBoard.Controls.Clear();

            int size = _board.Size;
            int btnSize = 47;

            pnlBoard.Width = size * btnSize;
            pnlBoard.Height = size * btnSize;

            // build buttons

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Button btn = new Button
                    {
                        Width = btnSize,
                        Height = btnSize,
                        Left = col * btnSize,
                        Top = row * btnSize,
                        UseVisualStyleBackColor = false,
                        Tag = $"{row},{col}",
                        BackColor = Color.LightGray
                    };

                    // Left click = reveal cell
                    btn.Click += CellButton_Click;

                    // Right click = flag/unflag
                    btn.MouseDown += CellButton_MouseDown;

                    _buttons[row, col] = btn;
                    pnlBoard.Controls.Add(btn);

                }
            }

                // timer reset/start (ONLY ONCE)
                secondsElapsed = 0;
                lblTimeValue.Text = "0";
                gameTimer.Start();

            }

        

        /// <summary>
        /// Left click: reveal a cell.
        /// IMPORTANT: We must call UpdateButtons() after revealing,
        /// otherwise nothing changes visually until the game ends.
        /// </summary>
        private void CellButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Get row/col from Tag
            string[] parts = btn.Tag.ToString().Split(',');
            int row = int.Parse(parts[0]);
            int col = int.Parse(parts[1]);

            // Apply reveal logic
            _service.VisitCell(_board, row, col);

            // Re-check game state after the move
            _board.GameState = _service.DetermineGameState(_board);

            // Update visuals immediately after reveal
            UpdateButtons();

            // If the game ended, reveal bombs and finish up
            if (_board.GameState != GameState.InProgress)
            {
                gameTimer.Stop(); // Stop the timer when the game ends (M5)

                RevealBombs();
                UpdateButtons();

                int finalScore = _service.DetermineFinalScore(_board);
                lblScoreValue.Text = finalScore.ToString();

                pnlBoard.Enabled = false;

                if (_board.GameState == GameState.Won)
                {
                    using (var frm = new FrmWinnerName(finalScore))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            string winnerName = frm.WinnerName;
                            MessageBox.Show("Form3 returned OK. About to open Form4."); // testing

                            int timeSeconds = secondsElapsed;

                            using (var frmScores = new FrmHighScores(winnerName, finalScore, timeSeconds))
                            {
                                frmScores.ShowDialog();
                            }
                        }
                    }
                }// M5 // Form3 will go here later // added
                else
                    MessageBox.Show("Boom! You lost!");

            }
        }

        /// <summary>
        /// Right click: toggle flag on a cell (if it's not visited).
        /// </summary>
        private void CellButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            Button btn = (Button)sender;

            string[] parts = btn.Tag.ToString().Split(',');
            int row = int.Parse(parts[0]);
            int col = int.Parse(parts[1]);

            _service.ToggleFlag(_board, row, col);
            UpdateButtons();
        }

        /// <summary>
        /// Paints every button based on the current board state.
        /// RULES:
        /// - flagged -> show F
        /// - not visited -> blank/gray and clickable
        /// - visited safe cell:
        ///      - 0 neighbors -> blank
        ///      - 1+ neighbors -> show number
        /// - visited bomb -> show B (normally only after game ends)
        /// </summary>
        private void UpdateButtons()
        {
            int size = _board.Size;


            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    var cell = _board.Cells[row, col];
                    var btn = _buttons[row, col];

                    // Start from a clean default each repaint
                    btn.Enabled = true;
                    btn.Text = "";
                    btn.BackColor = Color.LightGray;
                    btn.ForeColor = Color.Black;

                    // FLAGGED CELL
                    if (cell.IsFlagged)
                    {
                        btn.Text = "F";
                        btn.BackColor = Color.LightSkyBlue;
                        continue;
                    }

                    // NOT VISITED: keep hidden and clickable
                    if (!cell.IsVisited)
                    {
                        continue;
                    }

                    // VISITED: disable clicking
                    btn.Enabled = false;
                    btn.BackColor = Color.White;

                    // BOMB CELL (only visible after RevealBombs() or bomb clicked)
                    if (cell.IsBomb)
                    {
                        btn.Text = "B";
                        btn.BackColor = Color.LightCoral;
                        continue;
                    }

                    // SAFE CELL
                    if (cell.NumberOfBombNeighbors > 0)
                    {
                        btn.Text = cell.NumberOfBombNeighbors.ToString();
                    }
                    else
                    {
                        // 0 neighbors -> show blank (classic minesweeper)
                        btn.Text = "";
                    }
                }
            }
        }

        /// <summary>
        /// When the game ends, mark all bombs as visited so they display.
        /// </summary>
        private void RevealBombs()
        {
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    if (_board.Cells[row, col].IsBomb)
                        _board.Cells[row, col].IsVisited = true;
                }
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e) // M5 Timer Tick event
        {
            secondsElapsed++;
            lblTimeValue.Text = secondsElapsed.ToString();
            

        }
    }
    
}