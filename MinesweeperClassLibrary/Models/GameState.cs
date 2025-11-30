using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.Models
{
    /// <summary>
    /// Represents the current status of the Minesweeper game.
    /// Used to track whether the game is ongoing or has ended.
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// The game is still running; the player has not won or lost yet.
        /// </summary>
        InProgress,

        /// <summary>
        /// The player has visited all non-bomb cells and successfully won the game.
        /// </summary>
        Won,

        /// <summary>
        /// The player visited a bomb and the game is over.
        /// </summary>
        Lost
    }
}