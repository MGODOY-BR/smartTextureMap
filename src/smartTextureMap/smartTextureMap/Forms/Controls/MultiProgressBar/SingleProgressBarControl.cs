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
        /// Returns an indicator informing if the progress bar process concluded the processing. 
        /// </summary>
        public bool IsCompleted { get; private set; }

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
            this.pnlError.Visible = false;

            this.backgroundWorker1.RunWorkerAsync(this.FileName);
            this.lblStatus.Text = "Waiting...";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            String fileName = (String)e.Argument;

            using (SmartTextureMap smartMap = new SmartTextureMap())
            {
                var formOutput = (FormOutput)OutputManager.GetOutputWay();
                formOutput.RegisterOwner(smartMap.ContextMap, this);

                smartMap.Load(fileName);
                smartMap.Generate(
                    NewFileUtil.GetNewFullName(fileName));
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.lblStatus.Text = "RUNNING - " + e.ProgressPercentage + "%";
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                String message = GetErrorMessage(e.Error);

                this.toolTip1.SetToolTip(iconError, message);
                this.pnlError.Visible = true;
            }
            else
            {
                this.progressBar1.Value = 100;
                this.ReportComplete();
            }
        }

        /// <summary>
        /// Returns an error message 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        private string GetErrorMessage(Exception error)
        {
            #region Entries validation
            
            if (error == null)
            {
                throw new ArgumentNullException("error");
            }

            #endregion

            if (error is OutOfMemoryException)
            {
                return "Memória insuficiente. Talvez o sistema esteja muito ocupado. Aguarde os processos desocuparem e tente novamente";
            }
            else
            {
                return error.Message;
            }
        }

        private void btnReRun_Click(object sender, EventArgs e)
        {
            this.Run();
        }

        #region IReportProgress elements

        public void ReportProgress(double value)
        {
            try
            {
                this.backgroundWorker1.ReportProgress((int)value);
            }
            catch (InvalidOperationException)
            {
                // This kind of error can't stop the process.
            }
        }

        public void ReportComplete()
        {
            try
            {
                this.Visible = false;
            }
            catch
            {
                // Erros in here can't throws exception
            }
            finally
            {
                this.IsCompleted = true;
            }
        }

        #endregion

    }
}
