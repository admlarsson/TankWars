using System;
namespace TankWars.Game;
public class GameMenu
{
    public int GameModeChoice()
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
    public string GetMapChoice()
    {
        Console.Clear();
        Console.WriteLine("1. Spela på Träningsbana");
        Console.WriteLine("2. Spela på Jorden");
        Console.WriteLine("3. Spela på Månen");
        Console.WriteLine("4. Avsluta spelet");
        Console.Write("\nVälj ett alternativ (1-4): ");

        return Console.ReadLine();
    }

    // Meny 3: Välj vapen
    public (string, string) GetWeaponChoice(string playerName)
    {
        Console.Clear();
        Console.WriteLine($"--- {playerName.ToUpper()}: BYGG DITT VAPEN ---");
        
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

        public void DrawAngleGuide(bool isLeftPlayer)
        {
            Console.WriteLine("--- VINKEL-GUIDE ---");
            if (isLeftPlayer)
            {
                // Spelare 1
                Console.WriteLine("       90");
                Console.WriteLine("       |   / 60");
                Console.WriteLine("       |  /");
                Console.WriteLine("       | /___ 30");
                Console.WriteLine("  -----+-------- 0");
            }
            else
            {
                // Spelare 2 eller Datorn
                Console.WriteLine("       90");
                Console.WriteLine(" 60 \\   |");
                Console.WriteLine("     \\  |");
                Console.WriteLine(" 30 ___\\|");
                Console.WriteLine("  0 ---+-----");
            }
        }

        // NY METOD: Tvingar spelaren att skriva rätt värden!
        public (int, int) GetShootInput()
        {
            int angle, power;
            
            // Loopar tills spelaren skriver en giltig vinkel
            while (true)
            {
                Console.Write("\nAnge vinkel (0-90): ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) { angle = 45; break; } // Standardvärde vid Enter
                if (int.TryParse(input, out angle) && angle >= 0 && angle <= 90) break;
                
                Console.WriteLine("Fel! Du måste skriva en siffra mellan 0 och 90.");
            }

            // Loopar tills spelaren skriver en giltig kraft
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