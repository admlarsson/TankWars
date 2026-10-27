using TankWars.Map;

namespace TankWars.Tanks
{
    // FALL #6:
    // Vad: Bridge Pattern
    //
    // HUR: Vi använder BaseBullet som en gemensam basklass för NormalBullet
    // och ExplosiveBullet. BaseBullet får ett IAirBehavior genom konstruktorn,
    // vilket gör att båda projektiltyperna kan använda GravityBehavior eller
    // DropBehavior. Flygbeteendet styr hur projektilen rör sig under skottet.
    //
    // VARFÖR: Vi kan kombinera olika projektiler med olika flygbeteenden
    // utan att behöva skapa en separat klass för varje kombination.
    // Det blir enklare att lägga till nya projektiler och flygbeteenden.
    public abstract class BaseBullet : IWeapon
    {
        public int Damage { get; }
        private int _shotDamage;
        protected IAirBehavior flightBehavior;
        
        public BaseBullet(IAirBehavior behavior, int damage)
        {
            flightBehavior = behavior;
            Damage = damage;
        }
        
        protected ConsoleKey? GetInputDuringFlight()
        {
            ConsoleKey? keyPressed = null;

                if (Console.KeyAvailable)
                {
                    keyPressed = Console.ReadKey(true).Key;
                    
                    while (Console.KeyAvailable) Console.ReadKey(true); 
                }
            return keyPressed;
        }

        public void Fire(
            int startX, 
            int startY, 
            double power, 
            int angle, 
            IMap map, 
            int damageBonus)
        {
            _shotDamage = Damage + damageBonus;
            flightBehavior.Reset();
            double angleRad = angle * Math.PI / 180.0;
            double vx = power * 0.1 * Math.Cos(angleRad);
            double vy = power * 0.1 * Math.Sin(angleRad);
            double x = startX;
            double y = startY + 1;
            bool isFlying = true;

            while (isFlying)
            {
                ConsoleKey? keyPressed = GetInputDuringFlight();

                x += vx; y += vy;

                flightBehavior.UpdateVelocity(ref vx, ref vy, keyPressed);

                int screenX = (int)Math.Round(x);
                int screenY = (int)Math.Round(y);

                isFlying = CheckIfStillFlying(screenX, screenY, map);
                    if (isFlying == false)
                    {
                        break;
                    }

                RenderFlightStep(screenX, screenY, map);    
            }
        }

        protected bool CheckIfStillFlying(int screenX, int screenY, IMap map)
        {
            if (screenX < 0 || screenX >= map.TerrainHeights.Length) return false;

            if (screenY <= map.TerrainHeights[screenX])
            {
                Explode(screenX, map.TerrainHeights[screenX] + 1, map, null);
                return false;
            }

            return !CheckTankCollision(screenX, screenY, map);
        }

        protected bool CheckTankCollision(int x, int y, IMap map)
        {
            foreach (ITank tank in map.Tanks.All)
            {
                if (!tank.IsHitAt(x, y)) continue;
                Explode(x, y, map, tank);
                return true;
            }
            return false;
        }

        protected void DrawProjectile(int x, int y, IMap map)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (y < map.Height)
            {
                Console.SetCursorPosition(x + 1, map.Height - y);
                Console.Write("*");
            }
            else
            {
                Console.SetCursorPosition(x + 1, 1);
                Console.Write("^");
            }
        }

        protected void RenderFlightStep(int x, int y, IMap map)
        {
            DrawProjectile(x, y, map);
            Thread.Sleep(50);
            EraseProjectile(x, y, map);

            map.DrawDecorations(); 
        }

        protected void EraseProjectile(int x, int y, IMap map)
        {
            int consoleY = y < map.Height
            ? map.Height - y
            : 1;

            Console.SetCursorPosition(x + 1, consoleY);
            Console.Write(" ");
        }

        protected void DealAreaDamage(int hitX, IMap map, int blastRadius)
        {
            foreach (ITank tank in map.Tanks.All)
            {
                if (Math.Abs(tank.X - hitX) <= blastRadius) DealDamage(tank, map);
            }
        }

        protected void DealDamage(ITank tank, IMap map)
        {
            int actualDamage = tank.TakeDamage(_shotDamage);
            int textX = Math.Max(0, tank.X - 5);
            int textY = Math.Max(0, map.Height - tank.Y - 2);
            Console.SetCursorPosition(textX, textY);

            if(actualDamage > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($" -{actualDamage} HP! ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("SKÖLDEN BLOCKERADE");
            }

            
            Console.ResetColor();
            Thread.Sleep(1500);
            Console.SetCursorPosition(textX, textY);
            Console.Write("           ");
        }
        protected abstract void Explode(int x, int y, IMap map, ITank? hitTank);
    }
}
