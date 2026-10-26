using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Game
{
    // FALL #3:
    // VAD: Strategy Pattern
    // HUR: PvEMode, PvPMode och EvEMode injiceras via GameSettings och används
    // för att välja tankfabriker, vapen, menyval och deltagarnamn.
    // VARFÖR: Varje spelläge kapslar in olika regler så klientkoden slipper
    // avgöra lägesbeteende med jämförelser av primitiva valkoder.
    public interface IGameModeStrategy
    {
        bool ShouldExit { get; }
        bool Player1ChoosesWeapon { get; }
        bool Player2ChoosesWeapon { get; }
        bool UsesBotPlayer1();
        bool UsesBotPlayer2();
        ITankFactory CreatePlayer1TankFactory(GameSettings settings);
        ITankFactory CreatePlayer2TankFactory(GameSettings settings);
        IWeapon CreatePlayer1Weapon(GameSettings settings);
        IWeapon CreatePlayer2Weapon(GameSettings settings);
        IPowerUpFactory CreatePowerUpFactory();
        string GetPlayerName(bool isPlayer1);
    }
}
