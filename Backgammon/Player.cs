using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Player
    {
        public enum PlayerColor { Black, Red}

        public string Name { get; private set; }

        public PlayerColor playerColor { get; set; }

        public bool isTurn { get; set; }

        public Player(string name, PlayerColor color)
        {
            Name = name;
            playerColor = color;
        }
    }
}
