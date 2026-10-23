using System;

namespace TankWars.Map
{
    public class MoonDecoration
    {
        public void Draw(int mapHeight, int[] terrainHeights)
        {
            // Mitten av kartan för flaggan
            int flagX = terrainHeights.Length / 2;
            int flagY = mapHeight - terrainHeights[flagX];
            
            // Placerar jorden uppe till höger i skyn (25 steg från högerkanten)
            int earthX = terrainHeights.Length - 25; 
            int earthY = 2;

            DrawEarth(earthX, earthY);
            DrawFlagpole(flagX, flagY);
            
            // Ritar själva flaggan
            DrawFlagLine(flagX + 1, flagY - 9, "* * *", "═════════", ConsoleColor.Red);
            DrawFlagLine(flagX + 1, flagY - 8, " * * ", "═════════", ConsoleColor.White);
            DrawFlagLine(flagX + 1, flagY - 7, "* * *", "═════════", ConsoleColor.Red);
            DrawFlagLine(flagX + 1, flagY - 6, "", "══════════════", ConsoleColor.White);
            DrawFlagLine(flagX + 1, flagY - 5, "", "══════════════", ConsoleColor.Red);
        }

        public void DrawFlagpole(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 1; i <= 9; i++)
            {
                Console.SetCursorPosition(x, y - i);
                Console.Write("│");
            }
            Console.ResetColor();
        }

        
        public void DrawFlagLine(int x, int y, string stars, string stripes, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            if (stars.Length > 0)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(stars);
                Console.ResetColor(); 
            }
            Console.ForegroundColor = color;
            Console.Write(stripes);
            Console.ResetColor();
        }

        public void DrawEarth(int x, int y)
        {
            string[] earth = {
                "      IIIII      ", "   WWWWWWWWWWW   ", "  WWLLLLWWWWWWW  ",
                " WWLLLLLLWWWWWWW ", " WWWLLLLWWWWWWWW ", " WWWWLLLWWWWWWWW ",
                "  WWWWWWWWWWWWW  ", "   WWWWWWWWWWW   ", "      IIIII      "
            };
            for (int i = 0; i < earth.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                foreach (char c in earth[i])
                {
                    if (c == 'W') { Console.ForegroundColor = ConsoleColor.Blue; Console.Write('~'); }
                    else if (c == 'L') { Console.ForegroundColor = ConsoleColor.Green; Console.Write('@'); }
                    else if (c == 'I') { Console.ForegroundColor = ConsoleColor.White; Console.Write('='); }
                    else Console.Write(' ');
                }
            }
            Console.ResetColor();
        }
    }
}