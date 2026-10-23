using System;
using TankWars.Map;

namespace TankWars.Factories
{
    public class EarthMapFactory : IMapFactory
    {
        protected readonly ITerrainGenerator _terrainGenerator;

        public EarthMapFactory(ITerrainGenerator terrainGenerator)
        {
            _terrainGenerator = terrainGenerator
                ?? throw new ArgumentNullException(nameof(terrainGenerator));
        }

        public IMap CreateMap(int width, int maxHeight)
        {
            // Använder den injicerade strategin för att generera jordens terräng.
            int[] heights = _terrainGenerator.GenerateTerrain(width, maxHeight);
            return new EarthMap(heights, maxHeight);
        }
    }
}
