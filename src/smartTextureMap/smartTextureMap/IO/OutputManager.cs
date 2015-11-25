
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.IO{
	/// <summary>
	/// Controls how the output is showing.
	/// </summary>
	public static class OutputManager {

		/// <summary>
		/// It's the output to user
		/// </summary>
		private static IOutput _output;

        /// <summary>
        /// Sets the output way
        /// </summary>
		/// <param name="output"></param>
		public static void SetOutPutWay(IOutput output)
        {
            #region Entries validation
            
            if (output == null)
            {
                throw new ArgumentNullException("output");
            }

            #endregion

            _output = output;
        }

		/// <summary>
		/// Write something to user
		/// </summary>
		/// <param name="stringFormat"></param>
		/// <param name="args"></param>
		public static void WriteLine(String stringFormat, params object[] args)
        {
            _output.WriteLine(stringFormat, args);
		}

        /// <summary>
        /// Jumps a line
        /// </summary>
        public static void WriteLine()
        {
            _output.WriteLine();
        }

        /// <summary>
        /// Cleans the user output
        /// </summary>
        public static void Clear()
        {
            _output.Clear();
		}
    }
}