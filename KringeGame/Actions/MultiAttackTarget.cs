using KringeGame.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KringeGame.Actions
{
    public class MultiAttackTarget : AttackAllTargets
    {
        public MultiAttackTarget()
        {
            Title = "Атака по группе";
        }

        public override void Run(Creature performer, Room room)
        {
            List<Creature> targets = new List<Creature>();

            if (performer is Player)
            {
                targets.AddRange(room.Enemies);
                Console.WriteLine($"{performer.Stats.Name} использует атаку по группе!");
            }
            else // Если это враг
            {
                targets.Add(room.Player);
                Console.WriteLine($"{performer.Stats.Name} атакует игрока!");
            }

            foreach (var target in targets)
            {
                int damage = new Random().Next(1, 4) + performer.Stats.Damage / 2;
                target.TakeDamage(damage);
                Console.WriteLine($"{performer.Stats.Name} наносит {damage} урона {target.Stats.Name}.");
            }
        }
    }
}
