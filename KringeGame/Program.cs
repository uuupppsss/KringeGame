using KringeGame.Creatures;

namespace KringeGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя вашего персонажа: ");
            string playerName = Console.ReadLine();

            Console.WriteLine("Выберите класс: 1 - Воин, 2 - Маг");
            int classChoice;

            while (!int.TryParse(Console.ReadLine(), out classChoice) || (classChoice != 1 && classChoice != 2))
            {
                Console.WriteLine("Некорректный выбор. Пожалуйста, выберите класс: 1 - Воин, 2 - Маг");
            }

            Player player = classChoice == 1 ? new Player(playerName, new Warrior().Stats) : new Player(playerName, new Mage().Stats);

            while (!player.IsDead)
            {
                if (player.IsDead)
                {
                    break;
                }
                Room room = new Room(player);
                room.RunBattle();

                Console.WriteLine("Вы хотите продолжить? введите y чтобы продолжить");
                if (Console.ReadLine()?.ToLower() != "y")
                {
                    break;
                }
            }

        }
    }
}
