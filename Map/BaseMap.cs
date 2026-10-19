using System;
using TankWars.Core;
using TankWars.Items;
using TankWars.Tanks;

namespace TankWars.Map
{
    public abstract class BaseMap : IMap
    {
        // Gemensam data för alla kartor
        public EntityManager<ITank> Tanks { get; } = new EntityManager<ITank>();
        public EntityManager<IPowerUp> PowerUps { get; } = new EntityManager<IPowerUp>();
        public int[] TerrainHeights { get; protected set; }
        public int Height { get; protected set; }

        public BaseMap(int[] heights, int height)
        {
            TerrainHeights = heights;
            Height = height;
        }

        // Den gemensamma utritnings-loopen!
        public void Draw()
        {
            int width = TerrainHeights.Length;
            
            SetFrameColor(); // Subklassen får bestämma färgen på ramen
            Console.WriteLine("╔" + new string('═', width) + "╗");

            for (int y = Height - 1; y >= 0; y--)
            {
                SetFrameColor();
                Console.Write("║");

                for (int x = 0; x < width; x++)
                {
                    // Låt subklassen bestämma exakt VAD som ritas ut på just denna pixel
                    DrawCoordinate(x, y, TerrainHeights[x]);
                }
                
                SetFrameColor();
                Console.WriteLine("║");
            }

            Console.WriteLine("╚" + new string('═', width) + "╝");
            
            // Rita ut alla tanks
            foreach (var tank in Tanks.GetAll())
            {
                tank.Draw();
            }
            Console.ResetColor();
        }

        // Dessa två metoder tvingar vi de specifika kartorna att implementera själva
        protected abstract void SetFrameColor();
        protected abstract void DrawCoordinate(int x, int y, int groundHeight);
    }
}
