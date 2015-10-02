
using smartTextureMap.Support;
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
        /// It's the distance of position of sensors
        /// </summary>
        private const int SENSOR_DISTANCE = 1;

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
		/// Reads the point and returns a boolean informing if the point it is a boundary of a polygon
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public Boolean Read(int x, int y)
        {
            #region Entries validation
            
            if (this._image == null)
            {
                throw new ArgumentNullException("this._image");
            }
            if (x > this._image.Width)
            {
                throw new ArgumentException("The axis X can't be higher then the width of image");
            }
            if (y > this._image.Height)
            {
                throw new ArgumentException("The axis Y can't be higher then the height of image");
            }
            if (x < 1)
            {
                throw new ArgumentException("The axis X can't be lower then 0");
            }
            if (y < 1)
            {
                throw new ArgumentException("The axis Y can't be lower then 0");
            }

            #endregion

            this.PositionSensors(x, y);

            return 
                this._currentSensor.Check() ||
                this._nextSensor.Check() ||
                this._bellowSensor.Check();
        }

        /// <summary>
        /// Reset the len settings
        /// </summary>
        public void Reset()
        {
            this.SetSensors(this._image);
		}

		/// <summary>
		/// Creates an instance of the object
		/// </summary>
		/// <param name="image"></param>
		public ShapeLen(Picture image)
        {
            #region Entries validation
            
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            #endregion

            this._image = image;

            this.SetSensors(image);
        }

        /// <summary>
        /// Set up the sensors
        /// </summary>
        private void SetSensors(Picture image)
        {
            #region Entries validation

            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            #endregion

            this._currentSensor = new Sensor(image);
            this._bellowSensor = new Sensor(image);
            this._nextSensor = new Sensor(image);

            this.PositionSensors(0, 0);
        }

        /// <summary>
        /// Positions the sensors
        /// </summary>
        private void PositionSensors(int x, int y)
        {
            this._currentSensor.Update(x, y);
            this._bellowSensor.Update(x, y + SENSOR_DISTANCE);
            this._nextSensor.Update(x + SENSOR_DISTANCE, y);

            this._lastPoint = new Point(x, y);
        }
    }
}