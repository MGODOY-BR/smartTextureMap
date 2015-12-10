
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Intelligence{
	/// <summary>
	/// Discovers shapes
	/// </summary>
	public class ShapeParser {

		/// <summary>
		/// Discovers shapes
		/// </summary>
		public ShapeParser() {
		}

		/// <summary>
		/// It´s the context of transformation
		/// </summary>
		private ContextMap _contextMap;

		/// <summary>
		/// Begins the analasys
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="image"></param>
		/// <returns></returns>
		public HashSet<Shape> Discover(Point startPoint, Picture image) {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// Creates an instance of object
		/// </summary>
		/// <param name="contextMap"></param>
		public ShapeParser(ContextMap contextMap) {
			// TODO implement here
		}

	}
}