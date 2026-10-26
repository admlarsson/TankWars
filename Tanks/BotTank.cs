using System;
using TankWars.Map;

namespace TankWars.Tanks
{
    public class BotTank : BaseTank
    {
        protected readonly ConsoleColor _color;
        protected readonly IBotStrategy _strategy;

        public BotTank(
            int startX,
            int minX,
            int maxX, 
            int direction, 
            IMap map, 
            IWeapon weapon,
            ConsoleColor color,
            IBotStrategy strategy)
            : base(startX, minX, maxX, direction, map, weapon)
        {
            _color = color;
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public override bool ExecuteAutomatedTurn(ITank opponent)
        {
            _strategy.ExecuteTurn(this, opponent);
            return true;
        }

        public void MoveForStrategy(bool moveRight, int steps, ITank opponent)
        {
            for (int i = 0; i < steps; i++)
                MoveAndRenderStep(moveRight, i, steps, opponent);
        }

        public void MoveAndRenderStep(bool moveRight, int step, int steps, ITank opponent)
        {
            if (moveRight) MoveRight(); else MoveLeft();
            Map.CheckPowerUpPickup(this);
            RenderMovementStatus(step, steps, opponent);
        }

        public void RenderMovementStatus(int step, int steps, ITank opponent)
        {
            Console.Clear();
            Map.Draw();
            Console.SetCursorPosition(0, Map.Height + 2);
            Console.WriteLine("*** DATORNS TUR ***");
            Console.WriteLine($"[ Position X: {X} | Datorns HP: {HP} ]");
            Console.WriteLine($"[ Motståndarens HP: {opponent.HP} ]");
            Console.WriteLine($"Datorn flyttar ({step + 1}/{steps})...");
            System.Threading.Thread.Sleep(150);
        }

        public override void Draw()
        {
           TankRenderer renderer = new TankRenderer();
           renderer.Draw(X, Y, Map.Height, _direction, _color);
        }

        
    }
}