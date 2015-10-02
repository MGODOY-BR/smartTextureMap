
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Intelligence.Lens{
	/// <summary>
	/// Represents a lens used to detect points.
	/// </summary>
	public class Sensor {

		/// <summary>
		/// Represents a lens used to detect points.
		/// </summary>
		public Sensor() {
		}

		/// <summary>
		/// It´s the current position of sensor
		/// </summary>
		private Point _currentPosition;

		/// <summary>
		/// Returns an sign about the identfied point
		/// </summary>
		/// <returns></returns>
		public Boolean Check() {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Updates the sensor
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void Update(int x, int y) {
			// TODO implement here
		}

		/// <summary>
		/// Gets the current point
		/// </summary>
		/// <returns></returns>
		public Point GetPoint() {
			// TODO implement here
			return null;
		}

	}
}