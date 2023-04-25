using System.Diagnostics;
using System;
using System.Linq;
using System.IO;
using Contacts;

/// <summary>
/// Test program for the contacts manager. Currently, to use, export a contacts list from your Google account or iCloud, in a CSV format. Save this file to bin/Debug/net7.0/testResources.
/// This will allow you to test with your own contacts.
/// Please remove this file prior to any pushes to Github.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // // Uncomment to save to a new file.
        // /*
        // File file = new File("App_Data/testResources/contacts.csv");
        //     fileio.Import(file);
        //     fileio.Save();
        // */

        // // Uncomment to load from a saved file.
        // /*
        // fileio.Load();
        // foreach (Contact c in fileio.QueryState)
        // {
        //     Console.WriteLine(c);
        // }
        // */
        FileIO fileIO = new FileIO();
        Resolver? resolver;
        
        Console.Clear();
        System.Console.WriteLine("CONTACTS PROJECT A05");

        System.Console.Write("> ");
        string? commandString = Console.ReadLine();
        while (commandString != "exit") {
            List<String> arguments = commandString.Split(" ").ToList<String>();
            string command = arguments[0];
            arguments.RemoveAt(0);

            switch (command.ToLower())
            {
                case "add":
                    Contact.AddContact(arguments[1], arguments[2], arguments[3], arguments[4]);
                    break;
                case "remove":
                    string fullname = arguments[1];
                    fullname += " " + arguments[2];
                    Contact.RemoveContact(fullname);
                    break;
                case "view":
                    Process.Start("notepad.exe", "yourContacts.save");
                    break;
                case "import":
                    if (arguments.Count <= 0)
                    {
                        System.Console.WriteLine("This command requires an argument. Use \"help\" for more info.");
                        break;
                    }
                    resolver = new Resolver(@arguments[0]);
                    fileIO.Import(resolver);
                    fileIO.Save(@arguments[0]);
                    Console.WriteLine("NEW FILE MADE (yourContacts.save)");
                    break;
                case "export":
                    break;
                case "help":
                    break;
                case "":
                    break;
                default:
                    System.Console.WriteLine("Invalid Opperation. Try again.");
                    break;
            }

            // DEAD LAST DO NOT TOUCHY
            Console.Write("> ");
            commandString = Console.ReadLine();
        }

        // Console.WriteLine($"COMMAND: {command}\nARGS: {string.Join(", ", arguments)}");
    }
}
