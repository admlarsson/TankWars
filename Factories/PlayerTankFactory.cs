using TankWars.Tanks;
using TankWars.Map;

namespace TankWars.Factories
{
    public class PlayerTankFactory : BaseTankFactory
    {
        public PlayerTankFactory(int playerNumber)
            : base(playerNumber){ }

        public override ITank CreateTank(IMap map, IWeapon weapon)
        {
            return new PlayerTank(
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