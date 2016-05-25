namespace BattleShips.ConsoleChecker
{
    public interface ISetupLanguage
    {
        IConsoleReader ThisReader { get; set; }

        void GetUserLanguageOption();
    }
}