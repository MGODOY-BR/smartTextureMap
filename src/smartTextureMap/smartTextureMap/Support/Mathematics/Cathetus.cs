
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support.Mathematics{
	/// <summary>
	/// Representes a cathetus of a square
	/// </summary>
	public class Cathetus {

		/// <summary>
		/// It's the start point
		/// </summary>
		private Point _startPoint;

		/// <summary>
		/// It´s the end point
		/// </summary>
		private Point _endPoint;
        
		/// <summary>
		/// Creates an instance of an object
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="endPoint"></param>
		public Cathetus(Point startPoint, Point endPoint)
        {
            #region Entries validation
            
            if (startPoint == null)
            {
                throw new ArgumentNullException("startPoint");
            }
            if (endPoint == null)
            {
                throw new ArgumentNullException("endPoint");
            }

            #endregion

            this._endPoint = endPoint;
            this._startPoint = startPoint;
        }

		/// <summary>
		/// Get the size between the points
		/// </summary>
		/// <returns></returns>
		public double GetSize()
        {
            #region Entries validation
            
            if (this._startPoint == null)
            {
                throw new ArgumentNullException("this._startPoint");
            }
            if (this._endPoint == null)
            {
                throw new ArgumentNullException("this._endPoint");
            }

            #endregion

            double ydiff = this._endPoint.Y - this._startPoint.Y;
            double xdiff = this._endPoint.X - this._startPoint.X;
            double hypothenuse =
                Math.Sqrt(
                    (xdiff * xdiff) +
                    (ydiff * ydiff));

            return hypothenuse;
        }

	}
}