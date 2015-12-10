
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.IO{
	/// <summary>
	/// Defines how the output to user must be
	/// </summary>
	public interface IOutput {

		/// <summary>
		/// Writes something to user
		/// </summary>
		/// <param name="contextMap"> </param>
		/// <param name="stringFormat"></param>
		/// <param name="args"></param>
		public void WriteLine(ContextMap contextMap, String stringFormat, HashSet<object> args);

		/// <summary>
		/// Cleans the output user
		/// </summary>
		public void Clear();

	}
}