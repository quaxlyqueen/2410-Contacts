namespace Contacts;

/// <summary>
/// Manages the contacts database and facilitates viewing the database via searching and sorting. Contains methods to update the current view.
/// </summary>
public class FileIo
{
    public IEnumerable<Contact> currentState { get; set; }
    private readonly List<Contact> _contacts = new();
    private string _filepath = "~/.contacts";

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
        // TODO
    }

    /// <summary>
    ///     Facilitates outgoing compatability with .vcf, .card, and .csv filetypes for contacts into this console-based
    ///     contacts manager.
    /// </summary>
    /// <param name="onIos"></param>
    public void Export(bool onIos)
    {
        // TODO
    }

    /// <summary>
    ///     Saves database state to a file.
    /// </summary>
    public void Save()
    {
        // TODO
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
    /// Search the database for contacts with the provided first name.
    /// </summary>
    /// <param name="name"></param>
    public void SearchByFirstName(string name)
    {
        currentState =
            from c in _contacts
            where c.FirstName == name
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
            where c.LastName == name
            select c;
    }

    /// <summary>
    /// Sort the database by contact first name.
    /// </summary>
    /// <param name="name"></param>
    public void SortByFirstName(string name)
    {
        currentState =
            (from c in _contacts
                select c).OrderBy(contact => contact.FirstName);
    }

    /// <summary>
    /// Sort the database by contact last name.
    /// </summary>
    /// <param name="name"></param>
    public void SortByLastName(string name)
    {
        currentState =
            (from c in _contacts
                select c).OrderBy(contact => contact.LastName);
    }

    /// <summary>
    /// Sort the database by contact birthdate.
    /// </summary>
    /// <param name="name"></param>
    public void SortByBirthdate(string name)
    {
        currentState =
            (from c in _contacts
                select c).OrderBy(contact => contact.Bday);
    }

    /// <summary>
    /// Sort the database by contact category.
    /// </summary>
    /// <param name="name"></param>
    public void SortByCategory(string name)
    {
        currentState =
            (from c in _contacts
                select c).OrderBy(contact => contact.Type);
    }

    /// <summary>
    /// Remove a contact from the database.
    /// </summary>
    /// <param name="cToDelete">Contact object to find and remove.</param>
    /// <exception cref="ArgumentException">Thrown if the contact is not stored in the database.</exception>
    public void Delete(Contact cToDelete)
    {
        if(!_contacts.Remove(cToDelete))
            throw new ArgumentException("Contact does not exist.");
    }
}