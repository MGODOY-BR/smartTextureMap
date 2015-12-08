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

namespace smartTextureMap.Forms.Controls.MultiProgressBar
{
    public partial class SingleProgressBarControl : UserControl
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
            smartMap.Generate(fileName);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
    }
}
