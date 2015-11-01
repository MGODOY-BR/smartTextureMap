
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support.Mathematics{
	/// <summary>
	/// Represents angle formed by the two adjacent catheti
	/// </summary>
	public class AdjacentCatheti {

		/// <summary>
		/// It's the oposite cathetus
		/// </summary>
		private Cathetus _oposite;

		/// <summary>
		/// It´s the adjacente cathetus
		/// </summary>
		private Cathetus _adjacent;

		/// <param name="adjacent"></param>
		/// <param name="oposite"></param>
		public AdjacentCatheti(Cathetus adjacent, Cathetus oposite)
        {
            #region Entries validation
            
            if (adjacent == null)
            {
                throw new ArgumentNullException("adjacent");
            }
            if (oposite == null)
            {
                throw new ArgumentNullException("oposite");
            }

            #endregion

            this._adjacent = adjacent;
            this._oposite = oposite;
        }

		/// <summary>
		/// Calculates the angle in degrees formed between adjacent cathetus
		/// </summary>
		/// <returns></returns>
		public double CalculateAngle()
        {
            #region Entries validation
            
            if (this._oposite == null)
            {
                throw new ArgumentNullException("this._oposite");
            }
            if (this._adjacent == null)
            {
                throw new ArgumentNullException("this._adjacent");
            }

            #endregion

            double tangent = this._oposite.GetSize() / this._adjacent.GetSize();

            double radianAngle = 
                Math.Atan(tangent);

            double degreeAngle = radianAngle * 180 / Math.PI;
            return degreeAngle;
        }
	}
}