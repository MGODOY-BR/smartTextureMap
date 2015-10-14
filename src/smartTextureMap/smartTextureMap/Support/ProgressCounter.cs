using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartTextureMap.Support
{
    /// <summary>
    /// Represents a counter of process progress
    /// </summary>
    public class ProgressCounter
    {
        /// <summary>
        /// It´s the last percentage identified
        /// </summary>
        private double _lastPercentage;

        /// <summary>
        /// Reset de progress counter
        /// </summary>
        public void Reset()
        {
            this._lastPercentage = 0;
        }

        /// <summary>
        /// Update de progress counter
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        public void Update(double value, double total)
        {
            #region Entries validation

            if (total == 0)
            {
                return;
            }

            #endregion

            double currentPercentage =
                value / total * 100D;

            if (currentPercentage == this._lastPercentage)
            {
                return;
            }

            this._lastPercentage = currentPercentage;

            this.Print(currentPercentage);
        }


        /// <summary>
        /// Print the progress
        /// </summary>
        private void Print(double currentPercentage)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Analysing...");
                Console.WriteLine(
                    currentPercentage.ToString() + "%");
            }
            catch (IOException)
            {
                // Error of this kind ocurred cause the Console object
            }
            catch
            {
                throw;
            }
        }

    }
}
