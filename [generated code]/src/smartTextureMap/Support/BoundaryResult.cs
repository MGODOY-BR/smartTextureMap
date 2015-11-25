
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a result of a boundary verification
	/// </summary>
	public class BoundaryResult {

		/// <summary>
		/// Represents a result of a boundary verification
		/// </summary>
		public BoundaryResult() {
		}

		/// <summary>
		/// The results was considered a boundary
		/// </summary>
		private Boolean _isBoundary;

		/// <summary>
		/// Is the color of point
		/// </summary>
		private Color _color;

	}
}