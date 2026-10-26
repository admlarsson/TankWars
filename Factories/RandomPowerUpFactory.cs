using TankWars.Items;

namespace TankWars.Factories
{
    public class RandomPowerUpFactory : IPowerUpFactory
    {
        private readonly Random _random = new Random();

        public IPowerUp CreatePowerUp(int x, int y, int mapHeight)
        {
            return _random.Next(3)
            switch
            {
                0 => new HealPowerUp(x, y, mapHeight),

                1 => new ShieldPowerUp(x, y, mapHeight),

                _ => new BoostPowerUp(x, y, mapHeight)
            };
        }
    }
}