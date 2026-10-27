namespace TankWars.Map
{
    public class MoonTerrain : ITerrainGenerator
    {
        public int [] GenerateTerrain(int width, int maxHeight)
        {
            int [] heights = new int[width];

            double peak = maxHeight/4.0; 
            double center = width/2.0; 

            double a = peak / (center * center); 

            for (int x = 0; x < width; x++) 
            {
                double height = peak - a * Math.Pow(x-center, 2); 

                heights[x] = (int)Math.Max(1, Math.Round(height)); 
            }
            return heights;
        }
    }

}