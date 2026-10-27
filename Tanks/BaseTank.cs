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
        protected ConsoleColor _color;

        public int MinX => _minX;
        public int MaxX => _maxX;

        private bool _boostNextShot;
        private bool _shieldActive;

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
            _direction = direction; 
            Map = map;
            _weapon = weapon;
            SetPosition(startX); 
        }

        public int TakeDamage(int amount)
        {
            if(_shieldActive)
            {
                _shieldActive = false;
                return 0;
            }

            int actualDamage = Math.Min(amount, HP);
            HP -= actualDamage;
            return actualDamage;
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

        public void Attack(int angle, double power)
        {
            int actualAngle = angle;

            if (_direction == -1)
            {
                actualAngle = 180 - angle; 
            }

            int damageBonus = _boostNextShot ? 10 : 0;
            _boostNextShot = false;

            _weapon.Fire(X, Y, power, actualAngle, Map, damageBonus);
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

        public void BoostNextShot()
        {
            _boostNextShot = true;
        }

        public void ActivateShield()
        {
            _shieldActive = true;
        }

        public virtual bool ExecuteAutomatedTurn(ITank opponent)
        {
            return false;
        }

        public void Draw()
            {
                TankRenderer renderer = new TankRenderer();
                renderer.Draw(X, Y, Map.Height, _direction, _color);
            }


    
    }
}