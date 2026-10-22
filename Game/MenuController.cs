using TankWars.Core;
using TankWars.Menu;

namespace TankWars.Game
{
    public class MenuController
    {
        public GameSettings CreateSettings()
        {
            var settings = new GameSettings();
            int step = 1;

            // Loopar tills vi når steg 5 (Då är vi färdiga)
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
            
            if (settings.GameMode == 4) return 5; // Spelaren valde "Avsluta". Hoppa ur loopen.
            
            return 2; // Gå framåt till steg 2
        }

        protected int HandleMapChoice(GameSettings settings)
        {
            settings.MapChoice = new MapMenu().RunMenu();
            
            if (settings.MapChoice == "0") return 1; // Spelaren valde 0. BACKA till steg 1!
            
            return 3; // Gå framåt till steg 3
        }

        protected int HandlePlayer1Weapon(GameSettings settings)
        {
            if (settings.GameMode == 3) return 4; // Datorer väljer inte vapen. Hoppa till nästa.

            var (b1, f1) = new WeaponMenu("Spelare 1").RunMenu();
            
            if (b1 == "0") return 2; // BACKA till Kartvalet!

            settings.Player1Bullet = b1;
            settings.Player1Flight = f1;
            return 4; // Gå framåt
        }

        protected int HandlePlayer2Weapon(GameSettings settings)
        {
            if (settings.GameMode != 2) return 5; // Endast PvP behöver vapen för spelare 2. Klar!

            var (b2, f2) = new WeaponMenu("Spelare 2").RunMenu();
            
            if (b2 == "0") return 3; // BACKA till Spelare 1:s vapenval!

            settings.Player2Bullet = b2;
            settings.Player2Flight = f2;
            return 5; // Gå framåt (Färdigt!)
        }
    }
}
