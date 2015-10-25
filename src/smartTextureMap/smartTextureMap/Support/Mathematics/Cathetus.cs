
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
        /// Returns the end point
        /// </summary>
        public Point EndPoint
        {
            get
            {
                return _endPoint;
            }
        }

        /// <summary>
        /// Returns de start of point
        /// </summary>
        public Point StartPoint
        {
            get
            {
                return _startPoint;
            }
        }

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

            this._endPoint = endPoint.Clone() as Point;
            this._startPoint = startPoint.Clone() as Point;
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

        /// <summary>
        /// Gets the perpendicular interception point between the cathetus
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Point GetPerpendicularInterceptionPoint(Cathetus other)
        {
            #region Entries validation
        
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            if (this._startPoint == null)
            {
                throw new ArgumentNullException("this._startPoint");
            }
            if (this._endPoint == null)
            {
                throw new ArgumentNullException("this._endPoint");
            }
            if (other._startPoint == null)
            {
                throw new ArgumentNullException("other._startPoint");
            }
            if (other._endPoint == null)
            {
                throw new ArgumentNullException("other._endPoint");
            }
            if (this._startPoint.LooksLike(other._startPoint))
            {
                return this._startPoint.Clone() as Point;
            }
            if (this._endPoint.LooksLike(other._endPoint))
            {
                return this._endPoint.Clone() as Point;
            }
            if (!
                (((other._startPoint.X == other._endPoint.X) ||
                (other._startPoint.Y == other._endPoint.Y)) &&
                ((this._startPoint.X == this._endPoint.X) ||
                (this._startPoint.Y == this._endPoint.Y))))
            {
                throw new NotSupportedException(
                    "Just perpendicular cathethi are suported.");
            }
            if (!
                ((this._startPoint.Y >= other._startPoint.Y && this._endPoint.Y <= other._endPoint.Y) ||
                (other._startPoint.Y >= this._startPoint.Y && other._endPoint.Y <= this._endPoint.Y)))
            {
                throw new ArgumentOutOfRangeException("Point Y out of range");
            }
            if (!
                ((this._startPoint.X >= other._startPoint.X && this._endPoint.X <= other._endPoint.X) ||
                (other._startPoint.X >= this._startPoint.X && other._endPoint.X <= this._endPoint.X)))
            {
                throw new ArgumentOutOfRangeException("Point X out of range");
            }

            #endregion

            #region Vertical vector

            // other
            if (other._startPoint.X == other._endPoint.X)
            {
                return
                    new Point(
                        other._endPoint.X,
                        this._endPoint.Y);
            }
            // this
            if (this._startPoint.X == this._endPoint.X)
            {
                return
                    new Point(
                        this._endPoint.X,
                        other._endPoint.Y);
            }

            #endregion

            #region Horizontal vector

            // other
            if (other._startPoint.Y == other._endPoint.Y)
            {
                return
                    new Point(
                        this._startPoint.X,
                        other._endPoint.Y);
            }
            // this
            if (this._startPoint.Y == this._endPoint.Y)
            {
                return
                    new Point(
                        other._startPoint.X,
                        this._endPoint.Y);
            }

            #endregion

            throw new ArgumentOutOfRangeException("There no common point among the catheti");
        }
    }
}