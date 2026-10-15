using System;
using TankWars.Map;
using TankWars.Factories;
using TankWars.Tanks;

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
                    Console.Clear(); // Rensa bort menyn så vi får en ren skärm
                    
                    // Skapa och rita precis som du tänkte!
                    

                    IMap map = factory.CreateMap(130, 40);

                    IWeapon basicCannon = new Cannon();

                    // 3. Skapa Spelare och Bot
                    // Spelaren börjar på X=10. Gränserna är 1 till 128 (innanför väggarna)
                    ITank player1 = new PlayerTank(startX: 10, minX: 1, maxX: 128, map, basicCannon);
                    
                    // Boten börjar på X=115 (på höger sida).
                    ITank bot1 = new BotTank(startX: 115, minX: 1, maxX: 128, map, basicCannon);

                    // 4. Lägg in dem i kartans Generic EntityManager
                    map.Tanks.Add(player1);
                    map.Tanks.Add(bot1);

                    map.Draw();

                    Console.SetCursorPosition(0, map.Height + 2);

                    // PAUSA! Annars loopar programmet direkt och ritar menyn igen
                    Console.WriteLine("\n[Tryck på Enter för att gå tillbaka till menyn]");
                    Console.ReadLine(); 
                }
            }
        }
    }
}