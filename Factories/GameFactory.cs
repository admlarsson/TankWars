using TankWars.Core;
using TankWars.Map;
using TankWars.Game; 
using TankWars.Tanks;

namespace TankWars.Factories
{
    public class GameFactory
    {
        protected readonly IMapFactory _mapFactory;
        protected readonly ITankFactory _leftTankFactory;
        protected readonly ITankFactory _rightTankFactory;

        // FALL #3:
        // VAD: Factory Method Pattern med Beroendeinjektion
        // HUR: Vi har en hierarki av fabriker (IMapFactory med subtyper) och produkter (IMap med subtyper). 
        // Abstraktionerna IMapFactory och ITankFactory injiceras i GameFactorys konstruktor.
        // VARFÖR: GameFactory behöver inte veta *vilken* karta eller tank som skapas, bara *att* den skapas. 
        // Subtyperna (t.ex. EarthMapFactory och MoonMapFactory) skiljer sig i beteende då de genererar helt olika terräng och instansierar olika kart-objekt.

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
            // 1. Skapa kartan via den injicerade fabriken
            IMap map = _mapFactory.CreateMap(180, 40);

            // 2. Skapa vapen
            BulletFactory bulletFactory = new BulletFactory();
            IWeapon w1 = bulletFactory.CreateWeapon(settings.Player1Bullet, settings.Player1Flight);
            IWeapon w2 = bulletFactory.CreateWeapon(settings.Player2Bullet, settings.Player2Flight);

            // Skriver över vapen om det är bot-matcher
            if (settings.GameMode == 3)
            {
                w1 = new NormalBullet(new GravityBehavior());
                w2 = new NormalBullet(new GravityBehavior());
            }
            else if (settings.GameMode == 1)
            {
                w2 = new NormalBullet(new GravityBehavior());
            }

            // 3. Skapa tanks via de injicerade fabrikerna
            ITank tank1 = _leftTankFactory.CreateTank(map, w1);
            ITank tank2 = _rightTankFactory.CreateTank(map, w2);

            map.Tanks.Add(tank1);
            map.Tanks.Add(tank2);

            // 4. Returnera den färdiga spelsessionen
            return new GameSession(map, tank1, tank2, settings.GameMode);
        }
    }
}
