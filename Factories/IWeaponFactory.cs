using TankWars.Tanks;

namespace TankWars.Factories
{
    public interface IWeaponFactory
    {
        IWeapon Create(IAirBehavior behavior);
    }
}
