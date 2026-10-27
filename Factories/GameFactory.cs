using TankWars.Core;
using TankWars.Map;
using TankWars.Game; 
using TankWars.Tanks;

namespace TankWars.Factories
{

    public class GameFactory
    {

        // FALL #7:
        // Vad: Factory Method Pattern (Kartor)
        //
        // HUR: I MapMenu väljer spelaren vilken karta som ska användas.
        // Den valda kartfabriken, exempelvis EarthMapFactory eller MoonMapFactory,
        // skickas till GameFactory. Där anropas CreateMap() för att skapa
        // kartan. Varje fabrik ansvarar för att skapa sin egen karttyp.
        //
        // VARFÖR: GameFactory behöver inte veta vilken konkret karta som skapas.
        // Vi kan använda samma metod för olika karttyper och enkelt
        // lägga till nya kartor utan att ändra GameFactory.
        protected readonly IMapFactory _mapFactory;

        // FALL #8:
        // Vad: Factory Method Pattern (Tankar)
        //
        // HUR: Det valda spelläget bestämmer vilka tankfabriker som ska
        // användas, exempelvis PlayerTankFactory eller BotTankFactory.
        // Dessa skickas till GameFactory, som anropar CreateTank()
        // för att skapa tankarna med den valda kartan och vapnen.
        //
        // VARFÖR: Vi kan skapa både spelarstyrda och datorstyrda tankar
        // genom samma metod. GameFactory behöver inte veta vilken
        // konkret tanktyp som skapas, vilket gör det enklare att
        // hantera olika spellägen och lägga till nya tanktyper.
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
            IWeapon w1 = _gameMode.CreatePlayer1Weapon(
                    _player1WeaponFactory, _player1AirBehavior);
            IWeapon w2 = _gameMode.CreatePlayer2Weapon(
                    _player2WeaponFactory, _player2AirBehavior);
            ITank tank1 = _leftTankFactory.CreateTank(map, w1);
            ITank tank2 = _rightTankFactory.CreateTank(map, w2);
            map.Tanks.Add(tank1);
            map.Tanks.Add(tank2);
            return new GameSession(map, tank1, tank2, _gameMode, 
                _gameMode.CreatePowerUpFactory());
        }
    }
}
