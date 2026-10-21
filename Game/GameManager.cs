using System;
using TankWars.Map;
using TankWars.Factories;
using TankWars.Tanks;
using TankWars.Core;
using System.ComponentModel.Design;
using System.Text;

namespace TankWars.Game
{
    public class GameManager
    {
        protected readonly GameMenu _menu = new GameMenu();
        public void StartGame()
        {
            bool isRunning = true;

            while(isRunning)
            {
                int modeChoice = _menu.GameModeChoice();
                if (modeChoice == 4) break;

                IMapFactory factory = GetMapFactory(_menu.GetMapChoice());
                PlayLevel(factory, modeChoice);
            }

            Console.WriteLine("Tack för du spelade! Stänger spelet!");
        }

        protected IMapFactory GetMapFactory(string choice)
        {
            if(choice == "2") return new EarthMapFactory();
            if(choice == "3") return new MoonMapFactory();
            return new TrainingMapFactory();
        }

        protected (ITankFactory, ITankFactory) CreateFactories(int choice)
        {
            if(choice == 2) return (new PlayerTankFactory(1), new PlayerTankFactory(2));
            if(choice == 2) return (new BotTankFactory(1), new BotTankFactory(2));
            return (new PlayerTankFactory(1), new BotTankFactory(2));
        }

        protected (IWeapon, IWeapon) GetWeapon(int modeChoice)
        {
            BulletFactory factory = new BulletFactory();
            
            if(modeChoice == 3)
                return (new NormalBullet(new GravityBehavior()),
                 new NormalBullet(new GravityBehavior()));

            var (b1, f1) = _menu.GetWeaponChoice("Spelare 1");
            IWeapon w1 = factory.CreateWeapon(b1, f1);

            if(modeChoice == 2)
            {
                var (b2, f2) = _menu.GetWeaponChoice("Spelare 2");
                return (w1, factory.CreateWeapon(b2, f2));
            }
            return (w1, new NormalBullet(new GravityBehavior()));
            
        }

        protected void PlayLevel(IMapFactory mapFactory, int modechoice)
        {
            IMap map = mapFactory.CreateMap(180,40);
            var (w1,w2) = GetWeapon(modechoice);

            var (leftFac, rigthFac) = CreateFactories(modechoice);
            ITank tank1 = leftFac.CreateTank(map, w1);
            ITank tank2 = rigthFac.CreateTank(map, w2);

            map.GetTanks().Add(tank1);
            map.GetTanks().Add(tank2);
            RunGameLoop(map, tank1, tank2, modechoice);
        }

       

        protected void RunGameLoop(IMap map, ITank tank1, ITank tank2, int modeChoice)
        {
            TurnManager turnManager = new TurnManager();
            turnManager.AddTank(tank1);
            turnManager.AddTank(tank2);

            bool gameRunning = true;
            while(gameRunning && turnManager.GetAliveCount() > 1)
            {
                ITank currentTank = turnManager.GetNextTank();
                string playerName = "Spelare 1";
                if(currentTank != tank1)
                    playerName = modeChoice == 2 ? "Spelare 2" : "Datorn";

                PlayTurn(currentTank, map, playerName, ref gameRunning);
            }
        }

        protected void PlayTurn(
            ITank tank,
            IMap map,
            string playerName,
            ref bool gameRunning)
        {
            bool isTurnActive = true;
            while(isTurnActive && gameRunning)
            {
                Console.Clear();
                map.Draw();
                
                Console.SetCursorPosition(0, map.GetHeight() + 2);
                // Skriver ut vems tur det är extra tydligt
                Console.WriteLine($"*** TUREN ÄR DIN, {playerName.ToUpper()}! ***");
                Console.WriteLine($"[ Position X: {tank.GetX()} | HP: {tank.GetHP()} ]");
                Console.WriteLine("Pilar = Kör | SPACE = Skjut | ESC = Avsluta");

                HandleInput(tank, map, ref isTurnActive, ref gameRunning);
            }
        }

        protected void HandleInput(
            ITank tank,
            IMap map, 
            ref bool isTurnActive, 
            ref bool gameRunning)
        {
             switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow: tank.MoveLeft(); break;
                case ConsoleKey.RightArrow: tank.MoveRight(); break;
                case ConsoleKey.Escape: gameRunning = false; break;
                case ConsoleKey.Spacebar:
                    ExecuteShoot(tank, map);
                    isTurnActive = false; // Avslutar turen
                    break;
            }
        }

        protected void ExecuteShoot(ITank tank, IMap map)
        {
            // Sätt markören under spelplanen
            Console.SetCursorPosition(0, map.GetHeight() + 6);
            
            // 1. Rita guiden (kollar om tanken är på vänstra halvan)
            _menu.DrawAngleGuide(tank.GetX() < 90);

            // 2. Hämta godkända värden från menyn!
            var (angle, power) = _menu.GetShootInput();

            // 3. Skjut
            tank.Attack(power, angle);
            System.Threading.Thread.Sleep(1000);
        }
    }
}

