using Arc;

internal class Program
{
    static void Debug()
    {
        ArchiveEntry entry1 = new(new FileInfo(@"C:\Users\NİRVANA\Desktop\H A L D U N\Biyoloji\1.jpg"));
        ArchiveEntry entry2 = new(new FileInfo(@"C:\Users\NİRVANA\Desktop\H A L D U N\Biyoloji\2.jpg"));

        Archive archive = new Archive("a.arc");
        //ArchiveEntry[] entries = ArchiveEntry.GetEntriesFromDir(new DirectoryInfo(@"C:\Users\NİRVANA\Desktop\H A L D U N\Biyoloji"));
        //foreach (ArchiveEntry entry in entries)
        //{
        //    archive.AddEntry(entry);
        //}


        //archive.Serialize();

        archive.ExtractAll("Test");
    }

    private static void Main(string[] args)
    {
        Debug();

        Console.WriteLine("Devam etmek için bir tuşa basın.");
        Console.ReadLine();
    }
}