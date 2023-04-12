using Contacts;
using File = Contacts.File;

public class Program
{
    public static void Main(string[] args)
    {
        File f = new File();
            f.Parse("./testResources/contacts.csv");

            List<Contact> contacts = f.Contacts;
            foreach (Contact c in contacts)
            {
                Console.WriteLine(c.ToString());
            }
    }
}
