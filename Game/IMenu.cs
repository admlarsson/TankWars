namespace TankWars.Menu
{
    // FALL #2:
    // Vad: Generics
    //
    // HUR: Vi använder IMenu<T> som ett gemensamt interface för våra menyer.
    // Alla menyer har metoden RunMenu(), men med T kan varje meny bestämma
    // vilken typ av objekt den ska returnera. Exempelvis returnerar
    // MapMenu en kartfabrik, medan WeaponMenu returnerar både en
    // vapenfabrik och ett flygbeteende.
    //
    // VARFÖR: Vi slipper skapa separata interface för varje meny.
    // Menyerna kan returnera olika typer av objekt genom samma metod,
    // samtidigt som MenuController får tillbaka rätt typ direkt.
    public interface IMenu<T>
    {
        T RunMenu();
    }
} 