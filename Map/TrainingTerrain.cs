namespace TankWars.Map
{


    public class TrainingTerrain : ITerrainGenerator
    {
        private readonly int groundLevel;

        public TrainingTerrain(int groundLevel = 0) => this.groundLevel = groundLevel;

        
        public int[] GenerateTerrain(int width, int maxHeight)
        {
            int[] heights = new int[width];

            for (int x = 0; x < width; x++)
            {
                heights[x] = groundLevel;
            }
            return heights;

        }

        }
}
