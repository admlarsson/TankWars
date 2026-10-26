using TankWars.Tanks;

namespace TankWars.Factories
{
    // FALL #9:
    // VAD: Factory Method Pattern
    // HUR: IWeaponFactory implementeras av NormalWeaponFactory och
    // ExplosiveWeaponFactory.
    // VARFÖR: Kapslar in skapandet av projektiler. Beroende på menyval
    // skapas olika BaseBullet-produkter laddade med valt flygbeteende.
    public interface IWeaponFactory
    {
        IWeapon Create(IAirBehavior behavior);
    }
}
