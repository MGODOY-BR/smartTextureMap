
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Intelligence.Lens{
	/// <summary>
	/// Represents an engine of moviment of shape len through the polygon
	/// </summary>
	public class AxisEngine {

		/// <summary>
		/// Represents an engine of moviment of shape len through the polygon
		/// </summary>
		public AxisEngine() {
		}

		/// <summary>
		/// It's the len which detects the points in picture
		/// </summary>
		private ShapeLen _len;

		/// <summary>
		/// 
		/// </summary>
		private Point _startPoint;

		/// <summary>
		/// It's a list of detected squares
		/// </summary>
		private HashSet<LogicalSquare> _squareList;

		/// <summary>
		/// It's the image beying analysed
		/// </summary>
		private Picture _image;

		/// <summary>
		/// Resets the position of len
		/// </summary>
		public void Reset() {
			// TODO implement here
		}

		/// <summary>
		/// Creates an instance of object
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="image"></param>
		public void AxisEngine(Point startPoint, Picture image) {
			// TODO implement here
		}

		/// <summary>
		/// Gets the generated squares
		/// </summary>
		/// <returns></returns>
		public HashSet<LogicalSquare> GetSquares() {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Aligns the axis in position
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void GoTo(int x, int y) {
			// TODO implement here
		}

		/// <summary>
		/// Runs the engine to looking for the squares
		/// </summary>
		public void Run() {
			// TODO implement here
		}

		/// <summary>
		/// Gets lastest len position
		/// </summary>
		/// <returns></returns>
		public Point GetLenPosition() {
			// TODO implement here
			return null;
		}

	}
}