
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a detected form (a polygon or a cyrcle) in texture map.
	/// </summary>
	public class Shape {

		/// <summary>
		/// A logical square existing in the middleware of polygon.
		/// </summary>
		private LogicalSquare _logicalSquare;

        /// <summary>
        /// The image object
        /// </summary>
        private Picture _image;

		/// <summary>
		/// Prints a mark in the form in image.
		/// </summary>
		/// <param name="letter">A letter which will printed in the form.   
        public void Mark(String letter)
        {
            #region Entries validation

            if (String.IsNullOrEmpty(letter))
            {
                throw new ArgumentNullException("letter");
            }
            if (this._image == null)
            {
                throw new ArgumentNullException("this._image");
            }

            #endregion

            // Getting the font
            Font font = this.GetFont(letter, this._logicalSquare);

            this._image.Mark(letter.ToUpper().ToLower(), this._logicalSquare.PointA, font);
        }

        /// <summary>
        /// Creates the object
        /// </summary>
        /// <param name="logicalSquare"></param>
        /// <param name="image"></param>
        public Shape(LogicalSquare logicalSquare, Picture image)
        {
            #region Entries validation

            if (logicalSquare == null)
            {
                throw new ArgumentNullException("logicalSquare");
            }
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            #endregion

            this._logicalSquare = logicalSquare;
            this._image = image;
        }

        /// <summary>
        /// Gets a font properly for the logical square
        /// </summary>
        /// <returns></returns>
        private Font GetFont(String letter, LogicalSquare logicalSquare)
        {
            #region Entries validation

            if (logicalSquare == null)
            {
                throw new ArgumentNullException("logicalSquare");
            }
            if (String.IsNullOrEmpty(letter))
            {
                throw new ArgumentNullException("letter");
            }

            #endregion

            float size = logicalSquare.PointB.X - logicalSquare.PointA.X;

            FontFamily fontFamily = new FontFamily("Verdana");
            Font font = new Font(
               fontFamily,
               size,
               FontStyle.Regular,
               GraphicsUnit.Pixel);

            return font;
        }
    }
}