using TankWars.Tanks;

namespace TankWars.Items
{
    public class BoostPowerUp : PowerUpBase
    {
        public BoostPowerUp(
            int x, 
            int y, 
            int mapHeight) : base(x, y, mapHeight) { }

        public override void Draw() => DrawAt('⚡', ConsoleColor.Red);
        public override void ApplyEffect(ITank tank) => tank.BoostNextShot();
    }
}
