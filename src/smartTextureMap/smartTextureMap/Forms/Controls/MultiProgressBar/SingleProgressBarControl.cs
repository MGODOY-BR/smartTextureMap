using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartTextureMap.Forms.Controls.MultiProgressBar
{
    public partial class SingleProgressBarControl : UserControl
    {
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
    }
}
