using System;
using TankWars.Core;  // För att hitta EntityManager
using TankWars.Items; // För att hitta IPowerUp (om ni lagt den i en mapp som heter Items)
using TankWars.Tanks; // Behövs också ofta i kartorna nu!
namespace TankWars.Map
{

    public class TrainingMap : IMap
    {

        public EntityManager<ITank> Tanks { get; } = new EntityManager<ITank>();
        public EntityManager<IPowerUp> PowerUps { get; } = new EntityManager<IPowerUp>();
        //public EntityManager<IPowerDown> PowerDowns { get; } = new EntityManager<IPowerDown>();
        public int[] TerrainHeights { get; private set; }

        public int Height { get; private set; }
        public TrainingMap(int[] heights, int height)
        {
            TerrainHeights = heights;
            Height = height;
        }    

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("╔" + new string('═', TerrainHeights.Length) + "╗");

            for (int y = Height -1; y >= 0; y--)
            {
                Console.Write("║");

                for (int x = 0; x < TerrainHeights.Length; x++)
                {
                    if (TerrainHeights[x] == y)
                    {
                        Console.Write("-"); // Rita mark
                    }
                    else
                    {
                        Console.Write(" "); // Rita tom himmel
                    }
                }
                Console.WriteLine("║");
                
            }

            Console.WriteLine("╚" + new string('═', TerrainHeights.Length) + "╝");

            foreach (var tank in Tanks.GetAll())
            {
                tank.Draw();
            }
            Console.ResetColor();
        }
    }
}