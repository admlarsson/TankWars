using TankWars.Items;


namespace TankWars.Factories
{
    // FALL #10:
    // VAD: Factory Method Pattern
    // HUR: Har två konkreta subtyper (RandomPowerUpFactory och
    // LocationBasedPowerUpFactory) som bygger produkter ur IPowerUp-hierarkin.
    // VARFÖR: Subtyperna skiljer sig markant. Den ena är stokastisk (slump),
    // den andra använder en matematisk algoritm (x % 3) för att bygga föremål.
    public interface IPowerUpFactory
    {
        IPowerUp CreatePowerUp(
            int x,
            int y, 
            int mapHeight);
    }
        
}