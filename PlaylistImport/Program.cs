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
            if (args.Length > 0)
            {
                String path = args[0];
                if(!Directory.Exists(path))
                {
                    Console.WriteLine("Cound not find {0}", path);
                    return;
                }
                String[] files = Directory.GetFiles(path, "*.playlist");
                foreach(String file in files)
                {
                    String outfile = Path.GetDirectoryName(file);
                    outfile += "\\" + Path.GetFileNameWithoutExtension(file);
                    outfile += ".xml";
                    CPlaylist list = new CPlaylist();
                    list.Load(path);
                    list.Path = outfile;
                    list.Save();
                }
            }
            else
            {
                Console.WriteLine("Must pass folder path with playlist files to import.");
            }
        }
    }
}
