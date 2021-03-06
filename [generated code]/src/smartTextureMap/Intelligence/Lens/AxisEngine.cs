
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
		/// It´s the context of transformation
		/// </summary>
		private ContextMap _contextMap;

		/// <summary>
		/// Resets the position of len
		/// </summary>
		public void Reset() {
			// TODO implement here
		}

		/// <summary>
		/// Creates an instance of object
		/// </summary>
		/// <param name="contextMap"> </param>
		/// <param name="startPoint"></param>
		/// <param name="image"></param>
		public void AxisEngine(ContextMap contextMap , Point startPoint, Picture image) {
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

		/// <summary>
		/// Indica se a análise chegou ao fim do arquivo
		/// </summary>
		/// <returns></returns>
		public Boolean EOF() {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Gets a logical square from picture
		/// </summary>
		/// <param name="len"></param>
		/// <param name="startX"></param>
		/// <param name="startY"></param>
		/// <returns></returns>
		private LogicalSquare ScanSquare(ShapeLen len, int startX, int startY) {
			// TODO implement here
			return null;
		}

	}
}