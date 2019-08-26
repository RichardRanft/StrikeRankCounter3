using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistImport
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = CListFileUtil.GetListStartPath();
            if (args.Length > 0)
            {
                path = args[0];
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Cound not find {0}", path);
                    return;
                }
            }
            List<CPlaylist> playlists = new List<CPlaylist>();
            String[] files = Directory.GetFiles(path, "*.playlist");
            foreach (String file in files)
            {
                String outfile = CListFileUtil.GetListStartPath();
                outfile += "\\" + Path.GetFileNameWithoutExtension(file);
                outfile += ".xml";
                CPlaylist list = new CPlaylist();
                list.Load(file);
                list.Path = outfile;
                list.Save();
                playlists.Add(list);
            }
            files = Directory.GetFiles(path, "*.ranklist");
            foreach (String file in files)
            {
                String outfile = CListFileUtil.GetListStartPath();
                outfile += "\\" + Path.GetFileNameWithoutExtension(file);
                outfile += ".xml";
                CPlaylist list = new CPlaylist();
                list.Load(file);
                list.Path = outfile;
                list.Save();
                playlists.Add(list);
            }
            files = Directory.GetFiles(path, "*.roundlist");
            foreach (String file in files)
            {
                String outfile = CListFileUtil.GetListStartPath();
                outfile += "\\" + Path.GetFileNameWithoutExtension(file);
                outfile += ".xml";
                CPlaylist list = new CPlaylist();
                list.Load(file);
                list.Path = outfile;
                list.Save();
                playlists.Add(list);
            }
        }
    }
}
