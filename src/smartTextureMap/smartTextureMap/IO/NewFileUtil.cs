using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartTextureMap.IO
{
    /// <summary>
    /// Offers utilities for handle new files
    /// </summary>
    public static class NewFileUtil
    {
        /// <summary>
        /// Gets the name of new file based on original one
        /// </summary>
        /// <param name="originalFile"></param>
        /// <returns></returns>
        public static string GetNewFullName(string originalFile)
        {
            #region Entries validation
            
            if (String.IsNullOrEmpty(originalFile))
            {
                throw new ArgumentNullException("originalFile");
            }

            #endregion

            string destination = Path.GetDirectoryName(originalFile);

            return Path.Combine(
                destination,
                Path.GetFileNameWithoutExtension(originalFile) + ".smartMap" + Path.GetExtension(originalFile));
        }
    }
}
