using System;
using System.IO;
using System.Threading;

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

        public static int TimeUntil(DateTime datetime)
        {
            DateTime now = DateTime.Now;
            int milisecsUntil = (int) (datetime - now).TotalMilliseconds;
            return milisecsUntil;
        }

        public static void Schedule(int timeUntil)
        {
            if (timeUntil > 0)
                Thread.Sleep(timeUntil);
        }
    }
}
