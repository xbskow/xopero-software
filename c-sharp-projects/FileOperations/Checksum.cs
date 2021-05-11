using System;
using System.IO;
using System.Security.Cryptography;

namespace FileOperations
{
    public static class Checksum
    {
        public static string CalculateChecksum(string source)
        {
            using (MD5 md5instance = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(source))
                {
                    byte[] hashResult = md5instance.ComputeHash(stream);
                    return BitConverter.ToString(hashResult).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public static string CompareChecksums(string before, string after)
        {
            if (CalculateChecksum(before) == CalculateChecksum(after))
                return "Suma kontrolna zgadza się";
            else
                return "Suma kontrolna nie zgadza się";
        }
    }
}
