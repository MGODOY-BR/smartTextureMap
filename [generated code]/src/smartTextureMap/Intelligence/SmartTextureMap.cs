
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
		private HashSet<Shape> _formList;

		/// <summary>
		/// It´s the original image to work on.
		/// </summary>
		private Picture _originalImage;

		/// <summary>
		/// It´s the context of transformation
		/// </summary>
		private ContextMap _contextMap;

		/// <summary>
		/// Marks the form
		/// </summary>
		/// <param name="forms">Mark all the forms</param>
		private void MarkAllTheForms(HashSet<Shape> forms) {
			// TODO implement here
		}

		/// <summary>
		/// Generates a smart texture map
		/// </summary>
		/// <summary>
		/// @param fileName It's the name of file to get the smart texture map
		/// </summary>
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