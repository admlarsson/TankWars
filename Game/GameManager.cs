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
                return (new NormalBullet(new GravityBehavior()), new NormalBullet(new GravityBehavior()));

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
            IMap map = mapFactory.CreateMap(130,20);
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

        protected void PlayTurn(ITank tank, IMap map, string playerName, ref bool gameRunning)
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

        protected void HandleInput(ITank tank, IMap map, ref bool isTurnActive, ref bool gameRunning)
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
            Console.SetCursorPosition(0, map.GetHeight() + 4);
            Console.Write("\nAnge vinkel (0-90): ");
            int.TryParse(Console.ReadLine(), out int angle);
            
            Console.Write("\nAnge kraft (1-100): ");
            int.TryParse(Console.ReadLine(), out int power);

            // Sätter standardvärden om spelaren bara trycker Enter
            tank.Attack(power == 0 ? 50 : power, angle == 0 ? 45 : angle);
            System.Threading.Thread.Sleep(1000);
        }
    }
}



        // FALL #4:
        // Factory Method Pattern.
        //
        // Vi har en hierarki av fabriker (IMapFactory med subtyperna EarthMapFactory, MoonMapFactory etc.) 
        // och en hierarki av produkter (IMap med subtyperna EarthMap, MoonMap etc.). 
        // I GameManager bestäms vilken specifik fabrik som ska skapas via menyn. Denna fabrik injiceras 
        // sedan in i metoden PlayLevel(IMapFactory) som skapar den specifika kartan.
        //
        // Varför?
        // För att frikoppla skapandelogiken från spel-loopen. Spel-loopen (PlayLevel) ska inte 
        // behöva veta exakt vilken underklass av en karta (och dess tillhörande terräng) som byggs. 
        // Den förlitar sig enbart på IMapFactory för att bygga och returnera en färdig IMap.
       /* private void PlayLevel(IMapFactory factory)
        {
            // 1. Skapa Karta
            IMap map = factory.CreateMap(130, 20);

            // --- NYTT: VAPENMENY ---
            Console.Clear();
            Console.WriteLine("--- BYGG DITT VAPEN ---");
            
            // Val 1: Ammunition
            Console.WriteLine("Steg 1: Välj Ammunitionstyp");
            Console.WriteLine("1. Normal (Liten träffyta, 50 Skada)");
            Console.WriteLine("2. Explosiv (Stor träffyta, 25 Skada)");
            Console.Write("Val (1-2): ");
            string bulletChoice = Console.ReadLine();

            // Val 2: Flygstil
            Console.WriteLine("\nSteg 2: Välj Flygstil");
            Console.WriteLine("1. Standard (Vanlig kastbana)");
            Console.WriteLine("2. Guidad (Tryck SPACE i luften för att störtdyka)");
            Console.Write("Val (1-2): ");
            string flightChoice = Console.ReadLine();

            // Låt fabriken bygga exakt den kombination spelaren valde
            BulletFactory bulletFactory = new BulletFactory();
            IWeapon playerWeapon = bulletFactory.CreateWeapon(bulletChoice, flightChoice);

            // Låt boten alltid få en standardkanon (så den inte råkar dyka ner sina egna skott)
            IWeapon botWeapon = new NormalBullet(new GravityBehavior());

            // 2. Skapa tanks och ge dem sina unika vapen
            ITank player1 = new PlayerTank(10, 1, 21, 1, map, playerWeapon);
            ITank bot1 = new BotTank(118, 108, 128, -1, map, botWeapon);

            // 3. Stoppa in dem i kartans lista
            map.GetTanks().Add(player1);
            map.GetTanks().Add(bot1);

            // --- HÄR BÖRJAR SPELLOOPEN ---
            // --- HÄR BÖRJAR SPELLOOPEN ---
            
            // 1. Starta Iteratorn (TurnManager) och lägg till spelarna
            TurnManager turnManager = new TurnManager();
            turnManager.AddTank(player1);
            turnManager.AddTank(bot1);

            bool gameRunning = true;
            
            // Spelet snurrar så länge spelet är igång OCH fler än 1 lever
            while (gameRunning && turnManager.GetAliveCount() > 1)
            {
                // 2. ITERATOR PATTERN: Hämta nästa tank i kön!
                ITank currentTank = turnManager.GetNextTank();
                
                bool isTurnActive = true;

                // 3. Den inre loopen för just DENNA spelares tur
                while (isTurnActive && gameRunning)
                {
                    Console.Clear();
                    map.Draw();

                    Console.SetCursorPosition(0, map.GetHeight() + 2);
                    Console.WriteLine($"[ AKTIV SPELARE: Tank på X:{currentTank.GetX()} | HP: {currentTank.GetHP()} ]");
                    Console.WriteLine($"Pilar = Kör | SPACE = Skjut | ESC = Avsluta");

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.LeftArrow:
                        currentTank.MoveLeft(); // BaseTank stoppar automatiskt vid MinX
                        break;

                        case ConsoleKey.RightArrow:
                        currentTank.MoveRight(); // BaseTank stoppar automatiskt vid MaxX
                        break;

                        case ConsoleKey.Spacebar:
                            // 4. BRIDGE PATTERN: Tanken använder sitt vapen!

                            
                            // 1. Rensa en liten yta under menyn för inmatning
                            Console.SetCursorPosition(0, map.GetHeight() + 4); 
                            Console.Write(new string(' ', 50)); 
                            Console.SetCursorPosition(0, map.GetHeight() + 4);
                            
                            // 2. Låt spelaren skriva in Vinkel
                            Console.Write("Ange vinkel (0-90): ");
                            string angleInput = Console.ReadLine();
                            int angle = 45; // Standardvärde om de bara trycker enter
                            int.TryParse(angleInput, out angle);
                            
                            // 3. Låt spelaren skriva in Kraft
                            Console.Write("Ange kraft (1-100): ");
                            string powerInput = Console.ReadLine();
                            int power = 50; // Standardvärde om de bara trycker enter
                            int.TryParse(powerInput, out power);

                            // 4. Skjut med spelarens egna värden!
                            currentTank.Attack(power, angle); 
                            
                            // Avsluta turen så while-loopen bryts och nästa tank hämtas
                            isTurnActive = false; 
                            
                            // Pausa i en sekund så spelaren ser att skottet gick iväg innan skärmen rensas
                            System.Threading.Thread.Sleep(1000); 
                            break;

                        case ConsoleKey.Escape:
                            gameRunning = false;
                            break;
                    }
                }
            }
        }
    }
}
*/