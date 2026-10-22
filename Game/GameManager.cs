using System;
using TankWars.Core;
using TankWars.Factories;

namespace TankWars.Game
{
    public class GameManager
    {
        public void StartGame()
        {
            bool applicationRunning = true;

            while (applicationRunning)
            {
                MenuController menuController = new MenuController();
                GameSettings settings = menuController.CreateSettings();

                if (settings.GameMode == 4) break;

                // SKAPAR FABRIKERNA HÄR INNAN MATCHEN BÖRJAR
                IMapFactory mapFactory = GetMapFactory(settings.MapChoice);
                var (leftTankFactory, rightTankFactory) = GetTankFactories(settings.GameMode);

                bool playRematch = true;

                while (playRematch)
                {
                    // INJICERAR DEM I HUVUDFABRIKEN
                    GameFactory factory = new GameFactory(mapFactory, leftTankFactory, rightTankFactory);
                    GameSession session = factory.CreateGame(settings);

                    session.Start();

                    Console.Clear();
                    Console.WriteLine("--- MATCHEN ÄR ÖVER ---");
                    Console.Write("Vill ni spela en Rematch med samma inställningar? (J/N): ");
                    
                    string input = Console.ReadLine()?.Trim().ToUpper();
                    if (input != "J")
                    {
                        playRematch = false; 
                    }
                }
            }

            Console.WriteLine("Tack för att du spelade! Stänger spelet...");
        }

        // Metoderna sätts till protected för att inte bryta mot blacklisten
        protected IMapFactory GetMapFactory(string choice)
        {
            if (choice == "2") return new EarthMapFactory();
            if (choice == "3") return new MoonMapFactory();
            return new TrainingMapFactory();
        }

        protected (ITankFactory, ITankFactory) GetTankFactories(int modeChoice)
        {
            if (modeChoice == 2) return (new PlayerTankFactory(1), new PlayerTankFactory(2));
            if (modeChoice == 3) return (new BotTankFactory(1), new BotTankFactory(2));
            return (new PlayerTankFactory(1), new BotTankFactory(2));
        }
    }
}
