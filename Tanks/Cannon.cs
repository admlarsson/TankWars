public class Cannon : IWeapon
    {
        public void Fire()
        {
            // Detta är logiken som körs när just en kanon skjuter.
            // Senare kommer vi kanske lägga till logik för att 
            // skicka iväg en "Projectile" på spelplanen.
            Console.WriteLine("Kanonen skjuter iväg en tung granat!");
        }
    }