namespace Contacts;

/// <summary>
/// Represents a contact inside of the contacts manager console application. Provides methods to update key information as well as methods to add and remove communication information.
/// </summary>
public class Contact : IEquatable<Contact>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Birthday? Bday { get; set; }
    public List<Address> Addresses { get; }
    public List<Phone> Numbers { get; }
    public List<string> Emails { get; }
    public ContactCategory Type { get; set; }


    /// <summary>
    /// Create a new Contact object and initialize the data structures responsible for storing multiple addresses, phone numbers, and emails.
    /// </summary>
    /// <param name="firstName">New contact's first name</param>
    /// <param name="lastName">New contact's last name</param>
    /// <param name="type">If null, defaults to "Other"</param>
    public Contact(string firstName, string lastName, ContactCategory? type)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Type = type ?? ContactCategory.Other;

        Addresses = new List<Address>();
        Numbers = new List<Phone>();
        Emails = new List<string>();
    }

    /// <summary>
    /// Create a new Contact object.
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="bday"></param>
    /// <param name="addresses"></param>
    /// <param name="numbers"></param>
    /// <param name="emails"></param>
    /// <param name="type"></param>
    public Contact(string firstName, string lastName, Birthday bday, List<Address> addresses, List<Phone> numbers, List<string> emails, ContactCategory? type)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Bday = bday;
        this.Addresses = addresses;
        this.Numbers = numbers;
        this.Emails = emails;
        
        this.Type = type ?? ContactCategory.Other;
    }

    /// <summary>
    /// If first = true, update only the first name, otherwise update the last name.
    /// </summary>
    /// <param name="name">Updated name</param>
    /// <param name="first">First or last name</param>
    public void UpdateName(string name, bool first)
    {
        if (first)
            FirstName = name;
        else
            LastName = name;
    }

    /// <summary>
    /// Update both the first name and the last name.
    /// </summary>
    /// <param name="fName">Updated first name</param>
    /// <param name="lName">Updated last name</param>
    public void UpdateName(string fName, string lName)
    {
        FirstName = fName;
        LastName = lName;
    }

    /// <summary>
    /// Associate a birthday with the contact.
    /// </summary>
    /// <param name="bday">Birthday object to save</param>
    public void UpdateBDay(Birthday bday)
    {
        this.Bday = bday;
    }

    /// <summary>
    /// Associate a new address with the contact.
    /// </summary>
    /// <param name="a">Address object to add</param>
    public void AddAddress(Address a)
    {
        Addresses.Add(a);
    }

    /// <summary>
    /// Disassociate an address from a contact.
    /// </summary>
    /// <param name="addrToRemove">Address object to find and remove.</param>
    /// <exception cref="ArgumentException">Thrown if the address is not associated with the contact.</exception>
    public void RemoveAddress(Address addrToRemove)
    {
        if (!Addresses.Remove(addrToRemove))
            throw new ArgumentException("Address does not exist.");
    }

    /// <summary>
    /// Add a new Phone to the contact.
    /// </summary>
    /// <param name="newPhone">Phone object to add.</param>
    public void AddPhone(Phone newPhone)
    {
        Numbers.Add(newPhone);
    }

    /// <summary>
    /// Disassociate a phone from a contact.
    /// </summary>
    /// <param name="phoneToRemove">Phone object to find and remove.</param>
    /// <exception cref="ArgumentException">Thrown if the phone is not associated with the contact.</exception>
    public void RemovePhone(Phone phoneToRemove)
    {
        if (!Numbers.Remove(phoneToRemove))
            throw new ArgumentException("Phone number does not exist.");
    }

    /// <summary>
    /// Add a new email to the contact.
    /// </summary>
    /// <param name="email">Email to add.</param>
    public void AddEmail(string email)
    {
        Emails.Add(email);
    }

    /// <summary>
    /// Disassociate an email from a contact.
    /// </summary>
    /// <param name="emailToRemove">Email to search and remove.</param>
    /// <exception cref="ArgumentException">Thrown if the email is not associated with this contact.</exception>
    public void RemoveEmail(string emailToRemove)
    {
        if (!Emails.Remove(emailToRemove))
            throw new ArgumentException("Email does not exist.");
    }

    /// <summary>
    /// Updates the contact type, ie. the relationship to the contact.
    /// </summary>
    /// <param name="type">Type to update to</param>
    public void SetContactType(ContactCategory type)
    {
        this.Type = type;
    }

    // TODO: Need overloaded Equals methods for different situations. This is only checking if two Contact objects are equal, but an imported Contact may not be detected.
    /// <summary>
    /// Determines if two contacts are equal, to avoid potential duplication.
    /// </summary>
    /// <param name="contactToCompare">Contact to compare to. If null, returns false.</param>
    /// <returns>Whether or not the two contacts are the same.</returns>
    public bool Equals(Contact? contactToCompare)
    {
        if (contactToCompare == null)
            return false;

        return this.GetHashCode() == contactToCompare.GetHashCode();
    }

    /// <summary>
    /// Calculates the hashcode of a contact by combining the hashcodes of each field of a contact.
    /// </summary>
    /// <returns>The Contact's hashcode</returns>
    public override int GetHashCode()
    {
        int code = 17;
        code *= FirstName.GetHashCode();
        code *= LastName.GetHashCode();
        code *= Bday.GetHashCode();

        foreach (Address a in Addresses)
        {
            code *= a.GetHashCode();
        }

        foreach (Phone p in Numbers)
        {
            code *= p.GetHashCode();
        }

        foreach (string e in Emails)
        {
            code *= e.GetHashCode();
        }

        code *= Type.GetHashCode();

        return code;
    }
}