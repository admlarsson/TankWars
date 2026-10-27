namespace TankWars.Tanks
{
    public interface IAirBehavior
    {
        void UpdateVelocity(ref double vx, ref double vy, ConsoleKey? input);

        void Reset(); 
    }
}
