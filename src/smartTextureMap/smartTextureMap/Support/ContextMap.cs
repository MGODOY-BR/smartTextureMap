
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a context of transformation
	/// </summary>
	public class ContextMap {

        /// <summary>
        /// It´s the identification of context
        /// </summary>
        private String _identification;

        /// <summary>
        /// Creates an instance of the object
        /// </summary>
        public ContextMap()
        {
            this._identification = Guid.NewGuid().ToString();
        }

		/// <summary>
		/// Returns the Identification of ContextMap
		/// </summary>
		/// <returns></returns>
		public String GetIdentification()
        {
            return this._identification;
		}
	}
}