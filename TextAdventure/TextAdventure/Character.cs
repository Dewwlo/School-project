using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventure.BaseClass;
using TextAdventure.Extensions;

namespace TextAdventure
{
    public class Character : Base
    {
        public string ReasonInprison { get; set; }

        public Character(string inputName, string inputReasonInprison, string inputCharDescription)
        {
            Name = inputName;
            ReasonInprison = inputReasonInprison;
            Description = inputCharDescription;
        }
        public static List<Character> CharacterList()
        {
            List<Character> list = new List<Character>();

            Character derp = new Character("Derp the dominator",  "Convicted of murder", "Sentenced to a lifetime in prison for murdering the weaponsmith after being caught stealing his weapons.");
            Character herp = new Character("Herp the thief", "Convicted of theviery", "Sentenced to 10 year is in prison for stealing a goat");
            Character sherpa = new Character("Sherpa herder","Convicted of witchcraft","Sentenced to burn at the stake for sorcery and witchcraft");

            list.AddMany(derp, herp, sherpa);

            return list;
        }
    }   
}
