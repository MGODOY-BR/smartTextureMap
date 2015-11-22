
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a result of a boundary verification
	/// </summary>
	public class BoundaryResult {

        public BoundaryResult()
        {

        }

		/// <summary>
		/// Creates the object
		/// </summary>
		public BoundaryResult(bool isBoundary, Color color)
        {
            this._color = color;
            this._isBoundary = isBoundary;
		}

		/// <summary>
		/// The results was considered a boundary
		/// </summary>
		private Boolean _isBoundary;

		/// <summary>
		/// Is the color of point
		/// </summary>
		private Color _color;

        /// <summary>
        /// The results was considered a boundary
        /// </summary>
        public bool IsBoundary
        {
            get
            {
                return _isBoundary;
            }
            internal set
            {
                _isBoundary = value;
            }
        }

        /// <summary>
        /// Is the color of point
        /// </summary>
        public Color Color
        {
            get
            {
                return _color;
            }
            internal set
            {
                _color = value;
            }
        }
    }
}