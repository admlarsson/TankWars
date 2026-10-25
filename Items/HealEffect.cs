using TankWars.Tanks;

namespace TankWars.Items
{
    public class HealEffect : IPowerUpEffect
    {
        public void Apply(ITank tank)
        {
            tank.Heal(25);
        }
    }
    
}