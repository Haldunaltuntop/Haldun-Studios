using Arc;
using Arc.Archiver;

internal class Program
{
    private static void Main(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            string arg = args[i];

            // Handle createion command
            if (arg == Commands.CreateCommand)
            {
                List<string> parameters = new List<string>();

                // Read parameters until new command
                for (; i < args.Length; i++) if (!args[i].StartsWith("-")) parameters.Add(args[i]);

                CreateArchive(parameters.ToArray(), GenerateArchiveName());
            }
        }
    }

    //
    // Creates suitable archive name.
    // 
    private static void CreateArchive(string[] parameters, string outName)
    {
        Archive archive = new Archive(outName + ".arc");

        foreach (string param in parameters)
        {
            DirectoryInfo directory = new DirectoryInfo(param);
            FileInfo fileInfo = new FileInfo(param);

            // If param is directiory get subitems.
            if (directory.Exists)
            {
                archive.AddDirectory(directory);
            }

            // If param is file add as entry.
            else if (fileInfo.Exists)
            {
                ArchiveEntry archiveEntry = new ArchiveEntry(fileInfo);
                archive.AddEntry(archiveEntry);
            }
        }

        archive.Serialize();
    }

    private static string GenerateArchiveName()
    {
        int i = 0;
        if (File.Exists(Settings.Default.DefaultArchiveName))
        {
            while (File.Exists(Settings.Default.DefaultArchiveName + i++)) ;

            return Settings.Default.DefaultArchiveName + i;
        }

        return Settings.Default.DefaultArchiveName;
    }

    public static class Settings
    {
        public static class Default
        {
            public static string DefaultArchiveName = "Arşiv";
        }
    }
}