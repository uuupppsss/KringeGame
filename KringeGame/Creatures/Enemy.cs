using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KringeGame.Creatures
{
    public abstract class Enemy : Creature
    {
        protected Enemy(CreatureClass stats, ConsoleColor color) : base(stats, color) { }

        public override void RunAction(Room room)
        {
            if (IsDead) return;

            Console.ForegroundColor = Color;
            var action = Stats.Actions[new Random().Next(Stats.Actions.Count)];
            Console.WriteLine($"{Stats.Name} использует действие: {action.Title}");
            action.Run(this, room);

            Console.ResetColor();
        }
    }
}
