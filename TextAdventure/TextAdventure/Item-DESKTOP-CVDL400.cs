using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Item
    {
        public int ItemId { get; set; }
        public int LocationFound { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        
        public Item(int inputItemId, int inputLocationFound, string inputName, string inputDescription, bool inputAvaiable)
        {
            ItemId = inputItemId;
            LocationFound = inputLocationFound;
            Name = inputName;
            Description = inputDescription;
            Available = inputAvaiable;
        }

        public static List<Item> ItemList()
        {
            List<Item> list = new List<Item>();

            Item key = new Item(0, 2, "Bronze key", "Bronze key, used for unlocking doors", true);
            Item brick = new Item(1, 0, "Brick", "a loose brick found in the prisonwall", true);
            Item axe = new Item(2, 4, "Metal Axe", "A heavy metal axe, good at chopping wood or maybe cutting a rope?", true);
            Item rustyKey = new Item(3, 5, "Rusty key", "Rusty key which probably have seen better days", true);
            Item guardKey = new Item(4, 5, "Guard key", "A shiny key marked with the words \"guard key\"", true);
            Item brokenKey = new Item(5, 5, "Broken key", "Broken key, could this have any use att all?", true);
            Item dustyKey = new Item(6, 8, "Dusty key", "Looks like an old key rarely used, what could this unlock?", true);

            list.Add(key);
            list.Add(brick);
            list.Add(axe);
            list.Add(rustyKey);
            list.Add(guardKey);
            list.Add(brokenKey);
            list.Add(dustyKey);

            return list;
        }
    }
}
