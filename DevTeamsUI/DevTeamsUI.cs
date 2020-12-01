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
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Developer By ID number\n" +
                    "4. Determine if Developer has access to Pluralsight\n" +
                    "5. Display list of Developers that need Pluralsight licesnse\n" +
                    "6. Update Existing Developer\n" +
                    "7. Delete Existing Developer\n" +
                    "8. Exit");
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
                        DisplayDevsWithoutPlural();
                        break;
                    case "6":
                        UpdateExistingDeveloper();
                        break;
                    case "7":
                        DeleteExistingDeveloper();
                        break;
                    case "8":
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
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Developer Team\n" +
                    "2. View All Developer Teams\n" +
                    "3. Add Developer to Team\n" +
                    "4. Remove Developer from Team\n" +
                    "5. Delete Developer Team\n" +
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
            bool isValid = false;
            while (!isValid)
            {
                int id;
                List<Developer> count = _devRepo.GetDeveloperDirectory();
                Console.WriteLine("Please input the employee ID number or press x to exit. ID numbers should be sequential. Suggested ID number is " + (count.Count() + 1));
                string input = Console.ReadLine().ToLower();
                bool isInt = int.TryParse(input, out id);
                if (isInt)
                {
                    Developer newDev = new Developer();
                    newDev.IDNumber = id;
                    if (_devRepo.IsInDirectory(newDev))
                    {
                        Console.WriteLine("This ID number is already in use in the directory");
                    }
                    else
                    {
                        isValid = true;
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
                else if (input == "x")
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Please input new ID number");
                }
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
                    $"ID Number: {dev.IDNumber} \n");
            }
        }
        private void DisplayDeveloperById()
        {
                Console.Clear();
            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.WriteLine("Please enter in developer ID number or type x to exit");
                int id;
                string input = Console.ReadLine().ToLower();
                bool isInt = int.TryParse(input, out id);
                if (isInt)
                {
                    Developer dev = _devRepo.GetDeveloperById(id);
                    if (dev != null) { 
                    Console.WriteLine($"Last Name: {dev.LastName}\n" +
                        $"First Name {dev.FirstName}\n");
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a vaid ID number.");
                    } 
                }else if(input == "x")
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Please input a numerical ID or x");
                }
            }
        }
        private void CheckAccess()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Enter in ID number of employee to check status of Pluralsight Access or type x to exit");
                int id;
                string input = Console.ReadLine();
                bool isInt = int.TryParse(input, out id);
                if (isInt)
                {
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
                else if (input.ToLower() == "x")
                {
                    keepRunning = false;
                }
                else
                {
                    Console.WriteLine("Please input a numerical ID or x");
                }
            }
        }
        private void DisplayDevsWithoutPlural()
        {
            bool everyDevHasLicense = true;
            Console.WriteLine("The following developers need a Pluralsight license:");
            foreach (Developer dev in _devRepo.GetDeveloperDirectory())
            {
                if (!dev.HasAccessToPluralsight)
                {
                    Console.WriteLine(dev.ToString());
                    everyDevHasLicense = false;
                }
            }
            if (everyDevHasLicense)
            {
                Console.WriteLine("There are no unlicensed developers");
            }
        }
        private void UpdateExistingDeveloper() { 
                Console.Clear();
                DisplayAllDevelopers();
        
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please enter employee ID number from list or type x to exit:");
                int id;
                string input = Console.ReadLine();
                bool isInt = int.TryParse(input, out id);
                if (isInt)
                {
                    Developer newDev = _devRepo.GetDeveloperById(id);
                    if (newDev != null)
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
                    else
                    {
                        Console.WriteLine("Please enter in a vid ID number");
                    }
                }
                else if (input == "x")
                {
                    keepRunning = false;
                }
                else
                {
                    Console.WriteLine("Please input a valid numerical ID or x");
                }
            }
        }
        private void DeleteExistingDeveloper()
        {
            Console.Clear();
            DisplayAllDevelopers();
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Enter in ID number of Developer to be removed or press x to exit");
                int id;
                string input = Console.ReadLine();
                bool isInt = int.TryParse(input, out id);
                if (isInt)
                {
                    Developer newDev = _devRepo.GetDeveloperById(id);
                    if (newDev != null)
                    {
                        bool wasDeleted = _devRepo.RemoveDeveloperFromDirectory(id);
                        if (wasDeleted)
                        {
                            Console.WriteLine("The developer was removed from the list");
                            keepRunning = false;
                        }
                        else
                        {
                            Console.WriteLine("The Developer could not be deleted");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID not valid.");
                    }
                }
                else if (input.ToLower() == "x")
                {
                    keepRunning = false;
                }
                else
                {

                    Console.WriteLine("Invalid input");
                }
            }
        }
        private void SeedDevDirectory()
        {
            Developer dev1 = new Developer("Braeger", "Connor", 1, true);
            Developer dev2 = new Developer("Wadman", "Amanda", 2, false);
            Developer dev3 = new Developer("Strife", "Cloud", 3, true);
            Developer dev4 = new Developer("Potter", "Harry", 4, true);
            Developer dev5 = new Developer("Rivers", "Philip", 5, false);
            Developer dev6 = new Developer("Jordan", "Michael", 6, true);
            _devRepo.AddDeveloperToDirectory(dev1);
            _devRepo.AddDeveloperToDirectory(dev2);
            _devRepo.AddDeveloperToDirectory(dev3);
            _devRepo.AddDeveloperToDirectory(dev4);
            _devRepo.AddDeveloperToDirectory(dev5);
            _devRepo.AddDeveloperToDirectory(dev6);
            DevTeam devTeam1 = new DevTeam("team1");
            devTeam1.DevsInTeam.AddDeveloperToDirectory(dev1);
            dev1.IsAssigned = true;
            _devRepo.UpdateExistingDirectory(1, dev1);
            devTeam1.DevsInTeam.AddDeveloperToDirectory(dev6);
            dev6.IsAssigned = true;
            _devRepo.UpdateExistingDirectory(6, dev6);
            DevTeam devTeam2 = new DevTeam("team2");
            devTeam2.DevsInTeam.AddDeveloperToDirectory(dev2);
            dev2.IsAssigned = true;
            _devRepo.UpdateExistingDirectory(2, dev2);
            devTeam2.DevsInTeam.AddDeveloperToDirectory(dev4);
            dev4.IsAssigned = true;
            _devRepo.UpdateExistingDirectory(4, dev4);
            _devTeamRepo.AddDevTeam(devTeam1);
            _devTeamRepo.AddDevTeam(devTeam2);



        }
        private void CreateNewDeveloperTeam()
        {
            Console.Clear();
            DisplayAllDeveloperTeams();
            bool validNewName = false;
            while (!validNewName)
            {
                Console.WriteLine("Please enter a new team name:");
                string name = Console.ReadLine();
                if (_devTeamRepo.IsNameTaken(name))
                {
                    Console.WriteLine("Name is already taken.");

                }
                else
                {
                    DevTeam newDevTeam = new DevTeam { TeamName = name };
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
                Console.WriteLine($"Dev Team: {devTeam.TeamName}\n" +
                    $"Members: {devTeam.DevsInTeam.ToString()}\n");
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
                DevTeam newDevTeam = new DevTeam();
                newDevTeam.SetEqual(_devTeamRepo.GetDevTeamById(teamName));
                if (newDevTeam != null)
                {
                    validTeamName = true;
                    bool validIdNumber = false;
                    while (!validIdNumber)
                    {
                        DisplayUnassignedDevelopers();
                        Console.WriteLine("Please enter the ID number of an unassigned developer member");
                        int idNumber;
                        bool isNumber = int.TryParse(Console.ReadLine(), out idNumber);
                        if (isNumber)
                        {
                            bool hasBeenReassigned = false;
                            Developer newDev = new Developer();
                            newDev.SetEqual(_devRepo.GetDeveloperById(idNumber));
                            if (newDev == null)
                            {
                                Console.WriteLine("Id invalid");
                            }
                            else if (newDev.IsAssigned||hasBeenReassigned)
                            {
                                Console.WriteLine("Developer is already assigned to a team. Would you like to switch " + newDev.FirstName + " " + newDev.LastName + " to a new team? (y/n)");//need to add option to switch developer to different team...
                                bool isValidInput = false;
                                while (!isValidInput)
                                {
                                    string input = Console.ReadLine().ToLower();
                                    if (input == "y")
                                    {
                                        ChangeTeam(newDevTeam, newDev);
                                        isValidInput = true;
                                        hasBeenReassigned = true;
                                        validIdNumber = true;
                                    }
                                    else if (input == "n")
                                    {
                                        isValidInput = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("invalid input");
                                    }
                                }
                            }
                            else
                            {
                                newDev.IsAssigned = true;
                                _devRepo.UpdateExistingDirectory(idNumber, newDev);
                                newDevTeam.DevsInTeam.AddDeveloperToDirectory(newDev);
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

            Console.Clear();
            bool validTeamName = false;
            while (!validTeamName)
            {
                DisplayAllDeveloperTeams();
                Console.WriteLine("Please enter name of team");
                string teamName = Console.ReadLine().ToLower();
                DevTeam newDevTeam = new DevTeam();
                bool wasAssigned =newDevTeam.SetEqual(_devTeamRepo.GetDevTeamById(teamName));
                if (wasAssigned)
                {
                    validTeamName = true;
                    bool validIdNumber = false;
                    while (!validIdNumber)
                    {
                        Console.WriteLine("Please enter the ID number of an assigned Team member");
                        int idNumber;
                        bool isNumber = int.TryParse(Console.ReadLine(), out idNumber);
                        if (isNumber)
                        {
                            Developer newDev = new Developer();
                            newDev.SetEqual(_devRepo.GetDeveloperById(idNumber));
                            if (newDev == null)
                            {
                                Console.WriteLine("Id invalid");
                            }
                            else if (!newDev.IsAssigned)
                            {
                                Console.WriteLine("Developer is not assigned to a team");//need to add option to switch developer to different team...
                            }
                            else
                            {
                                newDev.IsAssigned = false;
                                _devRepo.UpdateExistingDirectory(idNumber, newDev);
                                newDevTeam.DevsInTeam.RemoveDeveloperFromDirectory(idNumber);
                                _devTeamRepo.UpdateDevTeamList(teamName, newDevTeam);
                                validIdNumber = true;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter name of an existing team");
                }
            }
        }
        public void DeleteDeveloperTeam()
        {
            Console.Clear();
            bool validTeamName = false;
            while (!validTeamName)
            {
                DisplayAllDeveloperTeams();
                Console.WriteLine("Please enter name of team");
                string teamName = Console.ReadLine().ToLower();
                DevTeam delDevTeam = new DevTeam();
                bool wasAssigned = delDevTeam.SetEqual(_devTeamRepo.GetDevTeamById(teamName));
                if (wasAssigned)
                {
                    validTeamName = true;
                    bool wasDeleted;
                    wasDeleted = _devTeamRepo.DeleteDeveloperTeam(delDevTeam);
                    if (wasDeleted)
                    {
                        Console.WriteLine("Developer team was deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Unable to delete developer team.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
        public void ChangeTeam(DevTeam devTeam, Developer dev)
        {
            Console.Clear();
            dev.IsAssigned = false;
            _devRepo.UpdateExistingDirectory(dev.IDNumber, dev);
            devTeam.DevsInTeam.RemoveDeveloperFromDirectory(dev.IDNumber);
            _devTeamRepo.UpdateDevTeamList(devTeam.TeamName, devTeam);
            DisplayAllDeveloperTeams();
            DisplayUnassignedDevelopers();//test
            Console.WriteLine($"Which team would you like add {dev.FirstName} {dev.LastName} to?");
            bool validTeamName = false;
            while (!validTeamName)
            {
                string teamName = Console.ReadLine().ToLower();
                DevTeam newDevTeam = new DevTeam();
                bool nowEqual = newDevTeam.SetEqual(_devTeamRepo.GetDevTeamById(teamName));
                if (nowEqual)
                {
                    validTeamName = true;
                    newDevTeam.DevsInTeam.AddDeveloperToDirectory(dev);
                    _devTeamRepo.UpdateDevTeamList(teamName, newDevTeam);
                    Console.WriteLine($"{dev.FirstName} {dev.LastName} added to {newDevTeam.TeamName}");
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                }
            }
        }
    }
}
