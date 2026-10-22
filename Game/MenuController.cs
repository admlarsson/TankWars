using TankWars.Core;
using TankWars.Menu;

namespace TankWars.Game
{
    public class MenuController
    {
        public GameSettings CreateSettings()
        {
            var settings = new GameSettings();

            settings.GameMode = new GameModeMenu().RunMenu();

            if(settings.GameMode == 4) return settings;

            settings.MapChoice = new MapMenu().RunMenu();

            if(settings.GameMode == 1 || settings.GameMode == 2)
            {
                var (b1, f1) = new WeaponMenu("Spelare 1").RunMenu();
                settings.Player1Bullet = b1;
                settings.Player1Flight = f1;
            }

            if(settings.GameMode == 2)
            {
                var (b2, f2) = new WeaponMenu("Spelare 2").RunMenu();
                settings.Player2Bullet = b2;
                settings.Player2Flight = f2;
            }

            return settings;
        }
    }
}