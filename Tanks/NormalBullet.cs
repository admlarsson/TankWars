using TankWars.Map;

namespace TankWars.Tanks
{
    public class NormalBullet : BaseBullet
    {
        public NormalBullet(IAirBehavior behavior) : base(behavior, 50)  { }

        protected override void Explode(int x, int y, IMap map, ITank? hitTank)
        {
            if (y < map.Height)
            {
                Console.SetCursorPosition(x + 1, map.Height - y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#"); 
                Console.ResetColor();
                System.Threading.Thread.Sleep(500); 
                Console.SetCursorPosition(x + 1, map.Height - y);
                Console.Write(" "); 
            }
            if (hitTank is not null) DealDamage(hitTank, map);
            else DealAreaDamage(x, map, 0);
        }
    }
}
