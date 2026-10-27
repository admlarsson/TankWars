using TankWars.Factories;
using TankWars.Tanks;

namespace TankWars.Game
{
    // FALL #3:
    // VAD: Strategy Pattern
    // HUR: Spellägesstrategin skapar tankfabriker och vapen från injicerade
    // botstrategier, vapenfabriker och flygbeteenden.
    // VARFÖR: Varje spelläge kapslar in olika regler så klientkoden slipper
    // avgöra lägesbeteende med jämförelser av primitiva valkoder.
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
