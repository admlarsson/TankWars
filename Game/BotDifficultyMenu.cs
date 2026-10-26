using TankWars.Menu;
using TankWars.Tanks;

namespace TankWars.Game
{
    public class BotDifficultyMenu : IMenu<IBotStrategy>
    {
        public IBotStrategy RunMenu()
        {
            while (true)
            {
                Console.WriteLine("Välj datorns svårighetsgrad:");
                Console.WriteLine("1. Lätt  2. Medium  3. Svår");
                IBotStrategy? strategy = GetStrategy(Console.ReadLine()?.Trim());
                if (strategy != null) return strategy;
                Console.WriteLine("Ogiltigt val. Försök igen.");
            }
        }

        protected IBotStrategy? GetStrategy(string? choice)
        {
            return choice switch
            {
                "1" => new EasyBotStrategy(),
                "2" => new MediumBotStrategy(),
                "3" => new HardBotStrategy(),
                _ => null
            };
        }
    }
}
