using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using Aspose.Zip;
using Crypto.AES;
using SharpAESCrypt;

namespace FileOperations
{
    public class FileClass
    {
        string rootDir = "C:\\zadanie1";

        #region encryption
        public string Encryption(string source, string title, bool verify)
        {
            string verification = "";
            string destination = $"{rootDir}\\Encrypted";
            Directory.CreateDirectory(destination);
            try
            {
                SharpAESCrypt.SharpAESCrypt.Encrypt("8RlbaUk4", source, $"{destination}\\{Path.GetFileName(source)}");
                if (verify)
                {
                    Decryption($"{destination}\\{Path.GetFileName(source)}", title);
                    verification = " --- " + CompareChecksums(source, $"C:\\zadanie1\\Decrypted\\{Path.GetFileName(source)}");
                    File.Delete($"C:\\zadanie1\\Decrypted\\{Path.GetFileName(source)}");
                }
                return Finish(true, title) + verification;
                
            }
            catch (Exception e)
            {
                return Finish(false, title, e);
            }
        }
        public string Decryption(string source, string title)
        {
            string destination = $"{rootDir}\\Decrypted";
            Directory.CreateDirectory(destination);
            try
            {
                SharpAESCrypt.SharpAESCrypt.Decrypt("8RlbaUk4", source, $"{destination}\\{Path.GetFileName(source)}");
                return Finish(true, title);
            }
            catch (Exception e)
            {
                return Finish(false, title, e);
            }
        }
        #endregion
        #region compression
        public string Compress(string source, string title, bool verify)
        {
            string verification = "";
            string destination = $"{rootDir}\\Compress";
            Directory.CreateDirectory(destination);
            destination += $"\\{Path.GetFileName(source)}.zip";
            try
            {
                using (FileStream zipFile = File.Open(destination, FileMode.Create))
                {
                    switch (IsFolder(source))
                    {
                        case true:
                            using (Archive archive = new Archive())
                            {
                                DirectoryInfo corpus = new DirectoryInfo(source);
                                archive.CreateEntries(corpus);
                                archive.Save(zipFile);
                            }
                            break;
                        case false:
                            using (FileStream source1 = File.Open(source, FileMode.Open, FileAccess.Read))
                            {
                                using (var archive = new Archive(new Aspose.Zip.Saving.ArchiveEntrySettings()))
                                {
                                    archive.CreateEntry(Path.GetFileName(source), source1);
                                    archive.Save(zipFile);
                                }
                            }
                            break;
                    }
                }
                if (verify)
                {
                    Decompress(destination, title);
                    verification = " --- " + CompareChecksums(source, $"C:\\zadanie1\\Decompress\\{Path.GetFileNameWithoutExtension(destination)}");
                    File.Delete($"C:\\zadanie1\\Decompress\\{Path.GetFileNameWithoutExtension(destination)}");
                }
                return Finish(true, title) + verification;
            }
            catch (Exception e)
            {
                return Finish(false, title, e);
            }

        }
        public string Decompress(string source, string title)
        {
            string destination = $"{rootDir}\\Decompress";
            Directory.CreateDirectory(destination);
            try
            {
                switch (Path.GetExtension(Path.GetFileNameWithoutExtension(source)) != null)
                {
                    case true:
                        using (FileStream zipFile = File.Open(source, FileMode.Open))
                        {
                            using (Archive archive = new Archive(zipFile))
                            {
                                archive.ExtractToDirectory(destination);
                            }
                        }
                        break;
                    case false:
                        using (FileStream fs = File.OpenRead(source))
                        {
                            using (Archive archive = new Archive(fs))
                            {
                                int percentReady = 0;
                                archive.Entries[0].ExtractionProgressed += (s, e) =>
                                {
                                    int percent = (int)((100 * e.ProceededBytes) / ((ArchiveEntry)s).UncompressedSize);
                                    if (percent > percentReady)
                                    {
                                        percentReady = percent;
                                    }
                                };
                                archive.Entries[0].Extract(destination + "\\" + Path.GetFileNameWithoutExtension(source));
                            }
                        }
                        break;
                }
                return Finish(true, title);
            }
            catch (Exception e)
            {
                return Finish(false, title, e);
            }

        }
        #endregion
        #region copy/delete
        public string Copy(string source, string title)
        {
            string destination = $"{rootDir}\\Copy";
            Directory.CreateDirectory(destination);
            destination += $"\\{Path.GetFileName(source)}";
            string fileName, destFile;
            try
            {
                switch (IsFolder(source))
                {
                    case true:
                        if (Directory.Exists(source))
                        {
                            string lastDirectory = Path.GetFileName(source);
                            string newDestination = destination + "\\" + lastDirectory;
                            if (!Directory.Exists(newDestination)) Directory.CreateDirectory(newDestination);

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
                return Finish(true, title);
            }
            catch (Exception e)
            {
                return Finish(false, title, e);
            }

        }
        public string Delete(string source)
        {
            switch (IsFolder(source))
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
        #endregion
        #region checksum verification
        public string CalculateChecksum(string source)
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

        public string CompareChecksums(string before, string after)
        {
            if (CalculateChecksum(before) == CalculateChecksum(after))
                return "Suma kontrolna zgadza się";
            else
                return "Suma kontrolna nie zgadza się";
        }
        #endregion

        #region misc
        public bool IsFolder(string source)
        {
            string extension = Path.GetExtension(source);
            if (extension == String.Empty)
                return true;
            else
                return false;
        }

        public string Finish(bool success, string title, Exception e = null)
        {
            if (success) return $"Zadanie \"{title}\" zakończone pomyślnie";
            else return $"Coś poszło nie tak z zadaniem \"{title}\" --- {e.Message}";
        }
        #endregion
    }
}
