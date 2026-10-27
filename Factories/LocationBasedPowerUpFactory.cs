using TankWars.Items;

namespace TankWars.Factories
{
    public class LocationBasedPowerUpFactory : IPowerUpFactory
    {
        public IPowerUp CreatePowerUp(int x, int y, int mapHeight)
        {
            int locationValue = x % 3;

            if(locationValue == 0)
            {
                return new ShieldPowerUp(x, y, mapHeight);
            }
            else if(locationValue == 1)
            {
                return new HealPowerUp(x, y, mapHeight);
            }
            else
            {
                return new BoostPowerUp(x, y , mapHeight);
            }
        }
    }
}
