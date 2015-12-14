using smartTextureMap.Properties;
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

            this.ShowRunningResult(false);

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
        /// Shows the runnnig result
        /// </summary>
        private void ShowRunningResult(bool visibility)
        {
            this.pnlRunningResult.Visible = visibility;
            this.btnRun.Enabled = !this.pnlRunningResult.Visible;
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
                retunedList.Add((String)item.Tag);
            }

            return retunedList.ToArray();
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

        /// <summary>
        /// Loads settings
        /// </summary>
        private void LoadSettings()
        {
            if (!String.IsNullOrEmpty(Settings.Default.lastSourceFolder))
            {
                this.txtSourceFolder.Text = Settings.Default.lastSourceFolder;
                this.folderBrowserDialog1.SelectedPath = this.txtSourceFolder.Text.Trim();
            }
            else
            {
                this.txtSourceFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }

            this.lblVersion.Text = this.GetType().Assembly.GetName().Version.ToString() + "(Alpha)";

            this.RefreshForm();
        }

        /// <summary>
        /// Refreshes the form
        /// </summary>
        private void RefreshForm()
        {
            if (!Directory.Exists(this.txtSourceFolder.Text))
            {
                return;
            }

            try
            {
                this.Interrupt();

                this.RefreshTreeViewList(this.txtSourceFolder.Text, this.treeView1.Nodes);

                this.folderBrowserDialog1.SelectedPath = this.txtSourceFolder.Text.Trim();
                Settings.Default.lastSourceFolder = this.txtSourceFolder.Text.Trim();
                Settings.Default.Save();
            }
            finally
            {
                this.Resume();
            }
        }

        /// <summary>
        /// Interrupts the user interface
        /// </summary>
        private void Interrupt()
        {
            this.EnableForm(false);
        }

        /// <summary>
        /// Resumes the user interface
        /// </summary>
        private void Resume()
        {
            this.EnableForm(true);
        }

        /// <summary>
        /// Enables / disables form
        /// </summary>
        /// <param name="enabled"></param>
        private void EnableForm(bool enabled)
        {
            if (enabled)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
            }

            this.pnlSourceFolder.Enabled = enabled;
            this.pnlTreeView.Enabled = enabled;
            this.pnlRunning.Enabled = enabled;
        }

        #region Events

        /// <summary>
        /// Loads the form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.LoadSettings();

            this.multiProgressBarControl1.AllRunningCompleted += MultiProgressBarControl1_AllRunningCompleted;
            this.FormClosed += PrincipalForm_FormClosed;
        }

        /// <summary>
        /// Occurs when the form has closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrincipalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Occurs when all the progress has completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MultiProgressBarControl1_AllRunningCompleted(object sender, EventArgs e)
        {
            this.btnRun.Enabled = true;
            this.pnlTreeView.Enabled = true;
            this.pnlSourceFolder.Enabled = true;
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

        /// <summary>
        /// Executes texture mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            var selectedNodeList = 
                GetSelectedNodesString(this.treeView1.Nodes);

            if (selectedNodeList.Length == 0)
            {
                MessageBox.Show("None file to analyse.", "Nothing to do...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ShowRunningResult(false);
                return;
            }

            this.ShowRunningResult(true);

            this.multiProgressBarControl1.ItemList = selectedNodeList;
            this.multiProgressBarControl1.Run();

            this.btnRun.Enabled = false;
            this.pnlTreeView.Enabled = false;
            this.pnlSourceFolder.Enabled = false;

        }

        /// <summary>
        /// Open folders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            if (this.folderBrowserDialog1.SelectedPath != null)
            {
                this.txtSourceFolder.Text = this.folderBrowserDialog1.SelectedPath;
                this.RefreshForm();
            }
        }

        /// <summary>
        /// Ocurrs when the user leaves the focus of source folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSourceFolder_Leave(object sender, EventArgs e)
        {
            this.RefreshForm();
        }

        #endregion
    }
}
