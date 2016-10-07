using System.Collections.Generic;
using TextAdventure.BaseClass;

namespace TextAdventure.GameObjects
{
    public class Doors : Base
    {
        public int CheckCurrentRoom { get; set; }
        public string HappeningOnUse { get; set; }
        public int RoomUnlocked { get; set; }
        public bool IfRoomIsOpen { get; set; }
        public string ItemToUnlock { get; set; }

        public Doors(int inputCheckCurrentRoom, string inputName, string inputDescription, string inputHappeningOnUse, int inputRoomUnlocked, bool inputIfRoomIsOpen, string inputItemToUnlock)
        {
            CheckCurrentRoom = inputCheckCurrentRoom;
            Name = inputName;
            Description = inputDescription;
            HappeningOnUse = inputHappeningOnUse;
            RoomUnlocked = inputRoomUnlocked;
            IfRoomIsOpen = inputIfRoomIsOpen;
            ItemToUnlock = inputItemToUnlock;
        }
        public static List<Doors> Doorlist()
        {
            List<Doors> list = new List<Doors>();

            Doors wall = new Doors(0, "wall", "You see a broken wall", "Using the brick you smash a large hole in the wall", 1, false, "brick");
            Doors woodenDoor = new Doors(1, "wooden door", "You see a small wooden door", "You pass through the wooden door", 2, true, null);
            Doors metalDoor = new Doors(1, "metal door", "You see a large metal door", "With the bronze key you unlock the metal door", 3, false, "bronze key");
            Doors ropeToDrawBridge = new Doors(3, "rope", "You see a rope", "Using the axe you cut the rope and the bridge falls down", 6, false, "metal axe");
            Doors greyDoor = new Doors(6, "grey door", "You see a grey door covered in moss", "After struggling for a short time you manage to unlock the grey door", 11, false, "dusty key");
            Doors guardDoor = new Doors(7, "guard door", "You see a guard door, a key should unlock this door", "Using the guard key you unlock the guard door", 9, false, "guard key");

            list.AddMany(wall, woodenDoor, metalDoor, ropeToDrawBridge, greyDoor, guardDoor);

            return list;
        }
    }
}
