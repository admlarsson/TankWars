using System;

namespace TankWars.Tanks
{
    // FALL #5: Strategy Pattern
    // VAD: IAirBehavior definierar utbytbara flygstrategier.
    // HUR: BaseBullet tar emot strategin via sin konstruktor;
    //      BulletFactory väljer GravityBehavior eller DropBehavior.
    // VARFÖR: Skottets rörelse kan ändras utan att ändra
    //         projektilens gemensamma flyglogik.
    public interface IAirBehavior
    {
        // 'ref' betyder att metoden kan ändra på skottets faktiska vx och vy
        void UpdateVelocity(ref double vx, ref double vy, ConsoleKey? input);

        // NYTT: Tvingar alla beteenden att kunna nollställa sig inför ett nytt skott
        void Reset(); 
    }
}
