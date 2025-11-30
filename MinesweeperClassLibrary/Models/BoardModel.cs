using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.Models
{
    public class BoardModel
    {
        public int Size { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public CellModel[,] Cells { get; set; }

        public DifficultyLevel Difficulty { get; set; }

        public int RewardsRemaining { get; set; } = 0;

        public GameState GameState { get; set; } = GameState.InProgress;

        public BoardModel(int size, DifficultyLevel difficulty)
        {
            Size = size;
            Difficulty = difficulty;

            Cells = new CellModel[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Cells[row, col] = new CellModel(row, col);
                }
            }

            StartTime = DateTime.Now;
        }
    }
}