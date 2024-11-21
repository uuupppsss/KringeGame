using KringeGame.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KringeGame.Actions
{
    public class UseItem:CreatureAction
    {
        public UseItem()
        {
            Title = "Использовать предмет";
        }

        public override void Run(Creature performer, Room room)
        {
            Console.WriteLine($"{performer.Stats.Name} использует предмет!");
        }
    }
}
