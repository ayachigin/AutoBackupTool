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
    public class AutoBackup
    {
        /* AutoBackup
         * 
         * Normally paint apps are save file in safe way. 
         * By using temp file and rename it and copy it and so on.
         * Which means if literally perform autosave to the modified files, there are so many same files are copied.
         * To avoid this, autosave app ignores the file saved consecutively within 5 seconds.
         * 
         */

        private FileSystemWatcher fswatcher;
        private string sourceDir;
        private string destDir;
        private string[] exts;
        private List<string> saveFileQueue;

        public AutoBackup(string sourceDir, string destDir, string[] exts)
        {
            this.sourceDir = sourceDir;
            this.destDir = destDir;
            this.exts = exts;
            this.saveFileQueue = new List<string>();

            fswatcher = new FileSystemWatcher(sourceDir);

            fswatcher.IncludeSubdirectories = true;
            fswatcher.NotifyFilter = NotifyFilters.LastWrite
                                   | NotifyFilters.FileName;

            fswatcher.Changed += new FileSystemEventHandler(OnChanged);
            fswatcher.Created += new FileSystemEventHandler(OnChanged);
            fswatcher.Renamed += new RenamedEventHandler(OnRenamed);
            //Console.WriteLine(e.FullPath.StartsWith(pwd));

            Start();
        }

        public void Start()
        {
            fswatcher.EnableRaisingEvents = true;
        }

        public void SetPath(string path)
        {
            fswatcher.Path = path;
        }

        public void SetExtensions(string[] extensions)
        {
            this.exts = extensions;
        }

        public void Stop()
        {
            fswatcher.EnableRaisingEvents = false;
        }

        public string NewFileName(string path)
        {
            var baseName = Path.GetFileNameWithoutExtension(path);
            var ext = Path.GetExtension(path);
            var dateNum = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            return destDir + "\\" + baseName + dateNum + ext;
        }

        private async void OnChanged(object source, FileSystemEventArgs e)
        {
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
            if (e.FullPath.StartsWith(destDir))
            {
                return;
            }

            saveFileQueue.Add(e.FullPath);

            // Perform backup
            await AsyncCopy(e.FullPath, NewFileName(e.FullPath));

            Console.WriteLine("File: " + e.FullPath + " : " + e.ChangeType);
            Console.WriteLine("New file: " + NewFileName(e.FullPath));
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
