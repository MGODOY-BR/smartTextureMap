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
        /// Determines if the progress counter is the main one.
        /// </summary>
        public bool IsMainProgress { get; private set; }

        /// <summary>
        /// It´s a list of instances
        /// </summary>
        private static List<ProgressCounter> _progressCounterList = new List<ProgressCounter>();

        /// <summary>
        /// Creates an instance of object
        /// </summary>
        public ProgressCounter(ContextMap contextMap, bool isMainProgress)
        {
            this._contextMap = contextMap;
            this.IsMainProgress = isMainProgress;
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
                            ProgressCounter.Refresh(_progressCounterList);
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
        private static void Refresh(List<ProgressCounter> progressCounterList)
        {
            #region Entries validation

            if (progressCounterList.Count == 0)
            {
                return;
            }

            #endregion

            lock (progressCounterList)
            {
                foreach (var progressCounter in progressCounterList)
                {
                    try
                    {
                        OutputManager.Clear(progressCounter, progressCounter._contextMap);
                        OutputManager.WriteLine(progressCounter, progressCounter._contextMap, progressCounter._buffer);
                    }
                    catch (IOException)
                    {
                        // Errors in this process can't be mess the natural flow of process
                    }

                    progressCounter.Reset();
                }
            }
        }

        /// <summary>
        /// Stop the refresh for current progress counter
        /// </summary>
        public static void Stop(ProgressCounter progressCounter)
        {
            #region Entries validation

            if (_timer == null)
            {
                throw new ArgumentNullException("_timer");
            }
            if (progressCounter == null)
            {
                throw new ArgumentNullException("progressCounter");
            }

            #endregion

            lock (_progressCounterList)
            {
                _progressCounterList.Remove(progressCounter);

                if (_progressCounterList.Count == 0)
                {
                    _timer.Dispose();
                }
            }
        }
    }
}
