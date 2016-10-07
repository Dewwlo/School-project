using System.Collections.Generic;
using TextAdventure.BaseClass;

namespace TextAdventure.GameObjects
{
    public class Item : Base
    {
        public int ItemId { get; set; }
        public int LocationFound { get; set; }
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
            Item brick = new Item(0, 0, "Brick", "a loose brick found in the prisonwall", true);
            Item axe = new Item(0, 4, "Metal axe", "A heavy metal axe, good at chopping wood", true);
            Item rustyKey = new Item(0, 5, "Rusty key", "Rusty key which probably have seen better days", true);
            Item guardKey = new Item(0, 5, "Guard key", "A shiny key marked with the words \"guard key\"", true);
            Item brokenKey = new Item(0, 5, "Broken key", "Broken key, could this have any use att all?", true);
            Item dustyKey = new Item(0, 8, "Dusty key", "Looks like an old key rarely used, what could this unlock?", true);
            Item corkscrew = new Item(1, 2, "Corkscrew", "Could open bottles", true);
            Item beerBottle = new Item(2, 2, "Beer bottle", "Bottle filled with ale", true);
            Item whiskeyBottle = new Item(2, 8, "Whiskey bottle", "A bottle filled with 12 year old whiskey", true);
            Item openBeerBottle = new Item(0, -1, "Open beer bottle", "Bottle filled with ale", true);
            Item openWhiskeyBottle = new Item(0, -1, "Open whiskey bottle", "A bottle filled with 12 year old whiskey", true);
            Item emptyBottle = new Item(0, -1, "Empty Bottle", "An empty bottle", true);

            list.AddMany(key, brick, axe, rustyKey, guardKey, brokenKey, dustyKey, corkscrew, beerBottle, whiskeyBottle, openBeerBottle, openWhiskeyBottle, emptyBottle);

            return list;
        }
    }
}
