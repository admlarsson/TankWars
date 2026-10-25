using TankWars.Map;
using TankWars.Tanks;

namespace TankWars.Factories
{
    public class BotTankFactory : BaseTankFactory
    {
        public BotTankFactory(int playerNumber)
            : base(playerNumber){ }

        public override ITank CreateTank(IMap map, IWeapon weapon)
        {
            return new BotTank(
                _startX,
                _minX,
                _maxX,
                _direction,
                map,
                weapon,
                _color);
        }
    }
}