
using smartTextureMap.Support.Mathematics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace smartTextureMap.Support{
	/// <summary>
	/// Represents a image
	/// </summary>
	public class Picture : IDisposable {
        
        /// <summary>
        /// A graphic created from bitmap
        /// </summary>
        private Graphics _graphics;

        /// <summary>
        /// The original bitmap
        /// </summary>
        private Image _originalImage;

        /// <summary>
        /// It's the new imagem
        /// </summary>
        private Image _newImage;

        /// <summary>
        /// Gets the width of image
        /// </summary>
        public int Width
        {
            get
            {
                return this._originalImage.Width;
            }
        }

        /// <summary>
        /// Getsthe height of image
        /// </summary>
        public int Height
        {
            get
            {
                return this._originalImage.Height;
            }
        }

        /// <summary>
        /// Creates a instance of the object
        /// </summary>
        public Picture(Image originalImage)
        {
            #region Entries validation
            
            if (originalImage == null)
            {
                throw new ArgumentNullException("originalImage");
            }

            #endregion

            this._originalImage = originalImage;
            this._newImage = new Bitmap(originalImage);
            this._graphics = Graphics.FromImage(this._newImage);
        }

        /// <summary>
        /// Prints the letter in the image
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="point"></param>
        public void Mark(String letter, Point point, Font font)
        {
            #region Entries validation

            if (String.IsNullOrEmpty(letter))
            {
                throw new ArgumentNullException("letter");
            }
            if (point == null)
            {
                throw new ArgumentNullException("point");
            }
            if (this._graphics == null)
            {
                throw new ArgumentNullException("this._graphics");
            }
            if (font == null)
            {
                throw new ArgumentNullException("font");
            }

            #endregion

            SolidBrush drawBrush = new SolidBrush(Color.DarkBlue);

            // Create point for upper-left corner of drawing.
            float x = point.X;
            float y = point.Y - (font.SizeInPoints / 2) + (font.SizeInPoints / 4);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();

            // Draw string to screen.
            this._graphics.DrawString(letter, font, drawBrush, x, y, drawFormat);
        }

        /// <summary>
        /// Draws a square
        /// </summary>
        /// <param name="square"></param>
        /// <remarks>This operation it is available for debug reason and normally isn't used</remarks>
        public void DrawSquare(LogicalSquare square)
        {
            #region Entries validation

            if (square == null)
            {
                throw new ArgumentNullException("square");
            }
            if (this._graphics == null)
            {
                throw new ArgumentNullException("this._graphics");
            }

            #endregion

            this._graphics.DrawRectangle(
                Pens.Red,
                square.PointA.X,
                square.PointA.Y,
                square.PointC.X - square.PointA.X,
                square.PointB.Y - square.PointC.Y); 
                
        }

		/// <summary>
		/// Verifies whether the current point is a boundary
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		public BoundaryResult CheckBoundary(Point point)
        {
            #region Entries validation

            if (point == null)
            {
                throw new ArgumentNullException("point");
            }
            if (this._originalImage == null)
            {
                throw new ArgumentNullException("this._originalImage");
            }
            if(!(this._originalImage is Bitmap))
            {
                throw new NotSupportedException("Just available for bitmap objects!");
            }
            if (point.Y > this._originalImage.Height)
            {
                return new BoundaryResult(false, Color.Transparent);
            }
            if (point.X > this._originalImage.Width)
            {
                return new BoundaryResult(false, Color.Transparent);
            }
            if (point.Y == this._originalImage.Height)
            {
                return new BoundaryResult(true, Color.Transparent);
            }
            if (point.X == this._originalImage.Width)
            {
                return new BoundaryResult(true, Color.Transparent);
            }

            #endregion

            Bitmap bitmap = (Bitmap)this._originalImage;

            var pixel = bitmap.GetPixel(point.X, point.Y);

            return this.CheckBoundaryColorRange(pixel);
        }

        /// <summary>
        /// Save the new picture
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveAs(String fileName)
        {
            #region Entries validation

            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }
            if (this._newImage == null)
            {
                throw new ArgumentNullException("this._newImage");
            }

            #endregion

            try
            {
                this._graphics.DrawImage(this._newImage, 0, 0);
                this._newImage.Save(fileName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error to save [" + fileName + "]. Try to choice a diferent file from the original as destination.", ex);
            }
        }

        /// <summary>
        /// Checks whether the collor represents a boundary color
        /// </summary>
        /// <returns></returns>
        private BoundaryResult CheckBoundaryColorRange(Color color)
        {
            #region Entries validation

            if (color == null)
            {
                throw new ArgumentNullException("color");
            }
            if (color == Color.White)
            {
                return new BoundaryResult(false, color);
            }
            if (color == Color.Black)
            {
                return new BoundaryResult(false, color);
            }
            if (this.IsGrayShade(color))
            {
                if (color.R == 0) // && color.A == 0) // PNG empty spaces
                {
                    return new BoundaryResult(false, color);
                }
                if (color.R == 229) // background
                {
                    return new BoundaryResult(false, color);
                }
                if (color.R > 180)
                {
                    return new BoundaryResult(false, color);
                }
            }
            else
            {
                if (color.GetBrightness() > 0.8)  // background
                {
                    return new BoundaryResult(false, color);
                }
            }

            #endregion

            return
                new BoundaryResult(
                    true,
                    color);
        }

        /// <summary>
        /// Gets an indicator informing if the color is a grade of gray
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private bool IsGrayShade(Color color)
        {
            #region Entries validation
            
            if (color == null)
            {
                throw new ArgumentNullException("color");
            }

            #endregion

            return color.R == color.G && color.G == color.B && color.R == color.B;
        }

        /// <summary>
        /// Returns a propertion beetwen width and height.
        /// </summary>
        /// <returns></returns>
        public float GetProportionRate()
        {
            #region Entries validation
            
            if (this._originalImage == null)
            {
                throw new ArgumentNullException("this._originalImage");
            }

            #endregion

            return this._originalImage.Width / this._originalImage.Height;
        }

        public void Dispose()
        {
            if (this._originalImage != null)
            {
                this._originalImage.Dispose();
            }
            if (this._newImage != null)
            {
                this._newImage.Dispose();
            }
        }
    }
}