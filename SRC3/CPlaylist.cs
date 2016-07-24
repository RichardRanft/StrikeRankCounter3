using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (Playlist.Count > 0)
            {
                m_single = true;
                if (m_random)
                    index = m_rand.Next(0, Playlist.Count - 1);
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
                using (StreamWriter sw = new StreamWriter(Path))
                {
                    sw.WriteLine(Name);
                    sw.WriteLine(Path);
                    sw.WriteLine(Random);
                    sw.WriteLine(Volume);
                    foreach (CPlaylistEntry entry in Playlist)
                    {
                        sw.WriteLine(entry.Name + "," + entry.Path);
                    }
                }
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
            bool updatePath = false;
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    Name = sr.ReadLine();
                    Path = sr.ReadLine();
                    if (Path != filepath)
                    {
                        Path = filepath;
                        updatePath = true;
                    }
                    String rand = sr.ReadLine();
                    Random = bool.Parse(rand);
                    String volume = sr.ReadLine();
                    Volume = double.Parse(volume);
                    String line = "";
                    String[] parts = { "" };
                    while(!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        parts = line.Split(',');
                        if(parts.Length > 1)
                        {
                            CPlaylistEntry entry = new CPlaylistEntry();
                            entry.Name = parts[0];
                            entry.Path = parts[1];
                            Playlist.Add(entry);
                        }
                    }
                }
                if (updatePath)
                    Save();
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
}
