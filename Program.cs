using File = Contacts.File;

public class Program
{
    public static void Main(string[] args)
    {
        File f = new File();
            f.Parse("./testResources/contacts-outlook.csv"); // Expected output: outlook csv
            f.Parse("./testResources/contacts.csv"); // Expected output: google csv
            f.Parse("./testResources/contacts.csv"); // Expected output: google csv
            f.Parse("./testResources/contacts-outlook.csv"); // Expected output: outlook csv
            f.Parse("./testResources/contacts.csv"); // Expected output: google csv
            f.Parse("./testResources/contacts.csv"); // Expected output: google csv

    }
}
