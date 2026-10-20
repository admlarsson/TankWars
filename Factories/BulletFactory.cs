using System;
using TankWars.Tanks;

namespace TankWars.Factories
{
    public class BulletFactory
    {
        // Tar nu emot två val från spelaren
        public IWeapon CreateWeapon(
            string bulletChoice, 
            string flightChoice)
        {
            // 1. Skapa valt flygbeteende (Implementor)
            IAirBehavior behavior;
            if (flightChoice == "2")
            {
                behavior = new DropBehavior();
            }
            else
            {
                behavior = new GravityBehavior();
            }

            // 2. Skapa vald ammunition och stoppa in beteendet (Abstraction + Bridge)
            if (bulletChoice == "2")
            {
                return new ExplosiveBullet(behavior);
            }
            else
            {
                return new NormalBullet(behavior);
            }
        }
    }
}
