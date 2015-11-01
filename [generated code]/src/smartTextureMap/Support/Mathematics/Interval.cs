
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support.Mathematics{
	/// <summary>
	/// Represents an interval between two numbers.
	/// </summary>
	public class Interval {

		/// <summary>
		/// Represents an interval between two numbers.
		/// </summary>
		public Interval() {
		}

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
		public void Interval(double value , double tolerance) {
			// TODO implement here
		}

		/// <summary>
		/// Compares the interval to another one
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(Interval other) {
			// TODO implement here
			return 0;
		}

	}
}