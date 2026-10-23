using System;
using System.IO.MemoryMappedFiles;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class ExplosiveBullet : BaseBullet
    {
        public ExplosiveBullet(IAirBehavior behavior) : base(behavior, 25) { }

        protected override void Explode(int x, int y, IMap map, ITank? hitTank)
        {
            if (y < map.Height)
            {
                // En större explosion för detta unika skott
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(Math.Max(1, x), map.Height - y);
                Console.Write("###"); 
                Console.ResetColor();
                System.Threading.Thread.Sleep(500); 
                Console.SetCursorPosition(Math.Max(1, x), map.Height - y);
                Console.Write("   "); 
            }
            DealAreaDamage(x, map, 2);
        }
    }
}
