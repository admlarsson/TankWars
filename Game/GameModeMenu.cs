using System.Text;
using TankWars.Menu;

namespace TankWars.Menu
{
    public class GameModeMenu : IMenu<int>
    {
        public int RunMenu()
        {
            while(true)

            {

                Console.Clear();
                Console.WriteLine("--- HUVUDMENY ---");
                Console.WriteLine("1. Människa vs Dator");
                Console.WriteLine("2. Människa vs Människa");
                Console.WriteLine("3. Dator vs Dator");
                Console.WriteLine("4. Avsluta spelet");
                Console.Write("\nDitt val (1-4): ");
                
                string input = Console.ReadLine()?.Trim();
                
                if (input == "1") return 1;
                if (input == "2") return 2;
                if (input == "3") return 3; 
                if (input == "4") return 4; 

                 // Om koden når hit betyder det att input var ogiltig.
                // Då varnar vi och låter while-loopen snurra ett varv till!
                Console.WriteLine("Ogiltigt val! Du måste skriva 1, 2, 3 eller 4.");
                Console.WriteLine("Tryck ENTER för att försöka igen...");
                Console.ReadLine();
            }
            
        }

    }
}