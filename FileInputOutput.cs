namespace Contacts;

/// <summary>
/// File input and output operations.
/// </summary>
public class FileInputOutput
{
    /// <summary>
    /// Print the contents of the file to the console.
    /// </summary>
    /// <param name="file"></param>
    public static void Print(string file)
    {
        try
        {
            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to read/write files.");
        }
    }

    /// <summary>
    /// Save the original file to a new file, with line numbers.
    /// </summary>
    /// <param name="oldFile"></param>
    /// <param name="newFile"></param>
    public static void SaveWithLineNumbers(string oldFile, string newFile)
    {
        
        using (StreamReader reader = new StreamReader(oldFile))
        using (StreamWriter writer = new StreamWriter(newFile))
        {
            int line = 1;
            while (!reader.EndOfStream)
            {
                writer.WriteLine($"{line++:00} {reader.ReadLine()}");
            }
        }

    }
}