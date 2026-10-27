using TankWars.Game;

namespace TankWars.Menu
{
    public class GameModeMenu : IMenu<IGameModeStrategy>
    {
        public IGameModeStrategy RunMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- HUVUDMENY ---");
                Console.WriteLine("1. Människa vs Dator");
                Console.WriteLine("2. Människa vs Människa");
                Console.WriteLine("3. Dator vs Dator");
                Console.WriteLine("4. Avsluta spelet");
                Console.Write("\nDitt val (1-4): ");
                IGameModeStrategy? mode = GetMode(Console.ReadLine()?.Trim());
                if (mode is not null) return mode;
                Console.WriteLine("Ogiltigt val! Du måste skriva 1, 2, 3 eller 4.");
                Console.WriteLine("Tryck ENTER för att försöka igen...");
                Console.ReadLine();
            }
        }

        protected IGameModeStrategy? GetMode(string? input)
        {
            return input switch
            {
                "1" => new PvEMode(),
                "2" => new PvPMode(),
                "3" => new EvEMode(),
                "4" => new ExitGameMode(),
                _ => null
            };
        }
    }
}
