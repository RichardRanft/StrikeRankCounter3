﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;

namespace PlaylistImport
{
    public static class CListFileUtil
    {
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

        public static bool RemapPlaylistBasePath(ref CPlaylist list, string optionsBasePath)
        {
            // all playlists and all audio files will reside at the provided base path in
            // <optionsBasePath>/Audio and <optionsBasePath>/Playlists respectively
            bool updated = false;
            List<CPlaylistEntry> removeList = new List<CPlaylistEntry>();
            string temp = list.Path;
            if (!temp.Contains(optionsBasePath))
                updated = true;
            int index = temp.LastIndexOf("Playlist");
            list.Path = optionsBasePath + "\\" + temp.Substring(index);
            foreach (CPlaylistEntry entry in list.Playlist)
            {
                temp = entry.Path;
                if (!temp.Contains(optionsBasePath))
                {
                    updated = true;
                    index = temp.LastIndexOf("Audio");
                    entry.Path = optionsBasePath + "\\" + temp.Substring(index);
                    if (!File.Exists(entry.Path))
                        removeList.Add(entry);
                }
            }
            foreach (CPlaylistEntry entry in removeList)
                list.Playlist.Remove(entry);
            return updated;
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
                String msg = "Unable to read base path from Registry....";
                msg += Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                    msg += Environment.NewLine + ex.InnerException.Message;
                Console.WriteLine("Unable to Read Base Path : {0}", msg);
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
                String msg = "Unable to add base path to Registry....";
                msg += Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                    msg += Environment.NewLine + ex.InnerException.Message;
                Console.WriteLine("Unable to Add Registry Key : {0}", msg);
            }
        }
    }
}
