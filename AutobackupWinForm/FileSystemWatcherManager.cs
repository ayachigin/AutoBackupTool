using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutobackupWinForm
{
    public class FileSystemWatcherManager
    {
        private FileSystemWatcher fswatcher;
        private string[] extensions;
        private AutoBackup autobackup;
        private ImageResizer imageResizer;

        public FileSystemWatcherManager(string source, string dest, string[] exts)
        {
            SourceFolder = source;
            DestinationFolder = dest;
            Extensions = exts;

            fswatcher = new FileSystemWatcher(source);

            SetupFSWatcher();
        }

        public string SourceFolder { set; get; }

        public string DestinationFolder { set; get; }

        public string[] Extensions
        {
            // Drop first dot if exists
            set
            {
                this.extensions = value.Select(v =>
                {
                    if (v.StartsWith("."))
                    {
                        return v.Remove(0, 1);
                    }
                    else
                    {
                        return v;
                    }
                }).ToArray();
            }
            get
            {
                return this.extensions;
            }
        }

        private void SetupFSWatcher()
        {
            if (this.IsReady)
            {
                autobackup = new AutoBackup(SourceFolder, DestinationFolder, extensions);

                fswatcher.IncludeSubdirectories = true;
                fswatcher.NotifyFilter = NotifyFilters.LastWrite
                                       | NotifyFilters.FileName;

                fswatcher.Changed += new FileSystemEventHandler(autobackup.OnChanged);
                fswatcher.Created += new FileSystemEventHandler(autobackup.OnChanged);

                imageResizer = new ImageResizer(SourceFolder, DestinationFolder);

                fswatcher.Changed += new FileSystemEventHandler(imageResizer.OnChanged);
                fswatcher.Created += new FileSystemEventHandler(imageResizer.OnChanged);

                Enable = true;
                EnableAutoBackup = true;
            }
        }

        public bool IsReady
        {
            get
            {
                return Directory.Exists(SourceFolder) &&
                       Directory.Exists(DestinationFolder) &&
                       this.extensions.Length != 0;
            }
        }

        public bool Enable
        {
            set
            {
                if (value && this.IsReady)
                {
                    fswatcher.EnableRaisingEvents = value;
                }
                else
                {
                    fswatcher.EnableRaisingEvents = false;
                }
            }

            get
            {
                return this.IsReady && fswatcher.EnableRaisingEvents;
            }

        }

        public bool EnableAutoBackup
        {
            set
            {
                if (value && IsReady)
                {
                    autobackup.Enable = value;
                } else
                {
                    autobackup.Enable = false;
                }

            }

            get
            {
                return IsReady && autobackup.Enable;
            }
        }

        public bool EnableImageResizer {
            set
            {
                if (value && IsReady)
                {
                    imageResizer.Enable = true;

                }
                else
                {
                    imageResizer.Enable = false;
                }
            }
            get => imageResizer.Enable;
        }

        public int ImageSizeOfLongSide
        {
            set => imageResizer.LongSide = value;
            get => imageResizer.LongSide;
        }

    }

}
