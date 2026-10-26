using TankWars.Map;
using TankWars.Tanks;

namespace TankWars.Factories
{
    public class BotTankFactory : BaseTankFactory
    {
        protected readonly IBotStrategy _strategy;

        public BotTankFactory(int playerNumber, IBotStrategy strategy)
            : base(playerNumber)
        {
            _strategy = strategy;
        }

        public override ITank CreateTank(IMap map, IWeapon weapon)
        {
            return new BotTank(
                _startX,
                _minX,
                _maxX,
                _direction,
                map,
                weapon,
                _color,
                _strategy);
        }
    }
}