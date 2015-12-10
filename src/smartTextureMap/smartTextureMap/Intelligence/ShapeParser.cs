
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
        /// It´s the context of transformation
        /// </summary>
        private ContextMap _contextMap;

        /// <summary>
        /// Creates an instance of object
        /// </summary>
        /// <param name="contextMap"></param>
        public ShapeParser(ContextMap contextMap)
        {
            this._contextMap = contextMap;
        }

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

            AxisEngine axisEngine = new AxisEngine(this._contextMap, startPoint, image);
            axisEngine.Run();

            foreach (var item in axisEngine.GetSquares())
            {
                retorno.Add(new Shape(item, image));
            }

            return retorno;
		}

        /// <summary>
        /// Returns the next point
        /// </summary>
        /// <param name="axisEngine"></param>
        /// <returns></returns>
        private static Point GetNextPoint(AxisEngine axisEngine)
        {
            #region Entries validation

            if (axisEngine == null)
            {
                throw new ArgumentNullException("axisEngine");
            }

            #endregion

            Point nextStart;
            if (axisEngine.DetectedSquare > 0)
            {
                nextStart =
                    axisEngine.GetSquares().LastOrDefault().PointC;
            }
            else
            {
                nextStart =
                    axisEngine.GetLenPosition();
            }

            return nextStart;
        }
    }
}