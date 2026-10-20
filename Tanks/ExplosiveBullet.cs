using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class ExplosiveBullet : BaseBullet
    {
        public ExplosiveBullet(IAirBehavior behavior) : base(behavior) 
        { 
            Damage = 25;
        }

        protected override void DrawExplosion(int x, int y, IMap map)
        {
            if (y < map.GetHeight())
            {
                // En större explosion för detta unika skott
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(Math.Max(1, x), map.GetHeight() - y);
                Console.Write("###"); 
                Console.ResetColor();
                System.Threading.Thread.Sleep(500); 
                Console.SetCursorPosition(Math.Max(1, x), map.GetHeight() - y);
                Console.Write("   "); 
            }
        }
    }
}
