namespace Contacts;

/// <summary>
/// Manages the contacts database and facilitates viewing the database via searching and sorting. Contains methods to update the current view.
/// </summary>
public class FileIo
{
    public IEnumerable<Contact> currentState { get; set; }
    private readonly List<Contact> _contacts = new();
    //private string _filepath = "~/.contacts";

    /// <summary>
    /// Create the FileIo object and set default view.
    /// </summary>
    public FileIo()
    {
        currentState =
            from c in _contacts
            select c;
    }

    /// <summary>
    ///     Facilitates incoming compatability with .vcf, .card, and .csv filetypes for contacts into this console-based
    ///     contacts manager.
    /// </summary>
    /// <param name="file"></param>
    public void Import(File file)
    {
        file.Parse();
        List<Contact> contacts = file.Contacts;
        foreach (Contact c in contacts)
            _contacts.Add(c);
    }

    /// <summary>
    /// Facilitates outgoing compatability with .vcf, .card, and .csv filetypes for contacts into this console-based contacts manager.
    /// </summary>
    /// <param name="onIos"></param>
    public void Export(bool onIos)
    {
        // TODO
    }

    /// <summary>
    /// Save the contacts in the database to a file.
    /// </summary>
    /// <param name="newFile"></param>
    public void Save()
    {
        using (StreamWriter writer = new StreamWriter("yourContacts.save"))
        {
            foreach (Contact c in _contacts)
            {
                writer.WriteLine($"{c.SaveString()}");
            }
        }
    }
    
    /// <summary>
    /// Load the saved contacts in the database.
    /// </summary>
    public void Load()
    {
        using (StreamReader reader = new StreamReader("yourContacts.save"))
        {
            while (!reader.EndOfStream)
            {
                _contacts.Add(new Contact(reader.ReadLine()));
            }
        }
    }
    

}