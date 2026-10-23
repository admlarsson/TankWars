using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Game
{
    public class PvEMode : IGameModeStrategy
    {
        public bool ShouldExit => false;
        public bool Player1ChoosesWeapon => true;
        public bool Player2ChoosesWeapon => false;

        public ITankFactory CreatePlayer1TankFactory() => new PlayerTankFactory(1);
        public ITankFactory CreatePlayer2TankFactory() => new BotTankFactory(2);

        public IWeapon CreatePlayer1Weapon(GameSettings settings)
        {
            return settings.Player1WeaponFactory.Create(settings.Player1AirBehavior);
        }

        public IWeapon CreatePlayer2Weapon(GameSettings settings)
        {
            return new NormalWeaponFactory().Create(new GravityBehavior());
        }

        public string GetPlayerName(bool isPlayer1) => isPlayer1 ? "Spelare 1" : "Datorn";
    }
}
