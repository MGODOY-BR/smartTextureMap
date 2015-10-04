
using smartTextureMap.Support;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace smartTextureMap.Intelligence.Lens{
	/// <summary>
	/// Represents an engine of moviment of shape len through the polygon
	/// </summary>
	public class AxisEngine {

        /// <summary>
        /// Indica se a an�lise chegou ao fim do arquivo
        /// </summary>
        private Boolean _eof;

		/// <summary>
		/// It's the len which detects the points in picture
		/// </summary>
		private ShapeLen _len;

		/// <summary>
		/// It's the start point
		/// </summary>
		private Support.Point _startPoint;

		/// <summary>
		/// It's a list of detected squares
		/// </summary>
		private List<LogicalSquare> _squareList = new List<LogicalSquare>();

		/// <summary>
		/// It's the image beying analysed
		/// </summary>
		private Picture _image;

        /// <summary>
        /// Resets the position of len
        /// </summary>
        public void Reset()
        {
            #region Entries validation
            
            if (this._len == null)
            {
                throw new ArgumentNullException("this._len");
            }
            if (this._squareList == null)
            {
                throw new ArgumentNullException("this._squareList");
            }

            #endregion

            this._len.Reset();
            this._squareList.Clear();
            this._eof = false;
        }

        /// <summary>
        /// Creates an instance of object
        /// </summary>
        /// <param name="image"></param>
        public AxisEngine(Picture image)
        {
            #region Entries validation

            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            #endregion

            this._startPoint = new Support.Point(0, 0);
            this._image = image;
            this._len = new ShapeLen(image);
        }

        /// <summary>
        /// Creates an instance of object
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="image"></param>
        public AxisEngine(Support.Point startPoint, Picture image)
        {
            #region Entries validation
            
            if (startPoint == null)
            {
                throw new ArgumentNullException("startPoint");
            }
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            #endregion

            this._startPoint = startPoint;
            this._image = image;
            this._len = new ShapeLen(image);
        }

        /// <summary>
        /// Gets the generated squares
        /// </summary>
        /// <returns></returns>
        public List<LogicalSquare> GetSquares()
        {
            return this._squareList;
		}

		/// <summary>
		/// Aligns the axis in position
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void GoTo(int x, int y)
        {
            #region Entries validation
            
            if (this._len == null)
            {
                throw new ArgumentNullException("this._len");
            }

            #endregion

            this._len.UpdateSensor(x, y);
            this._startPoint.X = x;
            this._startPoint.Y = y;
        }

		/// <summary>
		/// Runs the engine to looking for the squares
		/// </summary>
		public void Run()
        {
            #region Entries validation
            
            if (this._startPoint == null)
            {
                throw new ArgumentNullException("this._startPoint");
            }
            if (this._len == null)
            {
                throw new ArgumentNullException("this._len");
            }

            #endregion

            Support.Point pointA = null;
            Support.Point pointB = null;

            int startX = this._startPoint.X;
            int startY = this._startPoint.Y;

            for (int y = startY; y < this._image.Height - 1; y += ShapeLen.SENSOR_DISTANCE)
            {
                for (int x = startX; x < this._image.Width - 1; x += ShapeLen.SENSOR_DISTANCE)
                {
                    bool bondary = this._len.Read(x, y);

                    if (bondary)
                    {
                        if (pointA == null)
                        {
                            pointA = this._len.GetLastPosition();
                            startX = pointA.X + ShapeLen.SENSOR_DISTANCE;
                            x = startX;
                        }
                        else if (this._len.CheckBoundaryCorner())
                        {
                            pointB = this._len.GetLastPosition();

                            this._squareList.Add(
                                new LogicalSquare(pointA, pointB));

                            return;
                        }
                    }
                }
            }

            this._eof = true;
        }

		/// <summary>
		/// Gets lastest len position
		/// </summary>
		/// <returns></returns>
		public Support.Point GetLenPosition()
        {
            #region Entries validation
            
            if (this._len == null)
            {
                throw new ArgumentNullException("this._len");
            }

            #endregion

            return this._len.GetLastPosition();
		}

        /// <summary>
        /// Indica se a an�lise chegou ao fim do arquivo
        /// </summary>
        /// <returns></returns>
        public Boolean EOF()
        {
            return this._eof;
        }

    }
}