using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class BotTank : BaseTank
    {
        public BotTank(
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
            Console.ForegroundColor = ConsoleColor.Red; // Boten är Röd
            Console.Write("[B]");
            Console.ResetColor();
        }

        
    }
}