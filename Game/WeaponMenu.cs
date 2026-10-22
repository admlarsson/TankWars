using System;
using TankWars.Menu;

namespace TankWars.Menu
{
    public class WeaponMenu : IMenu<(string, string)>
    {
        protected readonly string _playerName;

        public WeaponMenu(string playerName)
        {
            _playerName = playerName;
        }

        public (string, string) RunMenu()
        {
            Console.Clear();
            Console.WriteLine($"--- {_playerName.ToUpper()}: BYGG DITT VAPEN ---");
            
            Console.WriteLine("Steg 1: Välj Ammunitionstyp");
            Console.WriteLine("1. Normal (Liten träffyta, 50 Skada)");
            Console.WriteLine("2. Explosiv (Stor träffyta, 25 Skada)");
            Console.WriteLine("0. Gå tillbaka");
            
            string bChoice = GetValidChoice("Val (0-2): ", "0", "1", "2");
            if (bChoice == "0") return ("0", "0");

            Console.WriteLine("\nSteg 2: Välj Flygstil");
            Console.WriteLine("1. Standard (Vanlig kastbana)");
            Console.WriteLine("2. Guidad (Tryck SPACE i luften för att störtdyka)");
            
            string fChoice = GetValidChoice("Val (1-2): ", "1", "2", "1"); // Tillåter inte 0 här
            return (bChoice, fChoice);
        }

        // Hjälpmetod för att tvinga fram rätt svar (uppfyller "inga privata metoder")
        protected string GetValidChoice(string prompt, string opt1, string opt2, string opt3)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();
                
                if (input == opt1 || input == opt2 || input == opt3)
                {
                    return input;
                }
                
                Console.WriteLine("Ogiltigt val! Försök igen.");
            }
        }
    }
}
