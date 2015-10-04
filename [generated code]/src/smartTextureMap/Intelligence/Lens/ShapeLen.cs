
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Intelligence.Lens{
	/// <summary>
	/// Represents a len, like existing in CD ROM, to detect points.
	/// </summary>
	public class ShapeLen {

		/// <summary>
		/// Represents a len, like existing in CD ROM, to detect points.
		/// </summary>
		public ShapeLen() {
		}

		/// <summary>
		/// It's the sensor positioned in current shape
		/// </summary>
		private Sensor _currentSensor;

		/// <summary>
		/// It's the sensor positioned in right of sensor
		/// </summary>
		private Sensor _nextSensor;

		/// <summary>
		/// It´s the sensor positioned bellow of the len.
		/// </summary>
		private Sensor _bellowSensor;

		/// <summary>
		/// It's the last point detected
		/// </summary>
		private Point _lastPoint;


		/// <summary>
		/// It's the image to be analyse
		/// </summary>
		private Picture _image;

		/// <summary>
		/// It´s the sensor of top
		/// </summary>
		private Sensor _topSensor;

		/// <summary>
		/// It´s the left sensor
		/// </summary>
		private Sensor _leftSensor;

		/// <summary>
		/// Reads the point and returns a boolean informing if the point it is a boundary of a polygon
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public Boolean Read(int x, int y) {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Reset the len settings
		/// </summary>
		public void Reset() {
			// TODO implement here
		}

		/// <summary>
		/// Creates an instance of the object
		/// </summary>
		/// <param name="image"></param>
		public void ShapeLen(Picture image) {
			// TODO implement here
		}

		/// <summary>
		/// Checks if the current position is considered a bottom boundary.
		/// </summary>
		/// <returns></returns>
		public Boolean CheckBottomBoundary() {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Check if the right position is a boundary
		/// </summary>
		/// <returns></returns>
		public Boolean CheckRightBoundary() {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Updates the position of sensors
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void UpdateSensor(int x, int y) {
			// TODO implement here
		}

		/// <summary>
		/// Verifies whether the current position is a corner of polygon
		/// </summary>
		/// <returns></returns>
		public Boolean CheckBondaryCorner() {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Checks whether the point it´s considered a start corner
		/// </summary>
		/// <returns></returns>
		public Boolean CheckStartCorner() {
			// TODO implement here
			return null;
		}

	}
}