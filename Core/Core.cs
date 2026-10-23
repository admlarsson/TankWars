using System.Collections.Generic;

namespace TankWars.Core
{
    // FALL #2:
    // VAD: Generics (Klass med Type Constraint)
    // HUR: Vi skapade EntityManager<T> (where T : class). I BaseMap konstrueras den med olika argument: 
    // EntityManager<ITank> och EntityManager<IPowerUp>.
    // VARFÖR: Istället för att skriva separata hanterare för tanks och powerups 
    // kan vi återanvända samma logik. Typinformationen bibehålls så vi slipper casta objekt när vi plockar ut dem ur listan.

    public class EntityManager<T> where T : class
    {
        private readonly List<T> _entities = new List<T>();

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        // Returnerar alla entiteter så att Kartan kan loopa igenom och rita dem
        public IEnumerable<T> All => _entities;
    }
}