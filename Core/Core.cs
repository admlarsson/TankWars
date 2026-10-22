using System.Collections.Generic;

namespace TankWars.Core
{
    // FALL #1: Generics
    // VAD: En egen generisk klass (EntityManager<T>).
    // HUR: Den hanterar en lista av en valfri typ <T> (t.ex. ITank eller IPowerUp). 
    //      Vi använder "where T : class" för att garantera att det är referenstyper vi hanterar.
    // VARFÖR: Istället för att skriva tre olika klasser (TankManager, PowerUpManager, PowerDownManager) 
    //         får vi en enda återanvändbar komponent. Detta minskar kodduplicering markant 
    //         och gör kartan oberoende av exakt VAD som förvaras på den.
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