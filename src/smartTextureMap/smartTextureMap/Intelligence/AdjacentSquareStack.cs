
using smartTextureMap.Support;
using smartTextureMap.Support.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Intelligence{
	/// <summary>
	/// Represents a stack of squares used to reduce redundances
	/// </summary>
	public class AdjacentSquareStack {

		/// <summary>
		/// It´s the angle key which all the squares have in common in adjacency.
		/// </summary>
		private String _angleKey;

		/// <summary>
		/// It´s the last square analised by TryCollect
		/// </summary>
		private LogicalSquare _lastSquare;

		/// <summary>
		/// It's a list of squares accepted by TryCollect operation
		/// </summary>
		private List<LogicalSquare> _acceptedSquareList = new List<LogicalSquare>();

		/// <summary>
		/// Tries to collect a square and returns a boolean indicating whether the square was accept or ignored.
		/// </summary>
		/// <param name="square"></param>
		/// <returns></returns>
		public bool TryCollect(LogicalSquare square)
        {
            #region Entries validation
            
            if (square == null)
            {
                throw new ArgumentNullException("square");
            }
            if (this._lastSquare != null)
            {
                if (!this._lastSquare.CheckIntersection(square))
                {
                    return false;
                }
            }

            #endregion

            String angleKey = null;
            bool accepted = false;
            if (this._lastSquare != null)
            {
                LogicalSquare mainSquare = this._lastSquare;
                LogicalSquare adjacentSquare = square;

                CathetusParser parser = new CathetusParser(mainSquare, adjacentSquare);
                var adjacentCatheti =
                    parser.GetAdjacentCatheti(
                        this.GetAngleStrategyEnum(
                            mainSquare, adjacentSquare));

                angleKey =
                    this.GetAngleKey(
                        adjacentCatheti.CalculateAngle());

                Console.WriteLine(angleKey);
            }

            if (angleKey == this._angleKey || String.IsNullOrEmpty(this._angleKey))
            {
                this._acceptedSquareList.Add(square);
                accepted = true;
            }

            this._lastSquare = square;

            if (String.IsNullOrEmpty(this._angleKey))
            {
                this._angleKey = angleKey;
            }

            return accepted;
        }

        /// <summary>
        /// Gets a equivalent logical square to replace all the logical squares collected
        /// </summary>
        /// <returns></returns>
        public LogicalSquare GetEquivalent()
        {
            #region Entries validation
            
            if (this._acceptedSquareList.Count == 0)
            {
                return null;
            }

            #endregion

            int aX = this._acceptedSquareList.Min(item => item.PointA.X);
            int aY = this._acceptedSquareList.Min(item => item.PointA.Y);
            int bX = this._acceptedSquareList.Max(item => item.PointB.X);
            int bY = this._acceptedSquareList.Max(item => item.PointB.Y);

            return new LogicalSquare(
                new Point(aX, aY),
                new Point(bX, bY));
        }

		/// <summary>
		/// Gets a list of collected squares
		/// </summary>
		/// <returns></returns>
		public List<LogicalSquare> GetList() {
			return this._acceptedSquareList;
		}

		/// <summary>
		/// Cleans the object
		/// </summary>
		public void Clear() {
            this._acceptedSquareList.Clear();
		}

		/// <summary>
		/// Checks if some square was accepted
		/// </summary>
		/// <returns></returns>
		public bool CheckForSomeSquareAccepted()
        {
            #region Entries validation

            if (this._acceptedSquareList == null)
            {
                throw new ArgumentNullException("this._acceptedSquareList");
            }

            #endregion

            return this._acceptedSquareList.Count > 0;
		}

        /// <summary>
        /// Gets the angle strategy regard to squares
        /// </summary>
        private AngleStrategyEnum GetAngleStrategyEnum(LogicalSquare mainSquare, LogicalSquare adjacentSquare)
        {
            #region Entries validation

            if (mainSquare == null)
            {
                throw new ArgumentNullException("mainSquare");
            }
            if (adjacentSquare == null)
            {
                throw new ArgumentNullException("adjacentSquare");
            }
            if (!(mainSquare.PointA.Y < adjacentSquare.PointA.Y))
            {
                throw new ArgumentOutOfRangeException("The main square should have been less than adjacent square");
            }

            #endregion

            if (mainSquare.PointA.X < adjacentSquare.PointA.X)
            {
                return AngleStrategyEnum.CCAD;
            }
            if (mainSquare.PointA.X > adjacentSquare.PointA.X)
            {
                return AngleStrategyEnum.AAAD;
            }
            if (adjacentSquare.PointC.X > mainSquare.PointC.X)
            {
                return AngleStrategyEnum.CBCC;
            }

            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets a angle based on a angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        private string GetAngleKey(double angle)
        {
            return Math.Round(angle, 2).ToString();
        }
    }
}