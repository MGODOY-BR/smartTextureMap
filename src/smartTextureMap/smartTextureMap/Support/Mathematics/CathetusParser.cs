
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

            // TODO: Review whether the strategies are correct

            switch (angleStrategyEnum)
            {
                case AngleStrategyEnum.A:

                    return new AdjacentCatheti(
                        new Cathetus(
                            this._mainSquare.PointA, this._mainSquare.PointC),
                        new Cathetus(
                            this._adjacentSquare.PointB, this._adjacentSquare.PointC));

                case AngleStrategyEnum.B:

                    return new AdjacentCatheti(
                        new Cathetus(
                            this._mainSquare.PointC, this._mainSquare.PointB),
                        new Cathetus(
                            this._adjacentSquare.PointA, this._adjacentSquare.PointC));

                case AngleStrategyEnum.C:

                    return new AdjacentCatheti(
                        new Cathetus(
                            this._mainSquare.PointA, this._mainSquare.PointC),
                        new Cathetus(
                            this._adjacentSquare.PointA, this._adjacentSquare.PointD));

                case AngleStrategyEnum.D:

                    return new AdjacentCatheti(
                        new Cathetus(
                            this._mainSquare.PointA, this._mainSquare.PointD),
                        new Cathetus(
                            this._adjacentSquare.PointD, this._adjacentSquare.PointB));

                default:
                    throw new NotSupportedException("Angle strategy not supported");
            }
        }

	}
}