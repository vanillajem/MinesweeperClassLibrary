using MinesweeperClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.BusinessLogicLayer
{
    public class BoardService
    {
        private readonly Random _random = new Random();

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

        public void CountBombsNearby(BoardModel board)
        {
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
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

        public GameState DetermineGameState(BoardModel board)
        {
            return board.GameState; // placeholder
        }

        public void UseSpecialBonus(BoardModel board)
        {
            // placeholder
        }

        public int DetermineFinalScore(BoardModel board)
        {
            return 0; // placeholder
        }
    }
}