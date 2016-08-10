using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseAdventure
{
    public class player
    {
        string PlayerName;
        bool SwordDrawn;
        bool TorchOut;
        bool IsAlive;
        bool WentInInventory;
        int PlayerLocation;

        public player(string PlayerName)
        {
            this.PlayerName = PlayerName;
            this.SwordDrawn = false;
            this.TorchOut = false;
            this.IsAlive = true;
            this.WentInInventory = false;
            this.PlayerLocation = 0;
        }
        public string getName()
        {
            return this.PlayerName;
        }
        public void DrawSword()
        {
            if (this.TorchOut == true)
            {
                Console.WriteLine("you put your torch away and pull out your sword.");
                this.TorchOut = false;
                this.WentInInventory = true;
            }
            else if (this.SwordDrawn == true)
            {
                Console.WriteLine("Your sword is already drawn.");
                this.WentInInventory = true;
            } 
            else
            {
                this.SwordDrawn = true;
                Console.WriteLine("a brilliance flashes off the steel as you draw your sword.");
                this.WentInInventory = true;
            }
        }
        public void SheathSword()
        {
            if (this.SwordDrawn == false)
            {
                Console.WriteLine("Your sword isn't drawn");
                this.WentInInventory = true;
            }
            else
            {
                Console.WriteLine("the ringing of cold steel is muffled as you sheath your sword.");
                this.SwordDrawn = false;
                this.WentInInventory = true;
            }
        }
        public void LightTorch()
        {
            if (this.TorchOut == true)
            {
                Console.WriteLine("Your torch is already ablaze with a white hot fury.");
                this.SwordDrawn = false;
                this.WentInInventory = true;
            }
            else if (this.SwordDrawn == true)
            {
                Console.WriteLine("you sheath your sword and light your torch.");
                this.WentInInventory = true;
            }
            else                
            { 
            Console.WriteLine("In a blaze of glory you light your torch.");
            this.TorchOut = true;
            this.WentInInventory = true;
            }
        }
        public void PutOutTorch()
        {
            if (this.TorchOut == true)
            {
                Console.WriteLine("In a cloud of smoke you extinguish your torch.");
                this.TorchOut = false;
                this.WentInInventory = true;
            }
            else
            {
                Console.WriteLine("In the darkness you ponder what you're trying to put out.");
                this.WentInInventory = true;
            }

        }
        public void PlayerDeath()
        {
            Console.WriteLine("You Life has come to a close!");
            this.IsAlive = false;
        }
        public bool PlayerLiving()
        {
            return this.IsAlive;
        }
        public int GetPlayerLocation()
        {
            return this.PlayerLocation;
        }
        public void MovePlayerForward()
        {
            this.PlayerLocation ++;
            this.WentInInventory = false;
        }
        public void MovePlayerBack()
        {
            this.PlayerLocation--;
            this.WentInInventory = false;
        }
        public bool GetWentInInventory()
        {
            return this.WentInInventory;
        }
        public bool GetSwordStatus()
        {
            return this.SwordDrawn;
        }
        public bool GetTorchStatus()
        {
            return this.TorchOut;
        }
        public void CallHelp()
        {
            Console.WriteLine("Available Commands include: Draw Sword, Sheath Sword, Light Torch, Put Out Torch, Go Forward, Go Back");
            this.WentInInventory = true;
        }
    }
    }

