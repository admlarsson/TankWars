using System;
using TankWars.Map;

namespace TankWars.Factories
{
    public class MoonMapFactory : IMapFactory
    {
        protected readonly ITerrainGenerator _terrainGenerator;

        public MoonMapFactory(ITerrainGenerator terrainGenerator)
        {
            _terrainGenerator = terrainGenerator
                ?? throw new ArgumentNullException(nameof(terrainGenerator));
        }

        public IMap CreateMap(int width, int maxHeight)
        {
            // Använder den injicerade strategin för att generera månens terräng.
            int[] heights = _terrainGenerator.GenerateTerrain(width, maxHeight);
            return new MoonMap(heights, maxHeight);
        }
    }
}