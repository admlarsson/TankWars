namespace TankWars.Tanks
{
    // FALL #5:
    // VAD: Strategy Pattern
    // HUR: EasyBotStrategy, MediumBotStrategy och HardBotStrategy
    // implementerar gränssnittet. Strategin injiceras sedan i BotTank.
    // VARFÖR: Frikopplar datorns intelligens från stridsvagnskroppen.
    // Svårighetsgraderna fattar unika beslut för rörelse och sikte.
    public interface IBotStrategy
    {
        void ExecuteTurn(BotTank bot, ITank opponent);
    }
}
