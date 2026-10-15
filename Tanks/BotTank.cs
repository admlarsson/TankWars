using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class BotTank : BaseTank
    {
        public BotTank(int startX, int minX, int maxX, IMap map, IWeapon weapon) 
            : base(startX, minX, maxX, map, weapon) { }

        public override void Draw()
        {
            Console.SetCursorPosition(X + 1, map.Height - Y);
            Console.ForegroundColor = ConsoleColor.Red; // Boten är Röd
            Console.Write("[B]");
            Console.ResetColor();
        }

        public override void TakeTurn() { /* Implementeras senare */ }
    }
}