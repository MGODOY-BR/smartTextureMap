
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a cartesyan coordinate.
	/// </summary>
	public class Point {

        /// <summary>
        /// Absciss
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Ordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Creates a instance of object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}