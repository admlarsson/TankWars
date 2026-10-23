using TankWars.Factories;
using TankWars.Map;
using TankWars.Tanks;

namespace TankWars.Game
{
    // GameSettings fungerar som beställningssedel: menyernas valda fabriker
    // och beteenden sparas här som objekt, inte som primitiva valkoder.
    public class GameSettings
    {
        public IGameModeStrategy GameMode { get; set; } = new PvEMode();
        // Standardkartan får samma terrängstrategi som träningsvalet i menyn.
        public IMapFactory MapFactory { get; set; } =
            new TrainingMapFactory(new TrainingTerrain(groundLevel: 0));
        public IWeaponFactory Player1WeaponFactory { get; set; } = new NormalWeaponFactory();
        public IAirBehavior Player1AirBehavior { get; set; } = new GravityBehavior();
        public IWeaponFactory Player2WeaponFactory { get; set; } = new NormalWeaponFactory();
        public IAirBehavior Player2AirBehavior { get; set; } = new GravityBehavior();
    }
}