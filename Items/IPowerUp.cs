using TankWars.Tanks;

namespace TankWars.Items
{
    public interface IPowerUp
    {
        int GetX();
        int GetY();
        
        void Draw();

        void ApplyEffect(ITank tank);
    }
}