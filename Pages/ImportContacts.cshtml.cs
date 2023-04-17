using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp.Pages;

public class ImportContactsModel : PageModel
{
    private readonly ILogger<ImportContactsModel> _logger;

    public ImportContactsModel(ILogger<ImportContactsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
