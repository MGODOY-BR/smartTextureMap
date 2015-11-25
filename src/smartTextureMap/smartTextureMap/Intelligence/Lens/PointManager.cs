
using smartTextureMap.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleToAttribute("smartTextureMap.Test, PublicKey=" +
    "00240000048000009400000006020000002400005253413100040000010001001db304b3ca3837" +
    "1bcae06ace586292857d3a2adbfa63bb565af98b08cc7cbcb71a7ba5d4ada5fad5a812f4a99159" +
    "908590c8765d7c870b3f371507b1575e5aed15a9bb84ea1496b83fcba52141287bc2ccdc6939f3"+
    "5ee2f406cd2e6065fa619134d749cdac1c519d69b20024aac78ddf17c12b9f74e79d301f167795" +
    "b7468ba8")]

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