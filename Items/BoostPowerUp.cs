using System;
using TankWars.Tanks;

namespace TankWars.Items
{
    public class BoostPowerUp : PowerUpBase, IPowerUp
    {
        public BoostPowerUp(int x, int y, int mapHeight) : base(x, y, mapHeight) { }

        public override void Draw() => DrawAt('B', ConsoleColor.Red);
        public override void ApplyEffect(ITank tank) => tank.BoostNextShot();
    }
}
