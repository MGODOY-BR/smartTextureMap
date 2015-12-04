
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
        /// It´s a random color control for mark letters
        /// </summary>
        private Random _randomColor = new Random();

        /// <summary>
        /// It's the width of picture
        /// </summary>
        private int _width;

        /// <summary>
        /// It´s the height of picture
        /// </summary>
        private int _height;

        /// <summary>
        /// It´s a buffer of picture, where key it's a combination of x and y coordinates. 
        /// </summary>
        private Dictionary<String, Color> _buffer;

        /// <summary>
        /// Gets the width of image
        /// </summary>
        public int Width
        {
            get
            {
                return this._width;
            }
        }

        /// <summary>
        /// Getsthe height of image
        /// </summary>
        public int Height
        {
            get
            {
                return this._height;
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
            if (!(originalImage is Bitmap))
            {
                throw new NotSupportedException("Just available for bitmap objects!");
            }

            #endregion

            this._originalImage = originalImage;
            this._newImage = new Bitmap(originalImage);
            this._graphics = Graphics.FromImage(this._newImage);

            this._width = this._originalImage.Width;
            this._height = this._originalImage.Height;

            this.LoadBuffer((Bitmap)this._originalImage);
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
            // Create point for upper-left corner of drawing.
            float x = point.X;
            float y = point.Y - (font.SizeInPoints / 2) + (font.SizeInPoints / 4);

            // Draw string to screen.
            this._graphics.DrawString(
                letter, 
                font,
                new SolidBrush(this.GetColorToLetter()), 
                x, 
                y, 
                new StringFormat());
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
            /*
            if (this._originalImage == null)
            {
                throw new ArgumentNullException("this._originalImage");
            }
            if(!(this._originalImage is Bitmap))
            {
                throw new NotSupportedException("Just available for bitmap objects!");
            }
            */
            if (point.Y > this._height)
            {
                return new BoundaryResult(false, Color.Transparent);
            }
            if (point.X > this._width)
            {
                return new BoundaryResult(false, Color.Transparent);
            }
            if (point.Y == this._height)
            {
                return new BoundaryResult(true, Color.Transparent);
            }
            if (point.X == this._width)
            {
                return new BoundaryResult(true, Color.Transparent);
            }

            #endregion

            var pixel =
                this._buffer[
                    this.FormatKey(point.X, point.Y)];

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
        /// Gets a random color to letter
        /// </summary>
        /// <returns></returns>
        private Color GetColorToLetter()
        {
            int value = _randomColor.Next(0, 100);

            if (value < 25)
            {
                return Color.DarkBlue;
            }
            else if (value >= 25 && value < 50)
            {
                return Color.Violet;
            }
            else if (value >= 50 && value < 75)
            {
                return Color.DarkGreen;
            }
            else
            {
                return Color.Crimson;
            }
        }

        /// <summary>
        /// Load the buffer
        /// </summary>
        private void LoadBuffer(Bitmap image)
        {
            #region Entries validation
            
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            #endregion

            lock (this)
            {
                #region Entries validation

                if (this._buffer != null)
                {
                    return;
                }

                #endregion

                this._buffer = new Dictionary<string, Color>();

                for (int y = 0; y < this._height; y++)
                {
                    for (int x = 0; x < this._width; x++)
                    {
                        this._buffer.Add(
                            this.FormatKey(x, y),
                            image.GetPixel(x, y));
                    }
                }
            }
        }

        /// <summary>
        /// Formats the coordinates to use as keys.
        /// </summary>
        private string FormatKey(int x, int y)
        {
            return String.Format("{0}_{1}", x, y);
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