using System;

namespace TankWars.Map
{
    public class MoonDecoration
    {
        public void Draw(int mapHeight, int[] terrainHeights)
        {
            int drawX = terrainHeights.Length / 2;
            int drawY = mapHeight - terrainHeights[drawX];

            // Flyttar upp själva flaggan (från -9 till -5)
            DrawFlagLine(drawX + 1, drawY - 9, "* * *", "══════", ConsoleColor.Red);
            DrawFlagLine(drawX + 1, drawY - 8, " * * ", "══════", ConsoleColor.White);
            DrawFlagLine(drawX + 1, drawY - 7, "* * *", "══════", ConsoleColor.Red);
            DrawFlagLine(drawX + 1, drawY - 6, "", "═══════════", ConsoleColor.White);
            DrawFlagLine(drawX + 1, drawY - 5, "", "═══════════", ConsoleColor.Red);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            
            // Förlänger stången från 6 till 9 rader
            for (int i = 1; i <= 9; i++)
            {
                Console.SetCursorPosition(drawX, drawY - i);
                Console.Write("│");
            }
            Console.ResetColor();
        }

        protected void DrawFlagLine(int x, int y, string stars, string stripes, ConsoleColor stripeColor)
        {
            Console.SetCursorPosition(x, y);
            
            if (stars.Length > 0)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(stars);
                Console.ResetColor(); 
            }
            
            Console.ForegroundColor = stripeColor;
            Console.Write(stripes);
            Console.ResetColor();
        }
    }
}
