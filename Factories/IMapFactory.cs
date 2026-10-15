using TankWars.Map;

namespace TankWars.Factories
{
    public interface IMapFactory
    {
        IMap CreateMap(int width, int maxHeight);
    }
}