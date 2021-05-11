using System;
using System.IO;
using System.Security.Cryptography;

namespace FileOperations
{
    public static class Encryption
    {
        static string rootDir = "C:\\zadanie1";
        static byte[] seed = File.ReadAllBytes("zadanie1.exe");

        public static string Encrypt(string source, string title, bool verify)
        {
            string verification = "";
            string destination = Path.Combine(rootDir, "Encrypted");
            Directory.CreateDirectory(destination);
            byte[] sourceBytes = File.ReadAllBytes(source);
            try
            {
                byte[] encryptedSourceBytes = ProtectedData.Protect(sourceBytes, seed, DataProtectionScope.CurrentUser);
                File.WriteAllBytes(Path.Combine(destination, Path.GetFileName(source)), encryptedSourceBytes);
                if (verify)
                {
                    Decrypt(Path.Combine(destination, Path.GetFileName(source)), title);
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
        public static string Decrypt(string source, string title)
        {
            string destination = Path.Combine(rootDir, "Decrypted");
            Directory.CreateDirectory(destination);
            byte[] sourceBytes = File.ReadAllBytes(source);
            try
            {
                byte[] decryptedSourceBytes = ProtectedData.Unprotect(sourceBytes, seed, DataProtectionScope.CurrentUser);
                File.WriteAllBytes(Path.Combine(destination, Path.GetFileName(source)), decryptedSourceBytes);
                return Misc.Finish(true, title);
            }
            catch (Exception e)
            {
                return Misc.Finish(false, title, e);
            }
        }
    }
}
