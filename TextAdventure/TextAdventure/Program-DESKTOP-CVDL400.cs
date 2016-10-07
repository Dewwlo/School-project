using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextAdventure
{
    class Program
    {
        public static List<Item> inventory = new List<Item>();
        public static List<Location> allRooms = Location.LocationList();
        public static List<Item> allItem = Item.ItemList();
        public static List<Doors> allDoors = Doors.Doorlist();
        public static List<Character> chosenCharacter = new List<Character>();
        public static string messageToScreen = "";
        public static int currentRoom = 0;
        public static int lastRoom = 0;
        public static string command = "";
        public static int charChoice = -1;



        // RoomMap 
        //        North      
        //          4       12--13
        //          |       |
        //  2---1---3---6---11
        //      |   |   |
        //      0   5   7---9---10
        //              |
        //              8

        static void Main(string[] args)
        {
            #region Intro

            while (true)
            {
                Console.WriteLine("Choose a character:");
                ShowCharacterLoop();

                try
                {
                    charChoice = int.Parse(Console.ReadLine());
                    charChoice--;
                    if ((charChoice != -1) && (charChoice < Character.CharacterList().Count))
                    {
                        chosenCharacter.Add(Character.CharacterList()[charChoice]);
                        Console.WriteLine(string.Format("\nYou choose {0}\n{1}\n{2}\n", chosenCharacter[0].Name, chosenCharacter[0].CharDescription, chosenCharacter[0].ReasonInprison));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You did not choose a character, try again\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("You did not enter a number, try again\n");
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Type \"help\" to see useful commands\n");
            Console.WriteLine("{0}\n", allRooms[currentRoom].EnterFirstTime);

            #endregion

            while (command != "exit")
            {
                Console.Write("\nInput Command ");
                command = Console.ReadLine().ToLower().Trim();

                Console.Clear();

                GetCommand(command);

                Console.WriteLine(messageToScreen);
                messageToScreen = "";
                CheckEndingCondition();
            }
        }

        #region Commands

        public static void GetCommand(string command)
        {

            Program instance = new Program();

            string[] array = command.Split(' ');

            switch (array[0])
            {
                case "get":
                    instance.GetItem(command);
                    break;
                case "inspect":
                    instance.InspectItem(command);
                    break;
                case "drop":
                    instance.DropItem(command);
                    break;
                case "help":
                    instance.HelpCommands(command);
                    break;
                case "go":
                    instance.Go(command);
                    break;
                case "look":
                    instance.Look(command);
                    break;
                case "use":
                    instance.Use(command);
                    break;
                case "inventory":
                    instance.ShowInventory();
                    break;
                case "exit":
                    messageToScreen = "Application will now terminate, press enter to exit";
                    break;
                default:
                    messageToScreen = "Not a valid command";
                    break;
            }
        }

        public void HelpCommands(string command)
        {
            for (int i = 0; i < Command.CommandList().Count; i++)
            {
                Console.Write(Command.CommandList()[i].Action.PadRight(30));
                Console.WriteLine(Command.CommandList()[i].Description);
            }
        }

        public void InspectItem(string command)
        {

            foreach (var item in inventory)
            {
                if (command.IndexOf(item.Name.ToLower()) != -1)
                {
                    messageToScreen = item.Description;
                }
            }
            foreach (var door in allDoors)
            {
                if (command.IndexOf(door.Name.ToLower()) != -1)
                {
                    messageToScreen = door.Description;
                }
            }
            if (messageToScreen == "")
            {
                messageToScreen = "Could not inspect that.";
            }
        }

        public void GetItem(string command)
        {
            if (inventory.Count <= 1)
            {
                for (int i = 0; i < allItem.Count; i++)
                {
                    if ((command.IndexOf(allItem[i].Name.ToLower()) != -1) && (allItem[i].Available == true) && (currentRoom == allItem[i].LocationFound))
                    {
                        inventory.Add(allItem[i]);
                        messageToScreen = string.Format("You added {0} to your inventory", allItem[i].Name);
                        allItem[i].Available = false;
                    }
                }
            }
            else
            {
                messageToScreen = "Inventory is full, drop something to pick that up";
            }
            if (messageToScreen == "")
            {
                messageToScreen = "could not get that";
            }
        }

        public void Go(string command)
        {
            string[] array = command.Split(' ');

            if (("go" == array[0]) && array.Length >= 2)
            {
                switch (array[1])
                {
                    case "east":
                        CheckValidPathEast(currentRoom);
                        break;
                    case "west":
                        CheckValidPathWest(currentRoom);
                        break;
                    case "north":
                        CheckValidPathNorth(currentRoom);
                        break;
                    case "south":
                        CheckValidPathSouth(currentRoom);
                        break;
                    default:
                        messageToScreen = "Not a valid path";
                        break;
                }
                ValitedatePathway();
            }
        }

        public void DropItem(string command)
        {
            if (command.IndexOf("drop") != -1)
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (command.IndexOf(inventory[i].Name.ToLower()) != -1)
                    {

                        for (int a = 0; a < allItem.Count; a++)
                        {
                            if (inventory[i].Name == allItem[a].Name)
                            {
                                allItem[a].LocationFound = currentRoom;
                                allItem[a].Available = true;
                            }
                        }
                        messageToScreen = string.Format("You dropped {0}", inventory[i].Name);
                        inventory.RemoveAt(i);
                    }
                }
            }
            if (messageToScreen == "")
            {
                messageToScreen = "could not drop that";
            }
        }

        public void Look(string command)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in allItem)
            {
                if ((item.LocationFound == currentRoom) && (item.Available == true))
                {
                    sb.Append(item.Name).Append("\n");
                }
            }
            if (sb.Length == 0)
            {
                sb.Append("No items found");
            }

            messageToScreen = string.Format("{0}\n\nITEMS Available:\n{1}", allRooms[currentRoom].LookAround, sb);
        }

        public void Use(string command)
        {

            for (int i = 0; i < allDoors.Count; i++)
            {
                foreach (var item in inventory)
                {
                    if ((command.IndexOf(item.Name.ToLower()) != -1) &&
                        (item.Name.ToLower() == allDoors[i].ItemToUnlock) &&
                        (command.IndexOf("on") != -1) &&
                        (command.IndexOf(allDoors[i].Name) != -1) &&
                        (allRooms[allDoors[i].RoomUnlocked].IfRoomIsOpen == false))
                    {
                        allDoors[i].IfRoomOpen = true;
                        messageToScreen = allDoors[i].HappeningOnUse;
                        allRooms[allDoors[i].RoomUnlocked].IfRoomIsOpen = true;
                    }

                    else if ((command.IndexOf(item.Name.ToLower()) != -1) &&
                             (item.Name.ToLower() == allDoors[i].ItemToUnlock) &&
                             (command.IndexOf("on") != -1) &&
                             (command.IndexOf(allDoors[i].Name) != -1) &&
                             (allRooms[allDoors[i].RoomUnlocked].IfRoomIsOpen == true))
                    {
                        messageToScreen = "Room is already available";
                    }

                    else if (messageToScreen == "")
                    {
                        messageToScreen = "Could not use or find that item";
                    }
                }
                if (messageToScreen == "")
                {
                    messageToScreen = "You dont have any items";
                }
            }
        }

        #endregion

        #region Validate

        public void ValitedatePathway()
        {
            if (lastRoom != currentRoom)
            {

                if (allRooms[currentRoom].IfRoomIsOpen == true)
                {
                    if (allRooms[currentRoom].CheckIfDiscoveredRoom == true)
                    {
                        messageToScreen = allRooms[currentRoom].RevisitRoom;
                    }
                    else if (allRooms[currentRoom].CheckIfDiscoveredRoom == false)
                    {
                        messageToScreen = allRooms[currentRoom].EnterFirstTime;
                    }
                    lastRoom = currentRoom;
                    allRooms[currentRoom].CheckIfDiscoveredRoom = true;
                }
                else
                {
                    messageToScreen = "You could not access that, either the door is locked or the pathway is blocked";
                    currentRoom = lastRoom;
                }
            }
        }

        public void CheckValidPathEast(int direction)
        {

            switch (direction)
            {
                case 1:
                    currentRoom = 3;
                    break;
                case 2:
                    currentRoom = 1;
                    break;
                case 3:
                    currentRoom = 6;
                    break;
                case 6:
                    currentRoom = 11;
                    break;
                case 7:
                    currentRoom = 9;
                    break;
                case 9:
                    currentRoom = 10;
                    break;
                case 12:
                    currentRoom = 13;
                    break;
                default:
                    messageToScreen = "You cannot go east";
                    break;
            }
        }

        public void CheckValidPathWest(int direction)
        {
            switch (direction)
            {
                case 1:
                    currentRoom = 2;
                    break;
                case 3:
                    currentRoom = 1;
                    break;
                case 6:
                    currentRoom = 3;
                    break;
                case 9:
                    currentRoom = 7;
                    break;
                case 10:
                    currentRoom = 9;
                    break;
                case 11:
                    currentRoom = 6;
                    break;
                case 13:
                    currentRoom = 12;
                    break;
                default:
                    messageToScreen = "You cannot go west";
                    break;
            }
        }

        public void CheckValidPathNorth(int direction)
        {
            switch (direction)
            {
                case 0:
                    currentRoom = 1;
                    break;
                case 3:
                    currentRoom = 4;
                    break;
                case 5:
                    currentRoom = 3;
                    break;
                case 7:
                    currentRoom = 6;
                    break;
                case 8:
                    currentRoom = 7;
                    break;
                case 11:
                    currentRoom = 12;
                    break;
                default:
                    messageToScreen = "You cannot go north";
                    break;
            }
        }

        public void CheckValidPathSouth(int direction)
        {
            switch (direction)
            {
                case 1:
                    currentRoom = 0;
                    break;
                case 3:
                    currentRoom = 5;
                    break;
                case 4:
                    currentRoom = 3;
                    break;
                case 6:
                    currentRoom = 7;
                    break;
                case 7:
                    currentRoom = 8;
                    break;
                case 12:
                    currentRoom = 11;
                    break;
                default:
                    messageToScreen = "You cannot go south";
                    break;
            }
        }

        #endregion

        public void ShowInventory()
        {
            if (inventory.Count != 0)
            {
                messageToScreen = " ";
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine(inventory[i].Name);
                }
            }
            else
            {
                messageToScreen = "Inventory is empty";
            }

        }

        public static void ShowCharacterLoop()
        {
            for (int i = 0; i < Character.CharacterList().Count; i++)
            {
                Console.WriteLine(string.Format("{0}. {1}", i + 1, Character.CharacterList()[i].Name));
            }
        }

        public static void CheckEndingCondition()
        {
            if (currentRoom == 13 || currentRoom == 10)
            {
                while (true)
                {
                    Console.Write("\nPlay again for an alternate ending? Y/N: ");
                    var replayOrExit = Console.ReadLine().ToLower().Trim();

                    if (replayOrExit == "n")
                    {
                        Environment.Exit(0);
                        break;
                    }
                    else if (replayOrExit == "y")
                    {
                        string myApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                        System.Diagnostics.Process.Start(myApp);
                        Environment.Exit(0);
                        break;
                    }
                }
            }
        }
    }
}
