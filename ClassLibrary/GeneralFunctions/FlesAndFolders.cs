using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibary.GeneralFunctions
{
    public class FlesAndFolders
    {
        public static string GetHomePath()
        {

            if (Environment.OSVersion.Platform == System.PlatformID.Unix)
                return Environment.GetEnvironmentVariable("HOME");

            return Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
        }
        public static string GetDownloadFolderPath()
        {
            if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
            {
                string pathDownload = System.IO.Path.Combine(GetHomePath(), "Downloads");
                return pathDownload;
            }

            return System.Convert.ToString(
                Microsoft.Win32.Registry.GetValue(
                     @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders"
                    , "{374DE290-123F-4565-9164-39C4925E467B}"
                    , String.Empty
                )
            );
        }
    }
}
