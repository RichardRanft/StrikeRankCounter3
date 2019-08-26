using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using log4net;

namespace SRC3
{
    public static class CListFileUtil
    {
        private static ILog m_log = LogManager.GetLogger(typeof(CListFileUtil));

        public static String BuildMultiSelectFileList(ListBox sourcebox, String path = "")
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
            foreach(object item in sourcebox.SelectedItems)
            {
                sb.Append(String.Format("{0}\\{1}", path, item.ToString()));
                if (++index < sourcebox.SelectedItems.Count)
                    sb.Append(";");
            }
            return sb.ToString();
        }

        public static String GetListFilename(String listname, String extension)
        {
            String playlistname = listname;
            String startPath = GetListStartPath();
            String[] files = Directory.GetFiles(startPath);
            bool addNumber = false;
            int count = 1;
            foreach (String file in files)
            {
                if (Path.GetFileName(file).Contains(playlistname))
                {
                    addNumber = true;
                    ++count;
                }
            }
            if (addNumber)
                playlistname += count.ToString() + extension;
            else
                playlistname += extension;

            return playlistname;
        }

        public static String GetListStartPath()
        {
            String startPath = GetBasePathFromRegistry();
            if (startPath.Contains("\\bin\\Debug") || startPath.Contains("\\bin\\Release"))
            {
                startPath = startPath.Replace("\\bin\\Debug", "");
                startPath = startPath.Replace("\\bin\\Release", "");
            }
            startPath += "\\Playlists\\";
            return startPath;
        }

        public static void InitPlaylist(ref CPlaylist list, ref ComboBox cbx, ref ListBox lbx, String name, String path, EListType type)
        {
            list = new CPlaylist();
            list.Name = name;
            list.Path = path + "\\" + name;
            list.ListType = type;
            lbx.Items.Clear();
            cbx.Items.Add(list);
            cbx.Sorted = false;
            cbx.Sorted = true;
            cbx.Invalidate();
            cbx.Refresh();
            for (int i = 0; i < cbx.Items.Count; ++i)
            {
                if (cbx.Items[i].ToString() == list.Name)
                {
                    cbx.SelectedIndex = i;
                    break;
                }
            }
        }

        public static string GetBasePathFromRegistry()
        {
            try
            {
                String basePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Roostertail Games\\SRC3";
                RegistryKey roostertail = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Roostertail Games\\SRC3");
                if (roostertail == null)
                {
                    roostertail = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Roostertail Games\\SRC3");
                    roostertail.SetValue("basePath", basePath);
                    return basePath;
                }
                else
                    return roostertail.GetValue("basePath").ToString();
            }
            catch (Exception ex)
            {
                m_log.Error("Unable to read base path from registry....", ex);
                String msg = "Unable to read base path from Registry....";
                msg += Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                    msg += Environment.NewLine + ex.InnerException.Message;
                MessageBox.Show(msg, "Unable to Read Base Path");
                return "";
            }
        }

        public static void SetBasePathInRegistry(String value)
        {
            try
            {
                RegistryKey roostertail = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Roostertail Games\\SRC3");
                if (roostertail == null)
                    roostertail = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Roostertail Games\\SRC3");
                roostertail.SetValue("basePath", value);
            }
            catch (Exception ex)
            {
                m_log.Error("Unable to add base path to Registry....", ex);
                String msg = "Unable to add base path to Registry....";
                msg += Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                    msg += Environment.NewLine + ex.InnerException.Message;
                MessageBox.Show(msg, "Unable to Add Registry Key");
            }
        }
    }
}
