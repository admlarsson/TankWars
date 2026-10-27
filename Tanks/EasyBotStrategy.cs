namespace TankWars.Tanks
{
    public class EasyBotStrategy : IBotStrategy
    {
        protected readonly Random _random = new Random();

        public void ExecuteTurn(BotTank bot, ITank opponent)
        {
            bool moveRight = _random.Next(2) == 0;
            int steps = _random.Next(1, 5);
            bot.MoveForStrategy(moveRight, steps, opponent);
            bot.Attack(_random.Next(20, 71), _random.Next(20, 81));
        }
    }
}
