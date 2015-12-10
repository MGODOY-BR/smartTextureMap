
using smartTextureMap.Support;
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
		void WriteLine(ContextMap contextMap, String stringFormat, params object[] args);

		/// <summary>
		/// Cleans the output user
		/// </summary>
		void Clear(ContextMap contextMap);

        /// <summary>
        /// Jumps a line
        /// </summary>
        void WriteLine(ContextMap contextMap);
    }
}