using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create
        public bool AddDevTeam(DevTeam devTeam)
        {
            if (IsNameTaken(devTeam.TeamName))
            {
                return false;
            }
            else
            {
                _devTeams.Add(devTeam);
                return true;
            }
        }

        //DevTeam Read

        public List<DevTeam> GetDevTeamList()
        {
            return _devTeams;
        }
        //DevTeam Update

        public bool UpdateDevTeamList(string id, DevTeam team)
        {
            DevTeam oldTeam = GetDevTeamById(id);
            if(oldTeam != null)
            {
                oldTeam.SetEqual(team);
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Delete
        public bool DeleteDeveloperTeam(DevTeam team)
        {
            if (GetDevTeamById(team.TeamName) == null)
            {
                return false;
            }
            else
            {
                
              
                team.DevsInTeam.UnAssignAllDevs();
                int count = _devTeams.Count();
                foreach (DevTeam devTeam in _devTeams)
                {
                    if( devTeam.TeamName == team.TeamName){
                        _devTeams.Remove(devTeam);
                        break;
                    }
                }
                if(count > _devTeams.Count())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDevTeamById(string id)
        {
            foreach (DevTeam team in _devTeams)
            {
                if (id.ToLower() == team.TeamName.ToLower())
                {
                    return team;
                }
            }return null;
        }
        public bool IsNameTaken(string teamName)
        {
            bool isTaken = false;
            foreach (DevTeam team in _devTeams)
            {
                if (team.TeamName.ToLower() == teamName)
                {
                    isTaken = true;
                }
            }
            return isTaken;
        }
    }
}
