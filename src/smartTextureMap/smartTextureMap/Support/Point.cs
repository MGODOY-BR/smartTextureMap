
using smartTextureMap.Support.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a cartesyan coordinate.
	/// </summary>
	public class Point : IEquatable<Point>, ICloneable, IComparable<Point> {

        /// <summary>
        /// It's the tolerance between the point recognize.
        /// </summary>
        private const int TOLERANCE = 5;

        /// <summary>
        /// Absciss
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Ordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Creates a instance of object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets the most relative point
        /// </summary>
        public static Point GetTheMost(Point point1, Point point2, OrderEnum orderEnum)
        {
            #region Entries validation

            if (point1 == null)
            {
                throw new ArgumentNullException("point1");
            }
            if (point2 == null)
            {
                throw new ArgumentNullException("point2");
            }

            #endregion

            switch (orderEnum)
            {
                case OrderEnum.Top:

                    return (point1.Y < point2.Y) ? point1 : point2;

                case OrderEnum.Bottom:

                    return (point1.Y > point2.Y) ? point1 : point2;

                case OrderEnum.AtRight:

                    return (point1.X > point2.X) ? point1 : point2;

                case OrderEnum.AtLeft:

                    return (point1.X < point2.X) ? point1 : point2;

                default:
                    throw new NotSupportedException("The specified order is not supported");
            }
        }

        public bool Equals(Point other)
        {
            #region Entries validation
            
            if (other == null)
            {
                return false;
            }

            #endregion

            /*
            Interval thisIntervalX = new Interval(this.X, TOLERANCE);
            Interval thisIntervalY = new Interval(this.Y, TOLERANCE);
            Interval otherIntervalX = new Interval(other.X, TOLERANCE);
            Interval otherIntervalY = new Interval(other.Y, TOLERANCE);

            return thisIntervalX.Equals(otherIntervalX) && thisIntervalY.Equals(otherIntervalY);
            */

            return this.X == other.X && this.Y == other.Y;
        }

        /// <summary>
        /// Gets an indicator informing whether the points are almost similar.
        /// </summary>
        public bool LooksLike(Point other)
        {
            #region Entries validation

            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            if (this.Equals(other))
            {
                return true;
            }

            #endregion

            return LooksLikeByX(other) && LooksLikeByY(other);
        }

        /// <summary>
        /// Gets an indicator informing whether the points are almost similar by Y.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool LooksLikeByY(Point other)
        {
            #region Entries validation

            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            #endregion
            /*
            int minY = other.Y - TOLERANCE;
            int maxY = other.Y + TOLERANCE;
            return (this.Y >= minY && this.Y <= maxY);
            */

            Interval interval = new Interval(other.Y, TOLERANCE);
            int minY = (int)interval.GetMinValue();
            int maxY = (int)interval.GetMaxValue();
            return (this.Y >= minY && this.Y <= maxY);
        }

        /// <summary>
        /// Gets an indicator informing whether the points are almost similar by X.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool LooksLikeByX(Point other)
        {
            #region Entries validation

            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            #endregion

            /*
            int minX = other.X - TOLERANCE;
            int maxX = other.X + TOLERANCE;
            return (this.X >= minX && this.X <= maxX);
            */

            Interval interval = new Interval(other.X, TOLERANCE);
            int minX = (int)interval.GetMinValue();
            int maxX = (int)interval.GetMaxValue();
            return (this.X >= minX && this.X <= maxX);
        }

        /// <summary>
        /// Returns the current instance whether the another is similar. Otherwise, returns the other.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Point GetSelfOrSimilar(Point other)
        {
            #region Entries validation

            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            #endregion

            if (this.LooksLike(other))
            {
                return this;
            }
            else
            {
                return other;
            }
        }

        public object Clone()
        {
            return new Point(this.X, this.Y);
        }

        public override string ToString()
        {
            return String.Format("X = {0}, Y = {1}", this.X, this.Y);
        }

        public int CompareTo(Point other)
        {
            #region Entries validation

            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            #endregion

            if (this.Y == other.Y)
            {
                return this.X.CompareTo(other.X);
            }
            else
            {
                return this.Y.CompareTo(other.Y);
            }
        }
    }
}