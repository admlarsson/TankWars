using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Game
{
    // FALL #3:
    // Vad: Strategy Pattern
    //
    // HUR: Vi använder IGameModeStrategy för våra olika spellägen: PvP, PvE och EvE.
    // I MenuController väljer spelaren vilket spelläge som ska användas.
    // Varje spelläge bestämmer bland annat vilka spelare som är bottar,
    // vilka tankfabriker som ska användas och hur vapen och power-ups skapas.
    // GameFactory och GameSession använder sedan det valda spelläget.
    //
    // VARFÖR: Vi kan ha olika regler för varje spelläge utan att behöva
    // skriva en massa if-satser i resten av spelet. Det blir också enklare
    // att lägga till nya spellägen utan att ändra den befintliga spellogiken.
    public interface IGameModeStrategy
    {
        bool ShouldExit { get; }
        bool Player1ChoosesWeapon { get; }
        bool Player2ChoosesWeapon { get; }
        bool UsesBotPlayer1();
        bool UsesBotPlayer2();
        ITankFactory CreatePlayer1TankFactory(IBotStrategy botStrategy);
        ITankFactory CreatePlayer2TankFactory(IBotStrategy botStrategy);
        IWeapon CreatePlayer1Weapon(IWeaponFactory factory, IAirBehavior behavior);
        IWeapon CreatePlayer2Weapon(IWeaponFactory factory, IAirBehavior behavior);
        IPowerUpFactory CreatePowerUpFactory();
        string GetPlayerName(bool isPlayer1);
    }
}
