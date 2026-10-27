using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Menu
{
    public class WeaponMenu : IMenu<(IWeaponFactory?, IAirBehavior?)>
    {
        protected readonly string _playerName;

        public WeaponMenu(string playerName)
        {
            _playerName = playerName;
        }

        public (IWeaponFactory?, IAirBehavior?) RunMenu()
        {
            Console.Clear();
            Console.WriteLine($"--- {_playerName.ToUpper()}: BYGG DITT VAPEN ---");
            Console.WriteLine("Steg 1: Välj Ammunitionstyp");
            Console.WriteLine("1. Normal (Liten träffyta, 50 Skada)");
            Console.WriteLine("2. Explosiv (Stor träffyta, 25 Skada)");
            Console.WriteLine("0. Gå tillbaka");
            IWeaponFactory? weaponFactory = 
                GetWeaponFactory(GetValidChoice("Val (0-2): ", "0", "1", "2"));
            if (weaponFactory is null) return (null, null);
            Console.WriteLine("\nSteg 2: Välj Flygstil");
            Console.WriteLine("1. Standard (Vanlig kastbana)");
            Console.WriteLine("2. Guidad (Tryck SPACE i luften för att störtdyka)");
            IAirBehavior behavior = 
                GetAirBehavior(GetValidChoice("Val (1-2): ", "1", "2"));
            return (weaponFactory, behavior);
        }

        protected IWeaponFactory? GetWeaponFactory(string choice)
        {
            return choice switch
            {
                "1" => new NormalWeaponFactory(),
                "2" => new ExplosiveWeaponFactory(),
                _ => null
            };
        }

        protected IAirBehavior GetAirBehavior(string choice)
        {
            return choice switch
            {
                "1" => new GravityBehavior(),
                "2" => new DropBehavior(),
                _ => throw new InvalidOperationException("Ogiltigt val av flygbeteende.")
            };
        }

        protected string GetValidChoice(string prompt, params string[] options)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine()?.Trim();
                if (input is not null && Array.Exists(options, option => option == input)) 
                    return input;
                Console.WriteLine("Ogiltigt val! Försök igen.");
            }
        }
    }
}
