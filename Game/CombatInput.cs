using System;

namespace TankWars.Game
{
    public class CombatInput
    {
        public (int, int) GetShootInput()
        {
            // Vi återanvänder samma metod för att hålla kodraderna korta (max 20 rader-regeln)
            int angle = GetValidNumber("\nAnge vinkel (0-90): ", 0, 90, 45);
            int power = GetValidNumber("Ange kraft (1-100): ", 1, 100, 50);
            
            return (angle, power);
        }

        // Måste vara protected (eller public) eftersom ni inte får använda private
        protected int GetValidNumber(
            string prompt, 
            int min, 
            int max, 
            int defaultVal)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(input)) return defaultVal;
                
                // TryParse hanterar bokstäver och fel utan att krascha
                if (int.TryParse(input, out int result) && result >= min && result <= max)
                {
                    return result;
                }
                
                Console.WriteLine($"Fel! Siffran måste vara mellan {min} och {max}.");
            }
        }
    }
}
