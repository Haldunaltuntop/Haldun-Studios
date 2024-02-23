using Arc;

internal class Program
{
    static void Debug()
    {
        ArchiveEntry archiveEntry = new(new FileInfo(@"C:\Users\NİRVANA\Desktop\H A L D U N\Biyoloji\1.jpg"));

        Archive archive = new Archive("test.arc");
        archive.AddEntry(archiveEntry);

        archive.Serialize();

        archive.ExtractEntry(archive.Entries[0], "test");
    }

    private static void Main(string[] args)
    {
        Debug();

        Console.WriteLine("Devam etmek için bir tuşa basın.");
        Console.ReadLine();
    }
}