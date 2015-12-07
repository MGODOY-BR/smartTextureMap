using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartTextureMap.Forms
{
    public partial class PrincipalForm : Form
    {
        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            if (this.folderBrowserDialog1.SelectedPath != null)
            {
                this.txtSourceFolder.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void txtSourceFolder_TextChanged(object sender, EventArgs e)
        {
            RefreshTreeViewList(this.txtSourceFolder.Text, this.treeView1.Nodes);
        }

        /// <summary>
        /// Refresh the tree view list
        /// </summary>
        private void RefreshTreeViewList(String sourceFolder, TreeNodeCollection nodes)
        {
            throw new NotImplementedException();
        }
    }
}
