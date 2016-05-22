using BattleShips.Setup;
using System;
using System.Globalization;
using System.Threading;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This class is used to get and set the user choice for the game language. Read line operations are repeated
    /// until valid input is obtained. A count is used to submit default values after 10 unsuccesful attempts.
    /// </summary>
    public class SetupLanguage : ISetupLanguage
    {
        public IConsoleReader ThisReader { get; set; }

        /// <summary>
        /// This method gets the user to type in an integer for the game language and then validates it
        /// before setting the UIculture. Get int of range in GameLanguages enum list. Give the user
        /// ten goes then do nothing (i.e. leave the default language)
        /// </summary>
        /// <returns></returns>
        public void SelectLanguage()
        {
            IConsoleReader anyReader = new ConsoleReader();
            ThisReader = anyReader;

            // show the welcome and language messages.
            Console.WriteLine(LanguageSetupMessages.welcome);
            Console.WriteLine(LanguageSetupMessages.getGameLanguage);

            var gameLangEnum = Enum.GetValues(typeof(GameLanguage)).Length;
            int langEntered;
            int count = 0;
            bool langIsChosen = false;
            while (count < 10 && langIsChosen==false)
            {
                string input = ThisReader.ReadConsole();
                bool result = int.TryParse(input, out langEntered);
                if (result == false || int.Parse(input) < 0 || int.Parse(input) > gameLangEnum - 1)
                {
                    Console.WriteLine(LanguageSetupMessages.getLanguageErrorMessage);
                    count++;
                }
                else
                {
                    langIsChosen = true;
                    // cast the int to its enum and check its name
                    GameLanguage thisModeAsEnum = (GameLanguage)langEntered;
                    switch (thisModeAsEnum.ToString())
                    {
                    case "English":
                            // do nothing, revert to default resource file (English)
                            Console.WriteLine(LanguageSetupMessages.showSelectionMessage, "English");
                            break;
                    case "Maori":
                            Thread.CurrentThread.CurrentCulture = new CultureInfo("mi-NZ");
                            Thread.CurrentThread.CurrentUICulture = new CultureInfo("mi-NZ");
                            Console.WriteLine(LanguageSetupMessages.showSelectionMessage, "Maori");
                            break;
                        // add more cases for additional languages
                    default:
                            // do nothing
                            break;
                    }
                }
            }
        }
    }
}