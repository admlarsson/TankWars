using TankWars.Map;
using TankWars.Tanks;

namespace TankWars.Factories
{
    public abstract class BaseTankFactory : ITankFactory
    {
        protected readonly int _startX;
        protected readonly int _minX;
        protected readonly int _maxX;
        protected readonly int _direction;
        protected readonly ConsoleColor _color;

        protected BaseTankFactory(int playerNumber)
        {
            if (playerNumber == 1)
            {
                _startX = 10;
                _minX = 2;
                _maxX = 21;
                _direction = 1;
                _color = ConsoleColor.Cyan;
            }
            else
            {
                _startX = 168;
                _minX = 159;
                _maxX = 178;
                _direction = -1;
                _color = ConsoleColor.Red;
            }
        }
        public abstract ITank CreateTank(IMap map, IWeapon weapon);
    }

    
}