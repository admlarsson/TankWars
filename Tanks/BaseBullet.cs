//Ersätter cannon

using System;
using System.Dynamic;
using TankWars.Map;

namespace TankWars.Tanks
{
    // FALL #6:
    // VAD: Bridge Pattern
    // HUR: Abstraktionen (BaseBullet med subtyper Normal/Explosive) är
    // komponerad med en implementatör (IAirBehavior med subtyper Gravity/Drop).
    // VARFÖR: Undviker en exponentiell klass-explosion. Valfri ammunition
    // kan kombineras med valfritt flygbeteende dynamiskt vid runtime.


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

                // MAGIN: Kollar om en knapp trycktes ner MEDAN skottet är i luften
                if (Console.KeyAvailable)
                {
                    keyPressed = Console.ReadKey(true).Key;
                    
                    // Rensar bufferten ifall spelaren spammar knappen
                    while (Console.KeyAvailable) Console.ReadKey(true); 

                    
                }
            return keyPressed;

        }



        public void Fire(int startX, int startY, double power, int angle, IMap map, int damageBonus)
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
                // Kollar om konapp trycks ned under färd
                ConsoleKey? keyPressed = GetInputDuringFlight();

                // 1. RÖRELSE
                x += vx; y += vy;

                // 2. STRATEGY/BRIDGE: Låt beteendet bestämma vad som händer med farten!
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

            // 1. Markkontroll: Träffade vi marken?
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

            map.DrawDecorations(); // Gör så att exmpelvis flaggan inte går sönder
        }

        protected void EraseProjectile(int x, int y, IMap map)
        {
           int consoleY = y < map.Height
        ? map.Height - y
        : 1;

    Console.SetCursorPosition(x + 1, consoleY);
    Console.Write(" ");
        }

        // Hjälpmetod för att dela ut skada till alla tanks inom en viss radie (Undviker kodduplicering)
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




        // Ersätter DrawExplosion. Tvingar subklasserna att bestämma både utseende OCH skaderadie.
        protected abstract void Explode(int x, int y, IMap map, ITank? hitTank);

    }
}
