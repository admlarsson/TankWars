using TankWars.Map;

namespace TankWars.Factories
{
    public class TrainingMapFactory : IMapFactory
    {
        protected readonly ITerrainGenerator _terrainGenerator;

        public TrainingMapFactory(ITerrainGenerator terrainGenerator)
        {
            _terrainGenerator = terrainGenerator
                ?? throw new ArgumentNullException(nameof(terrainGenerator));
        }

        public IMap CreateMap(int width, int maxHeight)
        {
            int[] heights = _terrainGenerator.GenerateTerrain(width, maxHeight);
            return new TrainingMap(heights, maxHeight);
        }
    }
}