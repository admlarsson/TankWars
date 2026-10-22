using System.Text;
using TankWars.Menu;

namespace TankWars.Menu
{
    public class WeaponMenu : IMenu<(string, string)>
    {

        private readonly string _playerName;

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
            Console.Write("Val (1-2): ");
            string bulletChoice = Console.ReadLine();

            Console.WriteLine("\nSteg 2: Välj Flygstil");
            Console.WriteLine("1. Standard (Vanlig kastbana)");
            Console.WriteLine("2. Guidad (Tryck SPACE i luften för att störtdyka)");
            Console.Write("Val (1-2): ");
            string flightChoice = Console.ReadLine();

            return (bulletChoice, flightChoice);
        }

    }
}