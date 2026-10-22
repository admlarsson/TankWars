using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class NormalBullet : BaseBullet
    {
        // Skickar flygbeteendet vidare till BaseBullet
        public NormalBullet(IAirBehavior behavior) : base(behavior, 50)  { }

        protected override void Explode(int x, int y, IMap map)
        {
            if (y < map.Height)
            {
                Console.SetCursorPosition(x + 1, map.Height - y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#"); // Liten explosion
                Console.ResetColor();
                System.Threading.Thread.Sleep(500); 
                Console.SetCursorPosition(x + 1, map.Height - y);
                Console.Write(" "); 
            }
            DealAreaDamage(x, map, 0);
        }
    }
}
