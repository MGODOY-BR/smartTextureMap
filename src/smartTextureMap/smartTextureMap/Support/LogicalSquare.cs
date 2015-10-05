
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a logical square contained inside of the shape, used to simplify the form of the shape
	/// </summary>
	public class LogicalSquare {

		/// <summary>
		/// It´s the calculated pointC
		/// </summary>
		private Point _pointC;

		/// <summary>
		/// It´s the calculated pointD
		/// </summary>
		private Point _pointD;

		/// <summary>
		/// It's the first coordinate of the logical square
		/// </summary>
		private Point _pointA;

		/// <summary>
		/// Represents the second coordinate of the logical square
		/// </summary>
		private Point _pointB;

        /// <summary>
        /// Gets the point C
        /// </summary>
        /// <remarks>
        /// Coordinates of points:
        /// A       C
        /// D       B
        /// </remarks>
        public Point PointC
        {
            get
            {
                return _pointC;
            }
        }

        /// <summary>
        /// Gets the point D
        /// </summary>
        /// <remarks>
        /// Coordinates of points:
        /// A       C
        /// D       B
        /// </remarks>
        public Point PointD
        {
            get
            {
                return _pointD;
            }
        }

        /// <summary>
        /// Gets the point A
        /// </summary>
        /// <remarks>
        /// Coordinates of points:
        /// A       C
        /// D       B
        /// </remarks>
        public Point PointA
        {
            get
            {
                return _pointA;
            }
        }

        /// <summary>
        /// Gets the point B
        /// </summary>
        /// <remarks>
        /// Coordinates of points:
        /// A       C
        /// D       B
        /// </remarks>
        public Point PointB
        {
            get
            {
                return _pointB;
            }
        }

        /// <summary>
        /// Verifies whether the point is inside of the logical square
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        /// <remarks>
        /// Coordinates of points:
        /// A       C
        /// D       B
        /// </remarks>
        public Boolean CheckInside(Point point)
        {
            #region Entries validation

            if (point == null)
            {
                throw new ArgumentNullException("point");
            }
            if (this._pointA == null)
            {
                throw new ArgumentNullException("this._pointA");
            }
            if (this._pointB == null)
            {
                throw new ArgumentNullException("this._pointB");
            }
            if (this._pointC == null)
            {
                throw new ArgumentNullException("this._pointC");
            }
            if (this._pointD == null)
            {
                throw new ArgumentNullException("this._pointD");
            }

            #endregion

            return
                point.X >= this._pointA.X &&
                point.X <= this._pointB.X &&
                point.Y >= this._pointA.Y &&
                point.Y <= this._pointB.Y;
        }

        /// <summary>
        /// Validates whether the square have valid parameters
        /// </summary>
        /// <returns></returns>
        public Boolean Validate()
        {
            if (this._pointB.X < this._pointA.X + 50)
            {
                return false;
            }
            if (this._pointB.Y < this._pointA.Y + 50)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Creates a instance of object using the points to forms a hypotenuse
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <remarks>
        /// Coordinates of points:
        /// A       C
        /// D       B
        /// </remarks>
        public LogicalSquare(Point pointA, Point pointB)
        {
            #region Entries validation

            if (pointA == null)
            {
                throw new ArgumentNullException("pointA");
            }
            if (pointB == null)
            {
                throw new ArgumentNullException("pointB");
            }
            if(pointB.X < pointA.X)
            {
                throw new ArgumentException("The coordinate X of point B cannot be lower than the point A");
            }
            if (pointB.Y < pointA.Y)
            {
                throw new ArgumentException("The coordinate Y of point B cannot be lower than the point A");
            }

            #endregion

            this._pointA = pointA;
            this._pointB = pointB;

            // Calculating the point C
            this._pointC = new Point(pointB.X, pointA.Y);

            // Calculating the point D
            this._pointD = new Point(pointA.X, pointB.Y);
        }

    }
}