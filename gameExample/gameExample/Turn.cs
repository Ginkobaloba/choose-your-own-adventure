using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Turn
    {
        Player player;

        public Turn(Player player)
        {
            this.player = player;
        }
        public void TakeTurn()
        {
            Console.WriteLine("It is your turn {0}", player.getName());
            player.addToScore();
            player.addToScore();
            Console.WriteLine("Your turn is over {0}, your score is {1}", player.getName(), player.getScore());
            Console.ReadKey();
        }
    }
}
