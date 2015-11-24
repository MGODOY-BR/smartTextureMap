
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
        /// It's a progressCounter of Run operation.
        /// </summary>
        private ProgressCounter _mainProgressCounter = new ProgressCounter();

        /// <summary>
        /// It's a auxiliar progressCounter
        /// </summary>
        private ProgressCounter _auxProgressCounter = new ProgressCounter();

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
            this._mainProgressCounter.Reset();
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
            this._mainProgressCounter.Reset();

            int y = this._startPoint.Y;
            int x = this._startPoint.X;

            while (x < this._image.Width)
            {
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

                this._mainProgressCounter.Update(x, this._image.Width);
                this._auxProgressCounter.Update(y, this._image.Height);

                #endregion

                if (!this.CheckContained(x, y))
                {
                    var newSquare =
                        this.ScanSquare(this._len, x, y);

                    // There is nothing to do in column
                    if (newSquare == null || !newSquare.Validate())
                    {
                        // x += ShapeLen.SENSOR_DISTANCE;
                        // y = this._startPoint.Y;
                        y += ShapeLen.SENSOR_DISTANCE;
                        continue;
                    }
                    //else if (!this.CheckIntersection(newSquare, this._squareList))
                    else if (!this.CheckContained(newSquare, this._squareList))
                    {
                        this._squareList.Add(newSquare);
                        this.DetectedSquare++;
                    }

                    if (newSquare != null)
                    {
                        y = newSquare.PointD.Y;
                    }
                }
                else
                {
                    y += ShapeLen.SENSOR_DISTANCE;
                }
            }

            ProgressCounter.Stop();

            try
            {
                Console.WriteLine("Wait, refining squares... (this might it takes several minutes)");

                this.RefineSquares(this._squareList);

                Console.WriteLine("Squares has been refined");
            }
            catch (IOException)
            {
                // Errors in this process can't be mess the natural flow of process
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

            // Support.Point lastRightBoundary = null;
            PointManager pointManager = new PointManager();

            //for (int x = startX; x < this._image.Width - 1; x += (ShapeLen.SENSOR_DISTANCE * (int)directionEnum))
            int x = startX;
            int maxX = this._image.Width - 1;
            int maxY = this._image.Height - 1;
            while (x < maxX)
            {
                if (pointA != null)
                {
                    x += (ShapeLen.SENSOR_DISTANCE * (int)directionEnum);
                }

                #region Square validation/creation logic

                var rightCorner = pointManager.GetRightCorner();

                if (pointA != null && rightCorner != null && len.CheckBottomBoundary())
                {
                    pointManager.Clear();
                    return new LogicalSquare(pointA, rightCorner);
                }

                if (x < 0)
                {
                    // Changes the direction
                    x = startX;
                    directionEnum = AxisDirectionEnum.Forward;
                }

                #endregion

                #region Boundary treatment

                if (len.Read(x, y))
                {
                    if (pointA == null)
                    {
                        pointA = len.GetLastPosition();
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
                                    pointManager.Register(len.GetLastPosition());
                                    directionEnum = AxisDirectionEnum.Backward;
                                }
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

                if (y + 1 >= maxY && x + 1 >= maxX)
                {
                    break;
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

        /// <summary>
        /// Checks whether the point is contained in a square in thes list
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool CheckContained(int x, int y)
        {
            #region Entries validation

            if (this._squareList == null)
            {
                throw new ArgumentNullException("this._squareList");
            }

            #endregion

            foreach (var square in this._squareList)
            {
                if (square.CheckInside(new Support.Point(x, y)))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether the point is contained in a square in thes list
        /// </summary>
        /// <returns></returns>
        private bool CheckContained(LogicalSquare square, List<LogicalSquare> squareList)
        {
            foreach (var squareItem in squareList)
            {
                if (square.CheckInside(squareItem))
                {
                    return true;
                }

                /*
                Support.Point compareItem = 
                    squareItem.PointA.GetSelfOrSimilar(square.PointA);

                if (compareItem.Equals(squareItem.PointA))
                {
                    return true;
                }
                */
            }

            return false;
        }

        /// <summary>
        /// Refines the square list, fixing the "trapeze echoes" and etc.
        /// </summary>
        private void RefineSquares(List<LogicalSquare> squareList)
        {
            #region Entries validation
            
            if (squareList == null)
            {
                throw new ArgumentNullException("squareList");
            }

            #endregion

            #region Consolidating points

            foreach (var squareItemA in squareList)
            {
                foreach (var squareItemB in squareList)
                {
                    #region Same points

                    squareItemB.PointA =
                        squareItemA.PointA.GetSelfOrSimilar(
                            squareItemB.PointA);
                    squareItemB.PointB =
                        squareItemA.PointB.GetSelfOrSimilar(
                            squareItemB.PointB);
                    squareItemB.PointC =
                        squareItemA.PointC.GetSelfOrSimilar(
                            squareItemB.PointC);
                    squareItemB.PointD =
                        squareItemA.PointD.GetSelfOrSimilar(
                            squareItemB.PointD);

                    #endregion

                    #region Adjacencies

                    if (squareItemA.PointA.LooksLikeByY(
                        squareItemB.PointD))
                    {
                        squareItemB.PointD.Y = squareItemA.PointA.Y;
                    }

                    if (squareItemA.PointB.LooksLikeByY(
                        squareItemB.PointC))
                    {
                        squareItemB.PointC.Y = squareItemA.PointB.Y;
                    }

                    if (squareItemA.PointD.LooksLikeByY(
                        squareItemB.PointA))
                    {
                        squareItemB.PointA.Y = squareItemA.PointD.Y;
                    }

                    //if (squareItemA.PointA.LooksLikeByX(
                    //    squareItemB.PointD))
                    //{
                    //    squareItemB.PointD.X = squareItemA.PointA.X;
                    //}

                    //if (squareItemA.PointD.LooksLikeByX(
                    //    squareItemB.PointA))
                    //{
                    //    squareItemB.PointA.X = squareItemA.PointD.X;
                    //}

                    //if (squareItemA.PointB.LooksLikeByX(
                    //    squareItemB.PointC))
                    //{
                    //    squareItemB.PointC.X = squareItemA.PointB.X;
                    //}

                    #endregion
                }
            }

            #endregion

            #region Sorting the list

            squareList.Sort();

            #endregion

            AdjacentSquareParser parser = new AdjacentSquareParser();
            foreach (var squareItem in squareList)
            {
                parser.TryToFit(squareItem);
            }

            #region Printing detected angles

            /*
            foreach (var stack in parser.AdjacentSquareStackList)
            {
                Console.WriteLine("AngleKey: " + stack.AngleKey + " quantity: " + stack.GetList().Count);
            }
            */

            #endregion

            // Removing all the echoes
            var echoeList = parser.GetAcceptedSquareList();

            int echoesDeleted =
                squareList.RemoveAll(delegate (LogicalSquare square)
                {
                    return echoeList.Contains(square);
                });

            Console.WriteLine(echoesDeleted + " trapeze's echoes detected has been deleted");

            // Replacing the echoes by the equivalent ones
            squareList.AddRange(
                parser.GetEquivalentSquares());
        }

        /// <summary>
        /// Get a key based on a hypotenuse
        /// </summary>
        private string GetHypotenuseKey(int hypotenuse)
        {
            String hypString = hypotenuse.ToString();
            int lastDigit = int.Parse(hypString[hypString.Length - 1].ToString());
            String newDigit;
            if (lastDigit > 5)
            {
                newDigit = "9";
            }
            else
            {
                newDigit = "0";
            }

            return hypString.Substring(0, hypString.Length - 1) + newDigit;
        }
    }
}