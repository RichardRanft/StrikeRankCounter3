﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media;

namespace SRC3
{
    public partial class FPlaylistEditor : Form
    {
        private FNewPlaylist m_newPlaylist;
        private MediaPlayer m_player;
        private CPlaylist m_playlist;
        private bool m_dirty = false;
        private bool m_doNotSelect = false;

        public FPlaylistEditor()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (m_dirty)
            {
                DialogResult result = MessageBox.Show("Do you wish to save changes to " + m_playlist.Name + "?", "Save Changes?", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;
                if (result == System.Windows.Forms.DialogResult.Yes)
                    m_playlist.Save();
            }
            m_dirty = false;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            String startPath = CListFileUtil.GetBasePathFromRegistry();;
            startPath += "\\Audio";
            fbdBrowse.SelectedPath = startPath;
            if(fbdBrowse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxFolder.Text = fbdBrowse.SelectedPath;
                updateFileList();
            }
        }

        private void updateFileList()
        {
            lbxFiles.Items.Clear();
            String[] files = Directory.GetFiles(tbxFolder.Text, "*.mp3");
            foreach (String file in files)
            {
                String name = Path.GetFileName(file);
                lbxFiles.Items.Add(name);
            }
            files = Directory.GetFiles(tbxFolder.Text, "*.wav");
            foreach (String file in files)
            {
                String name = Path.GetFileName(file);
                lbxFiles.Items.Add(name);
            }
            lbxFiles.Sorted = false;
            lbxFiles.Sorted = true;
            lbxFiles.Invalidate();
            lbxFiles.Refresh();
        }

        private void lbxFiles_MouseUp(object sender, MouseEventArgs e)
        {
            // right-mouse pop-up
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                lbxFiles.SelectedIndex = lbxFiles.IndexFromPoint(new Point(e.X, e.Y));
                cmsPopMenu.Show(Cursor.Position);
            }
        }

        private void lbxFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ListBox lb = ((ListBox)sender);
                Point pt = new Point(e.X, e.Y);
                //Retrieve the item at the specified location within the ListBox.
                int index = lb.IndexFromPoint(pt);

                // Starts a drag-and-drop operation.
                if (index >= 0)
                {
                    // Retrieve the selected item text to drag into the RichTextBox.
                    lb.DoDragDrop(tbxFolder.Text + "\\" + lb.Items[index].ToString(), DragDropEffects.Copy);
                }
            }
        }

        private void FPlaylistEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_player != null)
                m_player.Stop();
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_player == null)
                m_player = new MediaPlayer();
            m_player.Stop();
            m_player.Open(new Uri(tbxFolder.Text + "\\" + lbxFiles.SelectedItem.ToString()));
            m_player.Play();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_player != null)
                m_player.Stop();
        }

        private void previewPlayListMenuItem_Click(object sender, EventArgs e)
        {
            if (m_player == null)
                m_player = new MediaPlayer();
            m_player.Stop();
            CPlaylistEntry entry = (CPlaylistEntry)lbxPlaylist.SelectedItem;
            String path = entry.Path;
            m_player.Open(new Uri(path));
            m_player.Play();
        }

        private void stopPlayListMenuItem_Click(object sender, EventArgs e)
        {
            if (m_player != null)
                m_player.Stop();
        }

        private void lbxPlaylist_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Text"))
                e.Effect = DragDropEffects.Copy;
        }

        private void lbxPlaylist_DragDrop(object sender, DragEventArgs e)
        {
            if (cbxPlaylistSelect.SelectedItem == null)
                createPlaylist();
            CPlaylistEntry temp = new CPlaylistEntry();
            temp.Path = e.Data.GetData("System.String", true).ToString();
            temp.Name = Path.GetFileName(temp.Path);
            m_playlist.Playlist.Add(temp);
            lbxPlaylist.Items.Clear();
            foreach(CPlaylistEntry entry in m_playlist.Playlist)
                lbxPlaylist.Items.Add(entry);
            lbxPlaylist.Sorted = false;
            lbxPlaylist.Sorted = true;
            lbxPlaylist.Invalidate();
            lbxPlaylist.Refresh();
            m_dirty = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (m_newPlaylist == null)
                m_newPlaylist = new FNewPlaylist();
            if(m_newPlaylist.ShowDialog() == DialogResult.OK)
            {
                m_playlist.Save();
                createPlaylist(m_newPlaylist.PlaylistName);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (m_playlist == null)
                m_playlist = new CPlaylist();
            m_playlist.Playlist.Clear();
            lbxPlaylist.Items.Clear();
        }

        private void createPlaylist(String listname = "")
        {
            listname = CListFileUtil.GetListFilename(listname, ".playlist");
            String startPath = CListFileUtil.GetListStartPath();
            m_doNotSelect = true;
            CListFileUtil.CreatePlaylist(ref m_playlist, ref cbxPlaylistSelect, ref lbxPlaylist, listname, startPath);
            m_doNotSelect = false;
        }

        private void cbxPlaylistSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_doNotSelect)
                return;
            if(m_dirty)
            {
                DialogResult result = MessageBox.Show("Do you wish to save changes to " + m_playlist.Name + "?", "Save Changes?", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;
                if (result == System.Windows.Forms.DialogResult.Yes)
                    m_playlist.Save();
            }
            String playlistPath = CListFileUtil.GetBasePathFromRegistry();;
            playlistPath += "\\Playlists\\" + cbxPlaylistSelect.Text;
            if (cbxPlaylistSelect.SelectedIndex >= 0)
                m_playlist = (CPlaylist)cbxPlaylistSelect.SelectedItem;
            if(m_playlist != null)
            {
                lbxPlaylist.Items.Clear();
                foreach (CPlaylistEntry entry in m_playlist.Playlist)
                    lbxPlaylist.Items.Add(entry);
                lbxPlaylist.Sorted = false;
                lbxPlaylist.Sorted = true;
                lbxPlaylist.Invalidate();
                lbxPlaylist.Refresh();
            }
            m_dirty = false;
        }

        private void FPlaylistEditor_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                return;
            String startPath = CListFileUtil.GetBasePathFromRegistry();
            startPath += "\\Audio";
            tbxFolder.Text = startPath;
            String playlistPath = CListFileUtil.GetBasePathFromRegistry();;
            playlistPath += "\\Playlists\\";
            String[] files = Directory.GetFiles(playlistPath, "*.playlist");
            cbxPlaylistSelect.Items.Clear();
            foreach (String file in files)
            {
                CPlaylist list = new CPlaylist();
                list.Load(file);
                cbxPlaylistSelect.Items.Add(list);
            }
            if (cbxPlaylistSelect.Items.Count > 0)
                cbxPlaylistSelect.SelectedIndex = 0;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPlaylistEntry entry = (CPlaylistEntry)lbxPlaylist.SelectedItem;
            lbxPlaylist.Items.Remove(entry);
            m_playlist.Playlist.Remove(entry);
            m_dirty = true;
        }

        private void lbxPlaylist_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                lbxPlaylist.SelectedIndex = lbxPlaylist.IndexFromPoint(new Point(e.X, e.Y));
                cmsPopMenuPlaylist.Show(Cursor.Position);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CListFileUtil.RemapPlaylistBasePath(ref m_playlist, CListFileUtil.GetBasePathFromRegistry());
        }
    }
}
