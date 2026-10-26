using System;
using System.Drawing;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class PlayerTank : BaseTank
    {
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

        public override bool ExecuteAutomatedTurn(ITank opponent)
        {
            return false;
        }

    }
}