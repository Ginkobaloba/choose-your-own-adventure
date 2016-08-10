using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseAdventure
{
    public class Adventure
    {
        player player;
        public Adventure()
        {
            this.player = new player("Ginkobaloba");
        }
        public void CallInventory(string lower)
        {
            if (lower == "draw sword")
            {
                player.DrawSword();
            }
            else if (lower == "light torch")
            {
                player.LightTorch();
            }
            else if (lower == "go forward")
            {
                player.MovePlayerForward();
            }
            else if (lower == "go back")
            {
                player.MovePlayerBack();

            }
            else if (lower == "put out torch")
            {
                player.PutOutTorch();
            }
            else if (lower == "sheath sword")
            {
                player.SheathSword();
            }
            else if (lower == "help")
            {
                player.CallHelp();
            }
            else
            {
                RunGame();
            }
        }
        public void RunGame()
        {

            while (player.PlayerLiving()== true)
            {
                if (player.GetPlayerLocation() == 0 && player.GetWentInInventory() == false)
                {
                    Console.WriteLine("As you gain consciousness you find yourself at the the mouth of a dark cave, a quick check of your inventory reveals a sword and a torch. You faintly rememember your name {0}. How would you like to proceed?:", player.getName());
                    string line = Console.ReadLine();
                    string lower = line.ToLower();
                    this.CallInventory(lower);
                }
                else if (player.GetWentInInventory() == true)
                {
                    Console.WriteLine("{0}, What would you like to do now?:", player.getName());
                    string line = Console.ReadLine();
                    string lower = line.ToLower();
                    this.CallInventory(lower);
                }
                else if (player.GetPlayerLocation() == 1 && player.GetWentInInventory() == false)
                {
                    if (player.GetTorchStatus() == true)
                    {
                        Console.WriteLine("As you enter the cave your torch illuminates your path.You proceed forward until you reach a fork in the cave to the left you hear a low whine, to the right a constant steady pound how do you proceed?");
                        string line = Console.ReadLine();
                        string lower = line.ToLower();
                        this.CallInventory(lower);
                    }
                    else if (player.GetWentInInventory() == true)
                    {
                        Console.WriteLine("{0}, What would you like to do now?:", player.getName());
                        string line = Console.ReadLine();
                        string lower = line.ToLower();
                        this.CallInventory(lower);
                    }
                    else if (player.GetSwordStatus() == true)
                    {
                        Console.WriteLine("as you enter the darkened cave with your sword drawn. You are rushed by a necromancer's hord. You swing blindly hoping to find purchase. You are quickly overcome, the hord slowly consumes your body in the darkness. YOU DIE. ");
                        player.PlayerDeath();
                    }
                    else
                    {
                        Console.WriteLine("As you enter the pitch black cave you hear a rush of commotion.You are swarmed by a necromancer's hord. YOU DIE. ");
                        player.PlayerDeath();
                    }
                }

            }
            if (player.PlayerLiving() == true)
            {
                RunGame();
            }
            else
            {
            Adventure adventure = new Adventure();
            adventure.RunGame();
            }
        }
    }
}
