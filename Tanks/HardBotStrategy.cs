namespace TankWars.Tanks
{
    public class HardBotStrategy : IBotStrategy
    {
        protected readonly Random _random = new Random();

        public void ExecuteTurn(BotTank bot, ITank opponent)
        {
            MoveRandomly(bot, opponent);
            (int angle, int power) = FindBestShot(bot, opponent);
            bot.Attack(angle, power);
        }

        protected void MoveRandomly(BotTank bot, ITank opponent)
        {
            bool canLeft = bot.X > bot.MinX;
            bool canRight = bot.X < bot.MaxX;
            if (!canLeft && !canRight) return;
            bool moveRight = canRight && (!canLeft || _random.Next(2) == 0);
            int available = moveRight ? bot.MaxX - bot.X : bot.X - bot.MinX;
            int steps = _random.Next(1, Math.Min(8, available) + 1);
            bot.MoveForStrategy(moveRight, steps, opponent);
        }

        protected (int angle, int power) FindBestShot(BotTank bot, ITank opponent)
        {
            int bestAngle = 45;
            int bestPower = 50;
            double bestError = double.MaxValue;
            for (int angle = 10; angle <= 80; angle++)
                SearchAngle(bot, opponent, angle, ref bestAngle, ref bestPower, ref bestError);
            return (bestAngle, bestPower);
        }

        protected void SearchAngle(
            BotTank bot, ITank opponent, int angle,
            ref int bestAngle, ref int bestPower, ref double bestError)
        {
            for (int power = 10; power <= 100; power++)
                EvaluateShot(
                    bot, 
                    opponent, 
                    angle, 
                    power, 
                    ref bestAngle, 
                    ref bestPower, 
                    ref bestError);
        }

        protected void EvaluateShot(
            BotTank bot, ITank opponent, int angle, int power,
            ref int bestAngle, ref int bestPower, ref double bestError)
        {
            double radians = angle * Math.PI / 180.0;
            double vx = power * 0.1 * Math.Cos(radians);
            int distance = Math.Max(1, Math.Abs(opponent.X - bot.X));
            int frames = Math.Max(1, (int)Math.Round(distance / vx));
            double rise = frames * power * 0.1 * Math.Sin(radians)
                - 0.2 * frames * (frames - 1) / 2.0;
            double error = Math.Abs(bot.Y + 1 + rise - opponent.Y)
                + Math.Abs(frames * vx - distance);
            if (error >= bestError) return;
            bestError = error;
            bestAngle = angle;
            bestPower = power;
        }
    }
}
