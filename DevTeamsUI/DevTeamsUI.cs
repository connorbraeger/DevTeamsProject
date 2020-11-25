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
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        public void Run()
        {
            SeedDevDirectory();
            MainMenu();
        }
        public void MainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Enter Individual Developer Menu \n" +
                    "2. Enter Developer Team Mamangement Menu \n" +
                    "3. Exit Program\n");
                    
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        DeveloperMenu();
                        break;
                    case "2":
                        DeveloperTeamsMenu();
                        break;
                    case "3":
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
        private void DeveloperMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Developer By ID number\n" +
                    "4. Determine if Developer has access to Pluralsight\n" +
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
        private void DeveloperTeamsMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Developer Team\n" +
                    "2. View All Developer Teams\n" +
                    "3. Add Developer to Team\n" +
                    "4. Remove Developer from Team\n" +
                    "5. Delete Developer from Team" +
                    "6. Exit");
                string input = Console.ReadLine();
                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        CreateNewDeveloperTeam();
                        break;
                    case "2":
                        DisplayAllDeveloperTeams();
                        break;
                    case "3":
                        AddDeveloperToTeam();
                        break;
                    case "4":
                        RemoveDeveloperFromTeam();
                        break;
                    case "5":
                        DeleteDeveloperTeam();
                        break;
                    case "6":
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
                        Console.WriteLine("Developer does have access");
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
        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Please enter employee ID number from list:");
            DisplayAllDevelopers();
            int id = int.Parse(Console.ReadLine());
            Developer newDev = new Developer();
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
            bool wasUpdated = _devRepo.UpdateExistingDirectory(id, newDev);
            if (wasUpdated)
            {
                Console.WriteLine("Developer information updated.");
            }
            else
            {
                Console.WriteLine("Developer information could not be updated");
            }
        }
        private void DeleteExistingDeveloper()
        {
            Console.Clear();
            DisplayAllDevelopers();
            Console.WriteLine("Enter in ID number of Developer to be removed");
            int id  = int.Parse(Console.ReadLine());
            bool wasDeleted = _devRepo.RemoveDeveloperFromDirectory(id);
            if (wasDeleted)
            {
                Console.WriteLine("The developer was removed from the list");
            }
            else
            {
                Console.WriteLine("The Developer could not be deleted");
            }
            
        }
        private void SeedDevDirectory()
        {
            Developer dev1 = new Developer("Braeger", "Connor", 1, true);
            Developer dev2 = new Developer("Wadman", "Amanda", 2, false);
            Developer dev3 = new Developer("Strife", "Cloud", 3, true);
            _devRepo.AddDeveloperToDirectory(dev1);
            _devRepo.AddDeveloperToDirectory(dev2);
            _devRepo.AddDeveloperToDirectory(dev3);

        }
        private void CreateNewDeveloperTeam()
        {
            Console.Clear();
            bool validNewName = false;
            Console.WriteLine("Please enter a valid team name:");
            string name = Console.ReadLine();
            while (!validNewName)
            {
                if (_devTeamRepo.IsNameTaken(name))
                {
                    Console.WriteLine("Name is already taken.");

                }
                else
                {
                    DevTeam newDevTeam = new DevTeam{ TeamName= name};
                    _devTeamRepo.AddDevTeam(newDevTeam);
                    Console.WriteLine("New Team created. Would you like to add members to team now? (y/n)");
                    validNewName = true;
                    bool isValidInput = false;
                    while (!isValidInput)
                    {
                        string access = Console.ReadLine().ToLower();
                        if (access == "y")
                        {
                            AddDeveloperToTeam();
                            isValidInput = true;

                        }
                        else if (access == "n")
                        {
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
        public void DisplayUnassignedDevelopers()
        {
            List<Developer> unassignedDevelopers = _devRepo.GetListofUnassignedDevelopers();
            if (unassignedDevelopers == null)
            {
                Console.WriteLine("All Developers are currently assigned.");
            }
            else
            {
                foreach (Developer dev in unassignedDevelopers)
                {
                    Console.WriteLine(dev.ToString() + "\n");
                }
            }
        }
        public void DisplayAllDeveloperTeams()
        {
            Console.Clear();
            List<DevTeam> devTeams = _devTeamRepo.GetDevTeamList();
            foreach (DevTeam devTeam in devTeams)
            {
                Console.WriteLine($"Dev Team: {devTeam.TeamName}");
            }
        }
        public void AddDeveloperToTeam()
        {
            Console.Clear();
            bool validTeamName = false;
            while (!validTeamName)
            {
                DisplayAllDeveloperTeams();
                Console.WriteLine("Please enter name of team");
                string teamName = Console.ReadLine().ToLower();
                DevTeam newDevTeam = _devTeamRepo.GetDevTeamById(teamName);
                if (newDevTeam != null)
                {
                    validTeamName = true;
                    bool validIdNumber = false;
                    while (!validIdNumber) {
                        Console.WriteLine("Please enter the ID number of an unassigned Team member");
                        int idNumber;
                        bool isNumber = int.TryParse(Console.ReadLine(), out idNumber);
                        if (isNumber)
                        {
                            Developer newDev = _devRepo.GetDeveloperById(idNumber);
                            if (newDev == null)
                            {
                                Console.WriteLine("Id invalid");
                            }
                            else if (newDev.IsAssigned)
                            {
                                Console.WriteLine("Developer is already assigned to a team");//need to add option to switch developer to different team...
                            }
                            else
                            {
                                newDev.IsAssigned = true;
                                _devRepo.UpdateExistingDirectory(idNumber, newDev);
                                newDevTeam.CurrentDevs.Add(newDev);
                                _devTeamRepo.UpdateDevTeamList(teamName, newDevTeam);
                                validIdNumber = true;
                            }
                        }
                } 
                }
            }
        }
        public void RemoveDeveloperFromTeam()
        {

        }
        public void DeleteDeveloperTeam() { }
    }
}
