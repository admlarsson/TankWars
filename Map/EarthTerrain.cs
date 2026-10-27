namespace TankWars.Map
{
    public class EarthTerrain : ITerrainGenerator
    {
        private readonly int _groundLevel;
        
        private readonly Random _random = new Random();

        public EarthTerrain(int groundLevel = 10)
        {
            _groundLevel = groundLevel;
        }

        public int[] GenerateTerrain(int width, int maxHeight)
        {
            int[] heights = new int[width];
            int platformWidth = 20; 

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

                    double mountainBase = 
                        Math.Sin((shiftedX + randomOffset) * 0.1) * (maxHeight * 0.2); 

                    double sharpRocks = 
                        Math.Sin((shiftedX + randomOffset) * 0.4) * (maxHeight * 0.05);

                    double totalHeight = 
                        _groundLevel + mountainBase + sharpRocks;

                    int finalY = (int)Math.Max(1, Math.Round(totalHeight));

                    finalY = Math.Min(maxHeight - 1, finalY);

                    heights[x] = finalY;
                }
            }
            return heights;
        }
    }
}