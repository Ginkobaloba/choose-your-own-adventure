using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLists
{
    class TeamNameList
    {
       public List<string> teamNames = new List<string>();

        public void populateTeamNameList()
        {
            teamNames.Add("Brewers");
            teamNames.Add("Cubs");
        }
    }
}
