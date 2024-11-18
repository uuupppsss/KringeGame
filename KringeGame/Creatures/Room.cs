using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KringeGame.Creatures
{
    public class Room
    {
        public Player Player { get; private set; }
        public List<Creature> Enemies { get; private set; } = new List<Creature>();
        public RoomStatus Status { get; private set; }

        public Room(Player player)
        {
            Player = player;
            CreateEnemies();
            Status = (RoomStatus)new Random().Next(Enum.GetValues(typeof(RoomStatus)).Length);

            Console.WriteLine($"Вы попали в комнату. Статус комнаты: {Status}. Вокруг вас:");
            foreach (var enemy in Enemies)
            {
                Console.WriteLine(enemy.Stats.Name);
            }
        }

        private void CreateEnemies()
        {
            Random random = new Random();
            int enemyCount = random.Next(1, 4); 
            for (int i = 0; i < enemyCount; i++)
            {
                Enemies.Add(random.Next(0, 2) == 0 ? new Goblin() : new Orc());
            }
        }

        public void RunBattle()
        {
            int round = 1;

            while (!Player.IsDead && Enemies.Any(e => !e.IsDead))
            {
                Console.WriteLine($"Раунд {round++}:");
                foreach (var creature in Enemies)
                {
                    creature.RandomSpeed();
                }
                Player.RandomSpeed();

                var allCreatures = new List<Creature> { Player }.Concat(Enemies).OrderByDescending(c => c.Stats.Speed).ToList();

                foreach (var creature in allCreatures)
                {
                    if (Player.IsDead) break;

                    creature.RunAction(this);
                    Thread.Sleep(1000); // Задержка в одну секунду между ходами
                }
            }

            if (!Player.IsDead)
            {
                Console.WriteLine("Поздравляем! Вы очистили комнату!");
            }
            else
            {
                Console.WriteLine("Игра окончена.");
            }
        }
    }

    public enum RoomStatus
    {
        Normal,
        Fog,
        Darkness
    }

}

