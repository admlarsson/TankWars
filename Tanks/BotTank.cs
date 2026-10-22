using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class BotTank : BaseTank
    {
        protected readonly ConsoleColor _color;
        public BotTank(
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