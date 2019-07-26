using System.IO;

public class FileReader
{
    public int fileRows = 0;

    public FileReader()
    {

    }

    public string ReadString()
    {
        string path = "Assets/Levels/level1.txt";
        string symbols = "";
        StreamReader reader = new StreamReader(path);
        while ( !reader.EndOfStream )
        {
            symbols += reader.ReadLine();
            fileRows++;
        }
        reader.Close();
        return symbols;
    }
}
