using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigDiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game Game = new Game();
            Game.Setup();
            Game.runInstructions();
            Game.runGame();
            Game.EndGame();
        }
    }
}
