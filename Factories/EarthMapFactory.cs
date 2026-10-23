using TankWars.Map;

namespace TankWars.Factories
{
    // FALL #5:
    // VAD: Strategy Pattern
    // HUR: Algoritmen för att generera terrängens höjddata har brutits ut till gränssnittet ITerrainGenerator. 
    // Kartfabrikerna injicerar specifika strategier (EarthTerrain eller MoonTerrain) och anropar GenerateTerrain().
    // VARFÖR: Kartklasserna slipper innehålla komplicerad och specifik matematik. 
    // Subtyperna skiljer sig helt i beteende: EarthTerrain använder förskjutna sinuskurvor med inbyggd slump, 
    // medan MoonTerrain använder en strikt andragradsekvation för att skapa en kulle.

    public class EarthMapFactory : IMapFactory
    {
        public IMap CreateMap(int width, int maxHeight)
        {
            // Vi bestämmer att bergen ska utgå från rad 7
            ITerrainGenerator generator = new EarthTerrain(groundLevel: 7);
            
            int[] heights = generator.GenerateTerrain(width, maxHeight);
            return new EarthMap(heights, maxHeight);
        }
    }
}