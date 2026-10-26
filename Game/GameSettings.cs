using TankWars.Factories;
using TankWars.Map;
using TankWars.Tanks;

namespace TankWars.Game
{
    // GameSettings fungerar som beställningssedel: menyernas valda fabriker
    // och beteenden sparas här som objekt, inte som primitiva valkoder.
    public class GameSettings
    {
        private IBotStrategy _player1BotStrategy = new MediumBotStrategy();
        private IBotStrategy _player2BotStrategy = new MediumBotStrategy();

        public IGameModeStrategy GameMode { get; set; } = new PvEMode();
        // Standardkartan får samma terrängstrategi som träningsvalet i menyn.
        public IMapFactory MapFactory { get; set; } =
            new TrainingMapFactory(new TrainingTerrain(groundLevel: 0));
        public IWeaponFactory Player1WeaponFactory { get; set; } = 
            new NormalWeaponFactory();
        public IAirBehavior Player1AirBehavior { get; set; } = 
            new GravityBehavior();
        public IWeaponFactory Player2WeaponFactory { get; set; } = 
            new NormalWeaponFactory();
        public IAirBehavior Player2AirBehavior { get; set; } = 
            new GravityBehavior();

        public IBotStrategy GetPlayer1BotStrategy() => _player1BotStrategy;
        public IBotStrategy GetPlayer2BotStrategy() => _player2BotStrategy;
        public void SetPlayer1BotStrategy(IBotStrategy strategy) => 
            _player1BotStrategy = strategy;
        public void SetPlayer2BotStrategy(IBotStrategy strategy) => 
            _player2BotStrategy = strategy;
    }
}