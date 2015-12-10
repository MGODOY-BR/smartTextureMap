
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.IO{
	/// <summary>
	/// Controls how the output is showing.
	/// </summary>
	public class OutputManager {

		/// <summary>
		/// Controls how the output is showing.
		/// </summary>
		public OutputManager() {
		}

		/// <summary>
		/// It's the output to user
		/// </summary>
		private IOutput _output;

		/// <summary>
		/// Sets the output way
		/// </summary>
		/// <param name="output"></param>
		public static void SetOutPutWay(IOutput output) {
			// TODO implement here
		}

		/// <summary>
		/// Write something to user
		/// </summary>
		/// <param name="contextMap"> </param>
		/// <param name="stringFormat"></param>
		/// <param name="args"></param>
		public static void WriteLine(ContextMap contextMap , String stringFormat, HashSet<object> args) {
			// TODO implement here
		}

		/// <summary>
		/// Cleans the user output
		/// </summary>
		public static void Clear() {
			// TODO implement here
		}

	}
}