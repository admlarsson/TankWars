using TankWars.Items;

namespace TankWars.Factories
{
    public class RandomPowerUpFactory : IPowerUpFactory
    {
        private readonly Random _random = new Random();

        public IPowerUp CreatePowerUp(int x, int y, int mapHeight)
        {
            return _random.Next(3) switch
            {
                0 => new PowerUp(
                    x, y, mapHeight,
                    new HealEffect(), '+', ConsoleColor.Green),

                1 => new PowerUp(
                    x, y, mapHeight,
                    new ShieldEffect(), 'S', ConsoleColor.Cyan),

                _ => new PowerUp(
                    x, y, mapHeight,
                    new BoostEffect(), 'B', ConsoleColor.Red)
            };
        }
    }
}