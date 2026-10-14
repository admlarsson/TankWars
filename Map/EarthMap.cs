public class EarthMap : IMap
{
    public int[] TerrainHeights { get; private set; }
        
        // Jorden har "normal" gravitation
        public double Gravity { get; } = 9.82; 

        // Konstruktorn tar emot en färdig array med höjder (från fabriken)
        public EarthMap(int[] heights)
        {
            TerrainHeights = heights;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            
            // Hur högt upp skyn går i terminalen (ändra om ni vill ha en högre terminal)
            int maxHeight = 20; 

            // Rita uppifrån och ner (Terminalen byter rad nedåt)
            for (int y = maxHeight; y >= 0; y--)
            {
                // Loopa igenom varje X-koordinat från vänster till höger
                for (int x = 0; x < TerrainHeights.Length; x++)
                {
                    // Om marken på detta X är högre eller lika med nuvarande Y, rita mark!
                    if (TerrainHeights[x] >= y)
                    {
                        Console.Write("█");
                    }
                    else
                    {
                        Console.Write(" "); // Luft
                    }
                }
                Console.WriteLine(); // Byt rad
            }
            Console.ResetColor();
        }
}