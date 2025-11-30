using MinesweeperClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.BusinessLogicLayer
{
    /// <summary>
    /// Handles all business logic for the Minesweeper game.
    /// This includes: placing bombs, counting neighbors, 
    /// processing visits and flags, and determining game state.
    /// </summary>
    public class BoardService
    {
        /// <summary>
        /// Random generator used for bomb placement.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Randomly places bombs on the board based on difficulty level.
        /// Ensures bombs are not placed twice in the same cell.
        /// </summary>
        public void SetupBombs(BoardModel board)
        {
            int totalCells = board.Size * board.Size;

            // Calculate number of bombs based on % for the difficulty
            int numberOfBombs = GetBombCountForDifficulty(board.Difficulty, totalCells);

            int bombsPlaced = 0;

            // Randomly select cells until we reach the required bomb count
            while (bombsPlaced < numberOfBombs)
            {
                int row = _random.Next(0, board.Size);
                int col = _random.Next(0, board.Size);

                // Only place a bomb if this cell doesn't already have one
                if (!board.Cells[row, col].IsBomb)
                {
                    board.Cells[row, col].IsBomb = true;
                    bombsPlaced++;
                }
            }
        }

        /// <summary>
        /// Returns how many bombs to place on the board based on difficulty.
        /// </summary>
        private int GetBombCountForDifficulty(DifficultyLevel difficulty, int totalCells)
        {
            double percentage = difficulty switch
            {
                DifficultyLevel.Easy => 0.10,     // 10%
                DifficultyLevel.Medium => 0.15,  // 15%
                DifficultyLevel.Hard => 0.20,    // 20%
                _ => 0.10
            };

            int count = (int)Math.Round(totalCells * percentage);

            // Always place at least 1 bomb
            return Math.Max(count, 1);
        }

        /// <summary>
        /// For each cell on the board, determines how many bombs
        /// are in the eight surrounding cells.
        /// Bombs get a special marker (9).
        /// </summary>
        public void CountBombsNearby(BoardModel board)
        {
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        // Mark bombs with 9 for internal use
                        board.Cells[row, col].NumberOfBombNeighbors = 9;
                    }
                    else
                    {
                        board.Cells[row, col].NumberOfBombNeighbors =
                            CountBombsAroundCell(board, row, col);
                    }
                }
            }
        }

        /// <summary>
        /// Counts bombs around a specific (row, col) cell.
        /// Checks all 8 surrounding positions, skipping out-of-bounds.
        /// </summary>
        private int CountBombsAroundCell(BoardModel board, int row, int col)
        {
            int count = 0;

            // Check the 3x3 area surrounding the cell
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    // Skip invalid board positions
                    if (r < 0 || c < 0 || r >= board.Size || c >= board.Size)
                        continue;

                    // Skip the cell itself
                    if (r == row && c == col)
                        continue;

                    if (board.Cells[r, c].IsBomb)
                        count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Placeholder for later milestones.
        /// </summary>
        public void UseSpecialBonus(BoardModel board)
        {
            // special ability added in later milestone
        }

        /// <summary>
        /// Placeholder for later milestones (scoring system).
        /// </summary>
        public int DetermineFinalScore(BoardModel board)
        {
            return 0;
        }


        // ============================
        //    MILESTONE 2 LOGIC
        // ============================

        /// <summary>
        /// Marks a cell as visited. 
        /// If the cell is a bomb, sets game state to Lost.
        /// Flags cannot be visited.
        /// </summary>
        public void VisitCell(BoardModel board, int row, int col)
        {
            // Ignore invalid positions
            if (row < 0 || col < 0 || row >= board.Size || col >= board.Size)
                return;

            var cell = board.Cells[row, col];

            // Cannot visit flagged cells
            if (cell.IsFlagged)
                return;

            // Mark cell as visited
            cell.IsVisited = true;

            // If a bomb is visited → loss
            if (cell.IsBomb)
            {
                board.GameState = GameState.Lost;
            }
        }

        /// <summary>
        /// Toggles a flag on a cell.
        /// Flags cannot be placed on visited cells.
        /// </summary>
        public void ToggleFlag(BoardModel board, int row, int col)
        {
            if (row < 0 || col < 0 || row >= board.Size || col >= board.Size)
                return;

            var cell = board.Cells[row, col];

            // Cannot flag a cell that is already visited
            if (cell.IsVisited)
                return;

            // Toggle
            cell.IsFlagged = !cell.IsFlagged;
        }

        /// <summary>
        /// Determines if the player:
        /// - Lost: visited a bomb  
        /// - Won: all safe cells visited  
        /// - Is still playing  
        /// </summary>
        public GameState DetermineGameState(BoardModel board)
        {
            bool anyBombVisited = false;
            bool allSafeVisited = true;

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    var cell = board.Cells[row, col];

                    // Lose condition: visited a bomb
                    if (cell.IsBomb && cell.IsVisited)
                    {
                        anyBombVisited = true;
                    }

                    // Win condition requires ALL safe cells to be visited
                    if (!cell.IsBomb && !cell.IsVisited)
                    {
                        allSafeVisited = false;
                    }
                }
            }

            if (anyBombVisited)
                return GameState.Lost;

            if (allSafeVisited)
                return GameState.Won;

            return GameState.InProgress;
        }
    }
}