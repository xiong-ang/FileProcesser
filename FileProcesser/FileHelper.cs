using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcesser
{
    public class FileHelper
    {
        public static string OpenFile(string path)
        {
            string ret = string.Empty;
            if(string.IsNullOrWhiteSpace(path))
            {
                ret = "Missing path";
                return ret;
            }

            try
            {
                if (!path.StartsWith("http"))
                {
                    var file = new FileInfo(path);
                    if (!file.Exists) throw new FileNotFoundException();

                    var extensions = new List<string>
                    {
                        ".pdf",
                        ".txt",
                        ".html",
                        ".htm",
                        ".csv",
                        ".doc",
                        ".docx",
                        ".xml"
                    };
                    if (!extensions.Contains(file.Extension.ToLower())) throw new UnauthorizedAccessException();
                }

                //Windows will handle openind file
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception e)
            {
                ret = e.Message;
            }
            return ret;
        }

        public static string OpenFolder(string path)
        {
            string ret = string.Empty;
            if(string.IsNullOrWhiteSpace(path))
            {
                ret = "Missing path";
                return ret;
            }

            try
            {
                if(!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (var process = new System.Diagnostics.Process())
                {
                    process.StartInfo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe");
                    process.StartInfo.Arguments = path;
                    process.Start();
                }
            }
            catch (Exception e)
            {
                ret = e.Message;
            }
            return ret;
        }

        public static string OpenFolderAndSelectFile(string path)
        {
            string ret = string.Empty;
            if (string.IsNullOrWhiteSpace(path))
            {
                ret = "Missing path";
                return ret;
            }

            if (!File.Exists(path))
            {
                ret = "File: " + path + " not found";
                return ret;
            }

            try
            {
                using (var process = new System.Diagnostics.Process())
                {
                    process.StartInfo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe");
                    process.StartInfo.Arguments = "/select, \""+ path + "\"";
                    process.Start();
                }
            }
            catch (Exception e)
            {
                ret = e.Message;
            }
            return ret;
        }
    }
}
