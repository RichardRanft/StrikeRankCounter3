using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace SRC3
{
    public partial class FOptions : Form
    {
        private CPlaylistEntry m_resetSnd;

        public String BaseAudioPath { get { return tbxBaseSoundPath.Text; } }
        public CPlaylistEntry ResetSound { get { return m_resetSnd; } }
        public int RanksPerRound { get { return (int)nudRankPerRnd.Value; } }
        public bool CountUp = false;

        public FOptions()
        {
            InitializeComponent();
            m_resetSnd = new CPlaylistEntry();
            load();
        }

        private void save()
        {
            try
            {
                if(!Directory.Exists(tbxBaseSoundPath.Text))
                {
                    tbxBaseSoundPath.Text = CListFileUtil.GetBasePathFromRegistry();
                }
                String current = CListFileUtil.GetBasePathFromRegistry();
                if (current.CompareTo(tbxBaseSoundPath.Text) != 0)
                    CListFileUtil.SetBasePathInRegistry(tbxBaseSoundPath.Text);
            }
            catch(Exception ex)
            {
                String msg = "Unable to update base path in Registry....";
                msg += Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                    msg += Environment.NewLine + ex.InnerException.Message;
                MessageBox.Show(msg, "Unable to Update Base Path");
                return;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(tbxBaseSoundPath.Text + "\\settings.sf"))
                {
                    sw.WriteLine((int)nudRankPerRnd.Value);
                    sw.WriteLine(m_resetSnd.Name + "," + m_resetSnd.Path);
                    sw.WriteLine(CountUp.ToString());
                }
            }
            catch (Exception ex)
            {
                String msg = "Unable to save settings....";
                msg += Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                    msg += Environment.NewLine + ex.InnerException.Message;
                MessageBox.Show(msg, "Unable to Save Settings");
            }
        }

        private void load()
        {
            try
            {
                String path = CListFileUtil.GetBasePathFromRegistry();
                if (String.IsNullOrEmpty(path))
                {
                    path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    CListFileUtil.SetBasePathInRegistry(path);
                }
                tbxBaseSoundPath.Text = path;
            }
            catch (Exception ex)
            {
                String msg = "Unable to read base path from Registry....";
                msg += Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                    msg += Environment.NewLine + ex.InnerException.Message;
                MessageBox.Show(msg, "Unable to Read Base Path");
                if (!Directory.Exists(tbxBaseSoundPath.Text))
                {
                    tbxBaseSoundPath.Text = CListFileUtil.GetBasePathFromRegistry();
                }
                nudRankPerRnd.Value = 30;
                m_resetSnd = new CPlaylistEntry();
                return;
            }
            String settingsFileName = tbxBaseSoundPath.Text + "\\settings.sf";
            if (File.Exists(settingsFileName))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(settingsFileName))
                    {
                        nudRankPerRnd.Value = int.Parse(sr.ReadLine());
                        String line = sr.ReadLine();
                        String[] parts = line.Split(',');
                        if (parts.Length > 1)
                        {
                            m_resetSnd = new CPlaylistEntry();
                            m_resetSnd.Name = parts[0];
                            m_resetSnd.Path = parts[1];
                        }
                        tbxResetSnd.Text = m_resetSnd.Path;
                        CountUp = bool.Parse(sr.ReadLine());
                    }
                }
                catch (Exception ex)
                {
                    String msg = "Unable to load settings....";
                    msg += Environment.NewLine + ex.Message;
                    if (ex.InnerException != null)
                        msg += Environment.NewLine + ex.InnerException.Message;
                    MessageBox.Show(msg, "Unable to Load Settings");
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void FOptions_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(ofdResetOpen.ShowDialog() == DialogResult.OK)
            {
                String path = ofdResetOpen.FileName;
                String name = Path.GetFileName(path);
                tbxResetSnd.Text = name;
                if (m_resetSnd == null)
                    m_resetSnd = new CPlaylistEntry();
                m_resetSnd.Name = name;
                m_resetSnd.Path = path;
            }
        }

        private void FOptions_VisibleChanged(object sender, EventArgs e)
        {
            if (m_resetSnd == null)
                load();
            tbxResetSnd.Text = m_resetSnd.Name;
        }

        private void btnBrowseBasePath_Click(object sender, EventArgs e)
        {
            if(fbdBrowse.ShowDialog() == DialogResult.OK)
            {
                tbxBaseSoundPath.Text = fbdBrowse.SelectedPath;
            }
        }

        private void cbxCountUp_CheckedChanged(object sender, EventArgs e)
        {
            CountUp = cbxCountUp.Checked;
        }
    }
}
