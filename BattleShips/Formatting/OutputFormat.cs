using System;
using System.IO;
using System.Text;

namespace BattleShips.Formatting
{
    /// <summary>
    /// This class overrides and formats the console.writeline to
    /// include a carriage return before every string. It also
    /// provides a LHS margin of 3 spaces and word wrap where line
    /// length exceeds 60 characters.
    /// </summary>
    class OutputFormat : TextWriter
    {
        private TextWriter originalOut;

        // create a counter used to check the line length
        private int count = 0;

        // create a constant used to store the preferred line length
        private const int idealLineLength = 60;

        public OutputFormat()
        {
            originalOut = Console.Out;
        }

        public override Encoding Encoding
        {
            get { return new System.Text.ASCIIEncoding(); }
        }

        public override void WriteLine(string message)
        {
            originalOut.WriteLine(string.Format("{0}   {1}", "\n", FormatMessage(message)));
        }
        public override void Write(string message)
        {
            originalOut.Write(String.Format("{0}   {1}", "\n", FormatMessage(message)));
        }
        /// <summary>
        /// This method iterates the message and formats it with appropriate line
        /// breaks and spaces for the margin.
        /// </summary>
        /// <param name="thisMessage"></param>
        /// <returns></returns>
        private string FormatMessage(string thisMessage)
        {
            // set the count to zero
            count = 0;

            // create a new SB to store the formatted string
            var newString = new StringBuilder();

            for (int i = 0; i < thisMessage.Length; i++)
            {
                newString.Append(checkChar(thisMessage[i].ToString()));
            }
            return newString.ToString();
        }

        private string checkChar(string msgChar)
        {
            if (msgChar == Environment.NewLine || msgChar == "\n")
            {
                // reset the counter and return a margin
                count = 0;
                return (msgChar + "   ");
            }
            else
            {
                if (count > idealLineLength && msgChar == " ")
                {
                    // reset counter, add line break and margin
                    count = 0;
                    return ("\n   ");
                }
                else
                {
                    count++;
                    return msgChar;
                }
            }
        }
    }
}
