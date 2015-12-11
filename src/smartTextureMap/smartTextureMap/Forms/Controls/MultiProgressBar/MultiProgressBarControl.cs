using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace smartTextureMap.Forms.Controls.MultiProgressBar
{
    public partial class MultiProgressBarControl : UserControl
    {
        /// <summary>
        /// Occurs when all the progress bar conclude thair processing 
        /// </summary>
        public event EventHandler<EventArgs> AllRunningCompleted;

        /// <summary>
        /// It´s a list of pending progress bar to finish to process
        /// </summary>
        private List<SingleProgressBarControl> _pending = new List<SingleProgressBarControl>();

        /// <summary>
        /// It´s a list of items
        /// </summary>
        public String[] ItemList { get; set; }

        public MultiProgressBarControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        /// <summary>
        /// Updates the list and runs the processes
        /// </summary>
        public void Run()
        {
            #region Entries validation

            if (this.ItemList == null)
            {
                return;
            }

            #endregion

            _pending.Clear();
            this.panel1.Controls.Clear();

            foreach (var item in this.ItemList)
            {
                SingleProgressBarControl progressBar = new SingleProgressBarControl();
                _pending.Add(progressBar);

                progressBar.Width = this.Size.Width - 27;
                progressBar.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                progressBar.FileName = item;
                progressBar.Display = this.GetLastNames(item);

                this.panel1.Controls.Add(progressBar);

                // Running
                progressBar.Run();
            }

            this.timer1.Enabled = true;
        }

        /// <summary>
        /// Does on scanning of position of progress bar
        /// </summary>
        private void ScanProgressBarState(List<SingleProgressBarControl> singleProgressBarControlList)
        {
            #region Entries validation

            if (singleProgressBarControlList == null)
            {
                throw new ArgumentNullException("singleProgressBarControlList");
            }
            if (singleProgressBarControlList.Count == 0)
            {
                return;
            }

            #endregion

            int position = 0;
            foreach (var progressBar in singleProgressBarControlList)
            {
                if (progressBar.Visible)
                {
                    progressBar.Top = position;
                    position += progressBar.Size.Height;
                }
            }

            // Removing invisible controls
            singleProgressBarControlList.RemoveAll(delegate (SingleProgressBarControl progressBar)
            {
                return progressBar.Visible == false;
            });

            // Handling the progress
            bool concluded = true;
            foreach (Control control in this.panel1.Controls)
            {
                SingleProgressBarControl progressBar = control as SingleProgressBarControl;

                #region Entries validation

                if (progressBar == null)
                {
                    continue;
                }

                #endregion

                concluded &= progressBar.IsCompleted;
            }

            if (concluded)
            {
                this.OnAllRunningCompleted();
            }
        }

        /// <summary>
        /// Gets last names of file
        /// </summary>
        private string GetLastNames(string uri)
        {
            #region Entries validation

            if (String.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException("uri");
            }

            #endregion

            if (uri.IndexOf(@"\") == -1)
            {
                return Path.GetFileName(uri);
            }
            else
            {
                var uriPartList = uri.Split(char.Parse(@"\"));
                return @"...\" + uriPartList[uriPartList.Length - 2] + @"\" + uriPartList[uriPartList.Length - 1];
            }
        }

        /// <summary>
        /// Throw the event
        /// </summary>
        private void OnAllRunningCompleted()
        {
            #region Entries validation

            if (AllRunningCompleted == null)
            {
                return;
            }

            #endregion

            this.AllRunningCompleted(this, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ScanProgressBarState(this._pending);
        }
    }
}
