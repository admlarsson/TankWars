using TankWars.Tanks;

namespace TankWars.Items
{
    public class BoostEffect : IPowerUpEffect
    {
        public void Apply(ITank tank)
        {
            tank.BoostNextShot();
        }
    }
}