using System.Text;
using TankWars.Menu;

namespace TankWars.Menu
{
    public class GameModeMenu : IMenu<int>
    {
        public int RunMenu()
        {
            Console.Clear();
            Console.WriteLine("--- HUVUDMENY ---");
            Console.WriteLine("1. Människa vs Dator");
            Console.WriteLine("2. Människa vs Människa");
            Console.WriteLine("3. Dator vs Dator");
            Console.WriteLine("4. Avsluta spelet");
            Console.Write("\nDitt val (1-4): ");
            
            string input = Console.ReadLine();
            
            if (input == "2") return 2;
            if (input == "3") return 3;
            if (input == "4") return 4; // 4 = Avsluta
            
            return 1; // Standard om de trycker fel
        }

    }
}