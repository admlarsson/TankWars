using TankWars.Factories;
using TankWars.Tanks;
using TankWars.Map;

public class BotTankFactory : ITankFactory
{
    private readonly int _startX;
    private readonly int _minX;
    private readonly int _maxX;
    private readonly int _direction;
    protected readonly ConsoleColor _color;

    public BotTankFactory(int playerNumber)
    {
        if(playerNumber == 1)
        {
            _startX = 10;
            _minX = 1;
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

    public ITank CreateTank(IMap map, IWeapon weapon)
    {
        return new BotTank(_startX, _minX, _maxX, _direction, map, weapon, _color);
    }
            
}