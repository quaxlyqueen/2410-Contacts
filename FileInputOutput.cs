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
    public static void Print(String file)
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
    public static void SaveWithLineNumbers(String oldFile, string newFile)
    {
        
        using (StreamReader reader = new StreamReader(oldFile))
        using (StreamWriter writer = new StreamWriter(newFile))
        {
            while (!reader.EndOfStream)
            {
                writer.WriteLine($"{reader.ReadLine()}");
            }
        }

    }
}