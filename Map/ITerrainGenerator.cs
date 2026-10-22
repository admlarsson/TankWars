namespace TankWars.Map
{
    // FALL #5:
    // VAD: Strategy Pattern
    // HUR: Vi har brutit ut algoritmen för att generera marknivåer till ett eget gränssnitt, 
    // ITerrainGenerator. Våra kartfabriker injicerar specifika strategier (EarthTerrain, MoonTerrain) för att bygga arrayen.
    // VARFÖR: Kartklasserna (BaseMap) behöver inte innehålla tung och specifik matematik. 
    // Strategierna skiljer sig markant i beteende (EarthTerrain använder randomiserade sinuskurvor,
    // MoonTerrain använder en strikt andragradsekvation).
    public interface ITerrainGenerator
    {
        int[] GenerateTerrain(int width, int maxHeight);
    }
}