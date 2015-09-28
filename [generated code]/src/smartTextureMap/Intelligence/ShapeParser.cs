
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
		/// Discovers shapes
		/// </summary>
		public ShapeParser() {
		}

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
		public HashSet<Shape> Discover(Point startPoint, Picture image) {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Get the last coordinate A analysed.
		/// </summary>
		/// <returns></returns>
		public Point GetLastCoordinateA() {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Get the last coordinate B analysed
		/// </summary>
		/// <returns></returns>
		public Point GetLastCoordinateB() {
			// TODO implement here
			return null;
		}

	}
}