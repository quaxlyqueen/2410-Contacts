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
        FileIO fileIO = new FileIO();
        Resolver? resolver;
        
        Console.Clear();
        Console.ResetColor();
        // Console.WriteLine("CONTACTS PROJECT A05");
        Console.WriteLine("""
   _____               _                _          __  __                               
  / ____|             | |              | |        |  \/  |                              
 | |      ___   _ __  | |_  __ _   ___ | |_  ___  | \  / |  ___  _ __  __ _   ___  _ __ 
 | |     / _ \ | '_ \ | __|/ _` | / __|| __|/ __| | |\/| | / _ \| '__|/ _` | / _ \| '__|
 | |____| (_) || | | || |_| (_| || (__ | |_ \__ \ | |  | ||  __/| |  | (_| ||  __/| |   
  \_____|\___/ |_| |_| \__|\__,_| \___| \__||___/ |_|  |_| \___||_|   \__, | \___||_|   
                                                                       __/ |            
                                                                      |___/             
""");

        System.Console.Write("> ");
        string? commandString = Console.ReadLine();
        while (commandString != "exit") {
            List<String> arguments = commandString.Split(" ").ToList<String>();
            string command = arguments[0];
            arguments.RemoveAt(0);

            switch (command.ToLower())
            {
                case "add":
                    Contact.AddContact(arguments[0], arguments[1], arguments[2], arguments[3]);
                    break;
                case "remove":
                    string fullname = arguments[0];
                    fullname += " " + arguments[1];
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
                    break;
                case "export":
                    if (arguments.Count <= 0)
                    {
                        System.Console.WriteLine("This command requires an argument. Use \"help\" for more info.");
                        break;
                    }
                    fileIO.Save(arguments[0]); // probably doesn't need new fileName due to Contact.AddContact and Contact.RemoveContact
                    // TODO: Some way to tell them that it was saved to a certain spot in their computer
                    break;
                case "help":
                    Console.WriteLine("Contacts Merger Help\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ADD {0} {1}", new string('.', 8), "<FirstName> <LastName> <Phone#> <PhoneCategory>");
                    Console.WriteLine("Adds a new contact to the save file");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("REMOVE {0} {1}", new string('.', 5), "<FirstName> <LastName>");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("IMPORT {0} {1}", new string('.', 5), "<filePath (.csv) or (.vcf)>");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("EXPORT {0} {1}", new string('.', 5), "<newFileName>");
                    Console.ResetColor();
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
