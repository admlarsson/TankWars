using TankWars.Core;
using TankWars.Items;
using TankWars.Tanks;

namespace TankWars.Map
{
    public interface IMap
    {
        // Lägg till Height här så att alla vet att en IMap alltid har en höjd!
        int Height { get; }
        
        int[] TerrainHeights { get; }

        EntityManager<ITank> Tanks { get; }
        EntityManager<IPowerUp> PowerUps { get; }

        void Draw();
    }
}