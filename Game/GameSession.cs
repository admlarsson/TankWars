using System;
using TankWars.Map;
using TankWars.Tanks;
using TankWars.Core;
using TankWars.Factories;

namespace TankWars.Game
{
    public class GameSession
    {
        private readonly IMap _map;
        private readonly ITank _tank1;
        private readonly ITank _tank2;
        private readonly IGameModeStrategy _gameMode;
        private readonly IPowerUpFactory _powerUpFactory;
        private readonly Random _random = new Random();

        public GameSession(
            IMap map, 
            ITank tank1, 
            ITank tank2, 
            IGameModeStrategy gameMode, 
            IPowerUpFactory powerUpFactory)
        {
            _map = map;
            _tank1 = tank1;
            _tank2 = tank2;
            _gameMode = gameMode;
            _powerUpFactory = powerUpFactory;
        }

        public void Start()
        {
            RunTurns(CreateTurnManager());
        }

        protected TurnManager CreateTurnManager()
        {
            TurnManager turnManager = new TurnManager();
            turnManager.AddTank(_tank1);
            turnManager.AddTank(_tank2);
            return turnManager;
        }

        protected void RunTurns(TurnManager turnManager)
        {
            bool gameRunning = true;
            int turnsThisRound = 0;
            while (gameRunning && turnManager.AliveCount > 1)
            {
                PlayNextTurn(turnManager, ref gameRunning);

                turnsThisRound ++;

                if(turnsThisRound % 2 == 0)
                {
                    bool powerUpsAreOnMap = _map.PowerUps.All.Any();

                    if(!powerUpsAreOnMap && _random.Next(100) < 70)
                    SpawnPowerUpPair();
                }
            }
        }

        protected void SpawnPowerUpPair()
        {
            int leftX = _random.Next(2, 21);
            int rightX = _random.Next(159, 178);

            _map.PowerUps.Add(
                _powerUpFactory.CreatePowerUp(
                    leftX,
                    _map.TerrainHeights[leftX] + 1,
                    _map.Height));

            _map.PowerUps.Add(
                _powerUpFactory.CreatePowerUp(
                    rightX,
                    _map.TerrainHeights[rightX] + 1,
                    _map.Height));
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

        protected void PlayTurnFrame(
            ITank tank, 
            string playerName, 
            ref bool isTurnActive, 
            ref bool gameRunning)
        {
            Console.Clear();
            _map.Draw();

            ITank opponent = tank == _tank1 ? _tank2 : _tank1;
            if (tank.ExecuteAutomatedTurn(opponent))
            {
                isTurnActive = false;
                return;
            }


            DrawTurnStatus(tank, playerName);
            new ActionController().HandleInput(
                tank, 
                _map, 
                ref isTurnActive, 
                ref gameRunning);
        }

        protected void DrawTurnStatus(ITank tank, string playerName)
        {
            // Använder properties (Height, X, Hp) istället för getters.
            Console.SetCursorPosition(0, _map.Height + 2);
            Console.WriteLine($"*** TUREN ÄR DIN, {playerName.ToUpper()}! ***");
            Console.WriteLine($"[ Position X: {tank.X} ]");
            Console.WriteLine($"Spelare 1 HP: {_tank1.HP} | Spelare 2 HP: {_tank2.HP}");
            Console.WriteLine("Pilar = Kör | SPACE = Skjut | ESC = Avsluta");
        }

    }
}
