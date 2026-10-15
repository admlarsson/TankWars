using System.Text.RegularExpressions;

namespace TankWars.Map

{
    public class MoonTerrain : ITerrainGenerator

    {
        public int [] GenerateTerrain(int width, int maxHeight)
        {
            int [] heights = new int[width];

            double peak = maxHeight/3;
            double center = width/2;

            for (int x=0; x<width; x++)
            {
                double a = peak / (center * center);
                double height = peak - a * Math.Pow(x-center, 2);

                heights [x] = (int)Math.Max(1, Math.Round(height));

            }
            return heights;
        }
    }

}