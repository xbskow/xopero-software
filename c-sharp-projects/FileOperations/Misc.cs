using System;
using System.IO;

namespace FileOperations
{
    public static class Misc
    {
        public static bool IsFolder(string source)
        {
            if (Directory.Exists(source))
                return true;
            else
                return false;
        }

        public static string Finish(bool success, string title, Exception e = null)
        {
            if (success) return $"Zadanie \"{title}\" zakończone pomyślnie";
            else return $"Coś poszło nie tak z zadaniem \"{title}\" --- {e.Message}";
        }
    }
}
