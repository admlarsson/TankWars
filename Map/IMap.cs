using TankWars.Core;
using TankWars.Items;
using TankWars.Tanks;

namespace TankWars.Map
{
    public interface IMap
    {
        int Height { get; }
        
        int[] TerrainHeights { get; }

        EntityManager<ITank> Tanks { get; }
        EntityManager<IPowerUp> PowerUps { get; }

        void Draw();
        void DrawDecorations();
        void CheckPowerUpPickup(ITank tank);
    }
}