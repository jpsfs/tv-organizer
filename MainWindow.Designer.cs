namespace tv_organizer
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.labelSelectedPath = new System.Windows.Forms.Label();
            this.textBoxSelectedPath = new System.Windows.Forms.TextBox();
            this.buttonChoosePath = new System.Windows.Forms.Button();
            this.splitContainerMainWindow = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPrimaryLanguage = new System.Windows.Forms.ComboBox();
            this.linkLabelDevelopedBy = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabelEasySubtitles = new System.Windows.Forms.LinkLabel();
            this.checkBoxManualPath = new System.Windows.Forms.CheckBox();
            this.buttonSearchSubtitles = new System.Windows.Forms.Button();
            this.buttonDownloadSubtitles = new System.Windows.Forms.Button();
            this.buttonOrganizeFolders = new System.Windows.Forms.Button();
            this.buttonSearchForEpisodes = new System.Windows.Forms.Button();
            this.dataGridViewEpisodes = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerSearchEpisodes = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearchSubtitles = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDownloadSubtitles = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerOrganizeFolders = new System.ComponentModel.BackgroundWorker();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainWindow)).BeginInit();
            this.splitContainerMainWindow.Panel1.SuspendLayout();
            this.splitContainerMainWindow.Panel2.SuspendLayout();
            this.splitContainerMainWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEpisodes)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 565);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(747, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBarLabel
            // 
            this.toolStripProgressBarLabel.AutoSize = false;
            this.toolStripProgressBarLabel.Name = "toolStripProgressBarLabel";
            this.toolStripProgressBarLabel.Size = new System.Drawing.Size(250, 17);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.AutoSize = false;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(250, 16);
            // 
            // labelSelectedPath
            // 
            this.labelSelectedPath.AutoSize = true;
            this.labelSelectedPath.Location = new System.Drawing.Point(12, 42);
            this.labelSelectedPath.Name = "labelSelectedPath";
            this.labelSelectedPath.Size = new System.Drawing.Size(74, 13);
            this.labelSelectedPath.TabIndex = 2;
            this.labelSelectedPath.Text = "Selected Path";
            // 
            // textBoxSelectedPath
            // 
            this.textBoxSelectedPath.Enabled = false;
            this.textBoxSelectedPath.Location = new System.Drawing.Point(92, 39);
            this.textBoxSelectedPath.Name = "textBoxSelectedPath";
            this.textBoxSelectedPath.Size = new System.Drawing.Size(340, 20);
            this.textBoxSelectedPath.TabIndex = 3;
            this.textBoxSelectedPath.TextChanged += new System.EventHandler(this.textBoxSelectedPath_TextChanged);
            // 
            // buttonChoosePath
            // 
            this.buttonChoosePath.Location = new System.Drawing.Point(438, 37);
            this.buttonChoosePath.Name = "buttonChoosePath";
            this.buttonChoosePath.Size = new System.Drawing.Size(75, 23);
            this.buttonChoosePath.TabIndex = 4;
            this.buttonChoosePath.Text = "Choose";
            this.buttonChoosePath.UseVisualStyleBackColor = true;
            this.buttonChoosePath.Click += new System.EventHandler(this.buttonChoosePath_Click);
            // 
            // splitContainerMainWindow
            // 
            this.splitContainerMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainWindow.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainWindow.Name = "splitContainerMainWindow";
            this.splitContainerMainWindow.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMainWindow.Panel1
            // 
            this.splitContainerMainWindow.Panel1.Controls.Add(this.label1);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.comboBoxPrimaryLanguage);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.linkLabelDevelopedBy);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.linkLabelEasySubtitles);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.checkBoxManualPath);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.buttonSearchSubtitles);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.buttonDownloadSubtitles);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.buttonOrganizeFolders);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.buttonSearchForEpisodes);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.buttonChoosePath);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.textBoxSelectedPath);
            this.splitContainerMainWindow.Panel1.Controls.Add(this.labelSelectedPath);
            // 
            // splitContainerMainWindow.Panel2
            // 
            this.splitContainerMainWindow.Panel2.Controls.Add(this.dataGridViewEpisodes);
            this.splitContainerMainWindow.Size = new System.Drawing.Size(747, 587);
            this.splitContainerMainWindow.SplitterDistance = 142;
            this.splitContainerMainWindow.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Primary Language";
            // 
            // comboBoxPrimaryLanguage
            // 
            this.comboBoxPrimaryLanguage.Enabled = false;
            this.comboBoxPrimaryLanguage.FormattingEnabled = true;
            this.comboBoxPrimaryLanguage.Items.AddRange(new object[] {
            "pt",
            "en",
            "fr",
            "de",
            "rm"});
            this.comboBoxPrimaryLanguage.Location = new System.Drawing.Point(288, 104);
            this.comboBoxPrimaryLanguage.Name = "comboBoxPrimaryLanguage";
            this.comboBoxPrimaryLanguage.Size = new System.Drawing.Size(49, 21);
            this.comboBoxPrimaryLanguage.TabIndex = 1;
            this.comboBoxPrimaryLanguage.SelectionChangeCommitted += new System.EventHandler(this.comboBoxPrimaryLanguage_SelectionChangeCommitted);
            // 
            // linkLabelDevelopedBy
            // 
            this.linkLabelDevelopedBy.AutoSize = true;
            this.linkLabelDevelopedBy.LinkArea = new System.Windows.Forms.LinkArea(41, 16);
            this.linkLabelDevelopedBy.Location = new System.Drawing.Point(628, 42);
            this.linkLabelDevelopedBy.Name = "linkLabelDevelopedBy";
            this.linkLabelDevelopedBy.Size = new System.Drawing.Size(107, 55);
            this.linkLabelDevelopedBy.TabIndex = 12;
            this.linkLabelDevelopedBy.TabStop = true;
            this.linkLabelDevelopedBy.Text = "Developed By:\r\n    José Pedro Silva\r\n    http://jpsfs.com\r\n    Version 0.1\r\n";
            this.linkLabelDevelopedBy.UseCompatibleTextRendering = true;
            this.linkLabelDevelopedBy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDevelopedBy_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::tv_organize.Properties.Resources.tv_organizer_logo;
            this.pictureBox1.Location = new System.Drawing.Point(519, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabelEasySubtitles
            // 
            this.linkLabelEasySubtitles.AutoSize = true;
            this.linkLabelEasySubtitles.LinkArea = new System.Windows.Forms.LinkArea(15, 5);
            this.linkLabelEasySubtitles.Location = new System.Drawing.Point(628, 110);
            this.linkLabelEasySubtitles.Name = "linkLabelEasySubtitles";
            this.linkLabelEasySubtitles.Size = new System.Drawing.Size(112, 17);
            this.linkLabelEasySubtitles.TabIndex = 10;
            this.linkLabelEasySubtitles.TabStop = true;
            this.linkLabelEasySubtitles.Text = "Subtitles from SubDB";
            this.linkLabelEasySubtitles.UseCompatibleTextRendering = true;
            this.linkLabelEasySubtitles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEasySubtitles_LinkClicked);
            // 
            // checkBoxManualPath
            // 
            this.checkBoxManualPath.AutoSize = true;
            this.checkBoxManualPath.Location = new System.Drawing.Point(15, 109);
            this.checkBoxManualPath.Name = "checkBoxManualPath";
            this.checkBoxManualPath.Size = new System.Drawing.Size(122, 17);
            this.checkBoxManualPath.TabIndex = 9;
            this.checkBoxManualPath.Text = "Enable Manual Path";
            this.checkBoxManualPath.UseVisualStyleBackColor = true;
            // 
            // buttonSearchSubtitles
            // 
            this.buttonSearchSubtitles.Enabled = false;
            this.buttonSearchSubtitles.Location = new System.Drawing.Point(366, 76);
            this.buttonSearchSubtitles.Name = "buttonSearchSubtitles";
            this.buttonSearchSubtitles.Size = new System.Drawing.Size(147, 23);
            this.buttonSearchSubtitles.TabIndex = 8;
            this.buttonSearchSubtitles.Text = "Search Subtitles";
            this.buttonSearchSubtitles.UseVisualStyleBackColor = true;
            this.buttonSearchSubtitles.Click += new System.EventHandler(this.buttonSearchSubtitles_Click);
            // 
            // buttonDownloadSubtitles
            // 
            this.buttonDownloadSubtitles.Enabled = false;
            this.buttonDownloadSubtitles.Location = new System.Drawing.Point(366, 104);
            this.buttonDownloadSubtitles.Name = "buttonDownloadSubtitles";
            this.buttonDownloadSubtitles.Size = new System.Drawing.Size(147, 23);
            this.buttonDownloadSubtitles.TabIndex = 7;
            this.buttonDownloadSubtitles.Text = "Download Subtitles";
            this.buttonDownloadSubtitles.UseVisualStyleBackColor = true;
            this.buttonDownloadSubtitles.Click += new System.EventHandler(this.buttonDownloadSubtitles_Click);
            // 
            // buttonOrganizeFolders
            // 
            this.buttonOrganizeFolders.Enabled = false;
            this.buttonOrganizeFolders.Location = new System.Drawing.Point(190, 76);
            this.buttonOrganizeFolders.Name = "buttonOrganizeFolders";
            this.buttonOrganizeFolders.Size = new System.Drawing.Size(147, 23);
            this.buttonOrganizeFolders.TabIndex = 6;
            this.buttonOrganizeFolders.Text = "Organize Folders";
            this.buttonOrganizeFolders.UseVisualStyleBackColor = true;
            this.buttonOrganizeFolders.Click += new System.EventHandler(this.buttonOrganizeFolders_Click);
            // 
            // buttonSearchForEpisodes
            // 
            this.buttonSearchForEpisodes.Enabled = false;
            this.buttonSearchForEpisodes.Location = new System.Drawing.Point(15, 76);
            this.buttonSearchForEpisodes.Name = "buttonSearchForEpisodes";
            this.buttonSearchForEpisodes.Size = new System.Drawing.Size(147, 23);
            this.buttonSearchForEpisodes.TabIndex = 5;
            this.buttonSearchForEpisodes.Text = "Search for Episodes";
            this.buttonSearchForEpisodes.UseVisualStyleBackColor = true;
            this.buttonSearchForEpisodes.Click += new System.EventHandler(this.buttonSearchForEpisodes_Click);
            // 
            // dataGridViewEpisodes
            // 
            this.dataGridViewEpisodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEpisodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEpisodes.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEpisodes.Name = "dataGridViewEpisodes";
            this.dataGridViewEpisodes.Size = new System.Drawing.Size(747, 441);
            this.dataGridViewEpisodes.TabIndex = 0;
            this.dataGridViewEpisodes.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewEpisodes_DataBindingComplete);
            this.dataGridViewEpisodes.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewEpisodes_EditingControlShowing);
            // 
            // backgroundWorkerSearchEpisodes
            // 
            this.backgroundWorkerSearchEpisodes.WorkerReportsProgress = true;
            this.backgroundWorkerSearchEpisodes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearchEpisodes_DoWork);
            this.backgroundWorkerSearchEpisodes.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorkerSearchEpisodes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearchEpisodes_RunWorkerCompleted);
            // 
            // backgroundWorkerSearchSubtitles
            // 
            this.backgroundWorkerSearchSubtitles.WorkerReportsProgress = true;
            this.backgroundWorkerSearchSubtitles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearchSubtitles_DoWork);
            this.backgroundWorkerSearchSubtitles.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorkerSearchSubtitles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearchSubtitles_RunWorkerCompleted);
            // 
            // backgroundWorkerDownloadSubtitles
            // 
            this.backgroundWorkerDownloadSubtitles.WorkerReportsProgress = true;
            this.backgroundWorkerDownloadSubtitles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDownloadSubtitles_DoWork);
            this.backgroundWorkerDownloadSubtitles.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorkerDownloadSubtitles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDownloadSubtitles_RunWorkerCompleted);
            // 
            // backgroundWorkerOrganizeFolders
            // 
            this.backgroundWorkerOrganizeFolders.WorkerReportsProgress = true;
            this.backgroundWorkerOrganizeFolders.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerOrganizeFolders_DoWork);
            this.backgroundWorkerOrganizeFolders.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorkerOrganizeFolders.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerOrganizeFolders_RunWorkerCompleted);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 587);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainerMainWindow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Tv Series Organizer";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainerMainWindow.Panel1.ResumeLayout(false);
            this.splitContainerMainWindow.Panel1.PerformLayout();
            this.splitContainerMainWindow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainWindow)).EndInit();
            this.splitContainerMainWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEpisodes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProgressBarLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label labelSelectedPath;
        private System.Windows.Forms.TextBox textBoxSelectedPath;
        private System.Windows.Forms.Button buttonChoosePath;
        private System.Windows.Forms.SplitContainer splitContainerMainWindow;
        private System.Windows.Forms.Button buttonSearchForEpisodes;
        private System.Windows.Forms.DataGridView dataGridViewEpisodes;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearchEpisodes;
        private System.Windows.Forms.Button buttonDownloadSubtitles;
        private System.Windows.Forms.Button buttonOrganizeFolders;
        private System.Windows.Forms.Button buttonSearchSubtitles;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearchSubtitles;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDownloadSubtitles;
        private System.ComponentModel.BackgroundWorker backgroundWorkerOrganizeFolders;
        private System.Windows.Forms.CheckBox checkBoxManualPath;
        private System.Windows.Forms.LinkLabel linkLabelEasySubtitles;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabelDevelopedBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPrimaryLanguage;
    }
}

