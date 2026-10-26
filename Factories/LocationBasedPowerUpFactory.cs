using TankWars.Items;

namespace TankWars.Factories
{
    public class LocationBasedPowerUpFactory : IPowerUpFactory
    {
        public IPowerUp CreatePowerUp(int x, int y, int mapHeight)
        {
            // Genom att använda modulo (%) på X-koordinaten blir resten alltid 0, 1 eller 2.
            // Till skillnad från slumpfabriken, innebär detta att en specifik X-koordinat 
            // ALLTID resulterar i samma typ av PowerUp (deterministiskt beteende).
            int locationValue = x % 3;

            if(locationValue == 0)
            {
                return new ShieldPowerUp(x, y, mapHeight);
            }
            else if(locationValue == 1)
            {
                return new HealPowerUp(x, y, mapHeight);
            }
            else
            {
                return new BoostPowerUp(x, y , mapHeight);
            }
        }
    }
}
