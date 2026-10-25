using System;
using TankWars.Tanks;

namespace TankWars.Items
{
    public class BoostPowerUp : IPowerUp
    {
        protected readonly int _mapHeight;

        public int X { get; }
        public int Y { get; }

        public BoostPowerUp(int x, int y, int mapHeight)
        {
            X = x;
            Y = y;
            _mapHeight = mapHeight;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(X + 1, _mapHeight - Y);
            Console.Write("B");
            Console.ResetColor();
        }

        public void ApplyEffect(ITank tank)
        {
            tank.BoostNextShot();
        }
    }
}