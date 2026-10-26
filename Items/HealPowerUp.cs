using System;
using TankWars.Tanks;

namespace TankWars.Items
{
    public class HealPowerUp : PowerUpBase
    {
        public HealPowerUp(
            int x, 
            int y, 
            int mapHeight) : base(x, y, mapHeight) { }

        public override void Draw() => DrawAt('+', ConsoleColor.Green);
        public override void ApplyEffect(ITank tank) => tank.Heal(25);
    }
}
