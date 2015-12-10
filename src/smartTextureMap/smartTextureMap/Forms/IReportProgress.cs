using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartTextureMap.Forms
{
    /// <summary>
    /// Defines how report progress class should be
    /// </summary>
    public interface IReportProgress
    {
        /// <summary>
        /// Report a progress
        /// </summary>
        /// <param name="value"></param>
        void ReportProgress(double value);

        /// <summary>
        /// Report a complete process
        /// </summary>
        void ReportComplete();
    }
}
