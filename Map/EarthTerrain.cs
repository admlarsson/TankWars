using System;

namespace TankWars.Map
{
    public class EarthTerrain : ITerrainGenerator
    {
        private readonly int _groundLevel;
        
        // 1. Skapa en slumpgenerator
        private readonly Random _random = new Random();

        public EarthTerrain(int groundLevel = 10)
        {
            _groundLevel = groundLevel;
        }

        public int[] GenerateTerrain(int width, int maxHeight)
        {
            int[] heights = new int[width];
            int platformWidth = 20; 

            // 2. Slumpa fram en startpunkt (förskjutning) mellan 0 och 1000
            // Så att sinus kurverna inte startar på samma ställe hela tiden
            double randomOffset = _random.NextDouble() * 1000;

            for (int x = 0; x < width; x++)
            {
                // KONTROLL 1: Är vi ute på kanterna? Då gör vi marken helt platt (vår startplattform)!
                if (x < platformWidth || x >= width - platformWidth)
                {
                    heights[x] = _groundLevel; 
                }
                // KONTROLL 2: Annars är vi i mitten av kartan, och här ska vi bygga berg!
                else
                {
                    double shiftedX = x - platformWidth;

                    // Vi ritar ut stora, mjuka backar och dalar
                    double mountainBase = Math.Sin((shiftedX + randomOffset) * 0.1) * 5.0; 

                    //Vi lägger till små stenar och gupp ovanpå de stora backarna 
                    double sharpRocks = Math.Sin((shiftedX + randomOffset) * 0.4) * 2.0; 

                    //Vi lägger ihop allt (Standardhöjden + stora backar + små gupp)
                    double totalHeight = _groundLevel + mountainBase + sharpRocks;

                    //Tvättar datan (Avrundar till heltal och sätter lägsta värde till 1) så att terminalen kan rita ut hela block 
                    int finalY = (int)Math.Max(1, Math.Round(totalHeight));

                    // Sätter också ett maxHeight så att bergen inte kan växa högre än skärmen
                    finalY = Math.Min(maxHeight - 1, finalY);

                    heights[x] = finalY;
                }
            }

            return heights;
        }
    }
}