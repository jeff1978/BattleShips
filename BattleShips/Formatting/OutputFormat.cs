using System;
using System.IO;
using System.Text;

namespace BattleShips.Formatting
{
    /// <summary>
    /// This class overrides and formats the console.writeline to
    /// include a carriage return before every string. It also
    /// provides a LHS margin of 3 spaces.
    /// </summary>
    class OutputFormat : TextWriter
    {
        private TextWriter originalOut;

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
            originalOut.WriteLine(string.Format("{0}   {1}", "\n", message));
        }
        public override void Write(string message)
        {
            originalOut.Write(String.Format("{0}   {1}","\n", message));
        }
    }
}
