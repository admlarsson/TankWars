using System;
using TankWars.Core;
using TankWars.Items;
using TankWars.Tanks;

namespace TankWars.Map
{
    // FALL #3:
    // Generics. Oklart om vi använder 
    //
    // Vi har skapat en egen generisk typ EntityManager<T> med begränsningen 'where T : IGameObject'.
    // Den konstrueras med olika typ-argument i vår BaseMap: en för <ITank> och en för <IPowerUp>.
    //
    // VARFÖR använder ni konceptet (och varför krävs T framför en supertyp)?
    // Typinformationen måste bibehållas för att undvika osäker typkonvertering (casting). 
    // Om vi hade använt en vanlig List<IGameObject> hade t.ex. GetEntityAt(x) returnerat ett 
    // IGameObject. Eftersom vi använder T returnerar EntityManager<ITank> specifikt en ITank, 
    // vilket gör att vi kommer åt tank-specifika egenskaper utan casting.
    // Begränsningen (where T : IGameObject) krävs för att koden ska kompilera när vi anropar 
    // objektens egenskaper internt.
    public abstract class BaseMap : IMap
    {
        // Gemensam data för alla kartor
        public EntityManager<ITank> Tanks { get; } =
        new EntityManager<ITank>();
        public EntityManager<IPowerUp> PowerUps { get; } =
        new EntityManager<IPowerUp>();
        public int[] TerrainHeights { get; }
        public int Height { get; }
        public BaseMap(int[] heights, int height)
        {
            TerrainHeights = heights;
            Height = height;
        }

        public void Draw()
        {
            DrawFrame();
            DrawTanks();
            Console.ResetColor();
        }

        protected abstract void SetFrameColor();
        protected abstract void DrawCoordinate(
            int x,
            int y,
            int groundHeight);




        protected void DrawFrame()
        {
            int width = TerrainHeights.Length;
            DrawBorder('╔', '═', '╗', width);

            for (int y = Height - 1; y >= 0; y--)
            {
                DrawRow(y, width);
            }

            DrawBorder('╚', '═', '╝', width);
        }
        protected void DrawBorder(char left, char fill, char right, int width)
        {
            SetFrameColor();
            Console.WriteLine(left + new string(fill, width) + right);
        }

        protected void DrawRow(int y, int width)
        {
            SetFrameColor();
            Console.Write("║");

            for (int x = 0; x < width; x++)
            {
                DrawCoordinate(x, y, TerrainHeights[x]);
            }

            SetFrameColor();
            Console.WriteLine("║");
        }

        protected void DrawTanks()
        {
            foreach(ITank tank in Tanks.All)
            {
                tank.Draw();
            }
        }
    }
}
