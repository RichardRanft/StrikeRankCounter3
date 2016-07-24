using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.IO;

namespace SRC3
{
    public partial class FSoundEditor : Form
    {
        private FNewPlaylist m_newPlaylist;
        private MediaPlayer m_player;
        private CPlaylist m_ranklist;
        private CPlaylist m_roundlist;
        private bool m_rankDirty = false;
        private bool m_roundDirty = false;
        private bool m_doNotSelect = false;

        public FSoundEditor()
        {
            InitializeComponent();
        }

        private void createRanklist(String listname = "")
        {
            listname = CListFileUtil.GetListFilename(listname, ".ranklist");
            String startPath = CListFileUtil.GetListStartPath();
            m_doNotSelect = true;
            CListFileUtil.CreatePlaylist(ref m_ranklist, ref cbxRanklistSelect, ref lbxRanklist, listname, startPath);
            m_doNotSelect = false;
        }

        private void createRoundlist(String listname = "")
        {
            listname = CListFileUtil.GetListFilename(listname, ".roundlist");
            String startPath = CListFileUtil.GetListStartPath();
            m_doNotSelect = true;
            CListFileUtil.CreatePlaylist(ref m_roundlist, ref cbxRoundlistSelect, ref lbxRoundlist, listname, startPath);
            m_doNotSelect = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (m_rankDirty)
            {
                DialogResult result = MessageBox.Show("Do you wish to save changes to " + m_ranklist.Name + "?", "Save Changes?", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;
                if (result == System.Windows.Forms.DialogResult.Yes)
                    m_ranklist.Save();
            }
            m_rankDirty = false;
            if (m_roundDirty)
            {
                DialogResult result = MessageBox.Show("Do you wish to save changes to " + m_roundlist.Name + "?", "Save Changes?", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;
                if (result == System.Windows.Forms.DialogResult.Yes)
                    m_roundlist.Save();
            }
            m_rankDirty = false;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void FSoundEditor_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                return;
            String startPath = CListFileUtil.GetBasePathFromRegistry();
            startPath += "\\Audio";
            tbxFolder.Text = startPath;
            String playlistPath = CListFileUtil.GetBasePathFromRegistry();
            playlistPath += "\\Playlists\\";
            String[] files = Directory.GetFiles(playlistPath, "*.ranklist");
            cbxRanklistSelect.Items.Clear();
            foreach (String file in files)
            {
                CPlaylist list = new CPlaylist();
                list.Load(file);
                cbxRanklistSelect.Items.Add(list);
            }
            if (cbxRanklistSelect.Items.Count > 0)
                cbxRanklistSelect.SelectedIndex = 0;
            files = Directory.GetFiles(playlistPath, "*.roundlist");
            cbxRoundlistSelect.Items.Clear();
            foreach (String file in files)
            {
                CPlaylist list = new CPlaylist();
                list.Load(file);
                cbxRoundlistSelect.Items.Add(list);
            }
            if (cbxRoundlistSelect.Items.Count > 0)
                cbxRoundlistSelect.SelectedIndex = 0;
            updateFileList();
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

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPlaylistEntry entry = (CPlaylistEntry)lbxRanklist.SelectedItem;
            lbxRanklist.Items.Remove(entry);
            m_ranklist.Playlist.Remove(entry);
            m_rankDirty = true;
        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CPlaylistEntry entry = (CPlaylistEntry)lbxRoundlist.SelectedItem;
            lbxRoundlist.Items.Remove(entry);
            m_roundlist.Playlist.Remove(entry);
            m_rankDirty = true;
        }

        private void lbxRanklist_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Text"))
                e.Effect = DragDropEffects.Copy;
        }

        private void lbxRanklist_DragDrop(object sender, DragEventArgs e)
        {
            if (cbxRanklistSelect.SelectedItem == null)
                createRanklist();
            CPlaylistEntry temp = new CPlaylistEntry();
            temp.Path = e.Data.GetData("System.String", true).ToString();
            temp.Name = Path.GetFileName(temp.Path);
            m_ranklist.Playlist.Add(temp);
            lbxRanklist.Items.Clear();
            foreach (CPlaylistEntry entry in m_ranklist.Playlist)
                lbxRanklist.Items.Add(entry);
            lbxRanklist.Sorted = false;
            lbxRanklist.Sorted = true;
            lbxRanklist.Invalidate();
            lbxRanklist.Refresh();
            m_rankDirty = true;
        }

        private void lbxRoundlist_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Text"))
                e.Effect = DragDropEffects.Copy;
        }

        private void lbxRoundlist_DragDrop(object sender, DragEventArgs e)
        {
            if (cbxRoundlistSelect.SelectedItem == null)
                createRoundlist();
            CPlaylistEntry temp = new CPlaylistEntry();
            temp.Path = e.Data.GetData("System.String", true).ToString();
            temp.Name = Path.GetFileName(temp.Path);
            m_roundlist.Playlist.Add(temp);
            lbxRoundlist.Items.Clear();
            foreach (CPlaylistEntry entry in m_roundlist.Playlist)
                lbxRoundlist.Items.Add(entry);
            lbxRoundlist.Sorted = false;
            lbxRoundlist.Sorted = true;
            lbxRoundlist.Invalidate();
            lbxRoundlist.Refresh();
            m_roundDirty = true;
        }

        private void cbxRanklistSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_doNotSelect)
                return;
            if (m_rankDirty)
            {
                DialogResult result = MessageBox.Show("Do you wish to save changes to " + m_ranklist.Name + "?", "Save Changes?", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;
                if (result == System.Windows.Forms.DialogResult.Yes)
                    m_ranklist.Save();
            }
            String playlistPath = CListFileUtil.GetBasePathFromRegistry();;
            playlistPath += "\\Playlists\\" + cbxRanklistSelect.Text;
            if (cbxRanklistSelect.SelectedIndex >= 0)
                m_ranklist = (CPlaylist)cbxRanklistSelect.SelectedItem;
            if (m_ranklist != null)
            {
                lbxRanklist.Items.Clear();
                foreach (CPlaylistEntry entry in m_ranklist.Playlist)
                    lbxRanklist.Items.Add(entry);
                lbxRanklist.Sorted = false;
                lbxRanklist.Sorted = true;
                lbxRanklist.Invalidate();
                lbxRanklist.Refresh();
            }
            m_rankDirty = false;
        }

        private void cbxRoundlistSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_doNotSelect)
                return;
            if (m_roundDirty)
            {
                DialogResult result = MessageBox.Show("Do you wish to save changes to " + m_roundlist.Name + "?", "Save Changes?", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;
                if (result == System.Windows.Forms.DialogResult.Yes)
                    m_roundlist.Save();
            }
            String playlistPath = CListFileUtil.GetBasePathFromRegistry();;
            if (playlistPath.Contains("\\bin\\Debug") || playlistPath.Contains("\\bin\\Release"))
            {
                playlistPath = playlistPath.Replace("\\bin\\Debug", "");
                playlistPath = playlistPath.Replace("\\bin\\Release", "");
            }
            playlistPath += "\\Playlists\\" + cbxRoundlistSelect.Text;
            if (cbxRoundlistSelect.SelectedIndex >= 0)
                m_roundlist = (CPlaylist)cbxRoundlistSelect.SelectedItem;
            if (m_roundlist != null)
            {
                lbxRoundlist.Items.Clear();
                foreach (CPlaylistEntry entry in m_roundlist.Playlist)
                    lbxRoundlist.Items.Add(entry);
                lbxRoundlist.Sorted = false;
                lbxRoundlist.Sorted = true;
                lbxRoundlist.Invalidate();
                lbxRoundlist.Refresh();
            }
            m_roundDirty = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            String startPath = CListFileUtil.GetBasePathFromRegistry();;
            startPath += "\\Audio";
            fbdBrowse.SelectedPath = startPath;
            if (fbdBrowse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxFolder.Text = fbdBrowse.SelectedPath;
                updateFileList();
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

        private void lbxFiles_MouseUp(object sender, MouseEventArgs e)
        {
            // right-mouse pop-up
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                lbxFiles.SelectedIndex = lbxFiles.IndexFromPoint(new Point(e.X, e.Y));
                cmsPopMenu.Show(Cursor.Position);
            }
        }

        private void btnNewRank_Click(object sender, EventArgs e)
        {
            if (m_newPlaylist == null)
                m_newPlaylist = new FNewPlaylist();
            if (m_newPlaylist.ShowDialog() == DialogResult.OK)
            {
                m_ranklist.Save();
                createRanklist(m_newPlaylist.PlaylistName);
            }
        }

        private void btnClearRank_Click(object sender, EventArgs e)
        {
            if (m_ranklist == null)
                m_ranklist = new CPlaylist();
            m_ranklist.Playlist.Clear();
            lbxRanklist.Items.Clear();
        }

        private void btnNewRound_Click(object sender, EventArgs e)
        {
            if (m_newPlaylist == null)
                m_newPlaylist = new FNewPlaylist();
            if (m_newPlaylist.ShowDialog() == DialogResult.OK)
            {
                m_roundlist.Save();
                createRoundlist(m_newPlaylist.PlaylistName);
            }
        }

        private void btnClearRound_Click(object sender, EventArgs e)
        {
            if (m_roundlist == null)
                m_roundlist = new CPlaylist();
            m_roundlist.Playlist.Clear();
            lbxRoundlist.Items.Clear();
        }

        private void btnUpdateRank_Click(object sender, EventArgs e)
        {
            CListFileUtil.RemapPlaylistBasePath(ref m_ranklist, CListFileUtil.GetBasePathFromRegistry());
        }

        private void btnUpdateRound_Click(object sender, EventArgs e)
        {
            CListFileUtil.RemapPlaylistBasePath(ref m_roundlist, CListFileUtil.GetBasePathFromRegistry());
        }
    }
}
