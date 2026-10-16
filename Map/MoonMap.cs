using TankWars.Core;  // För att hitta EntityManager
using TankWars.Items; // För att hitta IPowerUp (om ni lagt den i en mapp som heter Items)
using TankWars.Tanks; // Behövs också ofta i kartorna nu!
namespace TankWars.Map
{
    public class MoonMap : IMap
    {

        public EntityManager<ITank> Tanks { get; } = new EntityManager<ITank>();
        public EntityManager<IPowerUp> PowerUps { get; } = new EntityManager<IPowerUp>();
        //public EntityManager<IPowerDown> PowerDowns { get; } = new EntityManager<IPowerDown>();
        public int[] TerrainHeights { get; private set; }
         public int Height { get; private set; }

        public MoonMap(int[] heights, int height)
        {
            TerrainHeights = heights;
            Height = height;
        }

        public void Draw()
        {
            // Sätt stämningen med mörkgrå färg
            Console.ForegroundColor = ConsoleColor.DarkGray; 
            int width = TerrainHeights.Length;

            Console.WriteLine("╔" + new string('═', width) + "╗");

            for (int y = Height - 1; y >= 0; y--)
            {
                Console.Write("║");

                for (int x = 0; x < width; x++)
                {
                    // Vi använder >= för att fylla hela månen med solid sten hela vägen ner till botten
                    if (TerrainHeights[x] >= y)
                    {
                        Console.Write("█"); 
                    }
                    else
                    {
                        Console.Write(" "); 
                    }
                }
                Console.WriteLine("║");
            }

            Console.WriteLine("╚" + new string('═', width) + "╝");
            foreach (var tank in Tanks.GetAll())
            {
                tank.Draw();
            }
            Console.ResetColor();
        }
    }
}