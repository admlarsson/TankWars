using TankWars.Core;
using TankWars.Factories;
using TankWars.Menu;

namespace TankWars.Game
{
    public class MenuController
    {
        public GameSettings CreateSettings()
        {
            var settings = new GameSettings();
            int step = 1;

            // Menyernas objekt sparas i settings; stegen styr bara framåt- och bakåtnavigering.
            while (step > 0 && step < 5)
            {
                if (step == 1) step = HandleGameMode(settings);
                else if (step == 2) step = HandleMapChoice(settings);
                else if (step == 3) step = HandlePlayer1Weapon(settings);
                else if (step == 4) step = HandlePlayer2Weapon(settings);
            }

            return settings;
        }

        protected int HandleGameMode(GameSettings settings)
        {
            settings.GameMode = new GameModeMenu().RunMenu();
            if (settings.GameMode.ShouldExit) return 5;
            return 2; // Gå framåt till steg 2
        }

        protected int HandleMapChoice(GameSettings settings)
        {
            IMapFactory? mapFactory = new MapMenu().RunMenu();
            if (mapFactory is null) return 1;
            settings.MapFactory = mapFactory;
            return 3; // Gå framåt till steg 3
        }

        protected int HandlePlayer1Weapon(GameSettings settings)
        {
            if (!settings.GameMode.Player1ChoosesWeapon) return 4;

            var (weaponFactory, airBehavior) = new WeaponMenu("Spelare 1").RunMenu();
            if (weaponFactory is null || airBehavior is null) return 2;
            settings.Player1WeaponFactory = weaponFactory;
            settings.Player1AirBehavior = airBehavior;
            return 4; // Gå framåt
        }

        protected int HandlePlayer2Weapon(GameSettings settings)
        {
            if (!settings.GameMode.Player2ChoosesWeapon) return 5;

            var (weaponFactory, airBehavior) = new WeaponMenu("Spelare 2").RunMenu();
            if (weaponFactory is null || airBehavior is null) return 3;
            settings.Player2WeaponFactory = weaponFactory;
            settings.Player2AirBehavior = airBehavior;
            return 5; // Gå framåt (Färdigt!)
        }
    }
}
