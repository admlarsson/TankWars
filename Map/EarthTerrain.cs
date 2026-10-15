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
            double randomOffset = _random.NextDouble() * 1000;

            for (int x = 0; x < width; x++)
            {
                if (x < platformWidth || x >= width - platformWidth)
                {
                    heights[x] = _groundLevel; 
                }
                else
                {
                    double shiftedX = x - platformWidth;

                    // 3. Lägg till det slumpmässiga värdet inuti parentesen
                    double mountainBase = Math.Sin((shiftedX + randomOffset) * 0.1) * 5.0; 
                    double sharpRocks = Math.Sin((shiftedX + randomOffset) * 0.4) * 2.0; 

                    double totalHeight = _groundLevel + mountainBase + sharpRocks;

                    int finalY = (int)Math.Max(1, Math.Round(totalHeight));
                    finalY = Math.Min(maxHeight - 1, finalY);

                    heights[x] = finalY;
                }
            }

            return heights;
        }
    }
}