namespace Contacts;

/// <summary>
/// Represents a phone number for a contact. Contains methods to determine if two phone numbers are the same.
/// </summary>
public class Phone : IEquatable<Phone>
{
    private string number;
    public PhoneType? Type { get; }

    /// <summary>
    /// Accepts an input string in the format "1234567890" to create a new Phone object for a Contacts.
    /// </summary>
    /// <param name="number"></param>
    /// <param name="type">If null, defaults to "Other"</param>
    /// <exception cref="ArgumentException">Thrown if input has an invalid format.</exception>
    public Phone(string number, PhoneType? type)
    {
        if (number.Length != 10)
            throw new ArgumentException("Input phone number should be in the format 1234567890.");

        this.number = number;
        this.Type = type;
    }

    /// <summary>
    /// Determines if two phone numbers are equal, to avoid potential duplication.
    /// </summary>
    /// <param name="numberToCompare">Phone number to compare to. If null, returns false.</param>
    /// <returns>Whether or not the two phone numbers are the same.</returns>
    public bool Equals(Phone? numberToCompare)
    {
        if (numberToCompare == null)
            return false;

        return this.ToString().Equals(numberToCompare.ToString());
    }

    /// <summary>
    /// Formats the phone number to "(123) 456 - 7890"
    /// </summary>
    /// <returns>Formatted phone number</returns>
    public override string ToString()
    {
        return "(" + number.Substring(0, 3) + ") " + number.Substring(3, 3) + " - " + number.Substring(6);
    }
}