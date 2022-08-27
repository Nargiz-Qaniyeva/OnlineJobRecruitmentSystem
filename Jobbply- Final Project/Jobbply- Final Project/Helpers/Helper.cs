using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Jobbply__Final_Project.Helpers
{
    public class Helper
    {
        public static void DeleteFile(IWebHostEnvironment env,string folderassets,string folderimg,string folder, string filename)
        {
            string path = env.WebRootPath;
            string resultPath = Path.Combine(path,folderassets,folderimg, folder, filename);

            if (System.IO.File.Exists(resultPath))
            {
                System.IO.File.Delete(resultPath);
            }
        }
    }

    public enum Roles
    {
        Admin,
        Member,
        SuperAdmin
    }
}
