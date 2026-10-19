//Ersätter cannon

using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    // BRIDGE PATTERN: Abstraction
    // Istället för Cannon, har vi en BaseBullet som ärver av IWeapon
    public abstract class BaseBullet : IWeapon
    {
        public int Damage { get; protected set; }
        // Skottet "äger" ett beteende (Strategy/Bridge)
        protected IAirBehavior flightBehavior;

        public BaseBullet(IAirBehavior behavior)
        {
            flightBehavior = behavior;
        }

        public void Fire(int startX, int startY, double power, int angle, IMap map)
        {
            flightBehavior.Reset();
            double angleRad = angle * Math.PI / 180.0;
            double vx = power * 0.1 * Math.Cos(angleRad);
            double vy = power * 0.1 * Math.Sin(angleRad);
            double x = startX;
            double y = startY + 1;
            bool isFlying = true;

            while (isFlying)
            {
                ConsoleKey? keyPressed = null;

                // MAGIN: Kollar om en knapp trycktes ner MEDAN skottet är i luften
                if (Console.KeyAvailable)
                {
                    keyPressed = Console.ReadKey(true).Key;
                    
                    // Rensar bufferten ifall spelaren spammar knappen
                    while (Console.KeyAvailable) Console.ReadKey(true); 
                }

                // 1. RÖRELSE
                x += vx;
                y += vy;

                // 2. STRATEGY/BRIDGE: Låt beteendet bestämma vad som händer med farten!
                flightBehavior.UpdateVelocity(ref vx, ref vy, keyPressed);

                int screenX = (int)Math.Round(x);
                int screenY = (int)Math.Round(y);

                // 3. KANTKONTROLL
                if (screenX < 0 || screenX >= map.TerrainHeights.Length)
                {
                    isFlying = false;
                    break;
                }

                // 4. MARKKONTROLL (Träff)
                if (screenY <= map.TerrainHeights[screenX])
                {
                    // Anropar den abstrakta explosionen (som bestäms av subklasserna!)
                    DrawExplosion(screenX, map.TerrainHeights[screenX] + 1, map);
                    isFlying = false;
                    break;
                }

                DrawProjectile(screenX, screenY, map);
                System.Threading.Thread.Sleep(50); // Något långsammare så man hinner reagera
                EraseProjectile(screenX, screenY, map);
            }
        }

        private void DrawProjectile(int x, int y, IMap map)
        {
            if (y < map.Height)
            {
                Console.SetCursorPosition(x + 1, map.Height - y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("*");
                Console.ResetColor();
            }
        }

        private void EraseProjectile(int x, int y, IMap map)
        {
            if (y < map.Height)
            {
                Console.SetCursorPosition(x + 1, map.Height - y);
                Console.Write(" "); // Bytt från "." till " " för ett renare utseende
            }
        }

        // Tvingar olika skott att ha olika stora explosioner
        protected abstract void DrawExplosion(int x, int y, IMap map);
    }
}
