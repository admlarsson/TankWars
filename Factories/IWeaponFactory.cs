using TankWars.Tanks;

namespace TankWars.Factories
{
    // FALL #9:
    // Vad: Factory Method Pattern (Vapen)
    //
    // HUR: I WeaponMenu väljer spelaren vilken projektiltyp som ska användas.
    // NormalWeaponFactory och ExplosiveWeaponFactory implementerar IWeaponFactory
    // och har samma metod, Create(). Den valda fabriken skickas vidare till
    // GameFactory, där den används för att skapa en projektil med spelarens
    // valda flygbeteende.
    //
    // VARFÖR: Vi kan skapa olika projektiltyper genom samma metod utan att
    // GameFactory behöver veta vilken konkret projektil som skapas.
    // Det blir enklare att lägga till nya vapentyper utan att behöva
    // ändra logiken som skapar vapnen.
    public interface IWeaponFactory
    {
        IWeapon Create(IAirBehavior behavior);
    }
}
