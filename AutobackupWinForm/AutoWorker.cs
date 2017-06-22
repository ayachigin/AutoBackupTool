using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutobackupWinForm
{
    interface AutoWorker
    {
        bool Enable
        {
            set; get;
        }

        void OnChanged(object source, FileSystemEventArgs e);
    }
}
