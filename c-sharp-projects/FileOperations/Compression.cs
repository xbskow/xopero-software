using Aspose.Zip;
using System;
using System.IO;

namespace FileOperations
{
    public static class Compression
    {
        
        static string rootDir = "C:\\zadanie1";
        public static string Compress(string source, string title, bool verify, DateTime datetime)
        {
            Misc.Schedule(Misc.TimeUntil(datetime));
            string verification = "";
            string destination = Path.Combine(rootDir, "Compress");
            Directory.CreateDirectory(destination);
            destination = Path.Combine(destination, Path.GetFileName(source) + ".zip");
            try
            {
                using (FileStream zipFile = File.Open(destination, FileMode.Create))
                {
                    switch (Misc.IsFolder(source))
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
                    Decompress(destination, title, datetime);
                    verification = " --- " + Checksum.CompareChecksums(source, Path.Combine(rootDir, "Decompress", Path.GetFileNameWithoutExtension(destination)));
                    File.Delete(Path.Combine(rootDir, "Decompress", Path.GetFileNameWithoutExtension(destination)));
                }
                return Misc.Finish(true, title) + verification;
            }
            catch (Exception e)
            {
                return Misc.Finish(false, title, e);
            }

        }
        public static string Decompress(string source, string title, DateTime datetime)
        {
            Misc.Schedule(Misc.TimeUntil(datetime));
            string destination = Path.Combine(rootDir, "Decompress");
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
                                archive.Entries[0].Extract(Path.Combine(destination, Path.GetFileNameWithoutExtension(source)));
                            }
                        }
                        break;
                }
                return Misc.Finish(true, title);
            }
            catch (Exception e)
            {
                return Misc.Finish(false, title, e);
            }

        }
    }
}
