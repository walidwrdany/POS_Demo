using System.IO;

namespace POS_Demo.Helper
{
    public static class Files
    {
        public static string CreateIfNotExist(string _path)
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath(_path);
            FileInfo file = new FileInfo(filePath);
            if (!file.Exists)
                file.Directory.Create();
            return filePath;
        }
    }
}