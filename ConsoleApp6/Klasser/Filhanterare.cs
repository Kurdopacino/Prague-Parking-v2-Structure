using System.IO;

static class GarageFileHandler
{
    private const string FilePath = "garageData.txt";

    public static void Save(string[] data) => File.WriteAllLines(FilePath, data);

    public static string[] Load(int size) => File.Exists(FilePath) ? File.ReadAllLines(FilePath) : new string[size];
}
