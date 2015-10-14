
using smartTextureMap.Support;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace smartTextureMap.Intelligence.Lens{
	/// <summary>
	/// Represents an engine of moviment of shape len through the polygon
	/// </summary>
	public class AxisEngine {

        /// <summary>
        /// Indica se a análise chegou ao fim do arquivo
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
        /// It´s a progressCounter of Run operation.
        /// </summary>
        private ProgressCounter _runProgressCounter = new ProgressCounter();

        /// <summary>
        /// Returns the amount of squares detected in last execution of Run()
        /// </summary>
        public int DetectedSquare{ get; private set; }

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
            this._runProgressCounter.Reset();
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
            if (this._image == null)
            {
                throw new ArgumentNullException("this._image");
            }

            #endregion

            this.DetectedSquare = 0;
            this._runProgressCounter.Reset();

            int y = this._startPoint.Y;

            //for (int x = this._startPoint.X; x < this._image.Width; x+= ShapeLen.SENSOR_DISTANCE)
            int x = this._startPoint.X;
            while (x < this._image.Width)
            {
                y += ShapeLen.SENSOR_DISTANCE;
                if (x == 0)
                {
                    x += ShapeLen.SENSOR_DISTANCE;
                }

                #region Iterator control

                if (y >= this._image.Height)
                {
                    if (x == this._image.Width)
                    {
                        // EOF
                        break;
                    }
                    else
                    {
                        // End of column. Try next
                        x += ShapeLen.SENSOR_DISTANCE;
                        y = this._startPoint.Y;
                    }
                }

                this._runProgressCounter.Update(x, this._image.Width);

                #endregion

                //if (this._len.Read(x, y))
                {
                    var newSquare =
                        this.ScanSquare(this._len, x, y);

                    // There is nothing to do in column
                    if (newSquare == null || !newSquare.Validate())
                    {
                        x += ShapeLen.SENSOR_DISTANCE;
                        y = this._startPoint.Y;
                        continue;
                    }
                    else if (!this.CheckIntersection(newSquare, this._squareList))
                    {
                        this._squareList.Add(newSquare);
                        this.DetectedSquare++;
                    }

                    if (newSquare != null)
                    {
                        y = newSquare.PointD.Y;
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
        /// Indica se a análise chegou ao fim do arquivo
        /// </summary>
        /// <returns></returns>
        public Boolean EOF()
        {
            return this._eof;
        }

        /// <summary>
        /// Checks whether the square are intersected in square list
        /// </summary>
        private bool CheckIntersection(LogicalSquare square, List<LogicalSquare> squareList)
        {
            #region Entries validation
            
            if (square == null)
            {
                throw new ArgumentNullException("square");
            }
            if (squareList == null)
            {
                throw new ArgumentNullException("squareList");
            }
            if (squareList.Count == 0)
            {
                return false;
            }

            #endregion

            foreach (var item in squareList)
            {
                #region Entries validation

                if (item == null)
                {
                    continue;
                }

                #endregion

                if (square.CheckIntersection(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets a logical square from picture
        /// </summary>
        private LogicalSquare ScanSquare(ShapeLen len, int startX, int startY)
        {
            #region Entries validation
            
            if (len == null)
            {
                throw new ArgumentNullException("len");
            }

            #endregion

            AxisDirectionEnum directionEnum = AxisDirectionEnum.Forward;
            AxisDirectionEnum lastDirectionEnum = AxisDirectionEnum.NotDefined;

            int y = startY;
            Support.Point pointA = null;

            Support.Point lastRightBoundary = null;

            //for (int x = startX; x < this._image.Width - 1; x += (ShapeLen.SENSOR_DISTANCE * (int)directionEnum))
            int x = startX;
            while (x < this._image.Width - 1)
            {
                if (pointA != null)
                {
                    x += (ShapeLen.SENSOR_DISTANCE * (int)directionEnum);
                }

                #region Square validation/creation logic

                if (pointA != null && lastRightBoundary != null && len.CheckBottomBoundary())
                {
                    return new LogicalSquare(pointA, lastRightBoundary);
                }
                if (x < 0)
                {
                    // This isn't a polygon
                    return null;
                }
                if (x == 0)
                {
                    x += (ShapeLen.SENSOR_DISTANCE * (int)directionEnum);
                    continue;
                }
                if (y == 0)
                {
                    y += ShapeLen.SENSOR_DISTANCE;
                    continue;
                }
                if (y >= this._image.Height)
                {
                    break;
                }

                #endregion

                #region Boundary treatment

                if (len.Read(x, y))
                {
                    if (pointA == null)
                    {
                        pointA = len.GetLastPosition();
                        startX = pointA.X + ShapeLen.SENSOR_DISTANCE;
                        x += ShapeLen.SENSOR_DISTANCE;
                        y += ShapeLen.SENSOR_DISTANCE;
                    }
                    else
                    {
                        #region Axis scan direction

                        lastDirectionEnum = directionEnum;

                        switch (directionEnum)
                        {
                            case AxisDirectionEnum.Backward:
                                directionEnum = AxisDirectionEnum.Forward;
                                break;

                            case AxisDirectionEnum.Forward:
                                if (len.CheckRightBoundary())
                                {
                                    lastRightBoundary = len.GetLastPosition();
                                }
                                directionEnum = AxisDirectionEnum.Backward;
                                break;

                            default:
                                break;
                        }

                        #endregion
                    }
                }

                #endregion

                if (lastDirectionEnum != directionEnum || pointA == null)
                {
                    // Resume next line
                    y += ShapeLen.SENSOR_DISTANCE;
                    lastDirectionEnum = directionEnum;
                }

                if (y >= this._image.Height)
                {
                    if (x < this._image.Width)
                    {
                        x += (ShapeLen.SENSOR_DISTANCE * (int)directionEnum);
                        y = startY;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns the fewest Y bigger then the referencial point
        /// </summary>
        private int GetFewestYBiggerThanReference(Support.Point referencialPoint, List<LogicalSquare> squareList)
        {
            #region Entries validation
            
            if (referencialPoint == null)
            {
                throw new ArgumentNullException("referencialPoint");
            }
            if (squareList == null)
            {
                throw new ArgumentNullException("squareList");
            }

            #endregion

            LogicalSquare[] squareArray = new LogicalSquare[squareList.Count];
            squareList.CopyTo(squareArray);
            List<LogicalSquare> squareList2 = new List<LogicalSquare>(squareArray);

            squareList2.Sort(
                delegate (LogicalSquare item, LogicalSquare compareTo)
                {
                    return item.PointA.Y.CompareTo(compareTo.PointA.Y);
                });

            var squareCandidateList = from item in squareList2
                                      where item.PointA.Y > referencialPoint.Y
                                      select item;

            return squareCandidateList.FirstOrDefault().PointA.Y;
        }

        /// <summary>
        /// Returns the most X for Y informed
        /// </summary>
        private int GetMostXForY(int y, List<LogicalSquare> squareList)
        {
            #region Entries validation
            
            if (squareList == null)
            {
                throw new ArgumentNullException("squareList");
            }

            #endregion

            LogicalSquare[] squareArray = new LogicalSquare[squareList.Count];
            squareList.CopyTo(squareArray);
            List<LogicalSquare> squareList2 = new List<LogicalSquare>(squareArray);

            squareList2.Sort(
                delegate (LogicalSquare item, LogicalSquare compareTo)
                {
                    return item.PointA.Y.CompareTo(compareTo.PointA.Y);
                });

            var squareCandidateList = from item in squareList2
                                      where item.PointC.Y == y
                                      select item;

            return squareCandidateList.LastOrDefault().PointC.X;
        }
    }
}