using System;

namespace TankWars.Tanks
{
    // Vanlig gravitation för standardskott
    public class GravityBehavior : IAirBehavior
    {
        private double gravity = 0.2;

        public void UpdateVelocity(
            ref double vx, 
            ref double vy, 
            ConsoleKey? input)
        {
            // Drar bara ner skottet varje frame, precis som er gamla Cannon gjorde
            vy -= gravity; 
        }

        public void Reset()
        {
            
        }
    }
}
