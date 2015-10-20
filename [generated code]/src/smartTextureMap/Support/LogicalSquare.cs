
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a logical square contained inside of the shape, used to simplify the form of the shape
	/// </summary>
	public class LogicalSquare {

		/// <summary>
		/// Represents a logical square contained inside of the shape, used to simplify the form of the shape
		/// </summary>
		public LogicalSquare() {
		}

		/// <summary>
		/// It´s the calculated pointC
		/// </summary>
		private Point _pointC;

		/// <summary>
		/// It´s the calculated pointD
		/// </summary>
		private Point _pointD;

		/// <summary>
		/// It's the first coordinate of the logical square
		/// </summary>
		private Point _pointA;

		/// <summary>
		/// Represents the second coordinate of the logical square
		/// </summary>
		private Point _pointB;


		/// <summary>
		/// Verifies whether the point is inside of the logical square
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		public Boolean CheckInside(Point point) {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Creates a instance of object
		/// </summary>
		/// <param name="pointA"></param>
		/// <param name="pointB"></param>
		public void LogicalSquare(Point pointA, Point pointB) {
			// TODO implement here
		}

		/// <summary>
		/// Checks whether the square have some intersect with the current
		/// </summary>
		/// <param name="square"></param>
		/// <returns></returns>
		public Boolean CheckIntersection(LogicalSquare square) {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Checks if the other is vertically adjacent to this.
		/// </summary>
		/// <param name="square"></param>
		/// <returns></returns>
		public Boolean CheckVerticalAdjacent(LogicalSquare square) {
			// TODO implement here
			return null;
		}

	}
}