using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;

namespace AutobackupWinForm
{
    public class AutoBackup : AutoWorker
    {
        /* AutoBackup
         * 
         * Normally paint apps are save file in safe way. 
         * By using temp file and rename it and copy it and so on.
         * Which means if literally perform autosave to the modified files, there are so many same files are copied.
         * To avoid this, autosave app ignores the file saved consecutively within 5 seconds.
         * 
         */
        public bool Enable { set; get; }

        private string[] exts;
        private List<string> saveFileQueue;

        public AutoBackup(string sourceDir, string destDir, string[] exts)
        {
            SourceFolder = sourceDir;
            DestinationFolder = destDir;
            this.exts = exts;
            this.saveFileQueue = new List<string>();

        }

        public string SourceFolder { set; get; }

        public string DestinationFolder { set; get; }

        public void SetExtensions(string[] extensions)
        {
            this.exts = extensions;
        }

        public static string GetTimeString()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        public string NewFileName(string path, string dateNum)
        {
            var baseName = Path.GetFileNameWithoutExtension(path);
            var ext = Path.GetExtension(path);

            return DestinationFolder + @"\" + baseName + dateNum + ext;
        }

        public async void OnChanged(object source, FileSystemEventArgs e)
        {
            if (!Enable) return;

            if (!File.Exists(e.FullPath)) return;

            var ext = Path.GetExtension(e.FullPath);

            if (ext == null) return;

            var extWithoutDot = ext.Remove(0, 1);

            // When the file is not backup target
            if(!Array.Exists(this.exts, element => element == extWithoutDot))
            {
                return;
            }

            // Ignore consecutively saved files within 5 second
            if (saveFileQueue.Any(element => element == e.FullPath))
            {
                return;
            }

            // Ignore files in backup folder
            if (Path.GetDirectoryName(e.FullPath)
                    .StartsWith(DestinationFolder))
            {
                return;
            }

            saveFileQueue.Add(e.FullPath);

            Console.WriteLine("File: " + e.FullPath + " : " + e.ChangeType);
            Console.WriteLine("New file: " + NewFileName(e.FullPath, GetTimeString()));

            // Perform backup
            await AsyncCopy(e.FullPath, NewFileName(e.FullPath, GetTimeString()));
        }

        async Task AsyncCopy(string s, string d, int retryCount = 3)
        {
            await Task.Delay(5000);
            if (File.Exists(s) && 
                !File.Exists(d))
            {
                try
                {
                    File.Copy(s, d);
                    saveFileQueue.Remove(s);
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                Console.WriteLine("File does not found: " + s);
            }
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " : " + e.ChangeType);
        }
    }
}
