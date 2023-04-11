using Microsoft.VisualBasic.FileIO;

namespace Contacts;

/// <summary>
/// 
/// </summary>
public class File
{
    public Contact Contact { get; }
    private string _filepath;
    private bool isGoogleCsv;

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
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                if (parser.PeekChars(5).Equals("Name,"))
                    isGoogleCsv = true;
                else
                    isGoogleCsv = false;
                
                parser.ReadLine();
                //Processing row
                string[] fields = parser.ReadFields();
                foreach (string field in fields) 
                {
                    if(!field.Equals(""))
                        contactInfo.Add(field);
                }
            }
        }
        if(isGoogleCsv)
            ParseGoogleCsv(contactInfo);
        else
            ParseOutlookCsv(contactInfo);
    }

    /// <summary>
    /// Parse the information contained by a Google formatted .csv file to generate a new Contact object.
    /// </summary>
    private void ParseGoogleCsv(List<string> csv)
    {
        Console.WriteLine("Google CSV");
        // TODO
    }
    
    /// <summary>
    /// Parse the information contained by an Outlook formatted .csv file to generate a new Contact object.
    /// </summary>
    private void ParseOutlookCsv(List<string> csv)
    {
        Console.WriteLine("Outlook CSV");
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