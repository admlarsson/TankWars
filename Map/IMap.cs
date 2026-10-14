public interface IMap
{
    // En array som håller alla Y-koordinater för marken
        int[] TerrainHeights { get; }
        
        // Gravitationen på den här kartan (påverkar hur skotten faller senare)
        double Gravity { get; }
        
        // En metod för att rita ut marken i terminalen
        void Draw();
}