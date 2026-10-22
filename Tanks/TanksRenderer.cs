using System;

namespace TankWars.Tanks
{
    public class TankRenderer
    {
        public void Draw(int x, int y, int mapHeight, int direction, ConsoleColor color)
        {
            // Justerar X så larvfötterna hamnar centrerat runt kärnkoordinaten
            int drawX = Math.Max(0, x - 1); 
            int drawY = mapHeight - y; 
            
            Console.ForegroundColor = color;

            // Överst: Kanontorn och eldrör
            Console.SetCursorPosition(drawX, drawY - 2);
            Console.Write(direction == 1 ? "▄██═" : "═██▄");

            // Mitten: Chassi
            Console.SetCursorPosition(drawX, drawY - 1);
            Console.Write("████");

            // Nederst: Larvfötter
            Console.SetCursorPosition(drawX, drawY);
            Console.Write("¤¤¤¤");

            Console.ResetColor();
        }
    }
}
