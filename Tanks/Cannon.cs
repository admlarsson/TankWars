using System;

namespace TankWars.Tanks
{
    public class Cannon : IWeapon
    {
        public void Fire(int startX, int startY, double power, int angle)
        {
            Console.WriteLine("Kanonen skjuter!");
        }
    }
}