using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public bool AddDeveloperToDirectory(Developer developer)
        {
           if (IsInDirectory(developer)){
                return false;
            }
            else
            {
                _developerDirectory.Add(developer);
                return true;
            }

        }
        //Developer Read

        public List<Developer> GetDeveloperDirectory()
        {
            return _developerDirectory;
        }
        //Developer Update
        public bool UpdateExistingDirectory(int idNumber, Developer developer)
        {
            Developer oldInfo = GetDeveloperById(idNumber);
            if (oldInfo != null)
            {
                oldInfo.FirstName = developer.FirstName;
                oldInfo.LastName = developer.LastName;
                oldInfo.HasAccessToPluralsight = developer.HasAccessToPluralsight;
                oldInfo.IDNumber = developer.IDNumber;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Developer Delete
        public bool RemoveDeveloperFromDirectory(int idNumber)
        {
            Developer dev = GetDeveloperById(idNumber);
            if(dev == null)
            {
                return false;
            }
            else
            {
                int count = _developerDirectory.Count();
                _developerDirectory.Remove(dev);
                if (count > _developerDirectory.Count())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //Developer Helper (Get Developer by ID)
        private Developer GetDeveloperById(int id)
        {
            foreach (Developer item in _developerDirectory)
            {
                if(item.IDNumber == id)
                {
                    return item;
                }

            }
            return null;
        }
        private bool IsInDirectory(Developer developer)
        {
            bool isMatch = false;
            foreach (Developer item in _developerDirectory)
            {
                if(developer.IDNumber == item.IDNumber)
                {
                    isMatch = true;
                }
            }
            return isMatch;
        }
    }
}
