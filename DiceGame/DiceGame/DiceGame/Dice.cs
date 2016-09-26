using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigDiceGame
{
    class Dice
    {
        int valueShown;
        int numberOfSides;

        public Dice(int numberOfSides)
        {
            this.valueShown = 0;
            this.numberOfSides = numberOfSides;
        }


       public int getDiceRoll(int numberOfSides)
        {
            Random random = new Random();
            this.valueShown = random.Next(1, (numberOfSides + 1));
            return this.valueShown;
        }
    }
}
