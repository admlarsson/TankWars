using System;
using System.Drawing;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class PlayerTank : BaseTank
    {
        protected readonly ConsoleColor _color;
        public PlayerTank(
            int startX, 
            int minX, 
            int maxX, 
            int direction, 
            IMap map, 
            IWeapon weapon,
            ConsoleColor color) 
            : base(startX, minX, maxX, direction, map, weapon)
        {
            _color = color;
        }

        public override void Draw()
        {
           TankRenderer renderer = new TankRenderer();
           renderer.Draw(X, Y, Map.Height, _direction, _color);
        }

    }
}