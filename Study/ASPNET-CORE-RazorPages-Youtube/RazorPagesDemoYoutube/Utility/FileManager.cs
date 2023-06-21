using IoFile = System.IO.File;
namespace RazorPagesDemoYoutube.Utility
{
    public static class FileManager
    {
        public static async Task<string> CopyFile(IFormFile file, string uploadFolder)
        {
            var extention = Path.GetExtension(file.FileName);
            string newName=Guid.NewGuid().ToString()+extention;   
            var fileDest= Path.Combine(uploadFolder,newName);   
            using(var fileStream = new FileStream(fileDest, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return newName;
        }
        public static void Deletefile(string filePath)
        {
            if (filePath != null)
            {
                if (IoFile.Exists(filePath))
                {
                    IoFile.Delete(filePath);  
                }
            }
        }
    }
}
