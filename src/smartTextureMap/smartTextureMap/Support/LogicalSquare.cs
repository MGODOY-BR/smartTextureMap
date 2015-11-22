
using smartTextureMap.Support.Mathematics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a logical square contained inside of the shape, used to simplify the form of the shape
	/// </summary>
	public class LogicalSquare : IComparable<LogicalSquare>, IEquatable<LogicalSquare>
    {
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
            set
            {
                this._pointC = value;
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
            set
            {
                this._pointD = value;
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
            set
            {
                this._pointA = value;
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
            set
            {
                this._pointB = value;
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
                point.X >= this._pointA.X && point.X <= this._pointB.X &&
                point.Y >= this._pointA.Y && point.Y <= this._pointB.Y;
        }

        /// <summary>
        /// Verifies whether the point is inside of the logical square
        /// </summary>
        public Boolean CheckInside(LogicalSquare other)
        {
            #region Entries validation
            
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            #endregion

            return
                this.CheckInside(other.PointA) ||
                this.CheckInside(other.PointB) ||
                this.CheckInside(other.PointC) ||
                this.CheckInside(other.PointD);
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
            /*
            else if (this._pointD.X * this._pointA.X < 20)
            {
                return false;
            }
            else if (this._pointD.Y * this._pointA.Y < 20)
            {
                return false;
            }
            */
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

            double minXA = new Interval(this.PointA.X, 5D).GetMinValue();
            double maxXA = new Interval(this.PointA.X, 5D).GetMaxValue();
            double minYA = new Interval(this.PointA.Y, 5D).GetMinValue();
            double maxYA = new Interval(this.PointA.Y, 5D).GetMaxValue();

            double minXB = new Interval(this.PointB.X, 5D).GetMinValue();
            double maxXB = new Interval(this.PointB.X, 5D).GetMaxValue();
            double minYB = new Interval(this.PointB.Y, 5D).GetMinValue();
            double maxYB = new Interval(this.PointB.Y, 5D).GetMaxValue();

            commonPoint =
                (square.PointA.X >= minXA && square.PointA.X <= maxXA) &&
                (square.PointA.Y >= minYA && square.PointA.Y <= maxYA);

            commonPoint |=
                (square.PointB.X >= minXB && square.PointB.X <= maxXB) &&
                (square.PointB.Y >= minYB && square.PointB.Y <= maxYB);

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
                !(this._pointB.LooksLikeByY(square._pointA) || this._pointA.LooksLikeByY(square._pointB)))
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

            if (this._pointD.LooksLike(square.PointC))
            {
                selfCathetus = this._pointD.Y - this._pointA.Y;
                otherCathetus = square._pointC.X - square._pointA.X;
            }
            else if (this._pointB.LooksLike(square.PointA))
            {
                selfCathetus = this._pointB.Y - this._pointC.Y;
                otherCathetus = square._pointC.X - square._pointA.X;
            }
            else if (this._pointC.LooksLike(square.PointD))
            {
                selfCathetus = this._pointD.Y - this._pointA.Y;
                otherCathetus = square._pointC.X - square._pointA.X;
            }
            else if (this._pointA.LooksLike(square.PointB))
            {
                selfCathetus = this._pointB.Y - this._pointC.Y;
                otherCathetus = square._pointC.X - square._pointA.X;
            }

            return (int)Math.Round(
                Math.Sqrt(
                (selfCathetus * selfCathetus) + (otherCathetus * otherCathetus)));
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

        public int CompareTo(LogicalSquare other)
        {
            #region Entries validation
            
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            #endregion

            Interval thisIntervalX = new Interval(this.PointA.X, 5);
            Interval thisIntervalY = new Interval(this.PointA.Y, 5);
            Interval otherIntervalX = new Interval(other.PointA.X, 5);
            Interval otherIntervalY = new Interval(other.PointA.Y, 5);

            if (this.PointA.Y < other.PointA.Y)
            {
                return -1;
            }
            if (thisIntervalY.Equals(otherIntervalY))
            {
                return this.PointA.X.CompareTo(other.PointA.X);
            }
            if (thisIntervalY.Equals(otherIntervalY) && thisIntervalX.Equals(otherIntervalX))
            {
                return 0;
            }
            else
            {
                return this.PointA.Y.CompareTo(other.PointA.Y);
            }
        }

        public bool Equals(LogicalSquare other)
        {
            #region Entries validation

            if (other == null)
            {
                return false;
            }

            #endregion

            return this.ToString() == other.ToString();
        }
    }
}