using KringeGame.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KringeGame.Actions
{
    public class Thunder_bolt:AttackOneTarget
    {
        public Thunder_bolt()
        {
            Title = "Thunder bolt";
        }
        public override void Run(Creature performer, Room room)
        {
            if (performer is Player)
            {
                Console.WriteLine("Выберите врага для атаки:");
                for (int i = 0; i < room.Enemies.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {room.Enemies[i].Stats.Name}");
                }

                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= room.Enemies.Count)
                {
                    var target = room.Enemies[choice - 1];
                    int damage = new Random().Next(5, 10) + performer.Stats.Damage;

                    // Проверка на статус комнаты "Туман"
                    if (room.Status == RoomStatus.Fog && new Random().NextDouble() < 0.3)
                    {
                        Console.WriteLine("Атака промахнулась из-за тумана!");
                        return;
                    }

                    target.TakeDamage(damage);
                    Console.WriteLine($"{performer.Stats.Name} атакует {target.Stats.Name} с легкой атакой на {damage} урона.");
                }
                else
                {
                    Console.WriteLine("Некорректный выбор.");
                }
            }
            else 
            {
                var target = room.Player;
                int damage = new Random().Next(1, 5) + performer.Stats.Damage;

                if (room.Status == RoomStatus.Fog && new Random().NextDouble() < 0.3)
                {
                    Console.WriteLine("Атака промахнулась из-за тумана!");
                    return;
                }

                target.TakeDamage(damage);
                Console.WriteLine($"{performer.Stats.Name} атакует {target.Stats.Name} с легкой атакой на {damage} урона.");
            }
        }
    }
}
