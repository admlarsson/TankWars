namespace TankWars.Game
{
    public class CombatInput
    {
        public (int, int) GetShootInput()
        {
            int angle = GetValidNumber("\nAnge vinkel (0-90): ", 0, 90, 45);
            int power = GetValidNumber("Ange kraft (1-100): ", 1, 100, 50);
            
            return (angle, power);
        }

        protected int GetValidNumber(
            string prompt, 
            int min, 
            int max, 
            int defaultVal)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(input)) return defaultVal;
                
                if (int.TryParse(input, out int result) && result >= min && result <= max)
                {
                    return result;
                }
                
                Console.WriteLine($"Fel! Siffran måste vara mellan {min} och {max}.");
            }
        }
    }
}
