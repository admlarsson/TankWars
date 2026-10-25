using TankWars.Tanks;

namespace TankWars.Items
{
    public class ShieldEffect : IPowerUpEffect
    {
        public void Apply(ITank tank)
        {
            tank.ActivateShield();
        }
    }
}