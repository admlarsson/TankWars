namespace TankWars.Menu
{
    // FALL #1:
    // VAD: Generics
    // HUR: Vi har skapat det generiska gränssnittet IMenu<T> som konstrueras med olika typ-argument i våra menyer 
    // (t.ex. IMenu<int> i GameModeMenu och IMenu<string> i MapMenu).
    // VARFÖR: Det tvingar alla menyer att implementera RunMenu() med rätt returtyp utan typ-testning eller osäker casting. Koden i MenuController blir enklare och 100 % typsäker.

    public interface IMenu<T>
    {
        T RunMenu();
    }
}