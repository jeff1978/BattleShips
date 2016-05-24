namespace BattleShips.Setup
{
    /// <summary>
    /// This class stores all the console messages used during the language setup
    /// </summary>
    public static class LanguageSetupMessages
    {
        public const string welcome =
@"__________________________________
|   ___________________________   |
|  |                           |  |
|  |                           |  |
|  |      Battleships v1.0     |  |
|  |                           |  |
|  |___________________________|  |
|                                 |
|*********************************|
|              J A W              |
|_________________________________|

     Welcome to Battleships!";

        public const string getLanguageErrorMessage =
@"The language you entered was not recognised. Try again using a valid number for your language.";

        public const string getGameLanguage =
@"Game language choices.....

0 - English (Default)
1 - Maori

Enter 0 or 1:";

        public const string showSelectionMessage =
@"{0} selected...";
    }
}
