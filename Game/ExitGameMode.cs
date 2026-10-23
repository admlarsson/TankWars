using System;
using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Game
{
    public class ExitGameMode : IGameModeStrategy
    {
        public bool ShouldExit => true;
        public bool Player1ChoosesWeapon => false;
        public bool Player2ChoosesWeapon => false;

        public ITankFactory CreatePlayer1TankFactory() => throw UnsupportedOperation();
        public ITankFactory CreatePlayer2TankFactory() => throw UnsupportedOperation();
        public IWeapon CreatePlayer1Weapon(GameSettings settings) => throw UnsupportedOperation();
        public IWeapon CreatePlayer2Weapon(GameSettings settings) => throw UnsupportedOperation();
        public string GetPlayerName(bool isPlayer1) => throw UnsupportedOperation();

        protected InvalidOperationException UnsupportedOperation()
        {
            return new InvalidOperationException("Avslutsvalet kan inte starta en match.");
        }
    }
}
