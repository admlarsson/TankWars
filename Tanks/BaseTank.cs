using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public abstract class BaseTank : ITank 
    {
        private int _x;
        private int _y;
        private int _hp;
        private readonly IMap _map;
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
            _hp = 100;
            _minX = minX; 
            _maxX = maxX; 
            _direction = direction; // Spara riktningen
            _map = map; 
            _weapon = weapon;
            SetPosition(startX); 
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }

        public int GetHP()
        {
            return _hp;
        }

        public IMap GetMap()
        {
            return _map;
        }

        public void SetPosition(int x)
        {
            _x = x;
            _y = _map.GetTerrainHeights()[x] + 1; 
        }

        public void MoveLeft()
        {
            if (_x > _minX) 
                SetPosition(_x - 1);
        }

        public void MoveRight()
        {
            if (_x < _maxX) 
                SetPosition(_x + 1);
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

            _weapon.Fire(_x, _y, power, actualAngle, _map);
        }

        // Dessa MÅSTE vara 'public abstract' och sluta med semikolon
        public abstract void Draw();
    
    }
}