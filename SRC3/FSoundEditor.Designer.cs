namespace SRC3
{
    partial class FSoundEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSoundEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbxRanklistSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lbxRanklist = new System.Windows.Forms.ListBox();
            this.lbxFiles = new System.Windows.Forms.ListBox();
            this.cbxRoundlistSelect = new System.Windows.Forms.ComboBox();
            this.lbxRoundlist = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.cmsPopMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPopMenuRank = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPopMenuRound = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearRank = new System.Windows.Forms.Button();
            this.btnNewRank = new System.Windows.Forms.Button();
            this.btnClearRound = new System.Windows.Forms.Button();
            this.btnNewRound = new System.Windows.Forms.Button();
            this.btnUpdateRank = new System.Windows.Forms.Button();
            this.btnUpdateRound = new System.Windows.Forms.Button();
            this.cmsPopMenu.SuspendLayout();
            this.cmsPopMenuRank.SuspendLayout();
            this.cmsPopMenuRound.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(578, 578);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(497, 578);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbxRanklistSelect
            // 
            this.cbxRanklistSelect.FormattingEnabled = true;
            this.cbxRanklistSelect.Location = new System.Drawing.Point(390, 68);
            this.cbxRanklistSelect.Name = "cbxRanklistSelect";
            this.cbxRanklistSelect.Size = new System.Drawing.Size(263, 21);
            this.cbxRanklistSelect.TabIndex = 13;
            this.cbxRanklistSelect.SelectedIndexChanged += new System.EventHandler(this.cbxRanklistSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "File Path";
            // 
            // tbxFolder
            // 
            this.tbxFolder.Location = new System.Drawing.Point(12, 25);
            this.tbxFolder.Name = "tbxFolder";
            this.tbxFolder.Size = new System.Drawing.Size(291, 20);
            this.tbxFolder.TabIndex = 11;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(309, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lbxRanklist
            // 
            this.lbxRanklist.AllowDrop = true;
            this.lbxRanklist.FormattingEnabled = true;
            this.lbxRanklist.HorizontalScrollbar = true;
            this.lbxRanklist.Location = new System.Drawing.Point(390, 91);
            this.lbxRanklist.Name = "lbxRanklist";
            this.lbxRanklist.Size = new System.Drawing.Size(263, 173);
            this.lbxRanklist.TabIndex = 9;
            this.lbxRanklist.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbxRanklist_DragDrop);
            this.lbxRanklist.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbxRanklist_DragEnter);
            // 
            // lbxFiles
            // 
            this.lbxFiles.FormattingEnabled = true;
            this.lbxFiles.HorizontalScrollbar = true;
            this.lbxFiles.Location = new System.Drawing.Point(12, 52);
            this.lbxFiles.Name = "lbxFiles";
            this.lbxFiles.Size = new System.Drawing.Size(372, 511);
            this.lbxFiles.TabIndex = 8;
            this.lbxFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxFiles_MouseDown);
            this.lbxFiles.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbxFiles_MouseUp);
            // 
            // cbxRoundlistSelect
            // 
            this.cbxRoundlistSelect.FormattingEnabled = true;
            this.cbxRoundlistSelect.Location = new System.Drawing.Point(390, 326);
            this.cbxRoundlistSelect.Name = "cbxRoundlistSelect";
            this.cbxRoundlistSelect.Size = new System.Drawing.Size(263, 21);
            this.cbxRoundlistSelect.TabIndex = 14;
            this.cbxRoundlistSelect.SelectedIndexChanged += new System.EventHandler(this.cbxRoundlistSelect_SelectedIndexChanged);
            // 
            // lbxRoundlist
            // 
            this.lbxRoundlist.AllowDrop = true;
            this.lbxRoundlist.FormattingEnabled = true;
            this.lbxRoundlist.HorizontalScrollbar = true;
            this.lbxRoundlist.Location = new System.Drawing.Point(390, 352);
            this.lbxRoundlist.Name = "lbxRoundlist";
            this.lbxRoundlist.Size = new System.Drawing.Size(263, 212);
            this.lbxRoundlist.TabIndex = 15;
            this.lbxRoundlist.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbxRoundlist_DragDrop);
            this.lbxRoundlist.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbxRoundlist_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Rank List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Round List";
            // 
            // cmsPopMenu
            // 
            this.cmsPopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.cmsPopMenu.Name = "cmsPopMenu";
            this.cmsPopMenu.Size = new System.Drawing.Size(116, 48);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.previewToolStripMenuItem.Text = "Preview";
            this.previewToolStripMenuItem.Click += new System.EventHandler(this.previewToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // cmsPopMenuRank
            // 
            this.cmsPopMenuRank.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.cmsPopMenuRank.Name = "cmsPopMenuRank";
            this.cmsPopMenuRank.Size = new System.Drawing.Size(118, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // cmsPopMenuRound
            // 
            this.cmsPopMenuRound.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem1});
            this.cmsPopMenuRound.Name = "cmsPopMenuRound";
            this.cmsPopMenuRound.Size = new System.Drawing.Size(118, 26);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem1.Text = "Remove";
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem1_Click);
            // 
            // btnClearRank
            // 
            this.btnClearRank.Location = new System.Drawing.Point(578, 23);
            this.btnClearRank.Name = "btnClearRank";
            this.btnClearRank.Size = new System.Drawing.Size(75, 23);
            this.btnClearRank.TabIndex = 19;
            this.btnClearRank.Text = "Clear";
            this.btnClearRank.UseVisualStyleBackColor = true;
            this.btnClearRank.Click += new System.EventHandler(this.btnClearRank_Click);
            // 
            // btnNewRank
            // 
            this.btnNewRank.Location = new System.Drawing.Point(497, 23);
            this.btnNewRank.Name = "btnNewRank";
            this.btnNewRank.Size = new System.Drawing.Size(75, 23);
            this.btnNewRank.TabIndex = 18;
            this.btnNewRank.Text = "New";
            this.btnNewRank.UseVisualStyleBackColor = true;
            this.btnNewRank.Click += new System.EventHandler(this.btnNewRank_Click);
            // 
            // btnClearRound
            // 
            this.btnClearRound.Location = new System.Drawing.Point(578, 270);
            this.btnClearRound.Name = "btnClearRound";
            this.btnClearRound.Size = new System.Drawing.Size(75, 23);
            this.btnClearRound.TabIndex = 21;
            this.btnClearRound.Text = "Clear";
            this.btnClearRound.UseVisualStyleBackColor = true;
            this.btnClearRound.Click += new System.EventHandler(this.btnClearRound_Click);
            // 
            // btnNewRound
            // 
            this.btnNewRound.Location = new System.Drawing.Point(497, 270);
            this.btnNewRound.Name = "btnNewRound";
            this.btnNewRound.Size = new System.Drawing.Size(75, 23);
            this.btnNewRound.TabIndex = 20;
            this.btnNewRound.Text = "New";
            this.btnNewRound.UseVisualStyleBackColor = true;
            this.btnNewRound.Click += new System.EventHandler(this.btnNewRound_Click);
            // 
            // btnUpdateRank
            // 
            this.btnUpdateRank.Location = new System.Drawing.Point(416, 23);
            this.btnUpdateRank.Name = "btnUpdateRank";
            this.btnUpdateRank.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateRank.TabIndex = 22;
            this.btnUpdateRank.Text = "Update";
            this.btnUpdateRank.UseVisualStyleBackColor = true;
            this.btnUpdateRank.Click += new System.EventHandler(this.btnUpdateRank_Click);
            // 
            // btnUpdateRound
            // 
            this.btnUpdateRound.Location = new System.Drawing.Point(416, 270);
            this.btnUpdateRound.Name = "btnUpdateRound";
            this.btnUpdateRound.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateRound.TabIndex = 23;
            this.btnUpdateRound.Text = "Update";
            this.btnUpdateRound.UseVisualStyleBackColor = true;
            this.btnUpdateRound.Click += new System.EventHandler(this.btnUpdateRound_Click);
            // 
            // FSoundEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 608);
            this.ControlBox = false;
            this.Controls.Add(this.btnUpdateRound);
            this.Controls.Add(this.btnUpdateRank);
            this.Controls.Add(this.btnClearRound);
            this.Controls.Add(this.btnNewRound);
            this.Controls.Add(this.btnClearRank);
            this.Controls.Add(this.btnNewRank);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbxRoundlist);
            this.Controls.Add(this.cbxRoundlistSelect);
            this.Controls.Add(this.cbxRanklistSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxFolder);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lbxRanklist);
            this.Controls.Add(this.lbxFiles);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FSoundEditor";
            this.Text = "FX Playlist Editor";
            this.VisibleChanged += new System.EventHandler(this.FSoundEditor_VisibleChanged);
            this.cmsPopMenu.ResumeLayout(false);
            this.cmsPopMenuRank.ResumeLayout(false);
            this.cmsPopMenuRound.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbxRanklistSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ListBox lbxRanklist;
        private System.Windows.Forms.ListBox lbxFiles;
        private System.Windows.Forms.ComboBox cbxRoundlistSelect;
        private System.Windows.Forms.ListBox lbxRoundlist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.ContextMenuStrip cmsPopMenu;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsPopMenuRank;
        private System.Windows.Forms.ContextMenuStrip cmsPopMenuRound;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.Button btnClearRank;
        private System.Windows.Forms.Button btnNewRank;
        private System.Windows.Forms.Button btnClearRound;
        private System.Windows.Forms.Button btnNewRound;
        private System.Windows.Forms.Button btnUpdateRank;
        private System.Windows.Forms.Button btnUpdateRound;
    }
}