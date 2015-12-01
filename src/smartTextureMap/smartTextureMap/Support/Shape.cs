
using System;
using System.Collections.Generic;
using System.Configuration;
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
            if (font == null)
            {
                return;
            }
            int fontSize = (int)font.SizeInPoints;
            
            int sizeX = this._logicalSquare.PointC.X - this._logicalSquare.PointA.X;
            int sizeY = this._logicalSquare.PointD.Y - this._logicalSquare.PointA.Y;

            Point letterPoint =
                new Point(
                    this._logicalSquare.PointA.X + (sizeX / 2) - fontSize / 2,
                    this._logicalSquare.PointA.Y + (sizeY / 2) - fontSize / 2);

            this._image.Mark(letter, letterPoint, font);

            object showShapeDiscoveredConfig = ConfigurationManager.AppSettings["showShapeDiscovered"];
            if (showShapeDiscoveredConfig != null)
            {
                bool showShapeDiscovered;
                if (!bool.TryParse(showShapeDiscoveredConfig.ToString(), out showShapeDiscovered))
                {
                    throw new ApplicationException("Bad showShapeDiscovered configuration.");
                }

                if (showShapeDiscovered)
                {
                    this._image.DrawSquare(this._logicalSquare);
                }
            }
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

            float horizontalSize = logicalSquare.PointC.X - logicalSquare.PointA.X;
            float verticalSize = logicalSquare.PointB.Y - logicalSquare.PointC.Y;

            float size = (horizontalSize < verticalSize) ? horizontalSize : verticalSize;

            if (size <= 0)
            {
                return null;
            }

            FontFamily fontFamily = new FontFamily("Courier New");
            Font font = new Font(
               fontFamily,
               size,
               FontStyle.Underline | FontStyle.Bold,
               GraphicsUnit.Pixel);

            return font;
        }
    }
}