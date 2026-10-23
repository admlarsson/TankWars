using TankWars.Tanks;

namespace TankWars.Factories
{
    public class NormalWeaponFactory : IWeaponFactory
    {
        public IWeapon Create(IAirBehavior behavior)
        {
            return new NormalBullet(behavior);
        }
    }
}
