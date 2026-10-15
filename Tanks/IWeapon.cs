namespace TankWars.Tanks
{
    public interface IWeapon
    {
        void Fire(int startX, int startY, double power, int angle); 
    }
}