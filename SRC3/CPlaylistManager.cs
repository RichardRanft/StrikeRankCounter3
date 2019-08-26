using System;
using System.Collections.Generic;
using System.IO;

namespace SRC3
{
    public class CPlaylistManager
    {
        private List<CPlaylist> m_playlists;

        public List<CPlaylist> Playlists
        {
            get { return getPlaylists(); }
            private set { }
        }

        public List<CPlaylist> Ranklists
        {
            get { return getRankLists(); }
            private set { }
        }

        public List<CPlaylist> Roundlists
        {
            get { return getRoundLists(); }
            private set { }
        }

        public CPlaylistManager()
        {
            m_playlists = new List<CPlaylist>();
        }

        public void Load(String path)
        {
            String[] listfiles = Directory.GetFiles(path, "*.xml");
            foreach(String file in listfiles)
            {
                CPlaylist list = new CPlaylist();
                list.Load(file);
                m_playlists.Add(list);
            }
        }

        public void Add(CPlaylist list)
        {
            m_playlists.Add(list);
        }

        public String Remove(CPlaylist list)
        {
            String msg = "";
            m_playlists.Remove(list);
            String filename = list.Path;
            try
            {
                File.Delete(filename);
            }
            catch(Exception ex)
            {
                msg = String.Format("Unable to delete {0} : {1}", filename, ex);
            }
            return msg;
        }

        private List<CPlaylist> getPlaylists()
        {
            List<CPlaylist> list = new List<CPlaylist>();
            foreach(CPlaylist l in m_playlists)
            {
                if (l.ListType == EListType.PLAYLIST)
                    list.Add(l);
            }
            return list;
        }

        private List<CPlaylist> getRankLists()
        {
            List<CPlaylist> list = new List<CPlaylist>();
            foreach (CPlaylist l in m_playlists)
            {
                if (l.ListType == EListType.RANKLIST)
                    list.Add(l);
            }
            return list;
        }

        private List<CPlaylist> getRoundLists()
        {
            List<CPlaylist> list = new List<CPlaylist>();
            foreach (CPlaylist l in m_playlists)
            {
                if (l.ListType == EListType.ROUNDLIST)
                    list.Add(l);
            }
            return list;
        }
    }
}
