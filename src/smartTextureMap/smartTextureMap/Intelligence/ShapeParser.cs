
using smartTextureMap.Intelligence.Lens;
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

            #endregion

            List<Shape> retorno = new List<Shape>();

            AxisEngine axisEngine = new AxisEngine(startPoint, image);
            while (!axisEngine.EOF())
            {
                axisEngine.Run();

                List<LogicalSquare> squareList = axisEngine.GetSquares();
                if (squareList.Count == 0)
                {
                    break;
                }

                Point nextStart = squareList.LastOrDefault().PointC;

                axisEngine.GoTo(
                    nextStart.X, nextStart.Y);
            }

            foreach (var item in axisEngine.GetSquares())
            {
                retorno.Add(new Shape(item, image));
            }

            return retorno;
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