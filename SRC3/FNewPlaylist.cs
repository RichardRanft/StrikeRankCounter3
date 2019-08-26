using System;
using System.Windows.Forms;
using log4net;

namespace SRC3
{
    public partial class FNewPlaylist : Form
    {
        private static ILog m_log = LogManager.GetLogger(typeof(FNewPlaylist));

        public String PlaylistName { get { return tbxPlaylistName.Text; } }

        public FNewPlaylist()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
