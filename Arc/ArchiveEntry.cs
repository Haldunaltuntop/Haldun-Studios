using System.Security.Cryptography;

namespace Arc
{
    public class ArchiveEntry
    {
        //FileName stores the file's name without its extension.
        public string FileName { get; set; }

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
            this.path = path;
            Size = size;
            DataOffset = dataOffset;
        }

        public ArchiveEntry(DirectoryInfo directoryInfo)
        {
            throw new NotImplementedException();
        }

        // Reads file's contents by byte.
        public byte[] GetContent()
        {
            throw new NotImplementedException();
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
                path = @"\" + value;
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
