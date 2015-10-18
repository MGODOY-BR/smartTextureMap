
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
            else if ((this._pointB.X * this._pointB.Y) - (this._pointA.X * this._pointA.Y) < 20)
            {
                return false;
            }
            else if (this._pointD.X * this._pointA.X < 20)
            {
                return false;
            }
            else if (this._pointD.Y * this._pointA.Y < 20)
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

            // Checking common points
            bool commonPoint = false;

            for (int x = square.PointA.X; x < square.PointB.X; x++)
            {
                for (int y = square.PointA.Y; y < square.PointB.Y; y++)
                {
                    commonPoint |= this.CheckInside(new Point(x, y));
                }
            }

            return commonPoint;

        }

        /// <summary>
        /// Checks if the other is vertically adjacent to this.
        /// </summary>
        /// <param name="square"></param>
        /// <returns></returns>
        public Boolean CheckVerticalAdjacent(LogicalSquare square)
        {
            #region Entries validation
            
            if (square == null)
            {
                throw new ArgumentNullException("square");
            }
            if (
                !(
                (this._pointB.Y == square._pointA.Y) ||
                (this._pointA.Y == square._pointB.Y))
                )
            {
                return false;
            }

            #endregion

            var leftPoint =
                Point.GetTheMost(
                    this._pointA, this._pointD, OrderEnum.AtLeft);

            var rightPoint =
                Point.GetTheMost(
                    this._pointC, this._pointB, OrderEnum.AtRight);

            var leftPointSquare =
                Point.GetTheMost(
                    square._pointA, square._pointD, OrderEnum.AtLeft);

            var rightPointSquare =
                Point.GetTheMost(
                    square._pointC, square._pointB, OrderEnum.AtRight);

            if (leftPoint.X <= leftPointSquare.X && rightPoint.X >= rightPointSquare.X)
            {
                return true;
            }
            else if (leftPointSquare.X <= leftPoint.X && rightPointSquare.X >= rightPoint.X)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Calculates the hypotenuse between Point A of 2 the current and another adjacent logical square
        /// </summary>
        /// <param name="square"></param>
        /// <returns></returns>
        public int CalculateExternalHypotenuse(LogicalSquare square)
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
            if (this._pointD == null)
            {
                throw new ArgumentNullException("this._pointD");
            }
            if (square._pointA == null)
            {
                throw new ArgumentNullException("square._pointA");
            }
            if (square._pointC == null)
            {
                throw new ArgumentNullException("square._pointC");
            }

            #endregion

            int selfCathetus = 0;
            int otherCathetus = 0;

            if (this._pointD.Equals(square.PointC))
            {
                selfCathetus = this._pointD.Y - this._pointA.Y;
                otherCathetus = square._pointC.X - square._pointA.X;
            }
            else if (this._pointB.Equals(square.PointA))
            {
                selfCathetus = this._pointB.Y - this._pointC.Y;
                otherCathetus = square._pointC.X - square._pointA.X;
            }

           return (int)Math.Truncate(
                Math.Sqrt(
                (selfCathetus * selfCathetus) + (otherCathetus + otherCathetus)));
        }

        public override string ToString()
        {
            #region Entries validation

            if (this._pointA == null)
            {
                return "LogicalSquare with Point A missed";
            }
            if (this._pointB == null)
            {
                return "LogicalSquare with Point B missed";
            }
            if (this._pointC == null)
            {
                return "LogicalSquare with Point C missed";
            }
            if (this._pointD == null)
            {
                return "LogicalSquare with Point D missed";
            }

            #endregion

            return String.Format(
                "Square A[x = {0}, y = {1}], B[x = {2}, y = {3}], C[x = {4}, y = {5}], D[x = {6}, y = {7}]",
                this._pointA.X,
                this._pointA.Y,
                this._pointB.X,
                this._pointB.Y,
                this._pointC.X,
                this._pointC.Y,
                this._pointD.X,
                this._pointD.Y);
        }

        /// <summary>
        /// Determines which of squares represents the ZOrder assigned.
        /// </summary>
        private LogicalSquare GetSquareByOrder(LogicalSquare squareA, LogicalSquare squareB, OrderEnum zorderEnum)
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

            switch (zorderEnum)
            {
                case OrderEnum.Bottom:

                    if (squareA.PointA.Y > squareB.PointA.Y)
                    {
                        return squareA;
                    }
                    else
                    {
                        return squareB;
                    }

                case OrderEnum.Top:

                    if (squareA.PointA.Y < squareB.PointA.Y)
                    {
                        return squareB;
                    }
                    else
                    {
                        return squareA;
                    }
                case OrderEnum.AtLeft:

                    if (squareA.PointA.X < squareB.PointA.X)
                    {
                        return squareA;
                    }
                    else
                    {
                        return squareB;
                    }

                case OrderEnum.AtRight:

                    if (squareA.PointA.X > squareB.PointA.X)
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