
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
		/// Representes a cathetus of a square
		/// </summary>
		public Cathetus() {
		}

		/// <summary>
		/// 
		/// </summary>
		private Point _startPoint;

		/// <summary>
		/// 
		/// </summary>
		private Point _endPoint;



		/// <summary>
		/// Creates an instance of an object
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="endPoint"></param>
		public void Cathetus(Point startPoint, Point endPoint) {
			// TODO implement here
		}

		/// <summary>
		/// Get the size between the points
		/// </summary>
		/// <returns></returns>
		public double GetSize() {
			// TODO implement here
			return 0.0D;
		}

		/// <summary>
		/// Gets the perpendicular interception point between the cathetus
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public Point GetPerpendicularInterceptionPoint(Cathetus other) {
			// TODO implement here
			return null;
		}

	}
}