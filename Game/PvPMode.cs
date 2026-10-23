using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Game
{
    public class PvPMode : IGameModeStrategy
    {
        public bool ShouldExit => false;
        public bool Player1ChoosesWeapon => true;
        public bool Player2ChoosesWeapon => true;

        public ITankFactory CreatePlayer1TankFactory() => new PlayerTankFactory(1);
        public ITankFactory CreatePlayer2TankFactory() => new PlayerTankFactory(2);

        public IWeapon CreatePlayer1Weapon(GameSettings settings)
        {
            return settings.Player1WeaponFactory.Create(settings.Player1AirBehavior);
        }

        public IWeapon CreatePlayer2Weapon(GameSettings settings)
        {
            return settings.Player2WeaponFactory.Create(settings.Player2AirBehavior);
        }

        public string GetPlayerName(bool isPlayer1) => isPlayer1 ? "Spelare 1" : "Spelare 2";
    }
}
