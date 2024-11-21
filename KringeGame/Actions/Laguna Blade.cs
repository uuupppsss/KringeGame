using KringeGame.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KringeGame.Actions
{
    public class Laguna_Blade:AttackAllTargets
    {
        public Laguna_Blade()
        {
            Title = "Laguna Blade";
        }

        public override void Run(Creature performer, Room room)
        {
            List<Creature> targets = new List<Creature>();

            if (performer is Player)
            {
                targets.AddRange(room.Enemies);
                Console.WriteLine($"{performer.Stats.Name} использует атаку по группе!");
            }
            else
            {
                targets.Add(room.Player);
                Console.WriteLine($"{performer.Stats.Name} атакует игрока!");
            }

            foreach (var target in targets)
            {
                int damage = new Random().Next(10,20) + performer.Stats.Damage;
                target.TakeDamage(damage);
                Console.WriteLine($"{performer.Stats.Name} наносит {damage} урона {target.Stats.Name}.");
            }
        }
    }
}
