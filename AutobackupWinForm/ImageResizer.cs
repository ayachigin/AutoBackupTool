using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutobackupWinForm
{
    class ImageResizer
    {
        private Bitmap img;

        ImageResizer(string path)
        {
            try
            {
                img = new Bitmap(path);
            } catch(ArgumentException e)
            {
                MessageBox.Show("画像をリサイズしようとしましたが失敗しました。\n" + e);
            }
        }

        public Bitmap Resize(int longSide, bool transparentPixel)
        {
            var width = img.Size.Width;
            var height = img.Size.Height;
            var newWidth = width > height ? longSide : width / (height / longSide);
            var newHeight = height > width ? longSide : height / (width / longSide);
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
