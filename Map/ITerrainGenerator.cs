namespace TankWars.Map
{
    // FALL #4:
    // VAD: Strategy Pattern
    // HUR: TrainingTerrain, EarthTerrain och MoonTerrain agerar konkreta
    // strategier med helt olika matematiska algoritmer.
    // VARFÖR: Terränggenereringen kan bytas ut dynamiskt i kartfabrikerna
    // utan att påverka systemet. Skiljer sig i algoritmiskt beteende.
    public interface ITerrainGenerator
    {
        int[] GenerateTerrain(int width, int maxHeight);
    }
}