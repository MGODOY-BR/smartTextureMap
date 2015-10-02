
using smartTextureMap.Support;
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
		/// It´s the current position of sensor
		/// </summary>
		private Point _currentPosition;

        /// <summary>
        /// It´s the image being analysed
        /// </summary>
        private Picture _image;

        /// <summary>
        /// Creates an instance of an object
        /// </summary>
        /// <param name="image"></param>
        public Sensor(Picture image)
        {
            #region Entries validation
            
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            #endregion

            this._image = image;
        }

        /// <summary>
        /// Returns an sign about the identified point
        /// </summary>
        /// <returns></returns>
        public Boolean Check()
        {
            #region Entries validation
            
            if (this._image == null)
            {
                throw new ArgumentNullException("this._image");
            }

            if (this._currentPosition == null)
            {
                throw new ArgumentNullException("this._currentPosition");
            }

            #endregion

            return this._image.CheckBoundary(this._currentPosition);
        }

		/// <summary>
		/// Updates the sensor
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void Update(int x, int y)
        {
            if (this._currentPosition == null)
            {
                this._currentPosition = new Point(x, y);
            }
            else
            {
                this._currentPosition.X = x;
                this._currentPosition.Y = y;
            }
		}

		/// <summary>
		/// Gets the current point
		/// </summary>
		/// <returns></returns>
		public Point GetPoint() {
            return this._currentPosition;
		}

	}
}