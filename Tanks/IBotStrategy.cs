namespace TankWars.Tanks
{
    // FALL #5:
    // Vad: Strategy Pattern
    //
    // HUR: Vi använder IBotStrategy för att styra hur bottarna spelar.
    // EasyBotStrategy, MediumBotStrategy och HardBotStrategy har olika
    // algoritmer för hur botten rör sig och skjuter. I BotDifficultyMenu
    // väljs svårighetsgrad och strategin skickas via BotTankFactory
    // till BotTank, som använder den när det är bottens tur.
    //
    // VARFÖR: Vi kan ha olika svårighetsgrader utan att behöva skriva
    // all botlogik direkt i BotTank. Det blir enklare att ändra
    // bottarnas beteende och lägga till nya svårighetsgrader.
    public interface IBotStrategy
    {
        void ExecuteTurn(BotTank bot, ITank opponent);
    }
}
