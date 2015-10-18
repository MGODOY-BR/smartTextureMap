
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a cartesyan coordinate.
	/// </summary>
	public class Point : IEquatable<Point> {

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
                    throw new NotSupportedException();
            }
        }

        public bool Equals(Point other)
        {
            #region Entries validation
            
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            #endregion

            return this.X == other.X && this.Y == other.Y;
        }
    }
}