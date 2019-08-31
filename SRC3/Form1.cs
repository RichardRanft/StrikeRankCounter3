using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using log4net;

namespace SRC3
{
    public partial class Form1 : Form
    {
        private static ILog m_log = LogManager.GetLogger(typeof(Form1));

        private FPlaylistEditor m_playlistEditor;
        private FSoundEditor m_soundEditor;
        private FOptions m_options;
        private FAboutBox m_about;
        private CPlaylistManager m_playlistMan;
        private CPlaylist m_playlist;
        private CPlaylist m_ranklist;
        private CPlaylist m_roundlist;
        private int m_rank = 30;
        private int m_round = 1;
        private int m_rankperrnd = 30;
        private bool m_countUp = false;

        public Form1()
        {
            InitializeComponent();
            m_log.Info("Main form loaded.");
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // Function keys for accessing tools
            bool inDialog = false;
            if (e.KeyCode == Keys.F1)
            {
                inDialog = true;
                showHelp();
                return;
            }
            if (e.KeyCode == Keys.F2)
            {
                inDialog = true;
                showOptions();
                return;
            }
            if (e.KeyCode == Keys.F3)
            {
                inDialog = true;
                showSoundEditor();
                return;
            }
            if (e.KeyCode == Keys.F4)
            {
                inDialog = true;
                showPlaylistEditor();
                return;
            }
            if (e.KeyCode == Keys.F5)
            {
                resetCounter();
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                exit();
                return;
            }
            if(!inDialog)
                advanceCounter();
        }

        private void  resetCounter()
        {
            m_countUp = m_options.CountUp;
            if (m_countUp)
                m_rank = 0;
            else
                m_rank = m_rankperrnd;
            m_round = 1;
            if(m_ranklist != null)
            {
                if(!String.IsNullOrEmpty(m_options.ResetSound.Path) && File.Exists(m_options.ResetSound.Path))
                {
                    m_ranklist.PlayOne(m_options.ResetSound.Path);
                }
            }
            lblRank.Text = m_rank.ToString();
            lblRound.Text = m_round.ToString();
            lblRound.Left = (panel1.Width / 2) - lblRound.Width / 2;
            lblRank.Left = (panel2.Width / 2) - lblRank.Width / 2;
        }

        private void advanceCounter()
        {
            bool playRound = false;
            if (m_countUp)
            {
                ++m_rank;
                if (m_rank > m_rankperrnd)
                {
                    ++m_round;
                    m_rank = 0;
                    playRound = true;
                }
            }
            else
            {
                --m_rank;
                if (m_rank < 0)
                {
                    ++m_round;
                    m_rank = m_rankperrnd;
                    playRound = true;
                }
            }
            lblRank.Text = m_rank.ToString();
            lblRound.Text = m_round.ToString();
            lblRound.Left = (panel1.Width / 2) - lblRound.Width / 2;
            lblRank.Left = (panel2.Width / 2) - lblRank.Width / 2;
            if(m_roundlist == null)
            {
                if (lbxRoundSelect.Items.Count > 0)
                    lbxRoundSelect.SelectedIndex = 0;
            }
            if(m_ranklist == null)
            {
                if (lbxRankSelect.Items.Count > 0)
                    lbxRankSelect.SelectedIndex = 0;
            }
            if (m_ranklist != null && m_roundlist != null)
            {
                if (playRound)
                    m_roundlist.PlayOne();
                else
                    m_ranklist.PlayOne();
            }
        }

        private void showPlaylistEditor()
        {
            if (m_playlistEditor == null)
                m_playlistEditor = new FPlaylistEditor();
            m_playlistEditor.PlaylistManager = m_playlistMan;
            m_playlistEditor.ShowDialog();
            lbxPlaylistSelect.Items.Clear();
            foreach (CPlaylist list in m_playlistMan.Playlists)
            {
                lbxPlaylistSelect.Items.Add(list);
            }
        }

        private void showSoundEditor()
        {
            if (m_soundEditor == null)
                m_soundEditor = new FSoundEditor();
            m_soundEditor.PlaylistManager = m_playlistMan;
            m_soundEditor.ShowDialog();
            lbxRankSelect.Items.Clear();
            foreach (CPlaylist list in m_playlistMan.Ranklists)
                lbxRankSelect.Items.Add(list);
            lbxRoundSelect.Items.Clear();
            foreach (CPlaylist list in m_playlistMan.Roundlists)
                lbxRoundSelect.Items.Add(list);
        }

        private void showOptions()
        {
            if (m_options == null)
                m_options = new FOptions();
            if (m_options.ShowDialog() == DialogResult.OK)
                m_rankperrnd = m_options.RanksPerRound;
        }

        private void showHelp()
        {
            if (m_about == null)
                m_about = new FAboutBox();
            m_about.ShowDialog();
        }

        private void exit()
        {
            // save all the things

            // exit
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1_Resize(this, new EventArgs());
            this.Invalidate();
            m_about = new FAboutBox();
            m_options = new FOptions();
            if (m_options.RanksPerRound > 1)
                m_rankperrnd = m_options.RanksPerRound;
            m_countUp = m_options.CountUp;
            m_playlistEditor = new FPlaylistEditor();
            m_soundEditor = new FSoundEditor();
            loadPlaylists();
            resetCounter();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Height = panel4.Height / 2;
            panel2.Height = panel4.Height / 2;
            panel2.Top = panel4.Top + panel2.Height;
            lblRound.Top = (panel1.Height / 2) - lblRound.Height / 2;
            lblRound.Left = (panel1.Width / 2) - lblRound.Width / 2;
            lblRank.Top = (panel2.Height / 2) - lblRank.Height / 2;
            lblRank.Left = (panel2.Width / 2) - lblRank.Width / 2;
        }

        private void loadPlaylists()
        {
            String basePath = CListFileUtil.GetBasePathFromRegistry();
            String listPath = basePath + "\\Playlists";
            if(!Directory.Exists(listPath))
            {
                try
                {
                    Directory.CreateDirectory(listPath);
                }
                catch(Exception ex)
                {
                    m_log.Error("Unable to create playlist storage path " + listPath, ex);
                    MessageBox.Show("Unable to create the playlist storage path.  " + ex.Message, "Unable To Create Path");
                    return;
                }
            }
            m_playlistMan = new CPlaylistManager();
            m_playlistMan.Load(listPath);
            lbxPlaylistSelect.Items.Clear();
            foreach (CPlaylist list in m_playlistMan.Playlists)
                lbxPlaylistSelect.Items.Add(list);
            lbxRoundSelect.Items.Clear();
            foreach (CPlaylist list in m_playlistMan.Roundlists)
                lbxRoundSelect.Items.Add(list);
            lbxRankSelect.Items.Clear();
            foreach (CPlaylist list in m_playlistMan.Ranklists)
                lbxRankSelect.Items.Add(list);
        }

        private void lbxPlaylistSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxPlaylistSelect.SelectedIndex < 0)
                return;
            if (m_playlist == null)
            {
                m_playlist = (CPlaylist)lbxPlaylistSelect.SelectedItem;
                tbrVolume.Value = (Int32)(m_playlist.Volume * 50);
                m_playlist.Play();
            }
            else
            {
                m_playlist.Stop();
                m_playlist = (CPlaylist)lbxPlaylistSelect.SelectedItem;
                tbrVolume.Value = (Int32)(m_playlist.Volume * 50);
                m_playlist.Play();
            }
        }

        private void lbxPlaylistSelect_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                lbxPlaylistSelect.SelectedIndex = lbxPlaylistSelect.IndexFromPoint(new Point(e.X, e.Y));
                cmsPopMainPlayback.Show(Cursor.Position);
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_playlist != null)
                m_playlist.Stop();
        }

        private void toggleRandomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbxPlaylistSelect.SelectedIndex >= 0)
            {
                CPlaylist list = (CPlaylist)lbxPlaylistSelect.SelectedItem;
                list.Random = !list.Random;
            }
        }

        private void lbxRoundSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxRoundSelect.SelectedIndex < 0)
                return;
            m_roundlist = (CPlaylist)lbxRoundSelect.SelectedItem;
            tbrFXVol.Value = (Int32)(m_roundlist.Volume * 50);
        }

        private void lbxRankSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxRankSelect.SelectedIndex < 0)
                return;
            m_ranklist = (CPlaylist)lbxRankSelect.SelectedItem;
            tbrFXVol.Value = (Int32)(m_ranklist.Volume * 50);
        }

        private void tbrVolume_ValueChanged(object sender, EventArgs e)
        {
            if(m_playlist == null)
            {
                if (lbxPlaylistSelect.Items.Count > 0)
                    lbxPlaylistSelect.SelectedIndex = 0;
            }
            if (m_playlist != null)
            {
                double val = (double)tbrVolume.Value;
                m_playlist.Volume = val / 50.0;
                m_playlist.Save();
            }
        }

        private void tbrFXVol_ValueChanged(object sender, EventArgs e)
        {
            if (m_ranklist == null)
            {
                if (lbxRankSelect.Items.Count > 0)
                    lbxRankSelect.SelectedIndex = 0;
            }
            if (m_ranklist != null)
            {
                double val = (double)tbrFXVol.Value;
                m_ranklist.Volume = val / 50.0;
                m_ranklist.Save();
            }
            if (m_roundlist == null)
            {
                if (lbxRoundSelect.Items.Count > 0)
                    lbxRoundSelect.SelectedIndex = 0;
            }
            if (m_roundlist != null)
            {
                double val = (double)tbrFXVol.Value;
                m_roundlist.Volume = val / 50.0;
                m_roundlist.Save();
            }
        }
    }
}
