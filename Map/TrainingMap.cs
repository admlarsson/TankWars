using System;

namespace TankWars.Map
{
    public class TrainingMap : BaseMap
    {
        public TrainingMap(int[] heights, int height) : base(heights, height) { }

        protected override void SetFrameColor()
        {
            Console.ForegroundColor = ConsoleColor.Green; 
        }

        protected override void DrawCoordinate(int x, int y, int groundHeight)
        {
            if (groundHeight == y)
            {
                Console.Write("-"); // Rita mark
            }
            else
            {
                Console.Write(" "); // Rita tom himmel
            }
        }
    }
}
