namespace TankWars.Map
{
    // FALL #4:
    // Vad: Strategy Pattern
    //
    // HUR: Vi använder ITerrainGenerator för att skapa olika typer av terräng.
    // TrainingTerrain, EarthTerrain och MoonTerrain har egna algoritmer för
    // hur marken ska se ut. I MapMenu väljs en kartfabrik som får en
    // terrängstrategi, och när kartan skapas används GenerateTerrain()
    // för att generera markens höjder.
    //
    // VARFÖR: Vi kan enkelt byta hur terrängen genereras utan att behöva
    // ändra kartfabrikernas kod. Varje terrängtyp har sin egen logik,
    // vilket gör det enklare att lägga till nya terrängtyper.
    public interface ITerrainGenerator
    {
        int[] GenerateTerrain(int width, int maxHeight);
    }
}