using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media;

namespace SRC3
{
    public class CPlaylist
    {
        public String Name = "";
        public String Path = "";
        public bool Random { get { return m_random; } set { m_random = value; } }
        public double Volume { get { return m_player.Volume; } set { m_player.Volume = value; } }
        public EListType ListType = EListType.PLAYLIST;

        public List<CPlaylistEntry> Playlist;

        private bool m_random;
        private Random m_rand;
        private MediaPlayer m_player;
        private int index = 0;
        private bool m_single = false;

        public CPlaylist()
        {
            Playlist = new List<CPlaylistEntry>();
            m_rand = new Random();
            m_random = true;
            m_player = new MediaPlayer();
            m_player.MediaEnded += m_player_MediaEnded;            
        }

        private void m_player_MediaEnded(object sender, EventArgs e)
        {
            ++index;
            if (index >= Playlist.Count)
                index = 0;
            if(!m_single)
                Play();
            m_single = false;
        }

        public override String ToString()
        {
            return Name;
        }

        public void Play()
        {
            if (Playlist.Count > 0)
            {
                if (m_random)
                    index = m_rand.Next(0, Playlist.Count - 1);
                m_player.Stop();
                m_player.Open(new Uri(Playlist[index].Path));
                m_player.Play();
            }
        }

        public void PlayOne()
        {
            if (Playlist.Count > 0)
            {
                m_single = true;
                if (m_random)
                    index = m_rand.Next(0, Playlist.Count - 1);
                try
                {
                    m_player.Stop();
                    m_player.Open(new Uri(Playlist[index].Path));
                    m_player.Play();
                }
                catch (Exception ex)
                {
                    String msg = "Unable to play sound : " + Environment.NewLine + ex.Message;
                    if (ex.InnerException != null)
                        msg += Environment.NewLine + ex.InnerException.Message;
                    MessageBox.Show(msg, "Unable To Play Sound");
                }
            }
        }

        public void PlayOne(String path)
        {
            if (File.Exists(path))
            {
                m_single = true;
                try
                {
                    m_player.Stop();
                    m_player.Open(new Uri(path));
                    m_player.Play();
                }
                catch (Exception ex)
                {
                    String msg = "Unable to play sound : " + Environment.NewLine + ex.Message;
                    if (ex.InnerException != null)
                        msg += Environment.NewLine + ex.InnerException.Message;
                    MessageBox.Show(msg, "Unable To Play Sound");
                }
            }
        }

        public void Stop()
        {
            m_player.Stop();
        }

        public bool Save()
        {
            try
            {
                DataSet set = new DataSet();
                DataTable headerTbl = new DataTable("HeaderInfo");
                DataColumn col = new DataColumn("Name", typeof(String));
                headerTbl.Columns.Add(col);
                col = new DataColumn("Path", typeof(String));
                headerTbl.Columns.Add(col);
                col = new DataColumn("Random", typeof(bool));
                headerTbl.Columns.Add(col);
                col = new DataColumn("Volume", typeof(double));
                headerTbl.Columns.Add(col);
                col = new DataColumn("ListType", typeof(int));
                headerTbl.Columns.Add(col);
                DataRow row = headerTbl.NewRow();
                row["Name"] = Name;
                row["Path"] = Path;
                row["Random"] = Random;
                row["Volume"] = Volume;
                row["ListType"] = ListType;
                headerTbl.Rows.Add(row);
                set.Tables.Add(headerTbl);
                DataTable listTbl = new DataTable("PlayList");
                col = new DataColumn("Name", typeof(String));
                listTbl.Columns.Add(col);
                col = new DataColumn("Path", typeof(String));
                listTbl.Columns.Add(col);
                foreach (CPlaylistEntry entry in Playlist)
                {
                    row = listTbl.NewRow();
                    row["Name"] = entry.Name;
                    row["Path"] = entry.Path;
                    listTbl.Rows.Add(row);
                }
                set.Tables.Add(listTbl);
                set.WriteXml(Path);
                return true;
            }
            catch(Exception ex)
            {
                String msg = Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                    msg += Environment.NewLine + ex.InnerException.Message;
                MessageBox.Show("Unable to write playlist file " + Path + ": " + msg, "Unable to Write Playlist");
            }
            return false;
        }

        public bool Load(String filepath)
        {
            try
            {
                DataSet set = new DataSet();
                set.ReadXml(filepath);
                if(set.Tables.Contains("HeaderInfo"))
                {
                    Name = set.Tables["HeaderInfo"].Rows[0]["Name"].ToString();
                    Path = set.Tables["HeaderInfo"].Rows[0]["Path"].ToString();
                    if (Path != filepath)
                    {
                        Path = filepath;
                        set.Tables["HeaderInfo"].Rows[0]["Path"] = Path;
                        set.WriteXml(filepath);
                    }
                    Random = bool.Parse(set.Tables["HeaderInfo"].Rows[0]["Random"].ToString());
                    Volume = double.Parse(set.Tables["HeaderInfo"].Rows[0]["Volume"].ToString());
                    ListType = (EListType)int.Parse(set.Tables["HeaderInfo"].Rows[0]["ListType"].ToString());
                    if (set.Tables.Contains("PlayList"))
                    {
                        foreach (DataRow row in set.Tables["PlayList"].Rows)
                        {
                            CPlaylistEntry entry = new CPlaylistEntry();
                            entry.Name = row["Name"].ToString();
                            entry.Path = row["Path"].ToString();
                            Playlist.Add(entry);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                String msg = Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                    msg += Environment.NewLine + ex.InnerException.Message;
                MessageBox.Show("Unable to read playlist file " + filepath + ": " + msg, "Unable to Read Playlist");
            }
            return false;
        }
    }

    public class CPlaylistEntry
    {
        public String Name = "";
        public String Path = "";

        public override String ToString()
        {
            return Name;
        }
    }

    public enum EListType
    {
        PLAYLIST,
        RANKLIST,
        ROUNDLIST
    }
}
