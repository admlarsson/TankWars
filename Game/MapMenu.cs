using TankWars.Factories;
using TankWars.Map;

namespace TankWars.Menu
{
    public class MapMenu : IMenu<IMapFactory?>
    {
        public IMapFactory? RunMenu()
        {
            while (true)
            {
                ShowMenu();
                string? input = Console.ReadLine()?.Trim();
                if (input == "0") return null;
                IMapFactory? factory = GetFactory(input);
                if (factory is not null) return factory;
                ShowInvalidChoice();
            }
        }

        protected void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("--- KARTVAL ---");
            Console.WriteLine("1. Spela på Träningsbana");
            Console.WriteLine("2. Spela på Jorden");
            Console.WriteLine("3. Spela på Månen");
            Console.WriteLine("0. Gå tillbaka till Huvudmenyn");
            Console.Write("\nVälj ett alternativ (0-3): ");
        }

        protected void ShowInvalidChoice()
        {
            Console.WriteLine("Ogiltigt val! Du måste skriva 0, 1, 2 eller 3.");
            Console.WriteLine("Tryck ENTER för att försöka igen...");
            Console.ReadLine();
        }

        protected IMapFactory? GetFactory(string? input)
        {
            return input switch
            {
                "0" => null,
                "1" => new TrainingMapFactory(new TrainingTerrain(groundLevel: 0)),
                "2" => new EarthMapFactory(new EarthTerrain(groundLevel: 7)),
                "3" => new MoonMapFactory(new MoonTerrain()),
                _ => null
            };
        }
    }
}
