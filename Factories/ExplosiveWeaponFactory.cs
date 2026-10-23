using TankWars.Tanks;

namespace TankWars.Factories
{
    public class ExplosiveWeaponFactory : IWeaponFactory
    {
        public IWeapon Create(IAirBehavior behavior)
        {
            return new ExplosiveBullet(behavior);
        }
    }
}
