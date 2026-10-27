namespace TankWars.Core
{
    // FALL #1: 
    // Vad: Generics
    //
    // HUR: I BaseMap använder vi EntityManager<ITank> för att hantera
    // tankarna och EntityManager<IPowerUp> för att hantera power-ups.
    // Båda använder samma metoder för att lägga till, ta bort och hämta objekt.
    //
    // VARFÖR: Vi slipper skriva separata klasser för tankar och power-ups.
    // Koden blir enklare att återanvända och vi säkerställer att rätt
    // typ av objekt hanteras.

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

        public IEnumerable<T> All => _entities;
    }
}