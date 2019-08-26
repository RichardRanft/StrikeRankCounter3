using System;
using System.Collections.Generic;
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
        public EListType ListType = EListType.PLAYLIST;

        public List<CPlaylistEntry> Playlist;

        private bool m_random;
        private double m_volume;

        public CPlaylist()
        {
            Playlist = new List<CPlaylistEntry>();
            m_random = true;
            m_volume = 1.0;
        }

        public override String ToString()
        {
            return Name;
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
            catch (Exception ex)
            {
                String msg = Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                    msg += Environment.NewLine + ex.InnerException.Message;
                Console.WriteLine("Unable to write playlist file " + Path + ": " + msg, "Unable to Write Playlist");
            }
            return false;
        }

        public bool Load(String filepath)
        {
            try
            {
                DataSet set = new DataSet();
                set.ReadXml(filepath);
                if (set.Tables.Contains("HeaderInfo"))
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
                Console.WriteLine("Unable to read playlist file " + filepath + ": " + msg, "Unable to Read Playlist");
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
