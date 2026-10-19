using System;
using TankWars.Map;
using TankWars.Factories;
using TankWars.Tanks;
using TankWars.Core;

namespace TankWars.Game
{
    public class GameManager
    {
        public void StartGame()
        {
            bool isRunning = true;

            // Hela menyn OCH utritningen måste ligga INUTI while-loopen
            while (isRunning)
            {
                Console.Clear(); // Glöm inte semikolon här!

                Console.WriteLine("1. Spela på Träningsbana");
                Console.WriteLine("2. Spela på Jorden");
                Console.WriteLine("3. Spela på Månen");
                Console.WriteLine("4. Avsluta spelet");
                Console.Write("\nVälj ett alternativ (1-4): ");

                string choice = Console.ReadLine();

                // SKAPA EN TOM FABRIK HÄR. 
                // Eftersom vi skapar den utanför switch-satsen, lever den vidare till slutet!
                IMapFactory factory = null;

                switch (choice)
                {
                    case "1":
                        // Fyll den tomma fabriken
                        factory = new TrainingMapFactory();
                        break;

                    case "2":
                        factory = new EarthMapFactory();
                        break;

                    case "3":
                        factory = new MoonMapFactory();
                        break;

                    case "4":
                        isRunning = false; // Bryter while-loopen
                        Console.WriteLine("Tack för att du spelade. Stänger spelet...");
                        continue; // Går tillbaka till toppen av loopen, som nu stängs av
                        
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        System.Threading.Thread.Sleep(1500); // Vänta lite så spelaren hinner läsa
                        continue; // Börja om loopen
                }

                // Om spelaren valde 1, 2 eller 3 så är factory inte null längre
                if (factory != null)
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
                    map.Tanks.Add(player1);
                    map.Tanks.Add(bot1);

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

                            Console.SetCursorPosition(0, map.Height + 2);
                            Console.WriteLine($"[ AKTIV SPELARE: Tank på X:{currentTank.X} | HP: {currentTank.HP} ]");
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
                                    // (Vi hårdkodar kraft 50 och vinkel 45 för tillfället)
                                    currentTank.Attack(45, 30); 
                                    
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
    }
}