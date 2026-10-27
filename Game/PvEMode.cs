using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Game
{
    public class PvEMode : IGameModeStrategy
    {
        private readonly Random _random = new Random();

        public bool ShouldExit => false;
        public bool Player1ChoosesWeapon => true;
        public bool Player2ChoosesWeapon => false;

        public bool UsesBotPlayer1() => false;
        public bool UsesBotPlayer2() => true;

        public ITankFactory CreatePlayer1TankFactory(IBotStrategy botStrategy) =>
            new PlayerTankFactory(1);
        public ITankFactory CreatePlayer2TankFactory(IBotStrategy botStrategy) =>
            new BotTankFactory(2, botStrategy);

        public IWeapon CreatePlayer1Weapon(IWeaponFactory factory, IAirBehavior behavior)
        {
            return factory.Create(behavior);
        }

        public IWeapon CreatePlayer2Weapon(IWeaponFactory factory, IAirBehavior behavior)
        {
            IWeaponFactory randomFactory = _random.Next(2) == 0
                ? new NormalWeaponFactory()
                : new ExplosiveWeaponFactory();
            IAirBehavior randomBehavior = _random.Next(2) == 0
                ? new GravityBehavior()
                : new DropBehavior();
            return randomFactory.Create(randomBehavior);
        }

        public IPowerUpFactory CreatePowerUpFactory() => 
            new LocationBasedPowerUpFactory();

        public string GetPlayerName(bool isPlayer1) => 
            isPlayer1 ? "Spelare 1" : "Datorn";
    }
}
