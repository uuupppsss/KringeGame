using KringeGame.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KringeGame.Creatures
{
    public class Orc : Enemy
    {
        public Orc() : base(new CreatureClass
        {
            Name = "Орк",
            CurrentHP = 80,
            MaxHP = 80,
            Damage = 20,
            Armor = 5,
            Speed = 8
        }, ConsoleColor.DarkYellow)
        {
            Stats.Actions.Add(new LightAttackTarget());
            Stats.Actions.Add(new MultiAttackTarget());
        }
    }
}
