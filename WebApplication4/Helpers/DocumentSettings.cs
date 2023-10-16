using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace WebApplication4.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);

            string FileName = $"{Guid.NewGuid()}{file.FileName}";

            string filePath = Path.Combine(FolderPath, FileName);
            using var FS = new FileStream(filePath, FileMode.Create);
            file.CopyTo(FS);
            return FileName;
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName, fileName);
            if (File.Exists(FolderPath))
            {
                File.Delete(FolderPath);
            }
        }
    }
}