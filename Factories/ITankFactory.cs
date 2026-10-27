using TankWars.Map;
using TankWars.Tanks;

namespace TankWars.Factories
{
    public interface ITankFactory
    {
        ITank CreateTank( 
            IMap map, 
            IWeapon weapon);
    }
}