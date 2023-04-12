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
        DefaultView();
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
        DefaultView();
    }
    
    /// <summary>
    /// Default view of the database.
    /// </summary>
    public void DefaultView()
    {
        currentState =
            from c in _contacts
            select c;
    }

    /// <summary>
    /// Search the database for contacts with the provided first name. Utilizes LINQ.
    /// </summary>
    /// <param name="name"></param>
    public void SearchByFirstName(string name)
    {
        currentState =
            from c in _contacts
            where c.FirstName.Contains(name)
            select c;
    }

    /// <summary>
    /// Search the database for contacts with the provided last name.
    /// </summary>
    /// <param name="name"></param>
    public void SearchByLastName(string name)
    {
        currentState =
            from c in _contacts
            where c.LastName.Contains(name)
            select c;
    }

    /// <summary>
    /// Sort the database by contact first name.
    /// </summary>
    /// <param name="ascending"></param>
    public void SortByFirstName(bool ascending)
    {
        if (ascending)
            currentState =
                (from c in _contacts
                    select c).OrderBy(contact => contact.FirstName);

        else
            currentState =
                (from c in _contacts
                    select c).OrderByDescending(contact => contact.FirstName);
    }

    /// <summary>
    /// Sort the database by contact last name.
    /// </summary>
    /// <param name="ascending"></param>
    public void SortByLastName(bool ascending)
    {
        if (ascending)
            currentState =
                (from c in _contacts
                    select c).OrderBy(contact => contact.LastName);

        else
            currentState =
                (from c in _contacts
                    select c).OrderByDescending(contact => contact.LastName);
    }

    /// <summary>
    /// Sort the database by contact birthdate.
    /// </summary>
    /// <param name="ascending"></param>
    public void SortByBirthdate(bool ascending)
    {
        if (ascending)
            currentState =
                (from c in _contacts
                    select c).OrderBy(contact => contact.Bday);

        else
            currentState =
                (from c in _contacts
                    select c).OrderByDescending(contact => contact.Bday);
    }

    /// <summary>
    /// Sort the database by contact category.
    /// <param name="ascending"></param>
    public void SortByCategory(bool ascending)
    {
        if (ascending)
            currentState =
                (from c in _contacts
                    select c).OrderBy(contact => contact.Type);

        else
            currentState =
                (from c in _contacts
                    select c).OrderByDescending(contact => contact.Type);
    }

    /// <summary>
    /// Remove a contact from the database.
    /// </summary>
    /// <param name="cToDelete">Contacts object to find and remove.</param>
    /// <exception cref="ArgumentException">Thrown if the contact is not stored in the database.</exception>
    public void Delete(Contact cToDelete)
    {
        if (!_contacts.Remove(cToDelete))
            throw new ArgumentException("Contacts does not exist.");
    }
}