using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KringeGame.Creatures
{
    public abstract class Creature
    {
        public CreatureClass Stats { get; private set; }
        public ConsoleColor Color { get; private set; }
        public bool IsDead => Stats.CurrentHP <= 0;

        protected Creature(CreatureClass stats, ConsoleColor color)
        {
            Stats = stats;
            Color = color;
        }

        public void TakeDamage(int damage)
        {
            Stats.TakeDamage(damage);
            if (IsDead)
            {
                Death();
            }
        }

        private void Death()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"{Stats.Name} погиб!");
            Console.ResetColor();
        }

        public abstract void RunAction(Room room);

        public void RandomSpeed()
        {
            Stats.Speed = new Random().Next(1, 11);
        }
    }
}
