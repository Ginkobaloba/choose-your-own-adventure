using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigDiceGame
{
    class Game
    {
        player playerOne;
        player playerTwo;
        Dice firstDie;
        int roundNumber;
        int TempScore;
    public void Setup()
        {
            Console.WriteLine("Good Day. Your Invited to play a Game of Pig!");
            Console.WriteLine("You Can choose to play against the CPU or play with a friend. How many Players? 1 or 2?");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("Excellent! Please, provide me with your name");
                this.playerOne = new player(Console.ReadLine(),false);
                Console.WriteLine("Thank you, {0}", playerOne.getPlayerName());
                this.playerTwo = new player("Automatic Pig Game Robot",true);

            }
            else
            {
                Console.WriteLine("Excellent! PlayerOne please provide me with your name:");
                this.playerOne = new player(Console.ReadLine(),false);
                Console.WriteLine("Hello, {0} thank you for playing.", playerOne.getPlayerName());
                Console.WriteLine("PlayerTwo please provide me with your name?:");
                this.playerTwo = new player(Console.ReadLine(),false);
                Console.WriteLine("Thank you, {0}", playerTwo.getPlayerName());
            }
            this.firstDie = new Dice(6);
            Console.Clear();
        }
        public void runInstructions()
        {
            Console.WriteLine("I would quickly just like to provide you with a run throught of how Pig is played.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Each turn, a player repeatedly rolls a die until either a 1 is rolled or the player decides to hold:");
            Console.ReadLine();
            Console.WriteLine("If the player rolls any other number, it is added to their turn total and the player's turn continues.");
            Console.ReadLine();
            Console.WriteLine("If a player chooses to hold, their turn total is added to their score, and it becomes the next player's turn.");
            Console.ReadLine();
            Console.WriteLine("The first player to score 100 or more points wins");
            Console.ReadLine();
            Console.WriteLine("For example, the first player, Ann, begins a turn with a roll of 5.");
            Console.ReadLine();
            Console.WriteLine("Ann could hold and score 5 points, but chooses to roll again.");
            Console.ReadLine();
            Console.WriteLine("Ann rolls a 2, and could hold with a turn total of 7 points, but chooses to roll again.");
            Console.ReadLine();
            Console.WriteLine("Ann rolls a 1, and must end her turn without scoring.");
            Console.ReadLine();
            Console.WriteLine("The next player, Bob, rolls the sequence 4 - 5 - 3 - 5 - 5, after which he chooses to hold,");
            Console.ReadLine();
            Console.WriteLine("Bob's turn total of 22 points gets added to his score.");
            Console.ReadLine();

        }
        
        public void runGame()
        {
            while (playerOne.getPlayerScore() < 100 && playerTwo.getPlayerScore() < 100)
            {
                Console.WriteLine("{0} are ready? Remember type Roll or Hold. When you hold it will end your turn.")
            }
        }



    }
}