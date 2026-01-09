using System;
using System.IO;

namespace MusiVerse.GUI.Utils
{
    public static class MediaHelper
    {
        private static readonly string _mediaFolderPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Resources", "PostMedia");

        static MediaHelper()
        {
            // Create media folder if not exists
            if (!Directory.Exists(_mediaFolderPath))
            {
                Directory.CreateDirectory(_mediaFolderPath);
            }
        }

        /// <summary>
        /// Save media file to project resources folder
        /// </summary>
        public static string SaveMediaFile(string sourceFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath) || !File.Exists(sourceFilePath))
                return "";

            try
            {
                string fileName = Path.GetFileName(sourceFilePath);
                string newFileName = $"{DateTime.Now:yyyyMMddHHmmss}_{fileName}";
                string destPath = Path.Combine(_mediaFolderPath, newFileName);

                File.Copy(sourceFilePath, destPath, overwrite: true);
                return destPath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Không th? l?u media file: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete media file
        /// </summary>
        public static bool DeleteMediaFile(string filePath)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get media type from file extension
        /// </summary>
        public static string GetMediaType(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return "";

            string ext = Path.GetExtension(filePath).ToLower();

            if (".jpg.jpeg.png.gif.bmp".Contains(ext))
                return "Image";
            else if (".mp4.avi.mkv.mov.flv.webm".Contains(ext))
                return "Video";

            return "";
        }

        /// <summary>
        /// Get media folder path
        /// </summary>
        public static string GetMediaFolderPath()
        {
            return _mediaFolderPath;
        }
    }
}
