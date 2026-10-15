using System;
using TankWars.Core;  // För att hitta EntityManager
using TankWars.Items; // För att hitta IPowerUp (om ni lagt den i en mapp som heter Items)
using TankWars.Tanks; // Behövs också ofta i kartorna nu!
namespace TankWars.Map
{
    public class EarthMap : IMap
    {

        public EntityManager<ITank> Tanks { get; } = new EntityManager<ITank>();
        public EntityManager<IPowerUp> PowerUps { get; } = new EntityManager<IPowerUp>();
        //public EntityManager<IPowerDown> PowerDowns { get; } = new EntityManager<IPowerDown>();
        public int[] TerrainHeights { get; private set; }
         public int Height { get; private set; }

        public EarthMap(int[] heights, int height)
        {
            TerrainHeights = heights;
            Height = height;
        }

        public void Draw()
        {
            int width = TerrainHeights.Length;
            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔" + new string('═', width) + "╗");

            for (int y = Height - 1; y >= 0; y--)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("║");

                for (int x = 0; x < width; x++)
                {
                    if (TerrainHeights[x] == y)
                    {

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("▲"); 
                    }
                    else if (TerrainHeights[x] > y)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("█"); 
                    }
                    else
                    {
                        Console.Write(" "); 
                    }
                }
                
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("║");
            }

            Console.WriteLine("╚" + new string('═', width) + "╝");
            Console.ResetColor();
        }
    }
}