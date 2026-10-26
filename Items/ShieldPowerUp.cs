using System;
using TankWars.Tanks;

namespace TankWars.Items
{
    public class ShieldPowerUp : PowerUpBase
    {
        public ShieldPowerUp(
            int x, 
            int y, 
            int mapHeight) : base(x, y, mapHeight) { }

        public override void Draw() => DrawAt('S', ConsoleColor.Cyan);
        public override void ApplyEffect(ITank tank) => tank.ActivateShield();
    }
}
