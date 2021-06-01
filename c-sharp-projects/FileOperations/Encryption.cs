using System;
using System.IO;
using System.Security.Cryptography;

namespace FileOperations
{
    public static class Encryption
    {
        static string rootDir = "C:\\zadanie1";

        public static string Encrypt(string source, string title, bool verify, string password)
        {
            string verification = "";
            string destination = Path.Combine(rootDir, "Encrypted");
            Directory.CreateDirectory(destination);
            try
            {
                SharpAESCrypt.SharpAESCrypt.Encrypt(password, source, Path.Combine(destination, Path.GetFileName(source)));
                if (verify)
                {
                    Decrypt(Path.Combine(destination, Path.GetFileName(source)), title, password);
                    verification = " --- " + Checksum.CompareChecksums(source, Path.Combine(rootDir, "Decrypted", Path.GetFileName(source)));
                    File.Delete(Path.Combine(rootDir, "Decrypted", Path.GetFileName(source)));
                }
                return Misc.Finish(true, title) + verification;

            }
            catch (Exception e)
            {
                return Misc.Finish(false, title, e);
            }
        }
        public static string Decrypt(string source, string title, string password)
        {
            string destination = Path.Combine(rootDir, "Decrypted");
            Directory.CreateDirectory(destination);
            try
            {
                SharpAESCrypt.SharpAESCrypt.Decrypt(password, source, Path.Combine(destination, Path.GetFileName(source)));
                return Misc.Finish(true, title);
            }
            catch (Exception e)
            {
                return Misc.Finish(false, title, e);
            }
        }
    }
}
