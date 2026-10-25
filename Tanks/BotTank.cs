using System;
using System.Runtime.InteropServices;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class BotTank : BaseTank
    {
        protected readonly ConsoleColor _color;
        private readonly Random _random = new Random();
        public BotTank(
            int startX,
            int minX,
            int maxX, 
            int direction, 
            IMap map, 
            IWeapon weapon,
            ConsoleColor color) 
            : base(startX, minX, maxX, direction, map, weapon)
        {
            _color = color;
        }

        public void TakeTurn(ITank target)
        {
            bool canMoveLeft = X - MinX >= 2;
            bool canMoveRight = MaxX - X >= 2;

            // Slumpa riktning, men välj bara en riktning där det finns plats att gå.
            bool moveRight = canMoveRight &&
                (!canMoveLeft || _random.Next(2) == 0);

            int availableSteps = moveRight ? MaxX - X : X - MinX;
            int steps = _random.Next(2, Math.Min(10, availableSteps) + 1);

            for (int i = 0; i < steps; i++)
            {
                if (moveRight)
                    MoveRight();
                else
                    MoveLeft();

                Map.CheckPowerUpPickup(this);

                Console.Clear();
                Map.Draw();
                Console.SetCursorPosition(0, Map.Height + 2);
                Console.WriteLine("*** DATORNS TUR ***");
                Console.WriteLine($"[ Position X: {X} | Datorns HP: {HP} ]");
                Console.WriteLine($"[ Spelarens HP: {target.HP} ]");
                Console.WriteLine($"Datorn flyttar ({i + 1}/{steps})...");
                System.Threading.Thread.Sleep(150);
            }

            int targetX = _random.Next(target.MinX, target.MaxX + 1);
            int distance = Math.Abs(targetX - X);

            int angle = 45;
            double power = Math.Sqrt(distance / 0.05);

            Attack(angle, power);
        }

        public override void Draw()
        {
           TankRenderer renderer = new TankRenderer();
           renderer.Draw(X, Y, Map.Height, _direction, _color);
        }

        
    }
}