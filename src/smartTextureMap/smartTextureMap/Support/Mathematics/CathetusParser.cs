
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support.Mathematics{
	/// <summary>
	/// Generates catheti
	/// </summary>
	public class CathetusParser {

		/// <summary>
		/// The main square
		/// </summary>
		private LogicalSquare _mainSquare;

        /// <summary>
        /// The adjacent square
        /// </summary>
        private LogicalSquare _adjacentSquare;

        public CathetusParser(LogicalSquare mainSquare, LogicalSquare adjacentSquare)
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

            #endregion

            this._mainSquare = mainSquare;
            this._adjacentSquare = adjacentSquare;
        }

        /// <summary>
        /// Gets the adjacent catheti
        /// </summary>
		/// <param name="angleStrategyEnum"></param>
		/// <returns></returns>
		public AdjacentCatheti GetAdjacentCatheti(AngleStrategyEnum angleStrategyEnum)
        {
            #region Entries validation

            if (this._mainSquare == null)
            {
                throw new ArgumentNullException("this._mainSquare");
            }
            if (this._adjacentSquare == null)
            {
                throw new ArgumentNullException("this._adjacentSquare");
            }

            #endregion

            Cathetus AC = new Cathetus(this._adjacentSquare.PointA, this._adjacentSquare.PointC);

            switch (angleStrategyEnum)
            {
                case AngleStrategyEnum.AAAD:

                    Cathetus AD = new Cathetus(this._mainSquare.PointA, this._mainSquare.PointD);
                    Cathetus AA = this.Cut(AC, AC.GetPerpendicularInterceptionPoint(AD));

                    return new AdjacentCatheti(AA, AD);

                case AngleStrategyEnum.CBCC:

                    Cathetus CB = new Cathetus(this._mainSquare.PointC, this._mainSquare.PointB);
                    Cathetus CC = this.Cut(AC, AC.GetPerpendicularInterceptionPoint(CB));

                    return new AdjacentCatheti(CB, CC);

                default:
                    throw new NotSupportedException("Angle strategy not supported");
            }
        }

        /// <summary>
        /// Returns a piece of cathetus
        /// </summary>
        private Cathetus Cut(Cathetus cathetus, Point intersectionPoint)
        {
            #region Entries validation
            
            if (cathetus == null)
            {
                throw new ArgumentNullException("cathetus");
            }
            if (intersectionPoint == null)
            {
                throw new ArgumentNullException("intersectionPoint");
            }

            #endregion

            // Warranting the new instance of endPoint
            Point endPoint = (Point)cathetus.EndPoint.Clone();

            if (intersectionPoint.X < endPoint.X)
            {
                endPoint.X = intersectionPoint.X;
            }
            if (intersectionPoint.Y < endPoint.Y)
            {
                endPoint.Y = intersectionPoint.Y;
            }

            return new Cathetus(cathetus.StartPoint, endPoint);
        }
    }
}