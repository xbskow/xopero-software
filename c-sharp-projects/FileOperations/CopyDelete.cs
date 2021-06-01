using System;
using System.IO;

namespace FileOperations
{
    public static class CopyDelete
    {
        public static string Copy(string source, string destination, string title)
        {
            Directory.CreateDirectory(destination);
            destination = Path.Combine(destination, Path.GetFileName(source));
            string fileName, destFile;
            try
            {
                switch (Misc.IsFolder(source))
                {
                    case true:
                        foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(source, destination));
                        }

                        foreach (string filePath in Directory.GetFiles(source, "*", SearchOption.AllDirectories))
                        {
                            File.Copy(filePath, filePath.Replace(source, destination), true);
                        }
                        break;
                    case false:
                        File.Copy(source, destination, true);
                        break;
                }
                return Misc.Finish(true, title);
            }
            catch (Exception e)
            {
                return Misc.Finish(false, title, e);
            }

        }
        public static string Delete(string source)
        {
            switch (Misc.IsFolder(source))
            {
                case true:
                    if (Directory.Exists(source))
                    {
                        try
                        {
                            Directory.Delete(source, true);
                        }
                        catch (IOException e)
                        {
                            return e.Message;
                        }
                    }
                    break;
                case false:
                    if (File.Exists(source))
                    {
                        try
                        {
                            File.Delete(source);
                        }
                        catch (IOException e)
                        {

                            return e.Message;
                        }
                    }
                    break;
            }
            return "Usuwanie zakończone powodzeniem";
        }
    }
}
