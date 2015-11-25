
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a image
	/// </summary>
	public class Picture {

		/// <summary>
		/// Represents a image
		/// </summary>
		public Picture() {
		}

		/// <summary>
		/// Prints the letter in the image
		/// </summary>
		/// <param name="letter"></param>
		/// <param name="point"></param>
		public void Mark(String letter, Point point) {
			// TODO implement here
		}

		/// <summary>
		/// Verifies whether the current point is a boundary
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		public BoundaryResult CheckBoundary(Point point) {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Save the new picture
		/// </summary>
		/// <param name="fileName"></param>
		public void SaveAs(String fileName) {
			// TODO implement here
		}

		/// <summary>
		/// Returns a propertion beetwen width and height.
		/// </summary>
		/// <returns></returns>
		public float GetProportionRate() {
			// TODO implement here
			return 0.0F;
		}

	}
}