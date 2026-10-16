using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class Cannon : IWeapon
    {
        public void Fire(int startX, int startY, double power, int angle, IMap map)
        {
            // 1. Översätt Vinkel & Kraft till "Fart åt sidan" (vx) och "Fart uppåt" (vy)
            double angleRad = angle * Math.PI / 180.0; // Datorn vill ha radianer
            
            // Vi multiplicerar med 0.1 för att skottet inte ska flyga utanför skärmen på ett steg
            double vx = power * 0.1 * Math.Cos(angleRad); 
            double vy = power * 0.1 * Math.Sin(angleRad);

            // Gravitationen - hur mycket sänks "Fart uppåt" per loop?
            double gravity = 0.2; 

            // Skottets startposition (vi sparar som double för att kunna röra oss mjukt)
            double x = startX;
            double y = startY + 1; // Avfyras precis ovanför tanken

            bool isFlying = true;

            // Fysik-loopen: Snurrar så länge skottet är i luften
            while (isFlying)
            {
                // -- 1. RÖRELSE --
                x += vx;       // Flytta i sidled
                y += vy;       // Flytta i höjdled
                vy -= gravity; // Gravitationen drar i skottet (sänker farten i höjdled)

                // Gör om de exakta positionerna (double) till heltal (int) för skärmen
                int screenX = (int)Math.Round(x);
                int screenY = (int)Math.Round(y);

                // -- 2. KONTROLL: ÄR VI UTANFÖR KARTAN? --
                if (screenX < 0 || screenX >= map.TerrainHeights.Length)
                {
                    isFlying = false; // Skottet flög utanför kanten
                    break;
                }

                // -- 3. KONTROLL: TRÄFFADE VI MARKEN? --
                // Kollar vi om skottets Y-värde är på, eller under, markhöjden för just detta X
                if (screenY <= map.TerrainHeights[screenX])
                {
                    DrawExplosion(screenX, map.TerrainHeights[screenX] + 1, map);
                    isFlying = false;
                    break;
                }

                // -- 4. RITA UT SKOTTET --
                DrawProjectile(screenX, screenY, map);
                
                // Pausa i 30 millisekunder så ögat hinner se skottet flyga
                System.Threading.Thread.Sleep(30);
                
                // Suddar ut skottet igen, så vi inte ritar en lång linje utan en rörlig prick
                EraseProjectile(screenX, screenY, map);
            }
        }

        // --- HJÄLPMETODER FÖR ATT RITA PÅ SKÄRMEN ---
        
        private void DrawProjectile(int x, int y, IMap map)
        {
            // Rita bara om skottet inte är högre upp än skärmens tak
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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("."); // Rita ett mellanslag över stjärnan
            }
        }

        private void DrawExplosion(int x, int y, IMap map)
        {
            if (y < map.Height)
            {
                Console.SetCursorPosition(x + 1, map.Height - y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#"); 
                Console.ResetColor();
                
                // Låt explosionen synas en halv sekund innan den försvinner
                System.Threading.Thread.Sleep(500); 
                
                Console.SetCursorPosition(x + 1, map.Height - y);
                Console.Write(" "); // Rensa explosionen
            }
        }
    }
}