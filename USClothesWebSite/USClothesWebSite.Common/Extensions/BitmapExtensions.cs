using System;
using System.Drawing;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Extensions
{
    public static class BitmapExtensions
    {
        public static Bitmap ResizeBitmap(this Bitmap sourceBitmap, int maxWidth, int maxHeight)
        {
            CheckHelper.ArgumentNotNull(sourceBitmap, "sourceBitmap");
            CheckHelper.ArgumentWithinCondition(maxWidth >= 2, "maxWidth >= 2");
            CheckHelper.ArgumentWithinCondition(maxHeight >= 2, "maxHeight >= 2");

            var originalWidth = (double)sourceBitmap.Width;
            var originalHeight = (double)sourceBitmap.Height;

            var longestDimension = Math.Max(originalWidth, originalHeight);
            var shortestDimension = Math.Min(originalWidth, originalHeight);
            var factor = longestDimension / shortestDimension;

            var newWidth =
                originalWidth < originalHeight
                    ? (int)(maxHeight / factor)
                    : maxWidth;

            var newHeight =
                originalWidth < originalHeight
                    ? maxHeight
                    : (int)(maxWidth / factor);

            var resizedBitmap = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(resizedBitmap))
                graphics.DrawImage(sourceBitmap, 0, 0, newWidth, newHeight);

            return resizedBitmap;
        }
    }
}
