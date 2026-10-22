using System;
using TankWars.Menu;

namespace TankWars.Menu
{
    public class MapMenu : IMenu<string>
    {
        public string RunMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- KARTVAL ---");
                Console.WriteLine("1. Spela på Träningsbana");
                Console.WriteLine("2. Spela på Jorden");
                Console.WriteLine("3. Spela på Månen");
                Console.WriteLine("0. Gå tillbaka till Huvudmenyn");
                Console.Write("\nVälj ett alternativ (0-3): ");

                string input = Console.ReadLine()?.Trim();

                if (input == "0" || input == "1" || input == "2" || input == "3")
                {
                    return input;
                }

                Console.WriteLine("Ogiltigt val! Du måste skriva 0, 1, 2 eller 3.");
                Console.WriteLine("Tryck ENTER för att försöka igen...");
                Console.ReadLine();
            }
        }
    }
}
