using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam//should make constructor that takes a list of devs
    {
        public string TeamName { get; set; }
        public DeveloperRepo DevsInTeam { get; set; }
        public DevTeam()
        {
            DevsInTeam = new DeveloperRepo();
            TeamName = "";
        }
        public DevTeam(string teamName)
        {
            TeamName = teamName;
            DevsInTeam = new DeveloperRepo();
        }
        public DevTeam(string teamName, DeveloperRepo devsInTeam)
        {
            TeamName = teamName;
            DevsInTeam.SetEqual(devsInTeam);
        }
        public bool SetEqual(DevTeam devTeam)
        {
            if (devTeam == null)
            {
                return false;
            }
            TeamName = devTeam.TeamName;
            DevsInTeam.SetEqual(devTeam.DevsInTeam);
            return true;
        }
    }
}
