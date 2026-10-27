namespace TankWars.Tanks
{
    public class DropBehavior : IAirBehavior
    {
        private double gravity = 0.2;
        private bool hasDropped = false;

        public void UpdateVelocity(
            ref double vx, 
            ref double vy, 
            ConsoleKey? input)
        {
            if (!hasDropped)
            {
                vy -= gravity; 
            }

            if (input == ConsoleKey.Spacebar && !hasDropped)
            {
                vx = 0;      
                vy = -2.0;   
                hasDropped = true; 
            }
        }

        public void Reset()
        {
            hasDropped = false; 
        }
    }
}
