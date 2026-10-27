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
                Console.Write("▲"); 
            }
            else if (groundHeight > y)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("█"); 
            }
            else
            {
                Console.Write(" "); 
            }
        }

        public override void DrawDecorations()
        {
            EarthDecoration decoration = new EarthDecoration();
            decoration.Draw(TerrainHeights);
        }
    }
}
