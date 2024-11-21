using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KringeGame.Actions;

namespace KringeGame.Creatures
{
    public class CreatureClass
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int Speed { get; set; }
        public List<CreatureAction> Actions { get; } = new List<CreatureAction>();

        public void TakeDamage(int damage)
        {
            int effectiveDamage = Math.Max(damage - Armor, 0);
            CurrentHP -= effectiveDamage;
            if (CurrentHP <0) CurrentHP = 0;
            Console.WriteLine($"{Name} получил {effectiveDamage} урона. Текущие HP: {CurrentHP}/{MaxHP}");
        }

        public void PrintActions()
        {
            Console.WriteLine($"{Name}, ваши действия:");
            for (int i = 0; i < Actions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Actions[i].Title}");
            }
        }
    }
}
