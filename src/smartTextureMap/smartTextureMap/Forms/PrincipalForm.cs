using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            #region Entries validation
            
            if (String.IsNullOrEmpty(sourceFolder))
            {
                throw new ArgumentNullException("sourceFolder");
            }
            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            #endregion

            nodes.Clear();

            var directoryList = Directory.GetDirectories(sourceFolder);
            var directoryNodeList = ConvertNodeList(directoryList);

            this.treeView1.Nodes.AddRange(directoryNodeList.ToArray());
        }

        /// <summary>
        /// Converts the list to list of treenodes.
        /// </summary>
        private List<TreeNode> ConvertNodeList(string[] directoryList)
        {
            #region Entries validation
                            
            if (directoryList == null)
            {
                throw new ArgumentNullException("directoryList");
            }

            #endregion

            List<TreeNode> returnList = new List<TreeNode>();

            foreach (var directoryItem in directoryList)
            {
                try
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Tag = directoryItem;
                    treeNode.Text = Path.GetFileName(directoryItem);

                    treeNode.Nodes.AddRange(
                        ConvertNodeList(
                            Directory.GetDirectories(directoryItem)).ToArray());

                    returnList.Add(treeNode);
                }
                catch (UnauthorizedAccessException)
                {
                    // Errors of this kind in this location cannot turns around the normal flow of algoritmn
                    continue;
                }
           }

            return returnList;
        }
    }
}
