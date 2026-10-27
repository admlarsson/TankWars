namespace TankWars.Tanks
{
    public class GravityBehavior : IAirBehavior
    {
        private double gravity = 0.2;

        public void UpdateVelocity(
            ref double vx, 
            ref double vy, 
            ConsoleKey? input)
        {
            vy -= gravity; 
        }

        public void Reset() { }
    }
}
