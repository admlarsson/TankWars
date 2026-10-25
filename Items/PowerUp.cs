using System;

namespace TankWars.Items
{
    public class PowerUp : IPowerUp
    {
        private readonly int _mapHeight;
        private readonly IPowerUpEffect _effect;
        private readonly char _symbol;
        private readonly ConsoleColor _color;

        public int X { get; }
        public int Y { get; }

        public PowerUp(
            int x,
            int y,
            int mapHeight,
            IPowerUpEffect effect,
            char symbol,
            ConsoleColor color)
        {
            X = x;
            Y = y;
            _mapHeight = mapHeight;
            _effect = effect;
            _symbol = symbol;
            _color = color;
        }

        public void Draw()
        {
            Console.ForegroundColor = _color;
            Console.SetCursorPosition(X + 1, _mapHeight - Y);
            Console.Write(_symbol);
            Console.ResetColor();
        }

        public void ApplyEffect(Tanks.ITank tank)
        {
            _effect.Apply(tank);
        }
    }
}