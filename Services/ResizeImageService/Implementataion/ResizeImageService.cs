using System;
using System.Drawing;

namespace Services.ResizeImageService.Implementataion
{
    public interface IResizeImageService
    {
        Image ResizeImage(Image image, int maxWidth, int maxHeight);
    }

    public class ResizeImageService : IResizeImageService
    {
        public Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double) maxWidth/image.Width;
            var ratioY = (double) maxHeight/image.Height;
            
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width*ratio);
            var newHeight = (int)(image.Height*ratio);

            var newImage = new Bitmap(newWidth, newHeight);
       
            Graphics.FromImage(newImage).DrawImage(image, 0,0, newWidth,newHeight);
            return newImage;
        }
    }
}