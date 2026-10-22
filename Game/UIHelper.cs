/*using System;

namespace TankWars.Menu
{
    public class UIHelper
    {
        public void DrawAngleGuide(bool isLeftPlayer)
        {
            Console.WriteLine("--- VINKEL-GUIDE ---");
            if (isLeftPlayer)
            {
                Console.WriteLine("       90");
                Console.WriteLine("       |   / 60");
                Console.WriteLine("       |  /");
                Console.WriteLine("       | /___ 30");
                Console.WriteLine("  -----+-------- 0");
            }
            else
            {
                Console.WriteLine("       90");
                Console.WriteLine(" 60 \\   |");
                Console.WriteLine("     \\  |");
                Console.WriteLine(" 30 ___\\|");
                Console.WriteLine("  0 ---+-----");
            }
        }

        public static (int, int) GetShootInput()
        {
            int angle, power;
            
            while (true)
            {
                Console.Write("\nAnge vinkel (0-90): ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) { angle = 45; break; }
                if (int.TryParse(input, out angle) && angle >= 0 && angle <= 90) break;
                
                Console.WriteLine("Fel! Du måste skriva en siffra mellan 0 och 90.");
            }

            while (true)
            {
                Console.Write("Ange kraft (1-100): ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) { power = 50; break; }
                if (int.TryParse(input, out power) && power >= 1 && power <= 100) break;
                
                Console.WriteLine("Fel! Kraften måste vara mellan 1 och 100.");
            }

            return (angle, power);
        }
    }
}
*/