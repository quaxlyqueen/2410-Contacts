using Microsoft.VisualBasic.FileIO;

namespace Contacts;

/// <summary>
/// 
/// </summary>
public class File
{
    public List<Contact> Contacts { get; set; }
    private string _filepath;
    private bool isGoogleCsv;

    public File()
    {
        Contacts = new List<Contact>();
    }

    /// <summary>
    /// Manages the parsing process and determines the correct parser to use based upon the filetype.
    /// </summary>
    public void Parse(string filepath)
    {
        _filepath = filepath;
        String filetype = _filepath.Substring(_filepath.LastIndexOf('.'));

        switch (filetype)
        {
            case ".csv":
                ParseCsv();
                break;
            case ".vcf":
                ParseVcf();
                break;
            case ".card":
                ParseCard();
                break;
        }
    }

    /// <summary>
    /// Convert a CSV file into a List<string>, and determine if the input csv is in the Google contact format or the Outlook contact format.
    /// </summary>
    private void ParseCsv()
    {
        List<string> contactInfo = new List<string>();
        using (TextFieldParser parser = new TextFieldParser(_filepath))
        {                
            if (parser.PeekChars(5).Equals("Name,"))
                isGoogleCsv = true;
            else
                isGoogleCsv = false;
            
            parser.ReadLine(); // skip header row
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                //Processing row
                string[] fields = parser.ReadFields();
                foreach (string field in fields)
                    if(!field.Equals("")) // skip blank fields
                        contactInfo.Add(field);
                
                parser.ReadLine(); // move to next line to read the next contact.
                Parse(contactInfo); // with current contact information, generate and add the new contact.
                contactInfo.Clear(); // clear contact information for next contact.
            }
        }
    }

    /// <summary>
    /// Parse the information contained by a Google formatted .csv file to generate a new Contacts object.
    /// </summary>
    private void Parse(List<string> csv)
    {
        Phone home = null;
        Phone work = null;
        Phone cell = null;
        Phone other = null;
        Contact c;
        string[] contact = csv.ToArray();
        
        // Check if the csv is a google or outlook formatted csv.
        if (isGoogleCsv)
            c = new Contact(contact[1], contact[2].Contains("*") ? "" : contact[2], null);
        else
            c = new Contact(contact[0], contact[1].Contains("*") ? "" : contact[1], null);
        
        // iterate through csv array
        for (int i = 0; i < contact.Length; i++)
        {
            // if current element is labeled as a number, 
            switch (contact[i])
            {
                case "Home":
                    home = ParsePhone(PhoneType.Home, contact[i + 1]);
                    if(home != null)
                        c.AddPhone(home);
                    break;
                case "Work":
                    work = ParsePhone(PhoneType.Work, contact[i + 1]);
                    if(work != null)
                        c.AddPhone(work);
                    break;
                case "Job":
                    work = ParsePhone(PhoneType.Work, contact[i + 1]);
                    if(work != null)
                        c.AddPhone(work);
                    break;
                case "Mobile":
                    cell = ParsePhone(PhoneType.Cell, contact[i + 1]);
                    if(cell != null) 
                        c.AddPhone(cell);
                    break;
                case "Cell":
                    cell = ParsePhone(PhoneType.Cell, contact[i + 1]);
                    if(cell != null) 
                        c.AddPhone(cell);
                    break;
                case "Other":
                    other = ParsePhone(PhoneType.Other, contact[i + 1]);
                    if(other != null)
                        c.AddPhone(other);
                    break;
                default: 
                    other = ParsePhone(PhoneType.Other, contact[i]);
                    if(other != null)
                        c.AddPhone(other);
                    break;
            }
            
            if(contact[i].Contains("@")) // detect an email address and add to the current contact.
                c.AddEmail(contact[i]);
            if (contact[i].Contains("http") || contact[i].Contains("www.")) // detect a URL and add to the current contact.
                c.PictureUrl = contact[i];
        }
        Contacts.Add(c);
    }

    /// <summary>
    /// Parse the information contained by the .vcf file to generate a new Contacts object.
    /// </summary>
    private void ParseVcf()
    {
        // TODO
    }
    
    /// <summary>
    /// Parse the information contained by the .card file to generate a new Contacts object.
    /// </summary>
    private void ParseCard()
    {
        // TODO
    }

    /// <summary>
    /// Parses any format of a phone number into the acceptable format 1234567890.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="number"></param>
    /// <returns></returns>
    private Phone ParsePhone(PhoneType type, string number)
    {
        List<char> list = new List<char>();
        char[] characters = number.ToCharArray();
        
        for (int i = 0; i < characters.Length; i++)
            if (Char.IsDigit(characters[i])) // if the character is a digit, add it to the list
                list.Add(characters[i]);

        if (list.Count == 11) // remove the international code
            list.RemoveAt(0); 
        
        String outputNumber = String.Join("", list);
        if (outputNumber.Length > 10 || outputNumber.Length < 10) // detect if this was an email or address labeled as a generic category, ie. "Home".
            return null;
        
        return new Phone(outputNumber, type);
    }
}