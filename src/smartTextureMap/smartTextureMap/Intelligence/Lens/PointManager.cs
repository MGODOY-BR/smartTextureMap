
using smartTextureMap.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleToAttribute("smartTextureMap.Test")]

namespace smartTextureMap.Intelligence.Lens{
	/// <summary>
	/// Represents a manager of points.
	/// </summary>
	class PointManager {

        /// <summary>
        /// It´s the last corner
        /// </summary>
        private Point _lastCorner;

		/// <summary>
		/// A list of points
		/// </summary>
		private List<Point> _pointList = new List<Point>();

		/// <summary>
		/// Registries a point
		/// </summary>
		/// <param name="point"></param>
		public void Register(Point point) {

            #region Entries validation

            if (point == null)
            {
                throw new ArgumentNullException("point");
            }

            #endregion

            if (!this._pointList.Contains(point))
            {
                this._pointList.Add(point);
            }

            if (this._lastCorner == null)
            {
                this._lastCorner = point;
            }
            else
            {
                if (point.CompareTo(this._lastCorner) == 1)
                {
                    this._lastCorner = point;
                }
            }
        }

		/// <summary>
		/// Gets the corner right point.
		/// </summary>
		/// <returns></returns>
		public Point GetRightCorner()
        {
            return this._lastCorner;

            // this._pointList.Sort();

            // return this._pointList.LastOrDefault();
		}

		/// <summary>
		/// Clears the point list
		/// </summary>
		public void Clear()
        {
            this._pointList.Clear();

            this._lastCorner = null;
		}

	}
}