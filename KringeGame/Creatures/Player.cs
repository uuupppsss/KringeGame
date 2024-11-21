using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KringeGame.Creatures
{
    public class Player : Creature
    {
        public string Name { get; set; }

        public Player(string name, CreatureClass stats) : base(stats, ConsoleColor.Green)
        {
            Name = name;
        }

        public override void RunAction(Room room)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Текущие HP: {Stats.CurrentHP}/{Stats.MaxHP}");
            Stats.PrintActions();
            Console.Write("Выберите действие: ");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Stats.Actions.Count)
            {
                var action = Stats.Actions[choice - 1];
                action.Run(this, room);
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
            }

            Console.ResetColor();
        }
    }
}
