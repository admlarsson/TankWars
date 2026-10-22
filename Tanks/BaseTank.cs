using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public abstract class BaseTank : ITank 
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int HP { get; }
        public IMap Map { get; }
        private readonly IWeapon _weapon;

        private readonly int _minX;
        private readonly int _maxX;
        private readonly int _direction;

       


        protected BaseTank(
            int startX, 
            int minX, 
            int maxX, 
            int direction, 
            IMap map, 
            IWeapon weapon)
        {
            HP = 100;
            _minX = minX; 
            _maxX = maxX; 
            _direction = direction; // Spara riktningen
            Map = map;
            _weapon = weapon;
            SetPosition(startX); 
        }

        public void SetPosition(int x)
        {
            X = x;
            Y = Map.TerrainHeights[x] + 1;
        }

        public void MoveLeft()
        {
            if (X > _minX)
                SetPosition(X - 1);
        }

        public void MoveRight()
        {
            if (X < _maxX)
                SetPosition(X + 1);
        }

        // Här är Attack-metoden MED en kropp (måsvingar) som anropar vapnet
        public void Attack(double power, int angle)
        {
            int actualAngle = angle;

            //Kontroll är tank vänd åt vänster
            if (_direction == -1)
            {
                // Spegelvänd vinkeln! (T.ex. om inmatningen är 35 grader, blir det 180 - 35 = 145 grader).
                // Detta får skottet att flyga i en perfekt båge åt vänster istället.
                actualAngle = 180 - angle; 
            }

            _weapon.Fire(X, Y, power, actualAngle, Map);
        }

        // Dessa MÅSTE vara 'public abstract' och sluta med semikolon
        public abstract void Draw();
    
    }
}