using System;
using TankWars.Core;
using TankWars.Items;
using TankWars.Tanks;

namespace TankWars.Map
{
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
            DrawDecorations();
            DrawPowerUps();
            DrawTanks();
            DrawPowerUpLegend();
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

    
        public virtual void DrawDecorations() 
        { 
            // Standard är att inte rita något extra
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

        protected void DrawPowerUps()
        {
            foreach (IPowerUp powerUp in PowerUps.All)
            {
                powerUp.Draw();
            }
        }

        public void CheckPowerUpPickup(ITank tank)
        {
            IPowerUp? collected = null;

            foreach(IPowerUp powerUp in PowerUps.All)
            {
                if(powerUp.GetX() == tank.X && powerUp.GetY() == tank.Y)
                {
                    collected = powerUp;
                    break;
                }
            }

            if(collected is null) return;
            collected.ApplyEffect(tank);
            PowerUps.Remove(collected);
        }

        protected void DrawPowerUpLegend()
        {
            Console.SetCursorPosition(2, 1); //Placerar ut text uppe till vänster
            Console.Write("PowerUps:");
            
            Console.SetCursorPosition(2, 2);
            Console.Write("[H] = Heal");
            
            Console.SetCursorPosition(2, 3);
            Console.Write("[B] = Boost");
            
            Console.SetCursorPosition(2, 4);
            Console.Write("[S] = Shield");
        }
    }
}
