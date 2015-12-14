
using smartTextureMap.IO;
using smartTextureMap.Support;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static Regex _regEx = new Regex(@"(\d{1,}[\.|\,]{0,1}\d{0,})%", RegexOptions.Compiled);

        /// <summary>
        /// Sets the owner of output
        /// </summary>
        public void RegisterOwner(ContextMap owner, IReportProgress reportProgress)
        {
            lock (this._reportProgressList)
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
        }

        public void Clear(object sender, ContextMap contextMap)
        {
            // throw new NotImplementedException();
        }

        public void WriteLine(object sender, ContextMap contextMap)
        {
            // throw new NotImplementedException();
        }

        public void WriteLine(object sender, ContextMap contextMap, string stringFormat, params object[] args)
        {
            lock (contextMap)
            {
                #region Entries validation

                if (String.IsNullOrEmpty(stringFormat))
                {
                    return;
                }
                if (!_regEx.IsMatch(stringFormat))
                {
                    return;
                }
                ProgressCounter progressCounter = sender as ProgressCounter;
                if (progressCounter == null)
                {
                    return;
                }
                if (!progressCounter.IsMainProgress)
                {
                    return;
                }

                #endregion

                Match match = _regEx.Match(stringFormat);
                double value = double.Parse(match.Groups[1].Value);

                this._reportProgressList[contextMap].ReportProgress(value);
            }
        }

        /// <summary>
        /// Reports the proccess
        /// </summary>
        public void ReportCompleted(ContextMap contextMap)
        {
            lock (this._reportProgressList)
            {
                this._reportProgressList[contextMap].ReportComplete();
                this._reportProgressList.Remove(contextMap);
            }
        }
    }
}