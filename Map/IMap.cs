using TankWars.Core;
using TankWars.Items;
using TankWars.Tanks;

namespace TankWars.Map
{
    public interface IMap
    {
        // Lägg till Height här så att alla vet att en IMap alltid har en höjd!
        int GetHeight();
        
        int[] GetTerrainHeights();

        EntityManager<ITank> GetTanks();
        EntityManager<IPowerUp> GetPowerUps(); 

        void Draw();
    }
}