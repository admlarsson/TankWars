namespace TankWars.Map
{
    public class MoonMap : BaseMap
    {
        public MoonMap(int[] heights, int height) : base(heights, height) { }

        protected override void SetFrameColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray; 
        }

        protected override void DrawCoordinate(int x, int y, int groundHeight)
        {
            if (groundHeight >= y)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray; 
                Console.Write("█"); 
            }
            else
            {
                Console.Write(" "); 
            }
        }

        public override void DrawDecorations()
        {
            MoonDecoration decoration = new MoonDecoration();
            decoration.Draw(Height, TerrainHeights);
        }


    }
}
