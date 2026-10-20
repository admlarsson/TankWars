using System;
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
            IWeapon weapon) 
            : base(startX, minX, maxX, direction, map, weapon) { }

        public override void Draw()
        {
            Console.SetCursorPosition(GetX() + 1, 
            GetMap().GetHeight() - GetY());
            Console.ForegroundColor = ConsoleColor.Cyan; // Spelaren är Cyan
            Console.Write("[P]");
            Console.ResetColor();
        }

    }
}