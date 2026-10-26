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

        public GameFactory(
            IMapFactory mapFactory, 
            ITankFactory leftTankFactory, 
            ITankFactory rightTankFactory)
        {
            _mapFactory = mapFactory;
            _leftTankFactory = leftTankFactory;
            _rightTankFactory = rightTankFactory;
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

            return new GameSession(
                map, tank1, tank2, settings.GameMode,
                settings.GameMode.CreatePowerUpFactory());
        }
    }
}
