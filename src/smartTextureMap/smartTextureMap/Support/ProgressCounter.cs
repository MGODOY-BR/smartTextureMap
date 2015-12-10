using smartTextureMap.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace smartTextureMap.Support
{
    /// <summary>
    /// Represents a counter of process progress
    /// </summary>
    public class ProgressCounter
    {
        /// <summary>
        /// It´s the context of transformation
        /// </summary>
        private ContextMap _contextMap = new ContextMap();

        /// <summary>
        /// It's the buffer of text
        /// </summary>
        private string _buffer;

        /// <summary>
        /// It's the timer that controls the exibition of progress
        /// </summary>
        private static Timer _timer;

        /// <summary>
        /// It´s a list of instances
        /// </summary>
        private static List<ProgressCounter> _progressCounterList = new List<ProgressCounter>();

        /// <summary>
        /// Creates an instance of object
        /// </summary>
        /// <param name="contextMap"></param>
        public ProgressCounter(ContextMap contextMap)
        {
            this._contextMap = contextMap;
        }

        /// <summary>
        /// Reset de progress counter
        /// </summary>
        public void Reset()
        {
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

            ProgressCounter counter;

            lock(_progressCounterList)
            {
                if (!_progressCounterList.Contains(this))
                {
                    _progressCounterList.Add(this);
                    counter = this;
                }
                else
                {
                    counter =
                        _progressCounterList.Find(delegate (ProgressCounter item)
                        {
                            return item == this;
                        });
                }
            }

            double currentPercentage =
                value / total * 100D;

            counter.Print(currentPercentage);
        }

        /// <summary>
        /// Print the progress
        /// </summary>
        private void Print(double currentPercentage)
        {
            try
            {
                this._buffer =
                    currentPercentage.ToString("0.###") + "%";

                lock(typeof(ProgressCounter))
                {
                    if (ProgressCounter._timer == null)
                    {
                        ProgressCounter._timer = new Timer(delegate (object state)
                        {
                            this.Refresh(_progressCounterList);
                        }, null, 0, 65); 
                    }
                }
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

        /// <summary>
        /// Refresh the screen informations
        /// </summary>
        private void Refresh(List<ProgressCounter> progressCounterList)
        {
            #region Entries validation

            if (progressCounterList.Count == 0)
            {
                return;
            }

            #endregion

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Processing... Please, wait...");

            foreach (var item in progressCounterList)
            {
                builder.AppendLine(item._buffer);
            }

            String output = builder.ToString();

            try
            {
                OutputManager.Clear(this._contextMap);
                OutputManager.WriteLine(this._contextMap, output);
            }
            catch (IOException)
            {
                // Errors in this process can't be mess the natural flow of process
            }

            foreach (var item in progressCounterList)
            {
                item.Reset();
            }
        }

        /// <summary>
        /// Stop the refresh
        /// </summary>
        public static void Stop()
        {
            #region Entries validation

            if (_timer == null)
            {
                throw new ArgumentNullException("_timer");
            }

            #endregion

            _timer.Dispose();
        }
    }
}
