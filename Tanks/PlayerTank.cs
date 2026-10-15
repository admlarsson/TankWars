using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class PlayerTank : BaseTank
    {
        public PlayerTank(int startX, int minX, int maxX, IMap map, IWeapon weapon) 
            : base(startX, minX, maxX, map, weapon) { }

        public override void Draw()
        {
            Console.SetCursorPosition(X + 1, map.Height - Y);
            Console.ForegroundColor = ConsoleColor.Cyan; // Spelaren är Cyan
            Console.Write("[P]");
            Console.ResetColor();
        }

        public override void TakeTurn() { /* Implementeras senare */ }
    }
}