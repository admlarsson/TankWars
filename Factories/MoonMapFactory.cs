using TankWars.Map;

namespace TankWars.Factories
{
public class MoonMapFactory : IMapFactory
{
    public IMap CreateMap(int width, int maxHeight)
        {
            ITerrainGenerator generator = new MoonTerrain();

            int [] heights = generator.GenerateTerrain(width, maxHeight);

            return new MoonMap(heights, maxHeight);
        }
}
}