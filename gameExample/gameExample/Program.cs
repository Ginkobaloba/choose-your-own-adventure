using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            game game = new game();
            game.RunGame();
            Console.WriteLine("Game Over man, Game Over!!");
            Console.ReadLine();
        }
    }
}
