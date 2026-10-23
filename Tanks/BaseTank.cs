using System;
using System.Data;
using System.Reflection.PortableExecutable;
using TankWars.Map;

namespace TankWars.Tanks
{
    public abstract class BaseTank : ITank 
    {

        protected const int MaxHP = 100;
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int HP { get; protected set; }
        public IMap Map { get; }
        private readonly IWeapon _weapon;

        private readonly int _minX;
        private readonly int _maxX;
        protected readonly int _direction;

       


        protected BaseTank(
            int startX, 
            int minX, 
            int maxX, 
            int direction, 
            IMap map, 
            IWeapon weapon)
        {
            HP = MaxHP;
            _minX = minX; 
            _maxX = maxX; 
            _direction = direction; // Spara riktningen
            Map = map;
            _weapon = weapon;
            SetPosition(startX); 
        }

        public void TakeDamage(int amount)
        {
            HP -= amount;
            if(HP < 0) HP = 0;
        }

        public bool IsHitAt(int projectileX, int projectileY)
        {
            int tankLeft = Math.Max(0, X - 1);
            int projectileColumn = projectileX + 1;
            int tankBottomRow = Map.Height - Y;
            int projectileRow = Map.Height - projectileY;
            return projectileColumn >= tankLeft && projectileColumn <= tankLeft + 3
                && projectileRow >= tankBottomRow - 2 && projectileRow <= tankBottomRow;
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
        public void Attack(int angle, double power)
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

        public void Heal(int amount)
        {
            if(amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if(amount > MaxHP - HP)
            {
                HP = MaxHP;
                return;
            }

            HP += amount;
        }

        // Dessa MÅSTE vara 'public abstract' och sluta med semikolon
        public abstract void Draw();
    
    }
}