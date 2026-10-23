using System;

namespace TankWars.Map
{
    public class EarthMap : BaseMap
    {
        public EarthMap(int[] heights, int height) : base(heights, height) { }

        protected override void SetFrameColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen; 
        }

        protected override void DrawCoordinate(int x, int y, int groundHeight)
        {
            if (groundHeight == y)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("▲"); // Gräs på ytan
            }
            else if (groundHeight > y)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("█"); // Jord under ytan
            }
            else
            {
                Console.Write(" "); // Tom himmel
            }
        }

        // Delegerar arbetet till den nya klassen
        public override void DrawDecorations()
        {
            EarthDecoration decoration = new EarthDecoration();
            decoration.Draw(TerrainHeights);
        }


    }
}
