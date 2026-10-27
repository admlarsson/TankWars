using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Game
{
    public class ExitGameMode : IGameModeStrategy
    {
        public bool ShouldExit => true;
        public bool Player1ChoosesWeapon => false;
        public bool Player2ChoosesWeapon => false;
        public bool UsesBotPlayer1() => false;
        public bool UsesBotPlayer2() => false;

        public ITankFactory CreatePlayer1TankFactory(IBotStrategy botStrategy) =>
            throw UnsupportedOperation();
        public ITankFactory CreatePlayer2TankFactory(IBotStrategy botStrategy) =>
            throw UnsupportedOperation();
        public IWeapon CreatePlayer1Weapon(IWeaponFactory factory, IAirBehavior behavior) =>
            throw UnsupportedOperation();
        public IWeapon CreatePlayer2Weapon(IWeaponFactory factory, IAirBehavior behavior) =>
            throw UnsupportedOperation();
        public IPowerUpFactory CreatePowerUpFactory() => 
            throw UnsupportedOperation();
        public string GetPlayerName(bool isPlayer1) => 
            throw UnsupportedOperation();

        protected InvalidOperationException UnsupportedOperation()
        {
            return new InvalidOperationException("Avslutsvalet kan inte starta en match.");
        }
    }
}
