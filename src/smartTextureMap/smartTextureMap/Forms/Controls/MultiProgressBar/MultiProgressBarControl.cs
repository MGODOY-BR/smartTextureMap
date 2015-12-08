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
    public partial class MultiProgressBarControl : UserControl
    {
        /// <summary>
        /// It´s a list of items
        /// </summary>
        public String[] ItemList { get; set; }

        public MultiProgressBarControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the list
        /// </summary>
        public void DataBind()
        {
            #region Entries validation

            if (this.ItemList == null)
            {
                return;
            }

            #endregion

            int position = 0;
            this.panel1.Controls.Clear();

            foreach (var item in this.ItemList)
            {
                SingleProgressBarControl progressBar = new SingleProgressBarControl();
                progressBar.Display = item;
                progressBar.Top = position;
                this.panel1.Controls.Add(progressBar);

                position += progressBar.Size.Height;
            }
        }
    }
}
