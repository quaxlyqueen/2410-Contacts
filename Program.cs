using Contacts;
using File = Contacts.File;

/// <summary>
/// Test program for the contacts manager. Currently, to use, export a contacts list from your Google account or iCloud, in a CSV format. Save this file to bin/Debug/net7.0/testResources.
/// This will allow you to test with your own contacts.
/// Please remove this file prior to any pushes to Github.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();

        FileIo fileio = new FileIo();
        
        // Uncomment to save to a new file.
        /*
        File file = new File("App_Data/testResources/contacts.csv");
            fileio.Import(file);
            fileio.Save();
        */
        
        // Uncomment to load from a saved file.
        /*
        fileio.Load();
        foreach (Contact c in fileio.QueryState)
        {
            Console.WriteLine(c);
        }

        */
    }
}
