namespace smartTextureMap.Forms
{
    partial class PrincipalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSourceFolder = new System.Windows.Forms.Panel();
            this.titleControl4 = new smartTextureMap.Forms.Controls.TitleControl();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.pnlTreeView = new System.Windows.Forms.Panel();
            this.titleControl5 = new smartTextureMap.Forms.Controls.TitleControl();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pnlRunning = new System.Windows.Forms.Panel();
            this.pnlRunningResult = new System.Windows.Forms.Panel();
            this.multiProgressBarControl1 = new smartTextureMap.Forms.Controls.MultiProgressBar.MultiProgressBarControl();
            this.titleControl6 = new smartTextureMap.Forms.Controls.TitleControl();
            this.btnRun = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlSourceFolder.SuspendLayout();
            this.pnlTreeView.SuspendLayout();
            this.pnlRunning.SuspendLayout();
            this.pnlRunningResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 386);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(903, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(903, 386);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 44);
            this.panel1.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(7, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(51, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Indefined";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::smartTextureMap.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(494, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.pnlSourceFolder, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlTreeView, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlRunning, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(897, 330);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // pnlSourceFolder
            // 
            this.pnlSourceFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlSourceFolder.Controls.Add(this.titleControl4);
            this.pnlSourceFolder.Controls.Add(this.txtSourceFolder);
            this.pnlSourceFolder.Controls.Add(this.btnOpenFolder);
            this.pnlSourceFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSourceFolder.Location = new System.Drawing.Point(3, 3);
            this.pnlSourceFolder.Name = "pnlSourceFolder";
            this.pnlSourceFolder.Size = new System.Drawing.Size(293, 324);
            this.pnlSourceFolder.TabIndex = 0;
            // 
            // titleControl4
            // 
            this.titleControl4.Icon = global::smartTextureMap.Properties.Resources.Step1;
            this.titleControl4.Location = new System.Drawing.Point(18, 13);
            this.titleControl4.Name = "titleControl4";
            this.titleControl4.Size = new System.Drawing.Size(238, 41);
            this.titleControl4.TabIndex = 3;
            this.titleControl4.TitleText = "Select where the textures are";
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceFolder.Location = new System.Drawing.Point(18, 91);
            this.txtSourceFolder.Multiline = true;
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(263, 214);
            this.txtSourceFolder.TabIndex = 2;
            this.txtSourceFolder.Leave += new System.EventHandler(this.txtSourceFolder_Leave);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(18, 60);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(37, 24);
            this.btnOpenFolder.TabIndex = 1;
            this.btnOpenFolder.Text = "...";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // pnlTreeView
            // 
            this.pnlTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pnlTreeView.Controls.Add(this.titleControl5);
            this.pnlTreeView.Controls.Add(this.treeView1);
            this.pnlTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTreeView.Location = new System.Drawing.Point(302, 3);
            this.pnlTreeView.Name = "pnlTreeView";
            this.pnlTreeView.Size = new System.Drawing.Size(293, 324);
            this.pnlTreeView.TabIndex = 1;
            // 
            // titleControl5
            // 
            this.titleControl5.Icon = global::smartTextureMap.Properties.Resources.Step2;
            this.titleControl5.Location = new System.Drawing.Point(11, 13);
            this.titleControl5.Name = "titleControl5";
            this.titleControl5.Size = new System.Drawing.Size(238, 41);
            this.titleControl5.TabIndex = 2;
            this.titleControl5.TitleText = "Check the texture which you want to mark";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(11, 91);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(270, 214);
            this.treeView1.TabIndex = 1;
            // 
            // pnlRunning
            // 
            this.pnlRunning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pnlRunning.Controls.Add(this.pnlRunningResult);
            this.pnlRunning.Controls.Add(this.titleControl6);
            this.pnlRunning.Controls.Add(this.btnRun);
            this.pnlRunning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRunning.Location = new System.Drawing.Point(601, 3);
            this.pnlRunning.Name = "pnlRunning";
            this.pnlRunning.Size = new System.Drawing.Size(293, 324);
            this.pnlRunning.TabIndex = 2;
            // 
            // pnlRunningResult
            // 
            this.pnlRunningResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRunningResult.Controls.Add(this.multiProgressBarControl1);
            this.pnlRunningResult.Location = new System.Drawing.Point(15, 127);
            this.pnlRunningResult.Name = "pnlRunningResult";
            this.pnlRunningResult.Size = new System.Drawing.Size(263, 178);
            this.pnlRunningResult.TabIndex = 3;
            this.pnlRunningResult.Visible = false;
            // 
            // multiProgressBarControl1
            // 
            this.multiProgressBarControl1.AutoScroll = true;
            this.multiProgressBarControl1.BackColor = System.Drawing.Color.White;
            this.multiProgressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiProgressBarControl1.ItemList = new string[0];
            this.multiProgressBarControl1.Location = new System.Drawing.Point(0, 0);
            this.multiProgressBarControl1.Name = "multiProgressBarControl1";
            this.multiProgressBarControl1.Size = new System.Drawing.Size(263, 178);
            this.multiProgressBarControl1.TabIndex = 2;
            // 
            // titleControl6
            // 
            this.titleControl6.Icon = global::smartTextureMap.Properties.Resources.Step3;
            this.titleControl6.Location = new System.Drawing.Point(15, 13);
            this.titleControl6.Name = "titleControl6";
            this.titleControl6.Size = new System.Drawing.Size(251, 72);
            this.titleControl6.TabIndex = 2;
            this.titleControl6.TitleText = "Run! After that, localize in the same folder of original texture for smartMap ver" +
    "sions";
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(15, 91);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(65, 30);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run!!";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select a source folder";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 408);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "PrincipalForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnlSourceFolder.ResumeLayout(false);
            this.pnlSourceFolder.PerformLayout();
            this.pnlTreeView.ResumeLayout(false);
            this.pnlRunning.ResumeLayout(false);
            this.pnlRunningResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnlSourceFolder;
        private System.Windows.Forms.Panel pnlTreeView;
        private System.Windows.Forms.Panel pnlRunning;
        private Controls.TitleControl titleControl1;
        private Controls.TitleControl titleControl2;
        private Controls.TitleControl titleControl3;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnRun;
        private Controls.TitleControl titleControl4;
        private Controls.TitleControl titleControl5;
        private Controls.TitleControl titleControl6;
        private Controls.MultiProgressBar.MultiProgressBarControl multiProgressBarControl1;
        private System.Windows.Forms.Panel pnlRunningResult;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblVersion;
    }
}