
using smartTextureMap.IO;
using smartTextureMap.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace smartTextureMap.Forms{
    /// <summary>
    /// Represents an output to user based on rich UI
    /// </summary>
    public class FormOutput : IOutput
    {

        /// <summary>
        /// It´s a list of report progress registered
        /// </summary>
        private Dictionary<ContextMap, IReportProgress> _reportProgressList = new Dictionary<ContextMap, IReportProgress>();

        /// <summary>
        /// Finds the percentage values in strings
        /// </summary>
        private static Regex _regEx = new Regex(@"\d{1,}[\.|\,]{0,1}\d{0,}", RegexOptions.Compiled);

        /// <summary>
        /// Sets the owner of output
        /// </summary>
        public void RegisterOwner(ContextMap owner, IReportProgress reportProgress)
        {
            #region Entries validation

            if (owner == null)
            {
                throw new ArgumentNullException("owner");
            }
            if (reportProgress == null)
            {
                throw new ArgumentNullException("reportProgress");
            }
            if (this._reportProgressList.ContainsKey(owner))
            {
                return;
            }

            #endregion

            this._reportProgressList.Add(owner, reportProgress);
        }

        public void Clear(ContextMap contextMap)
        {
            // throw new NotImplementedException();
        }

        public void WriteLine(ContextMap contextMap)
        {
            // throw new NotImplementedException();
        }

        public void WriteLine(ContextMap contextMap, string stringFormat, params object[] args)
        {
            #region Entries validation
            
            if (String.IsNullOrEmpty(stringFormat))
            {
                throw new ArgumentNullException("stringFormat");
            }
            if (!_regEx.IsMatch(stringFormat))
            {
                return;
            }

            #endregion

            Match match = _regEx.Match(stringFormat);
            double value = double.Parse(match.Value);

            this._reportProgressList[contextMap].ReportProgress(value);

            if (value == 100)
            {
                this.ReportCompleted(contextMap);
            }
        }

        /// <summary>
        /// Reports the proccess
        /// </summary>
        public void ReportCompleted(ContextMap contextMap)
        {
            this._reportProgressList[contextMap].ReportComplete();
        }
    }
}