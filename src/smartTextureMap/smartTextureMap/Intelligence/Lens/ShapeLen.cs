
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
        public const int SENSOR_DISTANCE = 1;

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
        /// It´s the sensor of top
        /// </summary>
        private Sensor _topSensor;

        /// <summary>
        /// It´s the left sensor
        /// </summary>
        private Sensor _leftSensor;

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
                return false;
            }
            if (y > this._image.Height)
            {
                return false;
            }
            if (x < 0)
            {
                throw new ArgumentException("The axis X can't be lower then 0");
            }
            if (y < 0)
            {
                throw new ArgumentException("The axis Y can't be lower then 0");
            }

            #endregion

            this.UpdateSensor(x, y);

            return this.CheckBorder();
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
        /// Checks if the current position is considered a bottom boundary.
        /// </summary>
        /// <returns></returns>
        public Boolean CheckBottomBoundary()
        {
            #region Entries validation

            if (this._bellowSensor == null)
            {
                throw new ArgumentNullException("this._bellowSensor");
            }
            if (this._currentSensor == null)
            {
                throw new ArgumentNullException("this._currentSensor");
            }

            #endregion

            return this._currentSensor.Check() && !this._bellowSensor.Check();
        }

        /// <summary>
        /// Check if the right position is a boundary
        /// </summary>
        /// <returns></returns>
        public Boolean CheckRightBoundary()
        {
            #region Entries validation

            if (this._currentSensor == null)
            {
                throw new ArgumentNullException("this._currentSensor");
            }
            if (this._nextSensor == null)
            {
                throw new ArgumentNullException("this._nextSensor");
            }

            #endregion

            // return (this._currentSensor.Check() && (!this.CheckNearRightSensor() || !this._leftSensor.Check()));
            return this._currentSensor.Check() && !this._nextSensor.Check();
            // return (this._currentSensor.Check() && (!this._nextSensor.Check() || !this._leftSensor.Check()));
        }

        /// <summary>
        /// Checks if the right sensor is checked, in a general sense
        /// </summary>
        /// <returns></returns>
        private bool CheckNearRightSensor()
        {
            var point = (Point)this._nextSensor.GetPoint().Clone();

            for (int i = 0; i < 2; i++)
            {
                this._nextSensor.Update(
                    point.X + i,
                    point.Y);

                if (!this._nextSensor.Check())
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks whether the left boundary has detected at current sensor position.
        /// </summary>
        /// <returns></returns>
        public Boolean CheckLeftBoundary()
        {
            #region Entries validation

            if (this._currentSensor == null)
            {
                throw new ArgumentNullException("this._currentSensor");
            }
            if (this._leftSensor == null)
            {
                throw new ArgumentNullException("this._leftSensor");
            }

            #endregion

            return this._currentSensor.Check() && !this._leftSensor.Check();
        }

        /// <summary>
        /// Verifies whether the current position is a corner of polygon
        /// </summary>
        public Boolean CheckBoundaryCorner()
        {
            return this.CheckBottomBoundary() && this.CheckRightBoundary();
        }

        /// <summary>
        /// Positions the sensors
        /// </summary>
        public void UpdateSensor(int x, int y)
        {
            #region Entries validation

            if (this._nextSensor == null)
            {
                throw new ArgumentNullException("this._nextSensor");
            }
            if (this._bellowSensor == null)
            {
                throw new ArgumentNullException("this._bellowSensor");
            }
            if (this._bellowSensor == null)
            {
                throw new ArgumentNullException("this._bellowSensor");
            }
            if (this._topSensor == null)
            {
                throw new ArgumentNullException("this._topSensor");
            }
            if (this._leftSensor == null)
            {
                throw new ArgumentNullException("this._leftSensor");
            }

            #endregion

            this._currentSensor.Update(x, y);
            this._bellowSensor.Update(x, y + SENSOR_DISTANCE);
            this._nextSensor.Update(x + SENSOR_DISTANCE, y);
            this._leftSensor.Update(x - SENSOR_DISTANCE, y);
            this._topSensor.Update(x, y - SENSOR_DISTANCE);

            this._lastPoint = new Point(x, y);
        }

        /// <summary>
        /// Gets the last position
        /// </summary>
        /// <returns></returns>
        public Point GetLastPosition()
        {
            return this._lastPoint;
        }

        /// <summary>
        /// Checks whether the sensor rules identify a border
        /// </summary>
        /// <returns></returns>
        private Boolean CheckBorder()
        {
            #region Entries validation
            
            if (this._currentSensor == null)
            {
                throw new ArgumentNullException("this._currentSensor");
            }

            #endregion

            return
                this._currentSensor.Check();
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
            this._topSensor = new Sensor(image);
            this._leftSensor = new Sensor(image);

            this.UpdateSensor(0, 0);
        }
    }
}