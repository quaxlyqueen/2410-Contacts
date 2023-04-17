using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp.Pages;

public class AddContactsModel : PageModel
{
    private readonly ILogger<AddContactsModel> _logger;

    public AddContactsModel(ILogger<AddContactsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
