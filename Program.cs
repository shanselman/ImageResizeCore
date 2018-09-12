using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace imageresize
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 128;
            int height = 128;
            var file = args[0];
            Console.WriteLine($"Loading {file}");
            using(FileStream pngStream = new FileStream(args[0],FileMode.Open, FileAccess.Read))
            using(var image = new Bitmap(pngStream))
            {
                var resized = new Bitmap(width, height);
                using (var graphics = Graphics.FromImage(resized))
                {
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.DrawImage(image, 0, 0, width, height);
                    resized.Save($"resized-{file}", ImageFormat.Png);
                    Console.WriteLine($"Saving resized-{file} thumbnail");
                }       
            }     
        }
    }
}
