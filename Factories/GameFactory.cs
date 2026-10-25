using TankWars.Core;
using TankWars.Map;
using TankWars.Game; 
using TankWars.Items;
using TankWars.Tanks;

namespace TankWars.Factories
{
    // FALL #4:
    // VAD: Factory Method Pattern
    // HUR: Map- och tankfabriker med olika subtyper injiceras i konstruktorn.
    // De skapar produkter via IMap och ITank, som också har konkreta subtyper.
    // VARFÖR: GameFactory kan bygga en match utan att själv välja konkreta
    // kartor eller tanks; fabrikernas subtyper skapar respektive produktfamilj.
    public class GameFactory
    {
        protected readonly IMapFactory _mapFactory;
        protected readonly ITankFactory _leftTankFactory;
        protected readonly ITankFactory _rightTankFactory;
        private readonly Random _random = new Random();
        private readonly IPowerUpFactory _powerUpFactory;


        public GameFactory(
            IMapFactory mapFactory, 
            ITankFactory leftTankFactory, 
            ITankFactory rightTankFactory,
            IPowerUpFactory powerUpFactory)
        {
            _mapFactory = mapFactory;
            _leftTankFactory = leftTankFactory;
            _rightTankFactory = rightTankFactory;
            _powerUpFactory = powerUpFactory;
        }

        public GameSession CreateGame(GameSettings settings)
        {
            IMap map = _mapFactory.CreateMap(180, 40);
            IWeapon w1 = settings.GameMode.CreatePlayer1Weapon(settings);
            IWeapon w2 = settings.GameMode.CreatePlayer2Weapon(settings);
            ITank tank1 = _leftTankFactory.CreateTank(map, w1);
            ITank tank2 = _rightTankFactory.CreateTank(map, w2);
            map.Tanks.Add(tank1);
            map.Tanks.Add(tank2);

            return new GameSession(map, tank1, tank2, settings.GameMode, _powerUpFactory);
        }
    }
}
