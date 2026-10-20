using System.Collections.Generic;
using TankWars.Tanks; // För att hitta ITank

namespace TankWars.Core
{

    public class TurnManager
    {
        private readonly List<ITank> _tanks = new List<ITank>();
        private int _currentIndex = -1; // Börjar på -1 så att första anropet ger index 0

        public void AddTank(ITank tank)
        {
            _tanks.Add(tank);
        }

        public int GetAliveCount()
        {
            return _tanks.Count;
        }

        // Iterator-metoden som hämtar nästa spelare
        public ITank GetNextTank()
        {
            if (_tanks.Count == 0)
                return null;

            // Loopa tills vi hittar en tank som lever
            while (true)
            {
                // 1. Gå ett steg framåt i listan
                _currentIndex++;

                // 2. Om vi nått slutet (t.ex. index 2 på en lista med 2 element), börja om på 0
                if (_currentIndex >= _tanks.Count)
                {
                    _currentIndex = 0;
                }

                // 3. Kolla på tanken vi just landade på
                ITank currentTank = _tanks[_currentIndex];

                // 4. Lever den? Returnera den!
                if (currentTank.GetHP() > 0)
                {
                    return currentTank;
                }
                else
                {
                    // 5. Är den död? Ta bort den och sänk index så vi inte hoppar över nästa person i listan
                    _tanks.RemoveAt(_currentIndex);
                    _currentIndex--; 
                }
            }
        }
    }
}