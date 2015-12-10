namespace smartTextureMap.Forms.Controls.MultiProgressBar
{
    partial class SingleProgressBarControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblCaption = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnReRun = new System.Windows.Forms.Button();
            this.iconError = new System.Windows.Forms.PictureBox();
            this.pnlError = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconError)).BeginInit();
            this.pnlError.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 16);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(155, 10);
            this.progressBar1.TabIndex = 1;
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(3, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(55, 13);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Unkwown";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnReRun
            // 
            this.btnReRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReRun.Location = new System.Drawing.Point(111, 2);
            this.btnReRun.Name = "btnReRun";
            this.btnReRun.Size = new System.Drawing.Size(50, 24);
            this.btnReRun.TabIndex = 3;
            this.btnReRun.Text = "Rerun";
            this.btnReRun.UseVisualStyleBackColor = true;
            this.btnReRun.Click += new System.EventHandler(this.btnReRun_Click);
            // 
            // iconError
            // 
            this.iconError.Image = global::smartTextureMap.Properties.Resources.error;
            this.iconError.Location = new System.Drawing.Point(3, 2);
            this.iconError.Name = "iconError";
            this.iconError.Size = new System.Drawing.Size(23, 22);
            this.iconError.TabIndex = 4;
            this.iconError.TabStop = false;
            // 
            // pnlError
            // 
            this.pnlError.Controls.Add(this.btnReRun);
            this.pnlError.Controls.Add(this.iconError);
            this.pnlError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlError.Location = new System.Drawing.Point(0, 16);
            this.pnlError.Name = "pnlError";
            this.pnlError.Size = new System.Drawing.Size(164, 40);
            this.pnlError.TabIndex = 5;
            this.pnlError.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(3, 29);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Ready";
            // 
            // SingleProgressBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlError);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblStatus);
            this.Name = "SingleProgressBarControl";
            this.Size = new System.Drawing.Size(164, 56);
            ((System.ComponentModel.ISupportInitialize)(this.iconError)).EndInit();
            this.pnlError.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblCaption;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnReRun;
        private System.Windows.Forms.PictureBox iconError;
        private System.Windows.Forms.Panel pnlError;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblStatus;
    }
}
