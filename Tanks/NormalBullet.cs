using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class NormalBullet : BaseBullet
    {
        // Skickar flygbeteendet vidare till BaseBullet
        public NormalBullet(IAirBehavior behavior) : base(behavior) 
        {
            Damage = 50;
        }

        protected override void DrawExplosion(int x, int y, IMap map)
        {
            if (y < map.GetHeight())
            {
                Console.SetCursorPosition(x + 1, map.GetHeight() - y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#"); // Liten explosion
                Console.ResetColor();
                System.Threading.Thread.Sleep(500); 
                Console.SetCursorPosition(x + 1, map.GetHeight() - y);
                Console.Write(" "); 
            }
        }
    }
}
