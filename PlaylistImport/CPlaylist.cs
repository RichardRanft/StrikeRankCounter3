using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace PlaylistImport
{
    public class CPlaylist
    {
        public String Name = "";
        public String Path = "";
        public bool Random { get { return m_random; } set { m_random = value; } }
        public double Volume { get { return m_volume; } set { m_volume = value; } }
        public List<CPlaylistEntry> Playlist;

        private bool m_random;
        private double m_volume;

        public CPlaylist()
        {
            Playlist = new List<CPlaylistEntry>();
            m_random = true;
            m_volume = 1.0;
        }

        public bool Save()
        {
            try
            {
                DataSet set = new DataSet();
                DataTable headerTbl = new DataTable("HeaderInfo");
                DataColumn col = new DataColumn("Name", Type.GetType("String"));
                headerTbl.Columns.Add(col);
                col = new DataColumn("Path", Type.GetType("String"));
                headerTbl.Columns.Add(col);
                col = new DataColumn("Random", Type.GetType("bool"));
                headerTbl.Columns.Add(col);
                col = new DataColumn("Volume", Type.GetType("double"));
                headerTbl.Columns.Add(col);
                DataRow row = headerTbl.NewRow();
                row["Name"] = Name;
                row["Path"] = Path;
                row["Random"] = Random;
                row["Volume"] = Volume;
                headerTbl.Rows.Add(row);
                set.Tables.Add(headerTbl);
                DataTable listTbl = new DataTable("PlayList");
                col = new DataColumn("Name", Type.GetType("String"));
                listTbl.Columns.Add(col);
                col = new DataColumn("Path", Type.GetType("String"));
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
                Console.WriteLine("Unable to write playlist file {0}:\n{1}", Path, msg);
            }
            return false;
        }

        public bool Load(String filepath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    Name = sr.ReadLine();
                    Path = sr.ReadLine();
                    String rand = sr.ReadLine();
                    Random = bool.Parse(rand);
                    String volume = sr.ReadLine();
                    Volume = double.Parse(volume);
                    String line = "";
                    String[] parts = { "" };
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        parts = line.Split(',');
                        if (parts.Length > 1)
                        {
                            CPlaylistEntry entry = new CPlaylistEntry();
                            entry.Name = parts[0];
                            entry.Path = parts[1];
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
                Console.WriteLine("Unable to read playlist file {0}:\n{1}", filepath, msg);
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
