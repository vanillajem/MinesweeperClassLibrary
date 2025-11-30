using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.Models
{
    /// <summary>
    /// Represents a single cell on the Minesweeper board.
    /// Stores positional data (row/column), state information
    /// such as visited/flagged, and gameplay attributes like 
    /// whether the cell contains a bomb or reward.
    /// </summary>
    public class CellModel
    {
        /// Row index of this cell on the board.
        public int Row { get; set; } = -1;

        /// Column index of this cell on the board.
        public int Column { get; set; } = -1;

        /// True if the player has visited (revealed) this cell.
        public bool IsVisited { get; set; } = false;

        /// True if this cell contains a bomb.
        public bool IsBomb { get; set; } = false;
        /// True if the player has placed a flag on this cell.
        /// /// Flags prevent accidental visits
        public bool IsFlagged { get; set; } = false;

        /// The number of bombs in the eight surrounding cells.
        /// This is shown to the player when the cell is visited.
        public int NumberOfBombNeighbors { get; set; } = 0;

        /// Indicates whether this cell contains a special reward.
        /// This feature is used in later milestones.
        public bool HasSpecialReward { get; set; } = false;

        /// <summary>
        /// Default constructor.
        /// Allows creating a cell without setting row/column immediately.
        /// </summary>
        public CellModel()
        {
        }

        /// <summary>
        /// Constructs a cell with a specific row and column.
        /// </summary>
        /// <param name="row">Row index of the cell</param>
        /// <param name="column">Column index of the cell</param>
        public CellModel(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}