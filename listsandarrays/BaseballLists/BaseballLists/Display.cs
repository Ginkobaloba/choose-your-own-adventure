using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLists
{
    class Display
    {
        public List<string> teamNames = new List<string>();
        static void Main(string[] args)

        {
            TeamNameList teamList = new TeamNameList();
            teamList.populateTeamNameList();
            PlayerNameLists playerNameList = new PlayerNameLists();
            playerNameList.populatePlayersNameTeam0();
            playerNameList.populatePlayersNameTeam1();



            foreach (string playerName in playerNameList.playersNameTeam0)
            {
                Console.WriteLine(teamList.teamNames[0]);
                Console.WriteLine(playerName);
                Console.ReadLine();
            }
            foreach (string playerName in playerNameList.playersNameTeam1)
            {
                Console.WriteLine(teamList.teamNames[1]);
                Console.WriteLine(playerName);
                Console.ReadLine();

            }


        }
    }
}
