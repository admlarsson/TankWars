namespace TankWars.Menu
{
    // FALL #2:
    // VAD: Generics
    // HUR: IMenu<T> används med konkreta returtyper som IMapFactory,
    // IGameModeStrategy och vapenvalets fabrik/beteende-tuple.
    // VARFÖR: Varje meny lämnar vidare ett typsäkert objekt utan att anroparen
    // behöver casta eller tolka en primitiv valkod.
    public interface IMenu<T>
    {
        T RunMenu();
    }
}