using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int IDNumber { get; set; }
        public bool HasAccessToPluralsight { get; set; }
        public bool IsAssigned { get; set; }
        public Developer() { }
        public Developer(string lastName, string firstName,int idNumber, bool hasAccess)
        {
            LastName = lastName;
            FirstName = firstName;
            IDNumber = idNumber;
            HasAccessToPluralsight = hasAccess;
            IsAssigned = false;
        }
        public override string ToString()
        {
            string devString = $"Name: {FirstName} {LastName}; ID Number = {IDNumber}";
            return devString;
        }
        public void SetEqual(Developer dev)
        {
            LastName = dev.LastName;
            FirstName = dev.FirstName;
            IDNumber = dev.IDNumber;
            HasAccessToPluralsight = dev.HasAccessToPluralsight;
            IsAssigned = dev.IsAssigned;
        }
    }
}
