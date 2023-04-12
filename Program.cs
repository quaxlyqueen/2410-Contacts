using Contacts;

/// <summary>
/// Test program for the contacts manager. Currently, to use, export a contacts list from your Google account or iCloud, in a CSV format. Save this file to bin/Debug/net7.0/testResources.
/// This will allow you to test with your own contacts.
/// Please remove this file prior to any pushes to Github.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        FileIo fileio = new FileIo();
        
        // Uncomment to save to a new file.
        /*
        File file = new File("testResources/contacts.csv");
            fileio.Import(file);
            fileio.Save();
        */

        // Uncomment to load from a saved file.
        /*
        fileio.Load();
        foreach (Contact c in fileio.currentState)
        {
            Console.WriteLine(c);
        }
        */
    }
}