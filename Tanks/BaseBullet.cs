//Ersätter cannon

using System;
using System.Dynamic;
using TankWars.Map;

namespace TankWars.Tanks
{
        // FALL #1:
        // Bridge Pattern (Strukturellt mönster).

        // Vi har frikopplat vapnets abstraktion (Ammunitionen: BaseBullet, NormalBullet, ExplosiveBullet) 
        // från dess implementering (Flygbeteendet: IAirBehavior, GravityBehavior, DropBehavior). 
        // BaseBullet "äger" en IAirBehavior-instans och delegerar logiken för rörelse (UpdateVelocity) över bron till beteendet.
      
        // Varför?
        // För att undvika en explosion av klasser (t.ex. NormalGravityBullet, ExplosiveDropBullet). 
        // Nu kan vi kombinera valfri ammunition med valfritt flygbeteende dynamiskt vid runtime, 
        // vilket gör det enkelt att lägga till nya skott eller flygsätt oberoende av varandra.

    public abstract class BaseBullet : IWeapon
    {
        public int Damage { get; }
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
                Explode(screenX, map.TerrainHeights[screenX] + 1, map);
                return false;
            }

            // 2. Tank-kontroll (Hitbox): Träffade vi en tank i luften?
            foreach (ITank tank in map.Tanks.All)
            {
                // Om skottet är max 1 block ifrån tanken (i X och Y), detonera!
                if (Math.Abs(screenX - tank.X) <= 2 && Math.Abs(screenY - tank.Y) <= +2)
                {
                    Explode(screenX, screenY, map);
                    return false;
                }
            }

            return true;
        }

        protected void DrawProjectile(int x, int y, IMap map)
        {
            if (y < map.Height)
            {
                Console.SetCursorPosition(x + 1, map.Height - y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("*");
                Console.ResetColor();
            }
        }

        protected void RenderFlightStep(int x, int y, IMap map)
        {
            DrawProjectile(x, y, map);
            Thread.Sleep(50);
            EraseProjectile(x, y, map);
        }

        protected void EraseProjectile(int x, int y, IMap map)
        {
            if (y < map.Height)
            {
                Console.SetCursorPosition(x + 1, map.Height - y);
                Console.Write(" "); 
            }
        }

        // Hjälpmetod för att dela ut skada till alla tanks inom en viss radie (Undviker kodduplicering)
        protected void DealAreaDamage(int hitX, IMap map, int blastRadius)
        {
            foreach (ITank tank in map.Tanks.All)
            {
                if (Math.Abs(tank.X - hitX) <= blastRadius)
                {
                    tank.TakeDamage(Damage);
                    
                    // Skriver ut skadan EXAKT ovanför den stridsvagn som blev träffad
                    int textX = Math.Max(0, tank.X - 5); 
                    int textY = Math.Max(0, map.Height - tank.Y - 2); 
                    
                    Console.SetCursorPosition(textX, textY);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($" -{Damage} HP! ");
                    Console.ResetColor();
                    
                    System.Threading.Thread.Sleep(1500); 
                    
                    // Suddar ut texten efter 1,5 sekunder
                    Console.SetCursorPosition(textX, textY);
                    Console.Write("           ");
                }
            }
        }




        // Ersätter DrawExplosion. Tvingar subklasserna att bestämma både utseende OCH skaderadie.
        protected abstract void Explode(int x, int y, IMap map);

    }
}
