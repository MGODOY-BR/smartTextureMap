using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using smartTextureMap.Intelligence;
using smartTextureMap.IO;
using System.IO;
using System.Threading;

namespace smartTextureMap.Forms.Controls.MultiProgressBar
{
    public partial class SingleProgressBarControl : UserControl, IReportProgress
    {
        /// <summary>
        /// It´s the fileName
        /// </summary>
        public String FileName { get; set; }

        /// <summary>
        /// It´s the text to display
        /// </summary>
        public String Display
        {
            get
            {
                return this.lblCaption.Text;
            }
            set
            {
                this.lblCaption.Text = value;
            }
        }

        public SingleProgressBarControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs the process
        /// </summary>
        public void Run()
        {
            this.backgroundWorker1.RunWorkerAsync(this.FileName);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            String fileName = (String)e.Argument;

            SmartTextureMap smartMap = new SmartTextureMap();

            var formOutput = (FormOutput)OutputManager.GetOutputWay();
            formOutput.RegisterOwner(smartMap.ContextMap, this);

            smartMap.Load(fileName);
            smartMap.Generate(
                NewFileUtil.GetNewFullName(fileName));
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        #region IReportProgress elements

        public void ReportProgress(double value)
        {
            this.backgroundWorker1.ReportProgress((int)value);
        }

        public void ReportComplete()
        {
            this.Visible = false;
        }

        #endregion

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar1.Value = 100;
            this.ReportComplete();
        }
    }
}
