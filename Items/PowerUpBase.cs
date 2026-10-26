using System;
using TankWars.Tanks;

namespace TankWars.Items
{
    public abstract class PowerUpBase : IPowerUp
    {
        protected readonly int _x;
        protected readonly int _y;
        protected readonly int _mapHeight;

        protected PowerUpBase(int x, int y, int mapHeight)
        {
            _x = x;
            _y = y;
            _mapHeight = mapHeight;
        }

        public int GetX() => _x;
        public int GetY() => _y;
        public abstract void Draw();
        public abstract void ApplyEffect(ITank tank);

        protected void DrawAt(char symbol, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(_x + 1, _mapHeight - _y);
            Console.Write(symbol);
            Console.ResetColor();
        }
    }
}
