using TankWars.Tanks;

namespace TankWars.Items
{
    public interface IPowerUpEffect
    {
        void Apply(ITank tank);
    }
}