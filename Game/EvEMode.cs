using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Game
{
    public class EvEMode : IGameModeStrategy
    {
        private readonly Random _random = new Random();

        public bool ShouldExit => false;
        public bool Player1ChoosesWeapon => false;
        public bool Player2ChoosesWeapon => false;

        public bool UsesBotPlayer1() => true;
        public bool UsesBotPlayer2() => true;

        public ITankFactory CreatePlayer1TankFactory(IBotStrategy botStrategy) =>
            new BotTankFactory(1, botStrategy);
        public ITankFactory CreatePlayer2TankFactory(IBotStrategy botStrategy) =>
            new BotTankFactory(2, botStrategy);

        public IWeapon CreatePlayer1Weapon(IWeaponFactory factory, IAirBehavior behavior)
        {
            return CreateRandomWeapon();
        }

        public IWeapon CreatePlayer2Weapon(IWeaponFactory factory, IAirBehavior behavior)
        {
            return CreateRandomWeapon();
        }

        protected IWeapon CreateRandomWeapon()
        {
            IWeaponFactory factory = _random.Next(2) == 0
                ? new NormalWeaponFactory()
                : new ExplosiveWeaponFactory();
            IAirBehavior behavior = _random.Next(2) == 0
                ? new GravityBehavior()
                : new DropBehavior();
            return factory.Create(behavior);
        }

        public IPowerUpFactory CreatePowerUpFactory() => 
            new LocationBasedPowerUpFactory();

        public string GetPlayerName(bool isPlayer1) => 
            isPlayer1 ? "Spelare 1" : "Datorn";
    }
}
