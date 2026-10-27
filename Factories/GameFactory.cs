using TankWars.Core;
using TankWars.Map;
using TankWars.Game; 
using TankWars.Tanks;

namespace TankWars.Factories
{

    public class GameFactory
    {

        // FALL #7:
        // VAD: Factory Method Pattern (Kartor)
        // HUR: En instans av IMapFactory (t.ex. EarthMapFactory) injiceras
        // för att skapa en specifik kartprodukt.
        // VARFÖR: GameFactory bygger upp spelvärlden utan att veta vilken
        // specifik karta som används, skapandet delegeras helt till subtypen.
        protected readonly IMapFactory _mapFactory;

        // FALL #8:
        // VAD: Factory Method Pattern (Tanks)
        // HUR: Två ITankFactory-instanser injiceras för att bygga PlayerTank
        // eller BotTank.
        // VARFÖR: Spelet kan dynamiskt montera ihop rätt stridsvagnstyper för
        // respektive spelare beroende på om det är PvP, PvE eller EvE.
        protected readonly ITankFactory _leftTankFactory;
        protected readonly ITankFactory _rightTankFactory;
        protected readonly IWeaponFactory _player1WeaponFactory;
        protected readonly IAirBehavior _player1AirBehavior;
        protected readonly IWeaponFactory _player2WeaponFactory;
        protected readonly IAirBehavior _player2AirBehavior;
        protected readonly IGameModeStrategy _gameMode;

        public GameFactory(
            IMapFactory mapFactory, 
            ITankFactory leftTankFactory, 
            ITankFactory rightTankFactory,
            IWeaponFactory player1WeaponFactory,
            IAirBehavior player1AirBehavior,
            IWeaponFactory player2WeaponFactory,
            IAirBehavior player2AirBehavior,
            IGameModeStrategy gameMode)
        {
            _mapFactory = mapFactory;
            _leftTankFactory = leftTankFactory;
            _rightTankFactory = rightTankFactory;
            _player1WeaponFactory = player1WeaponFactory;
            _player1AirBehavior = player1AirBehavior;
            _player2WeaponFactory = player2WeaponFactory;
            _player2AirBehavior = player2AirBehavior;
            _gameMode = gameMode;
        }

        public GameSession CreateGame()
        {
            IMap map = _mapFactory.CreateMap(180, 40);
            IWeapon w1 = _gameMode.CreatePlayer1Weapon(_player1WeaponFactory, _player1AirBehavior);
            IWeapon w2 = _gameMode.CreatePlayer2Weapon(_player2WeaponFactory, _player2AirBehavior);
            ITank tank1 = _leftTankFactory.CreateTank(map, w1);
            ITank tank2 = _rightTankFactory.CreateTank(map, w2);
            map.Tanks.Add(tank1);
            map.Tanks.Add(tank2);
            return new GameSession(map, tank1, tank2, _gameMode, _gameMode.CreatePowerUpFactory());
        }
    }
}
