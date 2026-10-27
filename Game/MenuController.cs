using TankWars.Factories;
using TankWars.Menu;
using TankWars.Map;
using TankWars.Tanks;

namespace TankWars.Game
{
    public class MenuController
    {
        // This is the single approved exception to the 20-line method limit:
        // keeping the entire procedural menu flow together is intentional.
        public GameFactory? CreateGameFactory()
        {
            IGameModeStrategy? gameMode = null;
            IMapFactory? mapFactory = null;
            IBotStrategy player1Bot = new MediumBotStrategy();
            IBotStrategy player2Bot = new MediumBotStrategy();
            IWeaponFactory player1WeaponFactory = new NormalWeaponFactory();
            IAirBehavior player1AirBehavior = new GravityBehavior();
            IWeaponFactory player2WeaponFactory = new NormalWeaponFactory();
            IAirBehavior player2AirBehavior = new GravityBehavior();
            int step = 1;

            while (step > 0 && step < 7)
            {
                if (step == 1)
                {
                    gameMode = new GameModeMenu().RunMenu();
                    if (gameMode.ShouldExit) return null;
                    step = 2;
                }
                else if (step == 2)
                {
                    mapFactory = new MapMenu().RunMenu();
                    step = mapFactory is null ? 1 : 3;
                }
                else if (step == 3)
                {
                    if (gameMode!.UsesBotPlayer1())
                        player1Bot = new BotDifficultyMenu().RunMenu();
                    step = 4;
                }
                else if (step == 4)
                {
                    if (gameMode!.UsesBotPlayer2())
                        player2Bot = new BotDifficultyMenu().RunMenu();
                    step = 5;
                }
                else if (step == 5)
                {
                    if (!gameMode!.Player1ChoosesWeapon) step = 6;
                    else
                    {
                        var (factory, behavior) = new WeaponMenu("Spelare 1").RunMenu();
                        if (factory is null || behavior is null) step = 4;
                        else
                        {
                            player1WeaponFactory = factory;
                            player1AirBehavior = behavior;
                            step = 6;
                        }
                    }
                }
                else if (step == 6)
                {
                    if (!gameMode!.Player2ChoosesWeapon) step = 7;
                    else
                    {
                        var (factory, behavior) = new WeaponMenu("Spelare 2").RunMenu();
                        if (factory is null || behavior is null) step = 5;
                        else
                        {
                            player2WeaponFactory = factory;
                            player2AirBehavior = behavior;
                            step = 7;
                        }
                    }
                }
            }

            return new GameFactory(
                mapFactory!, gameMode!.CreatePlayer1TankFactory(player1Bot),
                gameMode.CreatePlayer2TankFactory(player2Bot),
                player1WeaponFactory, player1AirBehavior,
                player2WeaponFactory, player2AirBehavior, gameMode);
        }
    }
}
