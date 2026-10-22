using System;
using TankWars.Map;
using TankWars.Tanks;
using TankWars.Core;
using TankWars.Menu;

namespace TankWars.Game
{
    public class GameSession
    {
        private readonly IMap _map;
        private readonly ITank _tank1;
        private readonly ITank _tank2;
        private readonly int _modeChoice;

        public GameSession(IMap map, ITank tank1, ITank tank2, int modeChoice)
        {
            _map = map;
            _tank1 = tank1;
            _tank2 = tank2;
            _modeChoice = modeChoice;
        }

        public void Start()
        {
            TurnManager turnManager = new TurnManager();
            turnManager.AddTank(_tank1);
            turnManager.AddTank(_tank2);

            bool gameRunning = true;
            
            while (gameRunning && turnManager.AliveCount > 1)
            {
                ITank currentTank = turnManager.GetNextTank();
                string playerName = "Spelare 1";
                if (currentTank != _tank1)
                    playerName = _modeChoice == 2 ? "Spelare 2" : "Datorn";

                PlayTurn(currentTank, playerName, ref gameRunning);
            }
        }

        public void PlayTurn(ITank tank, string playerName, ref bool gameRunning)
        {
            bool isTurnActive = true;
            ActionController actionController = new ActionController();

            while (isTurnActive && gameRunning)
            {
                Console.Clear();
                _map.Draw();
                
                // Använder properties (Height, X, Hp) istället för getters
                Console.SetCursorPosition(0, _map.Height + 2);
                Console.WriteLine($"*** TUREN ÄR DIN, {playerName.ToUpper()}! ***");
                Console.WriteLine($"[ Position X: {tank.X} | HP: {tank.HP} ]");
                Console.WriteLine("Pilar = Kör | SPACE = Skjut | ESC = Avsluta");

                actionController.HandleInput(tank, _map, ref isTurnActive, ref gameRunning);
            }
        }

        
    }
}
