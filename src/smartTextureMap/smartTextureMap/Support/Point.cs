
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a cartesyan coordinate.
	/// </summary>
	public class Point {

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
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="zOrderEnum"></param>
        public static Point GetTheMost(Point pointA, Point pointB, ZOrderEnum zOrderEnum)
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

            #endregion

            switch (zOrderEnum)
            {
                case ZOrderEnum.Top:

                    return (pointA.Y < pointB.Y) ? pointA : pointB;

                case ZOrderEnum.Bottom:

                    return (pointA.Y > pointB.Y) ? pointA : pointB;

                case ZOrderEnum.AtRight:

                    return (pointA.X > pointB.X) ? pointA : pointB;

                case ZOrderEnum.AtLeft:

                    return (pointA.X < pointB.X) ? pointA : pointB;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}