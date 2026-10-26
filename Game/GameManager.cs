using System;
using TankWars.Core;
using TankWars.Factories;

namespace TankWars.Game
{
    // Samordnar menyflöde och rematcher. Kartfabriken väljs i MapMenu och
    // spellägesstrategin skapar rätt tankfabriker innan de injiceras i GameFactory.
    public class GameManager
    {
        public void StartGame()
        {
            while (RunGameCycle()) { }
            Console.WriteLine("Tack för att du spelade! Stänger spelet...");
        }

        protected bool RunGameCycle()
        {
            GameSettings settings = new MenuController().CreateSettings();
            if (settings.GameMode.ShouldExit) return false;
            PlayRematches(settings);
            return true;
        }

        protected void PlayRematches(GameSettings settings)
        {
            bool playRematch = true;
            while (playRematch)
            {
                GameFactory factory = new GameFactory(
                    settings.MapFactory,
                    settings.GameMode.CreatePlayer1TankFactory(settings),
                    settings.GameMode.CreatePlayer2TankFactory(settings));
                    
                factory.CreateGame(settings).Start();
                playRematch = AskForRematch();
            }
        }

        protected bool AskForRematch()
        {
            Console.Clear();
            Console.WriteLine("--- MATCHEN ÄR ÖVER ---");
            Console.Write("Vill ni spela en Rematch med samma inställningar? (J/N): ");
            return Console.ReadLine()?.Trim().ToUpper() == "J";
        }
    }
}
