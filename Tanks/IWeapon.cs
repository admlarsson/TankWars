using TankWars.Map;

namespace TankWars.Tanks
{
    public interface IWeapon
    {
        void Fire(
            int startX, 
            int startY, 
            double power, 
            int angle, 
            IMap map,
            int damageBonus); 
    }
}