using Arc;

internal class Program
{
    static void Debug()
    {
        ArchiveEntry entry1 = new(new FileInfo(@"C:\Users\NİRVANA\Desktop\H A L D U N\Biyoloji\1.jpg"));
        ArchiveEntry entry2 = new(new FileInfo(@"C:\Users\NİRVANA\Desktop\H A L D U N\Biyoloji\2.jpg"));

        Archive archive = new Archive("Mir.arc");
        //archive.AddDirectory(new DirectoryInfo(@"C:\Users\NİRVANA\Desktop\Mir\product"));
        //archive.AddEntry(entry2);


        //archive.Serialize();

        archive.ExtractAll("MirOut");
    }

    private static void Main(string[] args)
    {
        Debug();

        Console.WriteLine("Devam etmek için bir tuşa basın.");
        Console.ReadLine();
    }
}