using System;
using TankWars.Tanks;

namespace TankWars.Items
{
    public class HealPowerUp : IPowerUp
    {
        protected readonly int _mapHeight;

        public int X { get; }
        public int Y { get; }

        public HealPowerUp(int x, int y, int mapHeight)
        {
            X = x;
            Y = y;
            _mapHeight = mapHeight;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(X + 1, _mapHeight - Y);
            Console.Write("+");
            Console.ResetColor();
        }

        public void ApplyEffect(ITank tank)
        {
            tank.Heal(25);
        }
    }
}
