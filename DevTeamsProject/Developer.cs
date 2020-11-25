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
        
        public Developer() { }
        public Developer(string lastName, string firstName, bool hasAccess)
        {
            LastName = lastName;
            FirstName = firstName;
            HasAccessToPluralsight = hasAccess;
        }
    }
}
