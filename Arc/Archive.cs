using Arc.Utiliy;

namespace Arc
{
    public class Archive
    {
        public const int MAGIC_NUMBER = 0x415243;
        public string Path { get; set; }

        public List<ArchiveEntry> Entries { get; set; }

        public Archive(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            Path = file.FullName;
            Entries = new List<ArchiveEntry>();

            // Load existing archive
            if (file.Exists)
            {
                BinaryReader br = new BinaryReader(File.OpenRead(Path));
                
                int magic = br.ReadInt32();
                CheckMagic(magic);

                string fileName = br.ReadString();
                string extension = br.ReadString();
                string path = br.ReadString();
                string creationDate = br.ReadString();
                long size = br.ReadInt64();
                long dataOffset = br.ReadInt64();

                
                
                Entries.Add(new ArchiveEntry(fileName, extension, path, size, dataOffset));

                

                br.Close();
            }
        }

        public void ExtractEntry(ArchiveEntry archiveEntry, string outDir)
        {
            Directory.CreateDirectory(outDir);

            FileStream fs = File.OpenRead(Path);
            fs.Position = archiveEntry.DataOffset;

            // Create file
            FileStream extractedFile = File.Create(outDir + archiveEntry.Path + archiveEntry.FileName);

            byte[] buffer = new byte[4096];
            int okunan = 0;
            while ((okunan += fs.Read(buffer, 0, buffer.Length)) > 0)
            {
                extractedFile.Write(buffer, 0, buffer.Length);
                if (okunan > archiveEntry.Size) break;
            }

            extractedFile.Close();
            fs.Close();
        }

        private static void CheckMagic(int magic)
        {
            if (magic != MAGIC_NUMBER) throw new Exception("File type was not an arc file.");
        }

        public void AddEntry(ArchiveEntry entry)
        {
            Entries.Add(entry);
        }

        public void Serialize()
        {
            BinaryWriter br = new BinaryWriter(File.Create(Path));

            br.Write(MAGIC_NUMBER);

            foreach (ArchiveEntry entry in Entries)
            {
                br.Write(entry.FileName);
                br.Write(entry.Extension);
                br.Write(entry.Path);
                br.Write(entry.CreationDate.ToString());
                br.Write(entry.Size);
                br.Write(entry.DataOffset = br.BaseStream.Position + 8);

                byte[] buffer = new byte[4096];
                FileStream sourceFile = File.OpenRead(entry.AbsolutePath);
                while (sourceFile.Read(buffer, 0, buffer.Length) != 0)
                {
                    br.Write(buffer, 0, buffer.Length);
                }

                br.Close();
            }
        }
    }
}
