using TankWars.Map;

namespace TankWars.Factories
{
    public class TrainingMapFactory : IMapFactory
    {
        public IMap CreateMap(int width, int maxHeight)
        {
            ITerrainGenerator generator = new TrainingTerrain(groundLevel: 0);  //Här skapas terrängen med ground level 0

            int [] heights = generator.GenerateTerrain(width, maxHeight);

            return new TrainingMap(heights, maxHeight);
        }


    }
}