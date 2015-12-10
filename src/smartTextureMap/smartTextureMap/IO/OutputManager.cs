
using smartTextureMap.Support;
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
        /// Gets the output way
        /// </summary>
        /// <returns></returns>
        public static IOutput GetOutputWay()
        {
            return _output;
        }

		/// <summary>
		/// Write something to user
		/// </summary>
		public static void WriteLine(object sender, ContextMap contextMap, String stringFormat, params object[] args)
        {
            _output.WriteLine(sender, contextMap, stringFormat, args);
		}

        /// <summary>
        /// Jumps a line
        /// </summary>
        public static void WriteLine(object sender, ContextMap contextMap)
        {
            _output.WriteLine(sender, contextMap);
        }

        /// <summary>
        /// Cleans the user output
        /// </summary>
        public static void Clear(object sender, ContextMap contextMap)
        {
            _output.Clear(sender, contextMap);
		}
    }
}