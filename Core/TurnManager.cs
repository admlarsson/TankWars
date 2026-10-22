using System.Collections.Generic;
using TankWars.Tanks; 

namespace TankWars.Core
{
    public class TurnManager
    {
        protected readonly List<ITank> _tanks = new List<ITank>();
        protected int _currentIndex = -1; 

        public void AddTank(ITank tank)
        {
            _tanks.Add(tank);
        }

        // GÖR TILL EN PROPERTY: Räknar aktivt hur många som lever JUST NU
        public int AliveCount 
        {
            get
            {
                int count = 0;
                foreach (ITank tank in _tanks)
                {
                    if (tank.HP > 0) count++;
                }
                return count;
            }
        }

        public ITank GetNextTank()
        {
            if (AliveCount <= 1) return null;

            while (true)
            {
                _currentIndex++;
                if (_currentIndex >= _tanks.Count) _currentIndex = 0;
                
                // Om tanken lever, returnera den
                if (_tanks[_currentIndex].HP > 0)
                {
                    return _tanks[_currentIndex];
                }
            }
        }
    }
}
