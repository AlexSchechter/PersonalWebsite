using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace Blog.Models
{
    public static class ImageUploadValidator
    {
        public static bool IsWebFriendlyImage(HttpPostedFileBase uploadedFile)
        {
            if (uploadedFile == null || uploadedFile.ContentLength < 1024 || uploadedFile.ContentLength > 5 * 1024 * 1024)
                return false;
            
            try
            {
                using (var image = Image.FromStream(uploadedFile.InputStream))
                {
                    return ImageFormat.Jpeg.Equals(image.RawFormat) || ImageFormat.Png.Equals(image.RawFormat) || ImageFormat.Gif.Equals(image.RawFormat);         
                }
            }
            catch
            {
                return false;
            }
        }
    }
}