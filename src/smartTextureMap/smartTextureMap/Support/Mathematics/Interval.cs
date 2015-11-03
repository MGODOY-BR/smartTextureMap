
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support.Mathematics{
	/// <summary>
	/// Represents an interval between two numbers.
	/// </summary>
	public class Interval : IComparable<Interval>, IEquatable<Interval>
    {

		/// <summary>
		/// It´s the value
		/// </summary>
		private double _value;

		/// <summary>
		/// It´s the tolerance used in comparison
		/// </summary>
		private double _tolerance;

		/// <param name="value"> </param>
		/// <param name="tolerance"></param>
		public Interval(double value , double tolerance)
        {
            this._value = value;
            this._tolerance = tolerance;
		}

		/// <summary>
		/// Compares the interval to another one
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(Interval other)
        {
            #region Entries validation

            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            #endregion

            if (this.Equals((Interval)other))
            {
                return 0;
            }
            else
            {
                return this._value.CompareTo(other._value);
            }
        }

        public bool Equals(Interval other)
        {
            #region Entries validation

            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            #endregion

            double minValue = GetMinValue();
            double maxValue = GetMaxValue();

            double minValueOther = other._value - other._tolerance;
            double maxValueOther = other._value + other._tolerance;

            bool minLimit = other._value >= minValue || this._value >= minValueOther;
            bool maxLimit = other._value <= maxValue || this._value <= maxValueOther;

            return minLimit && maxLimit;
        }

        /// <summary>
        /// Gets the maximun value possible
        /// </summary>
        /// <returns></returns>
        public double GetMaxValue()
        {
            return this._value + this._tolerance;
        }

        /// <summary>
        /// Gets the lower value possible
        /// </summary>
        /// <returns></returns>
        public double GetMinValue()
        {
            return this._value - this._tolerance;
        }
    }
}