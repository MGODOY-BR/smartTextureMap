
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
            #region Entries validation
            
            if (this._pointA == null)
            {
                throw new ArgumentNullException("this._pointA");
            }
            if (this._pointB == null)
            {
                throw new ArgumentNullException("this._pointB");
            }

            #endregion

            if (this._pointB.Y < this._pointA.Y)
            {
                return false;
            }
            else if (this._pointB.X < this._pointA.X)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            /*
            if(pointB.X < pointA.X)
            {
                throw new ArgumentException("The coordinate X of point B cannot be lower than the point A");
            }
            if (pointB.Y < pointA.Y)
            {
                throw new ArgumentException("The coordinate Y of point B cannot be lower than the point A");
            }
            */

            #endregion

            this._pointA = pointA;
            this._pointB = pointB;

            // Calculating the point C
            this._pointC = new Point(pointB.X, pointA.Y);

            // Calculating the point D
            this._pointD = new Point(pointA.X, pointB.Y);
        }

        /// <summary>
        /// Checks whether the square have some intersect with the current
        /// </summary>
        /// <param name="square"></param>
        /// <returns></returns>
        public Boolean CheckIntersection(LogicalSquare square)
        {
            #region Entries validation
            
            if (square == null)
            {
                throw new ArgumentNullException("square");
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
            if (square.PointA == null)
            {
                throw new ArgumentNullException("square.PointA");
            }
            if (square.PointB == null)
            {
                throw new ArgumentNullException("square.PointB");
            }
            if (square.PointC == null)
            {
                throw new ArgumentNullException("square.PointC");
            }
            if (square.PointD == null)
            {
                throw new ArgumentNullException("square.PointD");
            }

            #endregion

            LogicalSquare squareA =
                this.GetSquareByZOrder(this, square, ZOrderEnum.Bottom);

            LogicalSquare squareB =
                this.GetSquareByZOrder(this, square, ZOrderEnum.Top);

            // It's the comparison for Point A of square
            bool innerComparisonA =
                (squareB.PointA.X <= squareA.PointC.X && squareB.PointA.Y >= squareA.PointC.Y) &&
                (squareB.PointA.X >= squareA.PointA.X && squareB.PointA.Y <= squareA.PointB.Y);

            // It's the comparison for Point D of square
            bool innerComparisonD =
                (squareB.PointD.X <= squareA.PointB.X && squareB.PointD.Y >= squareA.PointC.Y) &&
                (squareB.PointD.X >= squareA.PointD.X && squareB.PointD.Y <= squareA.PointB.Y);

            // It's the comparison for sabe point
            bool samePoint =
                (squareA.PointA.X == squareB.PointA.X && squareA.PointA.Y == squareB.PointA.Y) &&
                (squareA.PointB.X == squareB.PointB.X && squareA.PointB.Y == squareB.PointB.Y);

            return innerComparisonA || innerComparisonD || samePoint;
        }

        /// <summary>
        /// Determines which of squares represents the ZOrder assigned.
        /// </summary>
        private LogicalSquare GetSquareByZOrder(LogicalSquare squareA, LogicalSquare squareB, ZOrderEnum zorderEnum)
        {
            #region Entries validation
            
            if (squareA == null)
            {
                throw new ArgumentNullException("squareA");
            }
            if (squareB == null)
            {
                throw new ArgumentNullException("squareB");
            }
            if (squareA.PointA == null)
            {
                throw new ArgumentNullException("squareA.PointA");
            }
            if (squareB.PointA == null)
            {
                throw new ArgumentNullException("squareB.PointA");
            }

            #endregion

            int compareX = squareA.PointA.X.CompareTo(squareB.PointA.X);

            switch (zorderEnum)
            {
                case ZOrderEnum.Bottom:

                    if (compareX <= 0)
                    {
                        return squareA;
                    }
                    else
                    {
                        return squareB;
                    }

                case ZOrderEnum.Top:

                    if (compareX <= 0)
                    {
                        return squareB;
                    }
                    else
                    {
                        return squareA;
                    }

                default:
                    throw new NotSupportedException();
            }
        }
    }
}