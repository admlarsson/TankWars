namespace TankWars.Tanks
{
    public class MediumBotStrategy : IBotStrategy
    {
        protected readonly Random _random = new Random();

        public void ExecuteTurn(BotTank bot, ITank opponent)
        {
            Move(bot, opponent);
            Fire(bot, opponent);
        }

        protected void Move(BotTank bot, ITank opponent)
        {
            bool canLeft = bot.X - bot.MinX >= 2;
            bool canRight = bot.MaxX - bot.X >= 2;
            bool moveRight = canRight && (!canLeft || _random.Next(2) == 0);
            int available = moveRight ? bot.MaxX - bot.X : bot.X - bot.MinX;
            if (available < 2) return;
            int steps = _random.Next(2, Math.Min(10, available) + 1);
            bot.MoveForStrategy(moveRight, steps, opponent);
        }

        protected void Fire(BotTank bot, ITank opponent)
        {
            int targetX = _random.Next(opponent.MinX, opponent.MaxX + 1);
            int distance = Math.Abs(targetX - bot.X);
            bot.Attack(45, Math.Sqrt(distance / 0.05));
        }
    }
}
