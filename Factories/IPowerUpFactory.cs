using TankWars.Items;

namespace TankWars.Factories
{
    // FALL #10:
    // Vad: Factory Method Pattern (Power-ups)
    //
    // HUR: Vi använder IPowerUpFactory för att skapa olika power-ups.
    // RandomPowerUpFactory väljer slumpmässigt vilken power-up som skapas,
    // medan LocationBasedPowerUpFactory använder X-koordinaten (x % 3)
    // för att bestämma typen. Den valda fabriken skickas till GameSession,
    // som använder CreatePowerUp() för att skapa power-ups under matchen.
    //
    // VARFÖR: Vi kan använda olika sätt att skapa power-ups utan att behöva
    // ändra logiken i GameSession. Det blir också enklare att lägga till
    // nya power-ups eller fabriker med andra regler för hur de skapas.
    public interface IPowerUpFactory
    {
        IPowerUp CreatePowerUp(
            int x,
            int y, 
            int mapHeight);
    }
        
}