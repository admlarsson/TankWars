using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Game
{
    public class EvEMode : IGameModeStrategy
    {
        public bool ShouldExit => false;
        public bool Player1ChoosesWeapon => false;
        public bool Player2ChoosesWeapon => false;

        public bool UsesBotPlayer1() => true;
        public bool UsesBotPlayer2() => true;

        public ITankFactory CreatePlayer1TankFactory(GameSettings settings) =>
            new BotTankFactory(1, settings.GetPlayer1BotStrategy());
        public ITankFactory CreatePlayer2TankFactory(GameSettings settings) =>
            new BotTankFactory(2, settings.GetPlayer2BotStrategy());

        public IWeapon CreatePlayer1Weapon(GameSettings settings)
        {
            return new NormalWeaponFactory().Create(new GravityBehavior());
        }

        public IWeapon CreatePlayer2Weapon(GameSettings settings)
        {
            return new NormalWeaponFactory().Create(new GravityBehavior());
        }

        public IPowerUpFactory CreatePowerUpFactory() => new LocationBasedPowerUpFactory();

        public string GetPlayerName(bool isPlayer1) => isPlayer1 ? "Spelare 1" : "Datorn";
    }
}
