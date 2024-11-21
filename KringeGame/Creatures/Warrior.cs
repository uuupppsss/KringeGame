using KringeGame.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KringeGame.Creatures
{
    public class Warrior : Creature
    {
        public Warrior() : base(new CreatureClass
        {
            Name = "Воин",
            CurrentHP = 100,
            MaxHP = 100,
            Damage = 20,
            Armor = 5,
            Speed = 10
        }, ConsoleColor.Blue)
        {
            Stats.Actions.Add(new LightAttackTarget());
            Stats.Actions.Add(new MultiAttackTarget());
        }

        public override void RunAction(Room room)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Текущие HP: {Stats.CurrentHP}/{Stats.MaxHP}");
            Stats.PrintActions();
            var action = Stats.Actions[new Random().Next(Stats.Actions.Count)];
            action.Run(this, room);

            Console.ResetColor();
        }
    }
}
