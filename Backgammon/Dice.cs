using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Dice
    {
        public int Cube1 { get; set; }

        public int Cube2 { get; set; }

        public bool isDouble { get; set; }

        private Random random = new Random();
        public void RollDice()
        {
            Cube1 = random.Next(1, 7);
            Cube2 = random.Next(1, 7);
            if (Cube1 == Cube2) isDouble = true;
            else isDouble = false;
        }
    }
}
