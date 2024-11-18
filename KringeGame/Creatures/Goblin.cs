using KringeGame.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KringeGame.Creatures
{
    public class Goblin : Enemy
    {
        public Goblin() : base(new CreatureClass
        {
            Name = "Гоблин",
            CurrentHP = 60,
            MaxHP = 60,
            Damage = 15,
            Armor = 3,
            Speed = 10
        }, ConsoleColor.Red)
        {
            Stats.Actions.Add(new LightAttackTarget());
        }
    }
}
