using TankWars.Items;


namespace TankWars.Factories
{
    public interface IPowerUpFactory
    {
        IPowerUp CreatePowerUp(
            int x,
            int y, 
            int mapHeight);
    }
        
}