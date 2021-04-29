using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using Aspose.Zip;

namespace FileOperations
{
    public class FileClass
    {
        string password = "8Rlba_Uk4";
        byte[] saltValueBytes = Encoding.ASCII.GetBytes("This is my salt");
        #region encryption
        public void Encryption(string source)
        {
            string destination = source + ".enc";

            Rfc2898DeriveBytes passwordKey = new Rfc2898DeriveBytes(password, saltValueBytes);

            RijndaelManaged alg = new RijndaelManaged();
            alg.Key = passwordKey.GetBytes(alg.KeySize / 8);
            alg.IV = passwordKey.GetBytes(alg.BlockSize / 8);

            using (FileStream inFile = new FileStream(source, FileMode.Open, FileAccess.Read))
            {
                byte[] fileData = new byte[inFile.Length];
                inFile.Read(fileData, 0, (int)inFile.Length);
                ICryptoTransform encryptor = alg.CreateEncryptor();

                using (FileStream outFile = new FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    CryptoStream encryptStream = new CryptoStream(outFile, encryptor, CryptoStreamMode.Write);
                    encryptStream.Write(fileData, 0, fileData.Length);
                }
            }
        }
        public void Decryption(string source)
        {
            string destination = source + ".dec";

            Rfc2898DeriveBytes passwordKey = new Rfc2898DeriveBytes(password, saltValueBytes);

            RijndaelManaged alg = new RijndaelManaged();
            alg.Key = passwordKey.GetBytes(alg.KeySize / 8);
            alg.IV = passwordKey.GetBytes(alg.BlockSize / 8);

            ICryptoTransform decryptor = alg.CreateDecryptor();
            using (FileStream inFile = new FileStream(source, FileMode.Open, FileAccess.Read))
            {
                CryptoStream decryptStream = new CryptoStream(inFile, decryptor, CryptoStreamMode.Read);
                byte[] fileData = new byte[inFile.Length];
                decryptStream.Read(fileData, 0, (int)inFile.Length);

                using (FileStream outFile = new FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    outFile.Write(fileData, 0, fileData.Length);
                }
            }
        }
        #endregion
        #region compression
        public void Compress(string source, string destination, bool isFolder, bool toEncrypt)
        {
            using (FileStream zipFile = File.Open(destination, FileMode.Create))
            {
                switch (isFolder)
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
        }
        public void Decompress(string source, string destination, bool isFolder)
        {
            switch (isFolder) // sprawdzić czy dekompresowanie folderu działa
            {
                case true:
                    using (FileStream zipFile = File.Open(source, FileMode.Open))
                    {
                        StringBuilder sb = new StringBuilder("Entries are: ");
                        int percentReady = 0;
                        using (Archive archive = new Archive(zipFile, new ArchiveLoadOptions()
                        {
                            EntryListed = (s, e) => { sb.Append($"{e.Entry.Name} "); },
                            EntryExtractionProgressed = (s, e) =>
                            {
                                int percent = (int)((100 * e.ProceededBytes) / ((ArchiveEntry)s).UncompressedSize);
                                if (percent > percentReady)
                                {
                                    Console.WriteLine($"{percent} compressed");
                                    percentReady = percent;
                                }
                            }
                        }))

                        {
                            Console.WriteLine(sb.ToString(0, sb.Length - 2));
                            using (FileStream extracted = File.Create(destination))
                            {
                                using (Stream decompressed = archive.Entries[0].Open())
                                {
                                    byte[] buffer = new byte[8192];
                                    int bytesRead;
                                    while (0 < (bytesRead = decompressed.Read(buffer, 0, buffer.Length)))
                                    {
                                        extracted.Write(buffer, 0, bytesRead);
                                    }
                                }
                            }
                            percentReady = 0;
                            archive.Entries[1].Extract(destination);
                        }
                    }
                    break;
                case false: // wypakowywanie jednego pliku wymaga podania jego odpowiedniego rozszerzenia. dopisać funkcjonalność
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
                                    Console.WriteLine(string.Format($"{percent}% decompressed"));
                                    percentReady = percent;
                                }
                            };
                            archive.Entries[0].Extract(destination);
                        }
                    }
                    break;
            }
        }
        #endregion
        #region copy/delete
        public void Copy(string source, string destination, bool isFolder, bool toEncrypt)
        {
            string fileName, destFile;
            switch (isFolder)
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
                    else Console.WriteLine("Ścieżka nie istnieje");
                    break;
                case false:
                    File.Copy(source, destination + "\\" + Path.GetFileName(source), true);
                    break;
            }
        }
        public void Delete(string source, bool isFolder)
        {
            switch (isFolder)
            {
                case true:
                    if (Directory.Exists(source))
                    {
                        try
                        {
                            Directory.Delete(source, true); // usuwa zawartość folderów read only ale nie same foldery
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine(e.Message);
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
                            Console.WriteLine(e.Message);
                            return;
                        }
                    }
                    break;
            }
        }
        #endregion
        public string WriteStatus(string taskType, string taskProgress)
        {
            string ending;
            if (taskProgress == "indev") ending = "w toku...";
            else ending = "przebiegło pomyślnie.";
            return $"Zadanie {taskType} {ending}";
        }
    }
}
