using System;
using MinesweeperClassLibrary.Models;

namespace MinesweeperClassLibrary.BusinessLogicLayer
{
    /// <summary>
    /// Handles all business logic for Minesweeper:
    /// - placing bombs
    /// - counting neighbor bombs
    /// - visiting cells (including flood fill)
    /// - flag toggling
    /// - game state checks
    /// </summary>
    public class BoardService
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Randomly places bombs based on difficulty.
        /// </summary>
        public void SetupBombs(BoardModel board)
        {
            int totalCells = board.Size * board.Size;
            int numberOfBombs = GetBombCountForDifficulty(board.Difficulty, totalCells);

            int bombsPlaced = 0;

            while (bombsPlaced < numberOfBombs)
            {
                int row = _random.Next(0, board.Size);
                int col = _random.Next(0, board.Size);

                if (!board.Cells[row, col].IsBomb)
                {
                    board.Cells[row, col].IsBomb = true;
                    bombsPlaced++;
                }
            }
        }

        /// <summary>
        /// Calculates bomb count using difficulty percentage.
        /// </summary>
        private int GetBombCountForDifficulty(DifficultyLevel difficulty, int totalCells)
        {
            double percentage = difficulty switch
            {
                DifficultyLevel.Easy => 0.10,
                DifficultyLevel.Medium => 0.15,
                DifficultyLevel.Hard => 0.20,
                _ => 0.10
            };

            int count = (int)Math.Round(totalCells * percentage);
            return Math.Max(count, 1);
        }

        /// <summary>
        /// Sets NumberOfBombNeighbors for every cell.
        /// IMPORTANT: bombs do NOT need a special "9" marker.
        /// The UI can just check IsBomb directly.
        /// </summary>
        public void CountBombsNearby(BoardModel board)
        {
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        board.Cells[row, col].NumberOfBombNeighbors = 0; // keep clean
                    }
                    else
                    {
                        board.Cells[row, col].NumberOfBombNeighbors =
                            CountBombsAroundCell(board, row, col);
                    }
                }
            }
        }

        private int CountBombsAroundCell(BoardModel board, int row, int col)
        {
            int count = 0;

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r < 0 || c < 0 || r >= board.Size || c >= board.Size)
                        continue;

                    if (r == row && c == col)
                        continue;

                    if (board.Cells[r, c].IsBomb)
                        count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Reveals a cell if possible.
        /// - ignores out-of-bounds
        /// - ignores flagged
        /// - bomb -> mark visited and end game
        /// - safe -> visit cell; if 0 neighbors -> flood fill region
        /// </summary>
        public void VisitCell(BoardModel board, int row, int col)
        {
            if (!IsInBounds(board, row, col))
                return;

            var cell = board.Cells[row, col];

            // can't reveal a flagged cell
            if (cell.IsFlagged)
                return;

            // already visited: nothing to do
            if (cell.IsVisited)
                return;

            // bomb hit -> loss
            if (cell.IsBomb)
            {
                cell.IsVisited = true;
                board.GameState = GameState.Lost;
                return;
            }

            // safe cell
            if (cell.NumberOfBombNeighbors == 0)
            {
                FloodFill(board, row, col);
            }
            else
            {
                cell.IsVisited = true;
            }
        }

        /// <summary>
        /// Right-click flags:
        /// - can't flag visited cells
        /// - toggles flagged on/off
        /// </summary>
        public void ToggleFlag(BoardModel board, int row, int col)
        {
            if (!IsInBounds(board, row, col))
                return;

            var cell = board.Cells[row, col];

            if (cell.IsVisited)
                return;

            cell.IsFlagged = !cell.IsFlagged;
        }

        /// <summary>
        /// Checks win/loss/in progress:
        /// - Lost if any bomb visited
        /// - Won if all safe cells visited
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

                    if (cell.IsBomb && cell.IsVisited)
                        anyBombVisited = true;

                    if (!cell.IsBomb && !cell.IsVisited)
                        allSafeVisited = false;
                }
            }

            if (anyBombVisited)
                return GameState.Lost;

            if (allSafeVisited)
                return GameState.Won;

            return GameState.InProgress;
        }

        /// <summary>
        /// Simple scoring (no timer).
        /// </summary>
        public int DetermineFinalScore(BoardModel board)
        {
            int totalCells = board.Size * board.Size;

            int diffMult = board.Difficulty switch
            {
                DifficultyLevel.Easy => 1,
                DifficultyLevel.Medium => 2,
                DifficultyLevel.Hard => 3,
                _ => 1
            };

            return totalCells * 10 * diffMult;
        }

        /// <summary>
        /// Flood fill reveal:
        /// - marks cell visited
        /// - if cell has neighbors > 0, stop
        /// - if 0 neighbors, recursively visit the 8 surrounding cells
        /// </summary>
        private void FloodFill(BoardModel board, int row, int col)
        {
            if (!IsInBounds(board, row, col))
                return;

            var cell = board.Cells[row, col];

            if (cell.IsVisited || cell.IsFlagged || cell.IsBomb)
                return;

            cell.IsVisited = true;

            // If it has a number, reveal it but don't spread
            if (cell.NumberOfBombNeighbors > 0)
                return;

            // Spread to neighbors
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r == row && c == col)
                        continue;

                    FloodFill(board, r, c);
                }
            }
        }

        private bool IsInBounds(BoardModel board, int row, int col)
        {
            return row >= 0 && col >= 0 && row < board.Size && col < board.Size;
        }
    }
}