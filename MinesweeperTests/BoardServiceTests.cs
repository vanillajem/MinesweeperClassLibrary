using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperTests
{
    /// <summary>
    /// Unit tests for the BoardService class to verify that
    /// Minesweeper business logic works correctly.
    /// These tests support Milestone 2 requirements.
    /// </summary>
    public class BoardServiceTests
    {
        /// <summary>
        /// Ensures that SetupBombs() places at least one bomb on the board.
        /// Since randomness is involved, we simply verify that the board  
        /// contains at least one bomb after the method runs.
        /// </summary>
        [Fact]
        public void SetupBombs_PlacesAtLeastOneBomb()
        {
            // ARRANGE
            var board = new BoardModel(5, DifficultyLevel.Easy);
            var service = new BoardService();

            // ACT
            service.SetupBombs(board);

            // ASSERT
            int bombCount = 0;

            // Count how many bomb cells exist on the board
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        bombCount++;
                    }
                }
            }

            // There should be at least one bomb
            Assert.True(bombCount > 0);
        }

        /// <summary>
        /// Verifies that CountBombsNearby correctly assigns neighbor counts.
        /// A single bomb is placed in the center of a 3x3 grid.  
        /// The bomb should get a value of 9, and all 8 surrounding cells  
        /// should detect exactly 1 bomb nearby.
        /// </summary>
        [Fact]
        public void CountBombsNearby_SetsCorrectNeighborCounts()
        {
            // ARRANGE
            var board = new BoardModel(3, DifficultyLevel.Easy);
            var service = new BoardService();

            // Place a single bomb in the center (1,1)
            board.Cells[1, 1].IsBomb = true;

            // ACT
            service.CountBombsNearby(board);

            // ASSERT

            // Bomb cell should have a special marker of 9
            Assert.Equal(9, board.Cells[1, 1].NumberOfBombNeighbors);

            // Coordinates of all 8 neighbors around (1,1)
            int[,] neighbors =
            {
                {0,0},{0,1},{0,2},
                {1,0},       {1,2},
                {2,0},{2,1},{2,2}
            };

            // All surrounding cells should have exactly 1 neighboring bomb
            for (int i = 0; i < neighbors.GetLength(0); i++)
            {
                int r = neighbors[i, 0];
                int c = neighbors[i, 1];

                Assert.Equal(1, board.Cells[r, c].NumberOfBombNeighbors);
            }
        }
    }
}