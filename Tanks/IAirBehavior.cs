using System;

namespace TankWars.Tanks
{
    public interface IAirBehavior
    {
        // 'ref' betyder att metoden kan ändra på skottets faktiska vx och vy
        void UpdateVelocity(ref double vx, ref double vy, ConsoleKey? input);

        // NYTT: Tvingar alla beteenden att kunna nollställa sig inför ett nytt skott
        void Reset(); 
    }
}
