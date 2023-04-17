using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp.Pages;

public class ExportContactsModel : PageModel
{
    private readonly ILogger<ExportContactsModel> _logger;

    public ExportContactsModel(ILogger<ExportContactsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
