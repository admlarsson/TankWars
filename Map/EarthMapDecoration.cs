namespace TankWars.Map
{
    public class EarthDecoration
    {
        public void Draw(int[] terrainHeights)
        {
            int moonX = terrainHeights.Length - 35;

            string[] crescent =
            {
                "   ▄██",
                "  ███▀",
                " ███▀ ",
                "  ███▄",
                "   ▀██"
            };

            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < crescent.Length; i++)
            {
                Console.SetCursorPosition(moonX, 2 + i);
                Console.Write(crescent[i]);
            }

            Console.ResetColor();
        }
    }
}
