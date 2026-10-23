using System;

namespace TankWars.Map
{
    public class EarthDecoration
    {
        public void Draw(int[] terrainHeights)
        {
            int moonX = terrainHeights.Length - 15;
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.SetCursorPosition(moonX, 3);
            Console.Write(" ▄███▄ ");
            
            Console.SetCursorPosition(moonX, 4);
            Console.Write("███████");
            
            Console.SetCursorPosition(moonX, 5);
            Console.Write(" ▀███▀ ");
            
            Console.ResetColor();
        }
    }
}
