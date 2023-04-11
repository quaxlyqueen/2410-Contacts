namespace Contacts;

/// <summary>
/// Represents the birthday of a contact.
/// </summary>
public class Birthday : IEquatable<Birthday>
{
    private readonly int day;
    private readonly int month;
    private readonly int year;
    public int age { get; }

    /// <summary>
    /// Creates a new Birthday object.
    /// </summary>
    /// <param name="month"></param>
    /// <param name="day"></param>
    public Birthday(int month, int day)
    {
        this.month = month;
        this.day = day;
        year = -1;
        age = -1;
    }

    /// <summary>
    /// Creates a new Birthday and determines the age.
    /// </summary>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="year"></param>
    public Birthday(int month, int day, int year)
    {
        this.month = month;
        this.day = day;
        this.year = year;
        age = 2023 - year;
    }

    /// <summary>
    /// Determines if two birthdays are equal, to avoid potential duplication.
    /// </summary>
    /// <param name="birthdayToCompare">Birthday to compare to. If null, returns false.</param>
    /// <returns>Whether or not the two birthdays are the same.</returns>
    public bool Equals(Birthday? birthdayToCompare)
    {
        if (birthdayToCompare == null)
            return false;

        return this.ToString().Equals(birthdayToCompare.ToString());
    }

    /// <summary>
    /// Formats a birthday to "MM-DD" or "MM-DD-YYYY", if a birthyear was provided.
    /// </summary>
    /// <returns>Formatted birthdate.</returns>
    public override string ToString()
    {
        if (year == -1)
            return month + "-" + day;
        return month + "-" + day + "-" + year;
    }
}