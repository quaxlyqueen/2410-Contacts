namespace Contacts;

/// <summary>
/// 
/// </summary>
public class File
{
    public Contact Contact { get; }
    private readonly string _filepath;

    /// <summary>
    /// Create a new file object and generates a new contact object.
    /// </summary>
    /// <param name="filepath"></param>
    public File(string filepath)
    {
        this._filepath = filepath;
    }

    /// <summary>
    /// Manages the parsing process and determines the correct parser to use based upon the filetype.
    /// </summary>
    public void Parse()
    {
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
        // TODO
    }

    /// <summary>
    /// Parse the information contained by the .csv file to generate a new Contact object.
    /// </summary>
    private void ParseCsv()
    {
        // TODO
    }
    
    /// <summary>
    /// Parse the information contained by the .vcf file to generate a new Contact object.
    /// </summary>
    private void ParseVcf()
    {
        // TODO
    }
    
    /// <summary>
    /// Parse the information contained by the .card file to generate a new Contact object.
    /// </summary>
    private void ParseCard()
    {
        // TODO
    }
}