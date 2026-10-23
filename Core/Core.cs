using System.Collections.Generic;

namespace TankWars.Core
{
    // FALL #1:
    // VAD: Generics
    // HUR: EntityManager<T> används som EntityManager<ITank> och
    // EntityManager<IPowerUp>. Add, Remove och All arbetar med T direkt.
    // VARFÖR: Samma typsäkra hanteringslogik fungerar för olika entitetstyper
    // utan separata manager-klasser eller casting när entiteter hämtas.
    public class EntityManager<T>
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