using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.Models
{
     /// <summary>
        /// Represents the entire Minesweeper game board.
        /// Stores the grid of cells, difficulty setting, game state,
        /// and timing information for the game session.
        /// </summary>
        public class BoardModel
        {

            /// The size of the board (NxN).
            public int Size { get; set; }

            /// Timestamp for when the game started.
            public DateTime StartTime { get; set; }

            /// Timestamp for when the game ends (win or loss).
            public DateTime EndTime { get; set; }

            /// <summary>
            /// Two-dimensional array containing all CellModel objects.
            /// Each CellModel represents a single square on the grid.
            /// </summary>
            public CellModel[,] Cells { get; set; }

            /// <summary>
            /// Difficulty level of the game (Easy, Medium, Hard).
            /// This determines bomb density.
            /// </summary>
            public DifficultyLevel Difficulty { get; set; }

            /// <summary>
            /// How many rewards the player has available.
            /// This feature is not implemented until later milestones.
            /// </summary>
            public int RewardsRemaining { get; set; } = 0;

            /// <summary>
            /// Tracks whether the player is still playing, has won, or lost.
            /// </summary>
            public GameState GameState { get; set; } = GameState.InProgress;

            /// <summary>
            /// Constructor that initializes the board with a given size and difficulty.
            /// Sets up an empty grid of CellModel objects and records start time.
            /// </summary>
            /// <param name="size">The board size (NxN)</param>
            /// <param name="difficulty">The selected difficulty level</param>
            public BoardModel(int size, DifficultyLevel difficulty)
            {
                Size = size;
                Difficulty = difficulty;

                // Allocate the NxN grid of cells
                Cells = new CellModel[size, size];

                // Initialize each CellModel with its row and column
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        Cells[row, col] = new CellModel(row, col);
                    }
                }

                // Record when the game starts
                StartTime = DateTime.Now;
            }
        }
    }

