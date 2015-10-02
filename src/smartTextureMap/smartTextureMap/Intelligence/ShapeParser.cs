
using smartTextureMap.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Intelligence{
	/// <summary>
	/// Discovers shapes
	/// </summary>
	public class ShapeParser {

		/// <summary>
		/// It's the current Point A of analysis
		/// </summary>
		private Point _currentPointA;

		/// <summary>
		/// It´s the current PointB of analysis
		/// </summary>
		private Point _currentPointB;

		/// <summary>
		/// Begins the analasys
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="image"></param>
		/// <returns></returns>
		public List<Shape> Discover(Point startPoint, Picture image)
        {
            #region Entries validation
            
            if (startPoint == null)
            {
                throw new ArgumentNullException("startPoint");
            }
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            #endregion

            List<Shape> shapeList = new List<Shape>();
            Point pointA = null;
            Point pointB = null;
            ShapeFunction function = ShapeFunction.WaitingToBegin;
            int resumeX = 0;
            int resumeY = 0;

            for (int x = resumeX; x < image.Width; x++)
            {
                for (int y = resumeY; y < image.Height; y++)
                {
                    if (function == ShapeFunction.SearchingToEnd)
                    {
                        resumeY++;
                    }

                    Point point = new Point(x, y);

                    // Searching for the beginning of shape
                    if (function == ShapeFunction.WaitingToBegin)
                    {
                        #region Entries validation

                        if (!image.CheckBoundary(point))
                        {
                            continue;
                        }

                        #endregion

                        pointA = new Point(x, y);
                        function = ShapeFunction.SearchingToEnd;
                        break;
                    }
                    // Seaching for the ending of shape
                    if (function == ShapeFunction.SearchingToEnd)
                    {
                        #region Entries validation

                        if (pointA == null)
                        {
                            throw new ArgumentNullException("pointA");
                        }
                        if (x <= pointA.X) // Ignoring previous X from the point A
                        {
                            continue;
                        }
                        if (image.CheckBoundary(point))
                        {
                            Point pseudoHPoint = new Point(x + 1, y);
                            if (image.CheckBoundary(pseudoHPoint))
                            {
                                continue;
                            }
                        }

                        #endregion

                        pointB = new Point(x, y);

                        // Closing the square
                        LogicalSquare square = new LogicalSquare(pointA, pointB);
                        Shape shape = new Shape(square, image);
                        shapeList.Add(shape);

                        // Preparing next searching for a new shape
                        function = ShapeFunction.WaitingToBegin;
                        // The beginning for the next shape is the ending of this one.
                        resumeX = pointB.X;
                        resumeY = pointA.Y;
                        break;
                    }
                }
            }

            this._currentPointA = pointA;
            this._currentPointB = pointB;

            return shapeList;
		}

		/// <summary>
		/// Get the last coordinate A analysed.
		/// </summary>
		/// <returns></returns>
		public Point GetLastCoordinateA() {
            return this._currentPointA;
        }

        /// <summary>
        /// Get the last coordinate B analysed
        /// </summary>
        /// <returns></returns>
        public Point GetLastCoordinateB() {
            return this._currentPointB;
		}

	}
}