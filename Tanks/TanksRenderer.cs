namespace TankWars.Tanks
{
    public class TankRenderer
    {
        public void Draw(
            int x, 
            int y, 
            int mapHeight, 
            int direction, 
            ConsoleColor color)
        {
            int drawX = Math.Max(0, x - 1); 
            int drawY = mapHeight - y; 
            
            Console.ForegroundColor = color;

            Console.SetCursorPosition(drawX, drawY - 2);
            Console.Write(direction == 1 ? "▄██═" : "═██▄");

            Console.SetCursorPosition(drawX, drawY - 1);
            Console.Write("████");

            Console.SetCursorPosition(drawX, drawY);
            Console.Write("¤¤¤¤");

            Console.ResetColor();
        }
    }
}
