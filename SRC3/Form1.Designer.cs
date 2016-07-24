namespace SRC3
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRound = new System.Windows.Forms.Label();
            this.tbrFXVol = new System.Windows.Forms.TrackBar();
            this.tbrVolume = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lbxRoundSelect = new System.Windows.Forms.ListBox();
            this.lbxPlaylistSelect = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHelp = new System.Windows.Forms.Label();
            this.lblRank = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxRankSelect = new System.Windows.Forms.ListBox();
            this.cmsPopMainPlayback = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleRandomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrFXVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrVolume)).BeginInit();
            this.panel2.SuspendLayout();
            this.cmsPopMainPlayback.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblRound);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 274);
            this.panel1.TabIndex = 0;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.ForeColor = System.Drawing.Color.Red;
            this.lblRound.Location = new System.Drawing.Point(494, 88);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(98, 108);
            this.lblRound.TabIndex = 0;
            this.lblRound.Text = "0";
            // 
            // tbrFXVol
            // 
            this.tbrFXVol.Location = new System.Drawing.Point(203, 104);
            this.tbrFXVol.Maximum = 50;
            this.tbrFXVol.Name = "tbrFXVol";
            this.tbrFXVol.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbrFXVol.Size = new System.Drawing.Size(45, 108);
            this.tbrFXVol.TabIndex = 6;
            this.tbrFXVol.TickFrequency = 5;
            this.tbrFXVol.ValueChanged += new System.EventHandler(this.tbrFXVol_ValueChanged);
            // 
            // tbrVolume
            // 
            this.tbrVolume.Location = new System.Drawing.Point(202, 19);
            this.tbrVolume.Maximum = 50;
            this.tbrVolume.Name = "tbrVolume";
            this.tbrVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbrVolume.Size = new System.Drawing.Size(45, 108);
            this.tbrVolume.TabIndex = 5;
            this.tbrVolume.TickFrequency = 5;
            this.tbrVolume.ValueChanged += new System.EventHandler(this.tbrVolume_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Round Playlists";
            // 
            // lbxRoundSelect
            // 
            this.lbxRoundSelect.FormattingEnabled = true;
            this.lbxRoundSelect.Location = new System.Drawing.Point(15, 32);
            this.lbxRoundSelect.Name = "lbxRoundSelect";
            this.lbxRoundSelect.Size = new System.Drawing.Size(186, 121);
            this.lbxRoundSelect.TabIndex = 3;
            this.lbxRoundSelect.SelectedIndexChanged += new System.EventHandler(this.lbxRoundSelect_SelectedIndexChanged);
            // 
            // lbxPlaylistSelect
            // 
            this.lbxPlaylistSelect.FormattingEnabled = true;
            this.lbxPlaylistSelect.Location = new System.Drawing.Point(14, 19);
            this.lbxPlaylistSelect.Name = "lbxPlaylistSelect";
            this.lbxPlaylistSelect.Size = new System.Drawing.Size(186, 108);
            this.lbxPlaylistSelect.TabIndex = 1;
            this.lbxPlaylistSelect.SelectedIndexChanged += new System.EventHandler(this.lbxPlaylistSelect_SelectedIndexChanged);
            this.lbxPlaylistSelect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbxPlaylistSelect_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblHelp);
            this.panel2.Controls.Add(this.lblRank);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 485);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 247);
            this.panel2.TabIndex = 1;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblHelp.Location = new System.Drawing.Point(0, 232);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(394, 13);
            this.lblHelp.TabIndex = 5;
            this.lblHelp.Text = "F1) Help | F2) Options | F3) Effect List Editor | F4) Playlist Editor | F5) Reset" +
    " Counter";
            // 
            // lblRank
            // 
            this.lblRank.AutoSize = true;
            this.lblRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRank.ForeColor = System.Drawing.Color.Black;
            this.lblRank.Location = new System.Drawing.Point(494, 94);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(98, 108);
            this.lblRank.TabIndex = 0;
            this.lblRank.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rank Playlists";
            // 
            // lbxRankSelect
            // 
            this.lbxRankSelect.FormattingEnabled = true;
            this.lbxRankSelect.Location = new System.Drawing.Point(15, 172);
            this.lbxRankSelect.Name = "lbxRankSelect";
            this.lbxRankSelect.Size = new System.Drawing.Size(186, 121);
            this.lbxRankSelect.TabIndex = 3;
            this.lbxRankSelect.SelectedIndexChanged += new System.EventHandler(this.lbxRankSelect_SelectedIndexChanged);
            // 
            // cmsPopMainPlayback
            // 
            this.cmsPopMainPlayback.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopToolStripMenuItem,
            this.toggleRandomToolStripMenuItem});
            this.cmsPopMainPlayback.Name = "cmsPopMainPlayback";
            this.cmsPopMainPlayback.Size = new System.Drawing.Size(159, 48);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toggleRandomToolStripMenuItem
            // 
            this.toggleRandomToolStripMenuItem.Name = "toggleRandomToolStripMenuItem";
            this.toggleRandomToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.toggleRandomToolStripMenuItem.Text = "Toggle Random";
            this.toggleRandomToolStripMenuItem.Click += new System.EventHandler(this.toggleRandomToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(274, 732);
            this.panel3.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lbxRoundSelect);
            this.groupBox2.Controls.Add(this.tbrFXVol);
            this.groupBox2.Controls.Add(this.lbxRankSelect);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(10, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 304);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Effects Playlists";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbxPlaylistSelect);
            this.groupBox1.Controls.Add(this.tbrVolume);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 140);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Music Playlists";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(274, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1018, 732);
            this.panel4.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 732);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 510);
            this.Name = "Form1";
            this.Text = "Strike Rank Counter 3.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrFXVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrVolume)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.cmsPopMainPlayback.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Label lblRank;
        private System.Windows.Forms.ListBox lbxPlaylistSelect;
        private System.Windows.Forms.ContextMenuStrip cmsPopMainPlayback;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleRandomToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbxRoundSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxRankSelect;
        private System.Windows.Forms.TrackBar tbrVolume;
        private System.Windows.Forms.TrackBar tbrFXVol;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

