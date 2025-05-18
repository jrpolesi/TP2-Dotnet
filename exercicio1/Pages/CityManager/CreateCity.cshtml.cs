using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace exercicio1.Pages.CityManager;

public class CreateCityModel : PageModel
{
    [BindProperty] public string CityName { get; set; }
}