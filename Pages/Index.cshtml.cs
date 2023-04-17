using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Contacts;
using Contacts.Controllers;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp.Pages;

public class ContactsModel : PageModel, IEnumerable
{
    private readonly ILogger<ContactsModel> _logger;

    public ContactsModel(ILogger<ContactsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        IEnumerable<Contact> contacts = SortController.DefaultView();
        foreach (Contact c in contacts)
            Console.WriteLine(String.Format("{0} <br />", c.ToString()));
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
