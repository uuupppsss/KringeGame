using KringeGame.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KringeGame.Creatures
{
    public class Mage:Creature
    {
        public Mage() : base(new CreatureClass
        {
            Name = "Маг",
            CurrentHP = 80,
            MaxHP = 80,
            Damage = 25,
            Armor = 2,
            Speed = 12
        }, ConsoleColor.Cyan)
        {
            Stats.Actions.Add(new Thunder_bolt());
            Stats.Actions.Add(new Laguna_Blade());
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
