using System;

namespace TankWars.Map
{
    public class MoonMap : BaseMap
    {
        // Skickar vidare datan till basklassen via : base()
        public MoonMap(int[] heights, int height) : base(heights, height) { }

        protected override void SetFrameColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray; 
        }

        protected override void DrawCoordinate(int x, int y, int groundHeight)
        {
            // Månen är solid sten ända ner i botten
            if (groundHeight >= y)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray; 
                Console.Write("█"); 
            }
            else
            {
                Console.Write(" "); // Tom rymd
            }
        }
    }
}
