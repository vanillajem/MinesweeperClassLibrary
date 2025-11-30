using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperTests
{
    public class BoardServiceTests
    {
        [Fact]
        public void SetupBombs_PlacesAtLeastOneBomb()
        {
            // arrange
            var board = new BoardModel(5, DifficultyLevel.Easy);
            var service = new BoardService();

            // act
            service.SetupBombs(board);

            // assert
            int bombCount = 0;

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

            Assert.True(bombCount > 0);
        }

        [Fact]
        public void CountBombsNearby_SetsCorrectNeighborCounts()
        {
            // arrange
            var board = new BoardModel(3, DifficultyLevel.Easy);
            var service = new BoardService();

            // put a single bomb in the middle
            board.Cells[1, 1].IsBomb = true;

            // act
            service.CountBombsNearby(board);

            // assert: bomb cell gets 9
            Assert.Equal(9, board.Cells[1, 1].NumberOfBombNeighbors);

            // neighbors should all see 1 bomb
            int[,] neighbors =
            {
                {0,0},{0,1},{0,2},
                {1,0},       {1,2},
                {2,0},{2,1},{2,2}
            };

            for (int i = 0; i < neighbors.GetLength(0); i++)
            {
                int r = neighbors[i, 0];
                int c = neighbors[i, 1];

                Assert.Equal(1, board.Cells[r, c].NumberOfBombNeighbors);
            }
        }
    }
}