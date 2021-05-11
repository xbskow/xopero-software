using System;
using System.IO;

namespace FileOperations
{
    public static class CopyDelete
    {
        static string rootDir = "C:\\zadanie1";
        public static string Copy(string source, string title)
        {
            string destination = Path.Combine(rootDir, "Copy"); 
            Directory.CreateDirectory(destination);
            destination = Path.Combine(destination, Path.GetFileName(source));
            string fileName, destFile;
            try
            {
                switch (Misc.IsFolder(source))
                {
                    case true:
                        if (Directory.Exists(source))
                        {
                            string lastDirectory = Path.GetFileName(source);
                            string newDestination = Path.Combine(destination, lastDirectory);
                            if (!Directory.Exists(newDestination)) 
                                Directory.CreateDirectory(newDestination);

                            string[] files = Directory.GetFiles(source);
                            foreach (string s in files)
                            {
                                fileName = Path.GetFileName(s);
                                destFile = Path.Combine(newDestination, fileName);
                                File.Copy(s, destFile, true);
                            }
                        }
                        else return "Ścieżka nie istnieje.";
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
