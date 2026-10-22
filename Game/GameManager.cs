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
                // 1. Datainsamling: Kör menyerna och få en färdig beställningssedel
                MenuController menuController = new MenuController();
                GameSettings settings = menuController.CreateSettings();

                // Avbryt om spelaren valde Avsluta (alternativ 4) i huvudmenyn
                if (settings.GameMode == 4) 
                {
                    break;
                }

                bool playRematch = true;

                // REMATCH-LOOP: Körs så länge spelarna vill spela om med samma inställningar
                while (playRematch)
                {
                    // 2. Produktion: Fabriken bygger en helt ny spelsession utifrån inställningarna
                    GameFactory factory = new GameFactory();
                    GameSession session = factory.CreateGame(settings);

                    // 3. Körning: Startar själva matchen
                    session.Start();

                    // 4. Utvärdering: Matchen är över, fråga om rematch
                    Console.Clear();
                    Console.WriteLine("--- MATCHEN ÄR ÖVER ---");
                    Console.Write("Vill ni spela en Rematch med samma inställningar? (J/N): ");
                    
                    string input = Console.ReadLine()?.Trim().ToUpper();
                    if (input != "J")
                    {
                        // Bryter den inre loopen och går tillbaka till huvudmenyn
                        playRematch = false; 
                    }
                }
            }

            Console.WriteLine("Tack för att du spelade! Stänger spelet...");
        }
    }
}
