using System.Collections.Generic;

namespace TextAdventure.GameObjects
{
    public class Location
    {
        public int Id { get; set; }
        public bool CheckIfDiscoveredRoom  { get; set; }
        public string EnterFirstTime { get; set; }
        public string RevisitRoom { get; set; }
        public string LookAround { get; set; }
        public string AfterEventLookAround { get; set; }
        public bool IfRoomIsAvailable { get; set; }

        public Location(int inputId, bool inputDiscoveredRoom, string inputEnterFirstTime, string inputRevisitRoom, string inputLookAround, string inputAfterEventLookAround, bool inputIfRoomIsAvailable)
        {
            Id = inputId;
            CheckIfDiscoveredRoom = inputDiscoveredRoom;
            EnterFirstTime = inputEnterFirstTime;
            RevisitRoom = inputRevisitRoom;
            LookAround = inputLookAround;
            AfterEventLookAround = inputAfterEventLookAround;
            IfRoomIsAvailable = inputIfRoomIsAvailable;
        }

        public static List<Location> LocationList()
        {
            List<Location> list = new List<Location>();

            Location prisonCell = new Location(0, true, "You wake up in a prisoncell realising it was not a dream.\nLast night you were caught by the guards after a month long manhunt.\nNot wanting to stay here you start looking for a way out.", 
                "Your enter the prisoncell", 
                "You see a damp cold prisoncell, you see prison bars and a locked prison door.\nTo the north you see a small hole in the wall.",
                "You see a damp cold prisoncell, you see prison bars and a locked prison door.\nTo the north you see a big hole in the wall.", true);
            Location corridor = new Location(1, false, "You walk through the hole in the wall and find yourself in a small and dark corridor with two doors,\nyou see a metal door to the east and a regular wooden door to the west.", 
                "you are now at the dark corridor",
                "A small and dark corridor, a metal door to the east, a regular wooden door to the west and south the smashed wall.",
                "A small and dark corridor, a metal door to the east, a regular wooden door to the west and south the smashed wall.", false);
            Location smallOffice = new Location(2, false, "You enter a small office room, you see a window but its barred.\nLooking out of the window you see the moon shining, realizing it must be in the middle of the night.\nLooking further you see to the south a table with a bronze key placed near a candle.", 
                "you are now at the small office", 
                "You see a barred window, a table with a chair and a wooden door to your east.",
                "You see a barred window, a table with a chair and a wooden door to your east.", true);
            Location drawBridgeRoom = new Location(3, false, "Walking through the metal door you see a large room with four exits.\nA quick look around and you see that the way to the east is blocked by a raised drawbridge,\nlooking closer you find that the drawbridge is connected by a sturdy rope.\nTo the north and south you see archs leading to other rooms.", 
                "You enter the large room with the drawbridge", 
                "To the north and south arches leading to other rooms,\nto the west a metal door and to the east a raised drawbridge connected to a sturdy rope.",
                "To the north and south arches leading to other rooms,\nto the west a metal door and to the east a lowered drawbridge and a loose rope hanging from the ceiling.", false);
            Location northArch = new Location(4, false, "You walk through the arch and find yourself a room which looks like an armory.\nStraight ahead you see a big wardrobe which appears to be locked,\na weapons rack used for storing weapons", 
                "You enter the armory", 
                "You see a locked wardrobe, a weapons rack and to the south the arch.",
                "You see a locked wardrobe, a weapons rack and to the south the arch.", true);
            Location southArch = new Location(5, false, "You walk through the arch into a prison cell corridor. Regonizing the cell you just escaped from.\nOn both sides you see prisoncells, a little bit further down the corridor a drawer and a key cabinet with several keys.", 
                "You enter the prisoncell corridor", 
                "You see alot of prisoncells, a drawer and a key cabinet. To the north the arch.",
                "You see alot of prisoncells, a drawer and a key cabinet. To the north the arch.", true);
            Location secondCorridor = new Location(6, false, "Walking over the drawbridge you enter a corridor. Its a simple passage with torches hanging on the wall, at the far end to the east you see a grey door covered in moss.\nTo the south you see stairs leading upwards.", 
                "you enter the well lit corridor", 
                "You see a lowered drawbridge to the west stairs going upwards to the south and a grey door to the east.",
                "You see a lowered drawbridge to the west stairs going upwards to the south and a grey door to the east.", false);
            Location hallway = new Location(7, false, "Walking up the stairs you see what appears to be a hallway. You can feel the presence of other humans nearby.\nLooking around you see to the east what looks like a guard door and to the south a regular wooden door", 
                "you enter the hallway", 
                "You see a guard door to the east, a wooden door to the south and a stairs going down to the north.",
                "You see a guard door to the east, a wooden door to the south and a stairs going down to the north.", true);
            Location wardensOffice = new Location(8, false, "Entering through the wooden door you find yourself in a room which looks like a warden´s office,\nScouting around in the room you see a desk filled with papers and,\nan unmade bed and drawer with a dusty key ontop.", 
                "You are now in the wardens office", 
                "You see a desk, a bed and a drawer. To the north a wooden door.",
                "You see a desk, a bed and a drawer. To the north a wooden door.", true);
            Location upperCorridor = new Location(9, false, "After unlocking the guard door you walk into a well decorated corridor with wooden floors and paintings on the walls.\nAt the end of the corridor to the east you see a wooden door.\nYou can see light sipping through the cracks and also hear voices on the other side of the door. Who could they be?", 
                "You are now at the upper corridor", 
                "To the east a wooden door with lights shining through the cracks and to the west a guard door",
                "To the east a wooden door with lights shining through the cracks and to the west a guard door", false);
            Location guardRoom = new Location(10, false, "Entering this room you suddenly stand face to face with several guards which immediately seize you.\nYou are now thrown back into a cell with no chance to escape.", 
                "game over", 
                "game over",
                "game over", true);
            Location sewerEntrance = new Location(11, false, "After unlocking the grey door you walk into a new room and it stinks.\nIt looks like a way into the sewers. To the north you see a ladder going down", 
                "You are now at the sewer entrance", 
                "To the north you see a sewer entrance and to the west a grey door.",
                "To the north you see a sewer entrance and to the west a grey door.", false);
            Location sewerTunnel = new Location(12, false, "Climbing down the ladder it breaks and you fall down! looking around you see a tunnel,\nat the end of the tunnel to the east a shimmer of moonlight is glowing on the ground", 
                "You are in the sewers", 
                "To the east you see a tunnel exit",
                "", true);
            Location freedom = new Location(13, false, "Moving through the sewer tunnel you now standing in the moonlight feeling the wind in your face.\nFree! For now atleast. Better start moving before the guards find out that you are missing", 
                "winning", 
                "winning",
                "winning", true);

            list.AddMany(prisonCell, corridor, smallOffice, drawBridgeRoom, northArch, southArch, secondCorridor, hallway, wardensOffice, upperCorridor, guardRoom, sewerEntrance, sewerTunnel, freedom);

            return list;
        }
    }
}
