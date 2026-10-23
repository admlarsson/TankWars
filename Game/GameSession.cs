using System;
using TankWars.Map;
using TankWars.Tanks;
using TankWars.Core;

namespace TankWars.Game
{
    public class GameSession
    {
        private readonly IMap _map;
        private readonly ITank _tank1;
        private readonly ITank _tank2;
        private readonly IGameModeStrategy _gameMode;

        public GameSession(IMap map, ITank tank1, ITank tank2, IGameModeStrategy gameMode)
        {
            _map = map;
            _tank1 = tank1;
            _tank2 = tank2;
            _gameMode = gameMode;
        }

        public void Start()
        {
            RunTurns(CreateTurnManager());
        }

        protected TurnManager CreateTurnManager()
        {
            TurnManager manager = new TurnManager();
            manager.AddTank(_tank1);
            manager.AddTank(_tank2);
            return manager;
        }

        protected void RunTurns(TurnManager turnManager)
        {
            bool gameRunning = true;
            while (gameRunning && turnManager.AliveCount > 1)
                PlayNextTurn(turnManager, ref gameRunning);
        }

        protected void PlayNextTurn(TurnManager turnManager, ref bool gameRunning)
        {
            ITank currentTank = turnManager.GetNextTank();
            string playerName = _gameMode.GetPlayerName(currentTank == _tank1);
            PlayTurn(currentTank, playerName, ref gameRunning);
        }

        public void PlayTurn(ITank tank, string playerName, ref bool gameRunning)
        {
            bool isTurnActive = true;
            while (isTurnActive && gameRunning)
                PlayTurnFrame(tank, playerName, ref isTurnActive, ref gameRunning);
        }

        protected void PlayTurnFrame(ITank tank, string playerName, ref bool isTurnActive, ref bool gameRunning)
        {
            Console.Clear();
            _map.Draw();
            DrawTurnStatus(tank, playerName);
            new ActionController().HandleInput(tank, _map, ref isTurnActive, ref gameRunning);
        }

        protected void DrawTurnStatus(ITank tank, string playerName)
        {
            // Använder properties (Height, X, Hp) istället för getters.
            Console.SetCursorPosition(0, _map.Height + 2);
            Console.WriteLine($"*** TUREN ÄR DIN, {playerName.ToUpper()}! ***");
            Console.WriteLine($"[ Position X: {tank.X} | HP: {tank.HP} ]");
            Console.WriteLine("Pilar = Kör | SPACE = Skjut | ESC = Avsluta");
        }

    }
}
