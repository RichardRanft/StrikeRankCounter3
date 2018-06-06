namespace SRC3
{
    partial class FPlaylistEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPlaylistEditor));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbxFiles = new System.Windows.Forms.ListBox();
            this.lbxPlaylist = new System.Windows.Forms.ListBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbxFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxPlaylistSelect = new System.Windows.Forms.ComboBox();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.cmsPopMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPopMenuPlaylist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewPlayListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopPlayListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmsPopMenu.SuspendLayout();
            this.cmsPopMenuPlaylist.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(497, 551);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(578, 551);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbxFiles
            // 
            this.lbxFiles.FormattingEnabled = true;
            this.lbxFiles.HorizontalScrollbar = true;
            this.lbxFiles.Location = new System.Drawing.Point(12, 52);
            this.lbxFiles.Name = "lbxFiles";
            this.lbxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxFiles.Size = new System.Drawing.Size(372, 485);
            this.lbxFiles.TabIndex = 2;
            this.lbxFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxFiles_MouseDown);
            this.lbxFiles.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbxFiles_MouseUp);
            // 
            // lbxPlaylist
            // 
            this.lbxPlaylist.AllowDrop = true;
            this.lbxPlaylist.FormattingEnabled = true;
            this.lbxPlaylist.HorizontalScrollbar = true;
            this.lbxPlaylist.Location = new System.Drawing.Point(390, 78);
            this.lbxPlaylist.Name = "lbxPlaylist";
            this.lbxPlaylist.Size = new System.Drawing.Size(263, 459);
            this.lbxPlaylist.TabIndex = 3;
            this.lbxPlaylist.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbxPlaylist_DragDrop);
            this.lbxPlaylist.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbxPlaylist_DragEnter);
            this.lbxPlaylist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbxPlaylist_MouseUp);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(309, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbxFolder
            // 
            this.tbxFolder.Location = new System.Drawing.Point(12, 25);
            this.tbxFolder.Name = "tbxFolder";
            this.tbxFolder.Size = new System.Drawing.Size(291, 20);
            this.tbxFolder.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "File Path";
            // 
            // cbxPlaylistSelect
            // 
            this.cbxPlaylistSelect.FormattingEnabled = true;
            this.cbxPlaylistSelect.Location = new System.Drawing.Point(390, 52);
            this.cbxPlaylistSelect.Name = "cbxPlaylistSelect";
            this.cbxPlaylistSelect.Size = new System.Drawing.Size(263, 21);
            this.cbxPlaylistSelect.TabIndex = 7;
            this.cbxPlaylistSelect.SelectedIndexChanged += new System.EventHandler(this.cbxPlaylistSelect_SelectedIndexChanged);
            // 
            // fbdBrowse
            // 
            this.fbdBrowse.SelectedPath = ".\\";
            this.fbdBrowse.ShowNewFolderButton = false;
            // 
            // cmsPopMenu
            // 
            this.cmsPopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.cmsPopMenu.Name = "contextMenuStrip1";
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
            // cmsPopMenuPlaylist
            // 
            this.cmsPopMenuPlaylist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.previewPlayListMenuItem,
            this.stopPlayListMenuItem});
            this.cmsPopMenuPlaylist.Name = "cmsPopMenuPlaylist";
            this.cmsPopMenuPlaylist.Size = new System.Drawing.Size(118, 70);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // previewPlayListMenuItem
            // 
            this.previewPlayListMenuItem.Name = "previewPlayListMenuItem";
            this.previewPlayListMenuItem.Size = new System.Drawing.Size(117, 22);
            this.previewPlayListMenuItem.Text = "Preview";
            this.previewPlayListMenuItem.Click += new System.EventHandler(this.previewPlayListMenuItem_Click);
            // 
            // stopPlayListMenuItem
            // 
            this.stopPlayListMenuItem.Name = "stopPlayListMenuItem";
            this.stopPlayListMenuItem.Size = new System.Drawing.Size(117, 22);
            this.stopPlayListMenuItem.Text = "Stop";
            this.stopPlayListMenuItem.Click += new System.EventHandler(this.stopPlayListMenuItem_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(497, 23);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(578, 23);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(416, 23);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // FPlaylistEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(665, 586);
            this.ControlBox = false;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.cbxPlaylistSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxFolder);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lbxPlaylist);
            this.Controls.Add(this.lbxFiles);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FPlaylistEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Music Playlist Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FPlaylistEditor_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FPlaylistEditor_VisibleChanged);
            this.cmsPopMenu.ResumeLayout(false);
            this.cmsPopMenuPlaylist.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lbxFiles;
        private System.Windows.Forms.ListBox lbxPlaylist;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbxFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxPlaylistSelect;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.ContextMenuStrip cmsPopMenu;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewPlayListMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopPlayListMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsPopMenuPlaylist;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
    }
}