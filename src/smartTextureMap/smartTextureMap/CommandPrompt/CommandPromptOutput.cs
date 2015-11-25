
using smartTextureMap.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.CommandPrompt{
	/// <summary>
	/// Represents a output to command prompt
	/// </summary>
	public class CommandPromptOutput : IOutput {

        public void Clear()
        {
            Console.Clear();
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string stringFormat, params object[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(stringFormat);
            }
            else
            {
                Console.WriteLine(
                    String.Format(stringFormat, args));
            }
        }
    }
}