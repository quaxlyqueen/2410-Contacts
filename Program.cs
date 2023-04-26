using System.Diagnostics;
using System.Drawing;
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
        Console.WriteLine(Bold("""
   ___               _                _                                               
  / __\ ___   _ __  | |_  __ _   ___ | |_  ___    /\/\    ___  _ __  __ _   ___  _ __ 
 / /   / _ \ | '_ \ | __|/ _` | / __|| __|/ __|  /    \  / _ \| '__|/ _` | / _ \| '__|
/ /___| (_) || | | || |_| (_| || (__ | |_ \__ \ / /\/\ \|  __/| |  | (_| ||  __/| |   
\____/ \___/ |_| |_| \__|\__,_| \___| \__||___/ \/    \/ \___||_|   \__, | \___||_|   
                                                                    |___/             
"""));
        Point point = new Point(Console.CursorLeft, Console.CursorTop++);
        // Console.WriteLine(Environment.GetEnvironmentVariable("HOMEDRIVE"));
        bool isDebug = false;
        bool isExported = false;
        Console.WriteLine($"{Cyan(new string('*', Console.BufferWidth - 3))}");
        Console.Write("> ");
        writeHelpCommand(90, 7);
        Console.SetCursorPosition(point.X, point.Y);
        string? commandString = Console.ReadLine();
        while (commandString != "exit")
        {
            List<String> arguments = commandString.Split(" ").ToList<String>();
            string command = arguments[0];
            arguments.RemoveAt(0);

            switch (command.ToLower())
            {
                case "add":
                    if (arguments.Count < 4)
                    {
                        Console.WriteLine("This command requires an argument. Use \"help\" for more info.");
                        break;
                    }
                    Contact.AddContact(arguments[0], arguments[1], arguments[2], arguments[3]);
                    break;
                case "remove":
                    if (arguments.Count < 2)
                    {
                        Console.WriteLine("This command requires an argument. Use \"help\" for more info.");
                        break;
                    }
                    string fullname = arguments[0];
                    fullname += " " + arguments[1];
                    Contact.RemoveContact(fullname);
                    break;
                case "view":
                    if (isExported)
                    {
                        Process.Start("notepad.exe", "yourContacts.save");
                    }
                    else
                    {
                        Console.WriteLine($"The database hasn't been exported to a {Red(".save")} file. Use {Cyan("EXPORT")} before using this command");
                    }
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
                    fileIO.Save();
                    isExported = true;
                    // TODO: Some way to tell them that it was saved to a certain spot in their computer
                    break;
                case "help":
                    writeHelpCommand(0, 0);
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "debug":
                    if (arguments.Count <= 0)
                    {
                        System.Console.WriteLine("This command requires an argument. Use \"help\" for more info.");
                        break;
                    }
                    if (arguments[0] == "true")
                    {
                        isDebug = true;
                    }
                    else if (arguments[0] == "false")
                    {
                        isDebug = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid argument. Try again.");
                    }
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
    }

    private static void writeHelpCommand(int left, int top)
    {
        if (left == 0 && top == 0)
        {
            Console.WriteLine("Contacts Merger Help\n");
            Console.WriteLine(Bold(Green("ADD {0} {1}")), new string('.', 8), "<FirstName> <LastName> <Phone#> <PhoneCategory>");
            Console.WriteLine("Adds a new contact to the final save file");
            Console.WriteLine(Bold(Yellow("REMOVE {0} {1}")), new string('.', 5), "<FirstName> <LastName>");
            Console.WriteLine("Removes contact from final save file");
            Console.WriteLine(Bold(Blue("IMPORT {0} {1}")), new string('.', 5), "<filePath (.csv) or (.vcf)>");
            Console.WriteLine($"Brings in contacts from either a {Red(".csv")} file or a {Red(".vcf")} file.");
            Console.WriteLine(Bold(Cyan("EXPORT {0}")), new string('.', 5));
            Console.WriteLine($"Takes all contacts taken from {Blue("IMPORT")} and compiles them into a pipe-separated file.");
            Console.WriteLine(Bold(Magenta("VIEW {0}")), new string('.', 5));
            Console.WriteLine($"Opens the .save file that has been exported.");
            Console.WriteLine(Bold(Yellow("EXIT {0}")), new string('.', 7));
            Console.WriteLine($"Exits the program");
        }
        else
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine("Contacts Merger Help\n");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(Bold(Green("ADD {0} {1}")), new string('.', 8), "<FirstName> <LastName> <Phone#> <PhoneCategory>");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("Adds a new contact to the final save file");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(Bold(Yellow("REMOVE {0} {1}")), new string('.', 5), "<FirstName> <LastName>");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("Removes contact from final save file");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(Bold(Blue("IMPORT {0} {1}")), new string('.', 5), "<filePath (.csv) or (.vcf)>");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Brings in contacts from either a {Red(".csv")} file or a {Red(".vcf")} file.");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(Bold(Cyan("EXPORT {0}")), new string('.', 5));
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Takes all contacts taken from {Blue("IMPORT")} and compiles them into a pipe-separated file.");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(Bold(Magenta("VIEW {0}")), new string('.', 5));
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Opens the .save file that has been exported.");
        }
    }
}
