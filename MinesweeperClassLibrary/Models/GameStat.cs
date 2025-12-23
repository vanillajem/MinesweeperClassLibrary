using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.Models
{
    public class GameStat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int GameTime { get; set; } // seconds

        public DateTime Date { get; set; }

        public GameStat() { }

        public GameStat(int id, string name, int score, int gameTime)
        {
            Id = id;
            Name = name;
            Score = score;
            GameTime = gameTime;
            Date = DateTime.Now;

        }
    }
}

