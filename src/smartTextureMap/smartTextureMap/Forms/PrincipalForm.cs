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
            var directoryNodeList = ConvertNodeList(directoryList, false);

            this.treeView1.CheckBoxes = true;
            this.treeView1.AfterCheck += TreeView1_AfterCheck;
            this.treeView1.Nodes.AddRange(directoryNodeList.ToArray());
            this.treeView1.ExpandAll();
        }

        /// <summary>
        /// Converts the list to list of treenodes.
        /// </summary>
        private List<TreeNode> ConvertNodeList(string[] uriList, bool handleUriAsFiles)
        {
            #region Entries validation
                            
            if (uriList == null)
            {
                throw new ArgumentNullException("directoryList");
            }

            #endregion

            List<TreeNode> returnList = new List<TreeNode>();

            foreach (var uriItem in uriList)
            {
                try
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Tag = uriItem;
                    treeNode.Text = Path.GetFileName(uriItem);

                    // Adding files
                    if (!handleUriAsFiles)
                    {
                        // Adding sub directories
                        treeNode.Nodes.AddRange(
                            ConvertNodeList(
                                Directory.GetDirectories(uriItem), 
                                false).ToArray());

                        treeNode.Nodes.AddRange(
                            ConvertNodeList(
                                GetExceptSmartMap(
                                    Directory.GetFiles(uriItem, "*.png")),
                                true).ToArray());

                        treeNode.Nodes.AddRange(
                            ConvertNodeList(
                                GetExceptSmartMap(
                                    Directory.GetFiles(uriItem, "*.bmp")),
                                true).ToArray());
                    }
                    // Handling files
                    else
                    {
                        treeNode.Checked = true;
                    }

                    returnList.Add(treeNode);
                }
                catch (IOException)
                {
                    // Errors of this kind in this location cannot turns around the normal flow of algoritmn
                    continue;
                }
                catch (UnauthorizedAccessException)
                {
                    // Errors of this kind in this location cannot turns around the normal flow of algoritmn
                    continue;
                }
           }

            return returnList;
        }

        /// <summary>
        /// Get a list informed, except for the smartMaps files.
        /// </summary>
        /// <param name="fileList"></param>
        /// <returns></returns>
        private string[] GetExceptSmartMap(string[] fileList)
        {
            #region Entries validation

            if (fileList == null)
            {
                throw new ArgumentNullException("fileList");
            }

            #endregion

            List<String> fileListTemp = new List<string>(fileList);
            return fileListTemp.FindAll(delegate (String item)
            {
                return !item.Contains(".smartMap.");
            }).ToArray();
        }

        /// <summary>
        /// Handles the click on check boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                return;
            }

            foreach (var item in e.Node.Nodes)
            {
                ((TreeNode)item).Checked = e.Node.Checked;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var selectedNodeList = 
                GetSelectedNodesString(this.treeView1.Nodes);

            this.multiProgressBarControl1.ItemList = selectedNodeList;
            this.multiProgressBarControl1.DataBind();
        }

        /// <summary>
        /// Gets the list of selected nodes
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private String[] GetSelectedNodesString(TreeNodeCollection nodes)
        {
            var selectedNodeList = this.GetSelectedNodes(nodes);

            List<String> retunedList = new List<string>();

            foreach (var item in selectedNodeList)
            {
                retunedList.Add(
                    GetLastNames((String)item.Tag));
            }

            return retunedList.ToArray();
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
        /// Gets the list of selected nodes
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private List<TreeNode> GetSelectedNodes(TreeNodeCollection nodes)
        {
            #region Entries validation

            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            #endregion

            List<TreeNode> returnValueList = new List<TreeNode>();

            foreach (var item in nodes)
            {
                TreeNode treeNode = (TreeNode)item;

                #region Entries validation

                if (treeNode.Nodes.Count > 0)
                {
                    returnValueList.AddRange(
                        this.GetSelectedNodes(treeNode.Nodes));

                    continue;
                }

                #endregion

                if (treeNode.Checked)
                {
                    returnValueList.Add(treeNode);
                }
            }

            return returnValueList;
        }
    }
}
