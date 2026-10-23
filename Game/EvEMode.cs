using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Game
{
    public class EvEMode : IGameModeStrategy
    {
        public bool ShouldExit => false;
        public bool Player1ChoosesWeapon => false;
        public bool Player2ChoosesWeapon => false;

        public ITankFactory CreatePlayer1TankFactory() => new BotTankFactory(1);
        public ITankFactory CreatePlayer2TankFactory() => new BotTankFactory(2);

        public IWeapon CreatePlayer1Weapon(GameSettings settings)
        {
            return new NormalWeaponFactory().Create(new GravityBehavior());
        }

        public IWeapon CreatePlayer2Weapon(GameSettings settings)
        {
            return new NormalWeaponFactory().Create(new GravityBehavior());
        }

        public string GetPlayerName(bool isPlayer1) => isPlayer1 ? "Spelare 1" : "Datorn";
    }
}
