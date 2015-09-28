
using smartTextureMap.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Intelligence{
	/// <summary>
	/// Represents a texture map intelligence.
	/// </summary>
	public class SmartTextureMap {

		/// <summary>
		/// Represents a texture map intelligence.
		/// </summary>
		public SmartTextureMap() {
		}

		/// <summary>
		/// Joins all the forms detected from textured map
		/// </summary>
		private List<Shape> _formList;

		/// <summary>
		/// It´s the original image to work on.
		/// </summary>
		private Picture _originalImage;

        /// <summary>
        /// Realizes the analysis
        /// </summary>
        /// <param name="shapeList"></param>
        private void Analyse(List<Shape> shapeList) {
			// TODO implement here
		}

		/// <param name="shapeList">Mark all the forms</param>
		private void MarkAllTheForms(List<Shape> shapeList) {
			// TODO implement here
		}

		/// <summary>
		/// Generates a smart texture map
		/// </summary>
		/// <param name="fileName">It's the name of file to get the smart teture map</param>
		public void Generate(String fileName) {
			// TODO implement here
		}

		/// <summary>
		/// Loads the image to analysis.
		/// </summary>
		/// <param name="fileName"></param>
		public void Load(String fileName ) {
			// TODO implement here
		}

	}
}