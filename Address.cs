namespace Contacts;

/// <summary>
/// Represents an address for a contact. Contains methods to determine if two addresses are equal.
/// </summary>
public class Address : IEquatable<Address>
{
    private readonly string _abbr;
    private readonly string _city;
    private readonly string _street;
    private readonly string _zip;
    public AddressType Type { get; }

    /// <summary>
    /// Accepts input string in format "123 Example St,City,ST,12345".
    /// </summary>
    /// <param name="address">Full address</param>
    /// <param name="type">If null, defaults to "Other"</param>
    public Address(string address, AddressType? type)
    {
        string[] parsedAddress = address.Split(",");
        if (parsedAddress.Length != 4)
            throw new ArgumentException("Address must be in the format of \"123 Example St,City,ST,12345\"");

        _street = parsedAddress[0];
        _city = parsedAddress[1];
        _abbr = parsedAddress[2];
        _zip = parsedAddress[3];

        this.Type = type ?? AddressType.Other;
    }

    /// <summary>
    /// Accepts input strings for each part of an address to create a new Address object.
    /// </summary>
    /// <param name="street"></param>
    /// <param name="city"></param>
    /// <param name="abbr"></param>
    /// <param name="zip"></param>
    /// <param name="type">If null, defaults to "Other"</param>
    public Address(string street, string city, string abbr, string zip, AddressType? type)
    {
        this._street = street;
        this._city = city;
        this._abbr = abbr;
        this._zip = zip;

        this.Type = type ?? AddressType.Other;
    }

    /// <summary>
    /// Determines if two addresses are equal, to avoid potential duplication.
    /// </summary>
    /// <param name="otherAddr">Address to compare to. If null, returns false.</param>
    /// <returns>Whether or not the two addresses are the same.</returns>
    public bool Equals(Address? otherAddr)
    {
        if (otherAddr == null)
            return false;

        return this.ToString().Equals(otherAddr.ToString());
    }

    /// <summary>
    /// Formats address object to "123 Example St, City, ST 12345".
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override string ToString()
    {
        return _street + ", " + _city + ", " + _abbr + " " + _zip;
    }
}