
using smartTextureMap.Support;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace smartTextureMap.Intelligence
{
    /// <summary>
    /// Represents a texture map intelligence.
    /// </summary>
    public class SmartTextureMap
    {
        /// <summary>
        /// Joins all the forms detected from textured map
        /// </summary>
        private List<Shape> _formList;

        /// <summary>
        /// It´s the original image to work on.
        /// </summary>
        private Picture _originalImage;

        /// <summary>
        /// Marks the form
        /// </summary>
		/// <param name="shapeList">Mark all the forms</param>
		private void MarkAllTheForms(List<Shape> shapeList)
        {
            #region Entries validation
            
            if (shapeList == null)
            {
                throw new ArgumentNullException("shapeList");
            }

            #endregion

            int charCode = 97;
            foreach (var shape in shapeList)
            {
                if (charCode == 123)
                {
                    charCode = 97;
                }

                shape.Mark(
                    char.ConvertFromUtf32(charCode));

                charCode++;
            }
        }

        /// <summary>
        /// Generates a smart texture map
        /// </summary>
        /// <param name="fileName">It's the name of file to get the smart teture map</param>
        public void Generate(String fileName)
        {
            try
            {
                #region Entries validation
                
                if (String.IsNullOrEmpty(fileName))
                {
                    throw new ArgumentNullException("fileName");
                }
                if (this._originalImage == null)
                {
                    throw new InvalidOperationException("You need to call Load() method before.");
                }

                #endregion

                ShapeParser shapeParser = new ShapeParser();
                this._formList =
                    shapeParser.Discover(
                        new Support.Point(0, 0),
                        this._originalImage);

                this.MarkAllTheForms(this._formList);

                this._originalImage.SaveAs(fileName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error to generate [" + fileName + "]", ex);
            }
        }

        /// <summary>
        /// Loads the image to analysis.
        /// </summary>
        /// <param name="fileName"></param>
        public void Load(String fileName)
        {
            #region Entries validation

            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File [" + fileName + "] not found.");
            }

            #endregion

            this._originalImage = new Picture(Image.FromFile(fileName));
        }
    }
}