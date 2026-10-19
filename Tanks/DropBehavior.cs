using System;

namespace TankWars.Tanks
{
    // Det guidade skottet som kan droppas med SPACE
    public class DropBehavior : IAirBehavior
    {
        private double gravity = 0.2;
        private bool hasDropped = false;

        public void UpdateVelocity(ref double vx, ref double vy, ConsoleKey? input)
        {
            if (!hasDropped)
            {
                vy -= gravity; // Vanlig gravitation om vi inte har droppat än
            }

            // Lyssnar: Tryckte spelaren precis på SPACE?
            if (input == ConsoleKey.Spacebar && !hasDropped)
            {
                vx = 0;      // Stanna helt i sidled
                vy = -2.0;   // Dyk rakt ner snabbt!
                hasDropped = true; // Förhindra att man trycker igen
            }
        }

        public void Reset()
        {
            hasDropped = false; // Nu kan vi droppa nästa skott
        }
    }
}
