using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsUI
{
    class DevTeamsUI
    {
        private DeveloperRepo _devRepo = new DeveloperRepo();
        public void Run()
        {
            SeedDevDirectory();
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Developer By ID number\n" +
                    "4. Determine if Developer has access to Pluralsight" +
                    "5. Update Existing Developer\n" +
                    "6. Delete Existing Developer\n" +
                    "7. Exit");
                string input = Console.ReadLine();
                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;
                    case "2":
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        DisplayDeveloperById();
                        break;
                    case "4":
                        CheckAccess();
                        break;
                    case "5":
                        UpdateExistingDeveloper();
                        break;
                    case "6":
                        DeleteExistingDeveloper();
                        break;
                    case "7":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDev = new Developer();
            Console.WriteLine("Please input the employee ID number");
            newDev.IDNumber = int.Parse(Console.ReadLine());
            if (_devRepo.IsInDirectory(newDev))

            {
                Console.WriteLine("This ID number is already in use in the directory");
            }
            else
            {
                Console.WriteLine("Please enter Last Name of Developer");
                newDev.LastName = Console.ReadLine();
                Console.WriteLine("Please enter First Name of Developer");
                newDev.FirstName = Console.ReadLine();
                Console.WriteLine("Does Developer have PluralSight access? (y/n)");
                bool isValidInput = false;
                while (!isValidInput)
                {
                    string access = Console.ReadLine().ToLower();
                    if (access == "y")
                    {
                        newDev.HasAccessToPluralsight = true;
                        isValidInput = true;
                    }
                    else if (access == "n")
                    {
                        newDev.HasAccessToPluralsight = false;
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid input");
                    }
                }
                _devRepo.AddDeveloperToDirectory(newDev);
            }
        }
        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<Developer> directoryOfDevs = _devRepo.GetDeveloperDirectory();
            foreach (Developer dev in directoryOfDevs)
            {
                Console.WriteLine($"Last Name : {dev.LastName} \n" +
                    $"First Name : {dev.FirstName} \n" +
                    $"ID Number: {dev.IDNumber}");
            }
        }
        private void DisplayDeveloperById()
        {
            Console.Clear();
            Console.WriteLine("Please enter in developer ID number");//need to error proof for non int inputs
            int id = int.Parse(Console.ReadLine());
            Developer dev = _devRepo.GetDeveloperById(id);
            Console.WriteLine($"Last Name: {dev.LastName}\n" +
                $"First Name {dev.FirstName}\n");

        }
        private void CheckAccess()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning) {
                Console.WriteLine("Enter in ID number of employee to check status of Pluralsight Access");
                int id = int.Parse(Console.ReadLine());
                Developer dev = _devRepo.GetDeveloperById(id);
                if (dev != null)
                {
                    if (dev.HasAccessToPluralsight)
                    {
                        Console.WriteLine("Developer does has access");
                        keepRunning = false;
                    }
                    else
                    {
                        Console.WriteLine("Developer does not have access");
                        keepRunning = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID. Try again?(y/n)");
                    bool isValidInput = false;
                    while (!isValidInput)
                    {
                        string shouldContinue = Console.ReadLine().ToLower();
                        if (shouldContinue == "y")
                        {

                            isValidInput = true;
                        }
                        else if (shouldContinue == "n")
                        {
                            keepRunning = false;
                            isValidInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid input");
                        }
                    }

                }
            }
        }
    }
}
