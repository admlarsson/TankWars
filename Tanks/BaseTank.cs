using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public abstract class BaseTank : ITank 
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int HP { get; protected set; }

        protected int MinX { get; set; }
        protected int MaxX { get; set; }

        protected IMap map;
        protected IWeapon weapon;

        public BaseTank(int startX, int minX, int maxX, IMap map, IWeapon weapon)
        {
            HP = 100;
            MinX = minX; 
            MaxX = maxX; 
            this.map = map; 
            this.weapon = weapon;
            SetPosition(startX); 
        }

        public void SetPosition(int x)
        {
            X = x;
            Y = map.TerrainHeights[x] + 1; 
        }

        public void MoveLeft()
        {
            if (X > MinX) 
                SetPosition(X - 1);
        }

        public void MoveRight()
        {
            if (X < MaxX) 
                SetPosition(X + 1);
        }

        // Här är Attack-metoden MED en kropp (måsvingar) som anropar vapnet
        public void Attack(double power, int angle)
        {
            weapon.Fire(X, Y, power, angle);
        }

        // Dessa MÅSTE vara 'public abstract' och sluta med semikolon
        public abstract void Draw();
        public abstract void TakeTurn();
    
    }
}