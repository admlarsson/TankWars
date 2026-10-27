using TankWars.Factories;

namespace TankWars.Game
{
    public class GameManager
    {
        public void StartGame()
        {
            while (RunGameCycle()) { }
            Console.WriteLine("Tack för att du spelade! Stänger spelet...");
        }

        protected bool RunGameCycle()
        {
            GameFactory? factory = new MenuController().CreateGameFactory();
            if (factory is null) return false;
            PlayRematches(factory);
            return true;
        }

        protected void PlayRematches(GameFactory factory)
        {
            bool playRematch = true;
            while (playRematch)
            {
                factory.CreateGame().Start();
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
