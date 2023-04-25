using System.Diagnostics;
using System;
using System.Linq;
using System.IO;
using Contacts;
using static Crayon.Output;
using Crayon;

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
        var rainbow = new Rainbow(0.5);
        // Console.WriteLine("CONTACTS PROJECT A05");
        Console.WriteLine(Bold("""
   ___               _                _                                               
  / __\ ___   _ __  | |_  __ _   ___ | |_  ___    /\/\    ___  _ __  __ _   ___  _ __ 
 / /   / _ \ | '_ \ | __|/ _` | / __|| __|/ __|  /    \  / _ \| '__|/ _` | / _ \| '__|
/ /___| (_) || | | || |_| (_| || (__ | |_ \__ \ / /\/\ \|  __/| |  | (_| ||  __/| |   
\____/ \___/ |_| |_| \__|\__,_| \___| \__||___/ \/    \/ \___||_|   \__, | \___||_|   
                                                                    |___/             
"""));
        Console.Write("> ");
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
                    Console.WriteLine(Bold(Green("ADD {0} {1}")), new string('.', 8), "<FirstName> <LastName> <Phone#> <PhoneCategory>");
                    Console.WriteLine("Adds a new contact to the final save file");
                    Console.WriteLine(Bold(Yellow("REMOVE {0} {1}")), new string('.', 5), "<FirstName> <LastName>");
                    Console.WriteLine("Removes contact from final save file");
                    Console.WriteLine(Bold(Blue("IMPORT {0} {1}")), new string('.', 5), "<filePath (.csv) or (.vcf)>");
                    Console.WriteLine($"Brings in contacts from either a {Red(".csv")} file or a {Red(".vcf")} file.");
                    Console.WriteLine(Bold(Cyan("EXPORT {0} {1}")), new string('.', 5), "<newFileName>");
                    Console.WriteLine($"Takes all contacts taken from {Blue("IMPORT")} and compiles them into a pipe-separated file.");
                    break;
                case "":
                    break;
                default:
                    Console.WriteLine("Invalid Opperation. Try again.");
                    break;
            }

            // DEAD LAST DO NOT TOUCHY
            Console.Write(rainbow.Next().Bold().Text("> "));
            commandString = Console.ReadLine();
        }

        // Console.WriteLine($"COMMAND: {command}\nARGS: {string.Join(", ", arguments)}");
    }
}
