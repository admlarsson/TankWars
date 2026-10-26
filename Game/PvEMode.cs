using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Game
{
    public class PvEMode : IGameModeStrategy
    {
        public bool ShouldExit => false;
        public bool Player1ChoosesWeapon => true;
        public bool Player2ChoosesWeapon => false;

        public bool UsesBotPlayer1() => false;
        public bool UsesBotPlayer2() => true;

        public ITankFactory CreatePlayer1TankFactory(GameSettings settings) => new PlayerTankFactory(1);
        public ITankFactory CreatePlayer2TankFactory(GameSettings settings) =>
            new BotTankFactory(2, settings.GetPlayer2BotStrategy());

        public IWeapon CreatePlayer1Weapon(GameSettings settings)
        {
            return settings.Player1WeaponFactory.Create(settings.Player1AirBehavior);
        }

        public IWeapon CreatePlayer2Weapon(GameSettings settings)
        {
            return new NormalWeaponFactory().Create(new GravityBehavior());
        }

        public IPowerUpFactory CreatePowerUpFactory() => new LocationBasedPowerUpFactory();

        public string GetPlayerName(bool isPlayer1) => isPlayer1 ? "Spelare 1" : "Datorn";
    }
}
