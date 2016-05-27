using BattleShips.Setup;
using System;
using System.Globalization;
using System.Threading;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This class is used to get and set the user choice for the game language.
    /// </summary>
    public class SetupLanguage : ISetupLanguage
    {
        public IConsoleReader ThisReader { get; set; }
        private bool langIsChosen { get; set; }

        public SetupLanguage()
        {
            IConsoleReader anyReader = new ConsoleReader();
            ThisReader = anyReader;
            langIsChosen = false;
        }

        public void GetUserLanguageOption()
        {
            // show the welcome and language messages.
            Console.WriteLine(LanguageSetupMessages.welcome);
            Console.WriteLine(LanguageSetupMessages.getGameLanguage);

            var noOfGameLangs = Enum.GetValues(typeof(GameLanguage)).Length;
            while (langIsChosen==false)
            {
                GetUserLangInt(noOfGameLangs);
            }
            // reset the property
            langIsChosen = false;
        }

        private void GetUserLangInt(int gameLangEnum)
        {
            int userIntInput;
            string input = ThisReader.ReadConsole();
            bool result = int.TryParse(input, out userIntInput);
            if (result == false || int.Parse(input) < 0 || int.Parse(input) > gameLangEnum - 1)
            {
                Console.WriteLine(LanguageSetupMessages.getLanguageErrorMessage);
            }
            else
            {
                langIsChosen = true;
                // cast the int to its enum and set the language
                SetUserLanguageOption((GameLanguage)userIntInput);
            }
        }

        private static void SetUserLanguageOption(GameLanguage thisModeAsEnum)
        {
            switch (thisModeAsEnum.ToString())
            {
                case "English":
                    // do nothing, revert to default resource file (English)
                    Console.WriteLine(LanguageSetupMessages.showSelectionMessage,
                        thisModeAsEnum.ToString());
                    break;
                case "Maori":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("mi-NZ");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("mi-NZ");
                    Console.WriteLine(LanguageSetupMessages.showSelectionMessage,
                        thisModeAsEnum.ToString());
                    break;
                // add more cases for additional languages
                default:
                    // do nothing
                    break;
            }
        }
    }
}