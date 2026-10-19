using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public abstract class BaseTank : ITank 
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int HP { get; protected set; }

        public int Direction { get; protected set; } //Håller koll på tankens riktning

        protected int MinX { get; set; }
        protected int MaxX { get; set; }

        protected IMap map;
        protected IWeapon weapon;

        public BaseTank(int startX, int minX, int maxX, int direction, IMap map, IWeapon weapon)
        {
            HP = 100;
            MinX = minX; 
            MaxX = maxX; 
            Direction = direction; // Spara riktningen
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
            int actualAngle = angle;

            //Kontroll är tank vänd åt vänster
            if (Direction == -1)
            {
                // Spegelvänd vinkeln! (T.ex. om inmatningen är 35 grader, blir det 180 - 35 = 145 grader).
                // Detta får skottet att flyga i en perfekt båge åt vänster istället.
                actualAngle = 180 - angle; 
            }

            weapon.Fire(X, Y, power, actualAngle, map);
        }

        // Dessa MÅSTE vara 'public abstract' och sluta med semikolon
        public abstract void Draw();
        public abstract void TakeTurn();
    
    }
}