using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventure.BaseClass;
using TextAdventure.Extensions;

namespace TextAdventure
{
    public class Command : Base
    {
        public string Action { get; set; }

        public Command(string inputAction, string inputDescription)
        {
            Action = inputAction;
            Description = inputDescription;
        }
        public static List<Command> CommandList()
        {
            List<Command> list = new List<Command>();

            Command get = new Command("Get", "Get or pickup an item");
            Command inspect = new Command("Inspect", "Show description of an item or object");
            Command go = new Command("Go", "Walk in a ceratin direction - East/West/North or South");
            Command drop = new Command("Drop", "Drops an item");
            Command showinventory = new Command("inventory", "List of all items in your inventory");
            Command exit = new Command("Exit", "Type exit to quit");
            Command look = new Command("Look", "Show a description of your surroundings");
            Command use1 = new Command("Use \"item\" on \"object\"", "Uses an item on an object in your surrounding, for example a door");
            Command use2 = new Command("Use \"item\" with \"item\"", "Uses one item on another item in your inventory");
            Command help = new Command("Help", "Show all commands");

            list.AddMany(help, get, go, drop, inspect, showinventory, exit, look, use1, use2);

            return list;
        }
    }
}
