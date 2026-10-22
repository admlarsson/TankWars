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

        // FALL #1: Factory Method Pattern
        // VAD: Factory Method Pattern (med Beroendeinjektion)
        // HUR: Vi injicerar abstraktionerna IMapFactory och ITankFactory via konstruktorn. 
        // VARFÖR: Genom att injicera fabrikerna slipper GameFactory veta exakt vilka kartor eller stridsvagnar 
        // som ska skapas (t.ex. EarthMapFactory eller MoonMapFactory). Koden blir extremt modulär, och vi uppfyller 
        // kravet på att fabrikerna faktiskt ska injiceras och inte hårdkodas inuti skapar-klassen.
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
