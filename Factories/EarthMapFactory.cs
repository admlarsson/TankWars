using TankWars.Map;

namespace TankWars.Factories
{
    public class EarthMapFactory : IMapFactory
    {
        public IMap CreateMap(int width, int maxHeight)
        {
            // Vi bestämmer att bergen ska utgå från rad 7
            ITerrainGenerator generator = new EarthTerrain(groundLevel: 7);
            
            int[] heights = generator.GenerateTerrain(width, maxHeight);
            return new EarthMap(heights, maxHeight);
        }
    }
}