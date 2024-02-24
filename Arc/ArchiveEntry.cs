using Arc.Utiliy;

namespace Arc
{
    public class ArchiveEntry
    {
        //FileName stores the file's name without its extension.
        private string fileName;

        // Extension stores the file's extension with dot (.).
        private string extension;

        // Path stores the file's path in the archive
        private string path;

        // Absolute path contains the real path of the file.
        private string? absolutePath;

        // Creation date stores the file's creation date.
        public DateTime CreationDate { get; set; }

        // Size stores the file's size.
        public long Size { get; set; }

        // Stores the beginning of the content.
        public long DataOffset { get; set; }

        public ArchiveEntry(FileInfo file)
        {
            FileName = file.Name;
            extension = file.Extension;
            path = @"\";
            absolutePath = file.FullName;
            CreationDate = DateTime.Now;
            Size = file.Length;
        }

        public ArchiveEntry(string fileName, string extension,  string path, long size, long dataOffset)
        {
            FileName = fileName;
            this.extension = extension;
            Path = path;
            Size = size;
            DataOffset = dataOffset;
        }

        public static ArchiveEntry[] GetEntriesFromDir(DirectoryInfo directory)
        {
            List<ArchiveEntry> entries = [];

            ExploreSubDirs(directory, entries, @"\");

            return [.. entries];
        }

        private static void ExploreSubDirs(DirectoryInfo directoryInfo, List<ArchiveEntry> entries, string parent)
        {
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                ArchiveEntry entry = new ArchiveEntry(file);
                entry.Path = parent;
                entry.Path = directoryInfo.Name;

                entries.Add(entry);
            }

            DirectoryInfo[] subDirs = directoryInfo.GetDirectories();
            foreach (DirectoryInfo subDir in subDirs)
            {
                ExploreSubDirs(subDir, entries, parent + @"\" + subDir.Parent.Name);
            }
        }

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName += @"\" + value;
            }
        }

        public string Extension
        {
            get { return extension; }
            set
            {
                if (string.IsNullOrEmpty(value)) extension = "";
            }
        }

        public string Path
        {
            get { return path; }
            set
            {
                if (!string.IsNullOrEmpty(value)) path += @"\" + value;
                else path = @"\";
            }
        }

        public string AbsolutePath
        {
            get { return absolutePath; }
            set
            {
                absolutePath = value;
            }
        }
    }
}
