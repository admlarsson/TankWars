using TankWars.Tanks;

namespace TankWars.Items
{
    public interface IPowerUp
    {
        int X { get; }
        int Y { get; }
        
        void Draw();

        void ApplyEffect(Tanks.ITank tank);
    }
}