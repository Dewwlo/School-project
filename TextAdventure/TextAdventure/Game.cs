using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TextAdventure.GameObjects;

namespace TextAdventure
{
    class Game
    {
        public static List<Item> Inventory = new List<Item>();
        public static List<Location> ListAllRooms = Location.LocationList();
        public static List<Item> ListAllItem = Item.ItemList();
        public static List<Doors> ListAllDoors = Doors.Doorlist();
        public static List<Character> ChosenCharacter = new List<Character>();
        public static string MessageToScreen = "";
        public static string Command = "";
        public static int CurrentRoom = 0;
        public static int LastRoom = 0;

        // RoomMap
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
                    var charChoice = int.Parse(Console.ReadLine());
                    charChoice--;

                    if ((charChoice != -1) && (charChoice < Character.CharacterList().Count))
                    {
                        ChosenCharacter.Add(Character.CharacterList()[charChoice]);
                        Console.WriteLine(string.Format("\nYou choose {0}\n{1}\n{2}\n", ChosenCharacter[0].Name, ChosenCharacter[0].Description, ChosenCharacter[0].ReasonInprison));
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You did not choose a character, try again\n");
                    }
                }
                catch (Exception exception)
                {
                    Console.Clear();
                    Console.WriteLine("You did not enter a number, try again\n");
                    using (StreamWriter sw = new StreamWriter(SiteConstants.PathToExceptionLog(), true))
                    {
                        sw.WriteLine(DateTime.Now + " " + exception.Message);
                    }
                }
            }

            #endregion

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Type \"help\" to see useful commands\n");
            Console.WriteLine("{0}", ListAllRooms[CurrentRoom].EnterFirstTime);
            Console.Write("\nITEMS Available:\n{0}", ListItemsInRoom());

            while (Command != "exit")
            {
                Console.Write("\nInput Command ");
                Command = Console.ReadLine().ToLower().Trim();

                Console.Clear();

                GetCommand(Command);

                Console.WriteLine(MessageToScreen);
                CheckEndingCondition();
                MessageToScreen = "";
            }
        }

        #region Commands

        public static void GetCommand(string command)
        {

            Game instance = new Game();

            string[] array = command.Split(' ');

            switch (array[0])
            {
                case "pickup":
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
                case "drink":
                    instance.Drink(command);
                    break;
                case "ultrahax":
                    MessageToScreen = "You cheat your way to the last room!\n" + ListAllRooms[12].EnterFirstTime;
                    CurrentRoom = 12;
                    ListAllRooms[CurrentRoom].CheckIfDiscoveredRoom = true;
                    break;
                case "attack":
                    instance.Attack();
                    break;
                default:
                    MessageToScreen = "Not a valid command";
                    break;
            }
        }

        public void HelpCommands(string command)
        {
            for (int i = 0; i < TextAdventure.Command.CommandList().Count; i++)
            {
                Console.Write(TextAdventure.Command.CommandList()[i].Action.PadRight(30));
                Console.WriteLine(TextAdventure.Command.CommandList()[i].Description);
            }
        }

        public void InspectItem(string command)
        {

            foreach (var item in ListAllItem)
            {
                if ((command.IndexOf(item.Name.ToLower()) != -1) && (CurrentRoom == item.LocationFound))
                {
                    MessageToScreen = item.Description;
                }
            }

            foreach (var item in Inventory)
            {
                if (command.IndexOf(item.Name.ToLower()) != -1)
                {
                    MessageToScreen = item.Description;
                }
            }

            foreach (var door in ListAllDoors)
            {
                if (command.IndexOf(door.Name.ToLower()) != -1)
                {
                    MessageToScreen = door.Description;
                }
            }

            if (MessageToScreen == "")
            {
                MessageToScreen = "Could not inspect that.";
            }
        }

        public void GetItem(string command)
        {
            if (Inventory.Count <= 2)
            {
                for (int i = 0; i < ListAllItem.Count; i++)
                {
                    if ((command.IndexOf(ListAllItem[i].Name.ToLower()) != -1) && (ListAllItem[i].Available == true) && (CurrentRoom == ListAllItem[i].LocationFound))
                    {
                        Inventory.Add(ListAllItem[i]);
                        MessageToScreen = string.Format("You added {0} to your inventory", ListAllItem[i].Name);
                        ListAllItem[i].Available = false;
                    }
                }
            }
            else
            {
                MessageToScreen = "Inventory is full, drop something to pick that up";
            }

            if (MessageToScreen == "")
            {
                MessageToScreen = "could not get that";
            }
        }

        public void Go(string command)
        {
            string[] array = command.Split(' ');

            switch (array[1])
            {
                case "east":
                    CheckValidPathEast(CurrentRoom);
                    break;
                case "west":
                    CheckValidPathWest(CurrentRoom);
                    break;
                case "north":
                    CheckValidPathNorth(CurrentRoom);
                    break;
                case "south":
                    CheckValidPathSouth(CurrentRoom);
                    break;
                default:
                    MessageToScreen = "Not a valid path";
                    break;
            }
            ValitedatePathway();
        }

        public void DropItem(string command)
        {
            if (command.IndexOf("drop") != -1)
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (command.IndexOf(Inventory[i].Name.ToLower()) != -1)
                    {

                        for (int a = 0; a < ListAllItem.Count; a++)
                        {
                            if (Inventory[i].Name == ListAllItem[a].Name)
                            {
                                ListAllItem[a].LocationFound = CurrentRoom;
                                ListAllItem[a].Available = true;
                            }
                        }
                        MessageToScreen = string.Format("You dropped {0}", Inventory[i].Name);
                        Inventory.RemoveAt(i);
                    }
                }
            }
            if (MessageToScreen == "")
            {
                MessageToScreen = "could not drop that";
            }
        }

        public void Look(string command)
        {
            MessageToScreen = string.Format("{0}\nITEMS Available:\n{1}", ListAllRooms[CurrentRoom].LookAround, ListItemsInRoom());
        }

        public void Use(string command)
        {
            if (command.IndexOf("on") != -1)
            {
                UseItemOnDoor(command);
            }
            else if (command.IndexOf("with") != -1)
            {
                UseItemWithItem(command);
            }
        }

        public static void UseItemOnDoor(string command)
        {
            foreach (var door in ListAllDoors)
            {
                foreach (var item in Inventory)
                {

                    if ((command.IndexOf(item.Name.ToLower()) != -1) &&
                        (item.Name.ToLower() == door.ItemToUnlock) &&
                        (command.IndexOf(door.Name) != -1) &&
                        (CurrentRoom == door.CheckCurrentRoom) &&
                        (ListAllRooms[door.RoomUnlocked].IfRoomIsAvailable == false))
                    {
                        door.IfRoomIsOpen = true;
                        MessageToScreen = door.HappeningOnUse;
                        ListAllRooms[door.RoomUnlocked].IfRoomIsAvailable = true;
                        ListAllRooms[CurrentRoom].LookAround = ListAllRooms[CurrentRoom].AfterEventLookAround;
                    }

                    else if ((command.IndexOf(item.Name.ToLower()) != -1) &&
                             (CurrentRoom == door.CheckCurrentRoom) &&
                             (item.Name.ToLower() == door.ItemToUnlock) &&
                             (command.IndexOf(door.Name) != -1) &&
                             (ListAllRooms[door.RoomUnlocked].IfRoomIsAvailable == true))
                    {
                        MessageToScreen = "Room is already accessible";
                    }
                    else if (MessageToScreen == "")
                    {
                        MessageToScreen = "You could not do that";
                    }
                }
            }
            if (MessageToScreen == "")
            {
                MessageToScreen = "You dont have any items";
            }
        }

        #endregion

        #region Validate

        public void ValitedatePathway()
        {
            if (LastRoom != CurrentRoom)
            {

                if (ListAllRooms[CurrentRoom].IfRoomIsAvailable == true)
                {


                    if (ListAllRooms[CurrentRoom].CheckIfDiscoveredRoom == true)
                    {
                        MessageToScreen = string.Format("{0}\nITEMS Available:\n{1}", ListAllRooms[CurrentRoom].RevisitRoom, ListItemsInRoom());
                    }
                    else if (ListAllRooms[CurrentRoom].CheckIfDiscoveredRoom == false)
                    {
                        MessageToScreen = string.Format("{0}\nITEMS Available:\n{1}", ListAllRooms[CurrentRoom].EnterFirstTime, ListItemsInRoom());
                    }
                    LastRoom = CurrentRoom;
                    ListAllRooms[CurrentRoom].CheckIfDiscoveredRoom = true;
                }
                else
                {
                    MessageToScreen = "You could not access that, either the door is locked or the pathway is blocked";
                    CurrentRoom = LastRoom;
                }
            }
        }

        public void CheckValidPathEast(int direction)
        {

            switch (direction)
            {
                case 1:
                    CurrentRoom = 3;
                    break;
                case 2:
                    CurrentRoom = 1;
                    break;
                case 3:
                    CurrentRoom = 6;
                    break;
                case 6:
                    CurrentRoom = 11;
                    break;
                case 7:
                    CurrentRoom = 9;
                    break;
                case 9:
                    CurrentRoom = 10;
                    break;
                case 12:
                    CurrentRoom = 13;
                    break;
                default:
                    MessageToScreen = "You cannot go east";
                    break;
            }
        }

        public void CheckValidPathWest(int direction)
        {
            switch (direction)
            {
                case 1:
                    CurrentRoom = 2;
                    break;
                case 3:
                    CurrentRoom = 1;
                    break;
                case 6:
                    CurrentRoom = 3;
                    break;
                case 9:
                    CurrentRoom = 7;
                    break;
                case 10:
                    CurrentRoom = 9;
                    break;
                case 11:
                    CurrentRoom = 6;
                    break;
                case 13:
                    CurrentRoom = 12;
                    break;
                default:
                    MessageToScreen = "You cannot go west";
                    break;
            }
        }

        public void CheckValidPathNorth(int direction)
        {
            switch (direction)
            {
                case 0:
                    CurrentRoom = 1;
                    break;
                case 3:
                    CurrentRoom = 4;
                    break;
                case 5:
                    CurrentRoom = 3;
                    break;
                case 7:
                    CurrentRoom = 6;
                    break;
                case 8:
                    CurrentRoom = 7;
                    break;
                case 11:
                    CurrentRoom = 12;
                    break;
                default:
                    MessageToScreen = "You cannot go north";
                    break;
            }
        }

        public void CheckValidPathSouth(int direction)
        {
            switch (direction)
            {
                case 1:
                    CurrentRoom = 0;
                    break;
                case 3:
                    CurrentRoom = 5;
                    break;
                case 4:
                    CurrentRoom = 3;
                    break;
                case 6:
                    CurrentRoom = 7;
                    break;
                case 7:
                    CurrentRoom = 8;
                    break;
                default:
                    MessageToScreen = "You cannot go south";
                    break;
            }
        }

        #endregion

        public void ShowInventory()
        {
            if (Inventory.Count != 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var item in Inventory)
                {
                    sb.Append(item.Name).Append("\n");
                }
                MessageToScreen = string.Format("Your items:\n{0}", sb);
            }
            else
            {
                MessageToScreen = "Inventory is empty";
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
            if (CurrentRoom == 13 || CurrentRoom == 10)
            {
                while (true)
                {
                    Console.Write("Play again? Y/N: ");
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

        public static string ListItemsInRoom()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ListAllItem)
            {
                if ((item.LocationFound == CurrentRoom) && (item.Available == true))
                {
                    sb.Append(item.Name).Append("\n");
                }
            }
            if (sb.Length == 0)
            {
                sb.Append("No items found");
            }
            return string.Format("{0}", sb);
        }

        #region HalffinnishedMethods

        public void Drink(string command)
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (command.Contains(Inventory[i].Name.ToLower()) && (Inventory[i].Name.Contains("Open")))
                {
                    Inventory[i] = ListAllItem[12];
                    MessageToScreen = "In just 5 seconds you chug down the content of the bottle";
                }
            }
            if (MessageToScreen == "")
            {
                MessageToScreen = "You cannot drink that";
            }
        }

        public void Attack()
        {
            foreach (var item in Inventory)
            {
                if (item.Name == "Metal axe" && Command.Contains("metal axe"))
                {
                    MessageToScreen = string.Format("{0} metal axe", CheckAttackedTarget(Command));
                }
                else if (item.Name == "Brick" && Command.Contains("brick"))
                {
                    MessageToScreen = string.Format("{0} brick", CheckAttackedTarget(Command));
                }
            }
            if (Command.Contains("fist"))
            {
                MessageToScreen = string.Format("{0} fists", CheckAttackedTarget(Command));
            }
            if (MessageToScreen == "")
            {
                MessageToScreen = "You could not use that for attack";
            }
        }

        public string CheckAttackedTarget(string target)
        {
            var attackedTarget = "";
            if (target.Contains("air"))
            {
                attackedTarget = "You attack the air with your";
            }
            else if (target.Contains("darkness"))
            {
                attackedTarget = "You attack the darkness with your";
            }
            else if (target.Contains("wall"))
            {
                attackedTarget = "You attack the wall with your";
            }
            else
            {
                attackedTarget = "could not attack that with your";
            }

            return attackedTarget;
        }

        public static void UseItemWithItem(string command)
        {
            for (int u = 0; u < Inventory.Count; u++)
            {
                if (Inventory[u].Name.ToLower() == "corkscrew")
                {
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        if (Inventory[i].ItemId == 2 && command.IndexOf(Inventory[i].Name.ToLower()) != -1)
                        {
                            switch (Inventory[i].Name)
                            {
                                case "Beer bottle":
                                    Inventory[i] = ListAllItem[10];
                                    MessageToScreen = "You open the beer bottle";
                                    break;
                                case "Whiskey bottle":
                                    Inventory[i] = ListAllItem[11];
                                    MessageToScreen = "You open the whiskey bottle";
                                    break;
                                default:
                                    break;
                            }
                        }
                        else if (MessageToScreen == "")
                        {
                            MessageToScreen = "Could not use item on that";
                        }
                    }
                }
            }
            if (MessageToScreen == "")
            {
                MessageToScreen = "You dont have that item";
            }
        }

        #endregion
    }
}
