using TankWars.Core;
using TankWars.Map;
using TankWars.Game; // För att kunna returnera en GameSession
using TankWars.Tanks;

namespace TankWars.Factories
{
    public class GameFactory
    {
        public GameSession CreateGame(GameSettings settings)
        {
            // 1. Skapa kartan
            IMapFactory mapFactory = GetMapFactory(settings.MapChoice);
            IMap map = mapFactory.CreateMap(180, 40);

            // 2. Skapa vapen
            var (w1, w2) = GetWeapons(settings);

            // 3. Skapa tanks
            var (leftFac, rightFac) = GetTankFactories(settings.GameMode);
            ITank tank1 = leftFac.CreateTank(map, w1);
            ITank tank2 = rightFac.CreateTank(map, w2);

            // Om GetTanks() nu är en egenskap efter er refaktorering, använd map.Tanks.Add()
            map.Tanks.Add(tank1);
            map.Tanks.Add(tank2);

            // 4. Returnera den färdiga spelsessionen
            return new GameSession(map, tank1, tank2, settings.GameMode);
        }

        private IMapFactory GetMapFactory(string choice)
        {
            if (choice == "2") return new EarthMapFactory();
            if (choice == "3") return new MoonMapFactory();
            return new TrainingMapFactory();
        }

        private (ITankFactory, ITankFactory) GetTankFactories(int modeChoice)
        {
            if (modeChoice == 2) return (new PlayerTankFactory(1), new PlayerTankFactory(2));
            if (modeChoice == 3) return (new BotTankFactory(1), new BotTankFactory(2));
            return (new PlayerTankFactory(1), new BotTankFactory(2));
        }

        private (IWeapon, IWeapon) GetWeapons(GameSettings settings)
        {
            BulletFactory factory = new BulletFactory();
            
            if (settings.GameMode == 3)
                return (new NormalBullet(new GravityBehavior()), new NormalBullet(new GravityBehavior()));

            IWeapon w1 = factory.CreateWeapon(settings.Player1Bullet, settings.Player1Flight);

            if (settings.GameMode == 2)
            {
                IWeapon w2 = factory.CreateWeapon(settings.Player2Bullet, settings.Player2Flight);
                return (w1, w2);
            }
            
            return (w1, new NormalBullet(new GravityBehavior()));
        }
    }
}
