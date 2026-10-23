namespace TankWars.Map
{
    public interface ITerrainGenerator
    {
        int[] GenerateTerrain(int width, int maxHeight);
    }
}