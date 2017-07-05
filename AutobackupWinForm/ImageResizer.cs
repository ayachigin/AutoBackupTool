using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutobackupWinForm
{
    class ImageResizer: AutoWorker
    {
        private Bitmap img;
        private string sourceFolder;
        private string destinationFolder;
        private int longSide;
        private bool transparentPixel;
        private bool enable;


        public ImageResizer(string sourceFolder, string destinationFolder)
        {
            enable = true;
            this.sourceFolder = sourceFolder;
            this.destinationFolder = destinationFolder + @"\thumbnails";
            this.longSide = 1000;
            this.transparentPixel = false;

            if(!Directory.Exists(this.destinationFolder))
            {
                Directory.CreateDirectory(this.destinationFolder);
            }

        }

        public bool Enable
        {
            get => enable;
            set => enable = value;
        }

        public int LongSide
        {
            get
            {
                return longSide;
            }
            set
            {
                longSide = value;
            }
        }

        public void OnChanged(object source, FileSystemEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            try
            {
                if (!Enable) return;

                if (Path.GetExtension(e.FullPath) != ".png") return;

                using (var fs = new FileStream(e.FullPath, FileMode.Open))
                {
                    img = new Bitmap(fs);
                }

                Resize().Save(destinationFolder + @"\" + Path.GetFileName(e.FullPath));
            } catch(FileNotFoundException)
            {
                Console.Error.WriteLine("Failed resize image :" + e.FullPath);
            }
        }

        public Bitmap Resize()
        {
            var width = img.Size.Width;
            var height = img.Size.Height;

            if (width <= LongSide && height <= LongSide) return img;

            int newWidth = width > height 
                ? longSide
                : (int)((double)width / ((double)height /(double) longSide));
            int newHeight = height > width 
                ? longSide 
                : (int)((double)height / ((double)width / (double)longSide));
            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(newWidth, newHeight);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            g.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, 0, 0, newWidth, newHeight);

            //BitmapとGraphicsオブジェクトを破棄
            img.Dispose();
            g.Dispose();

            return canvas;
        }        
    }
}
