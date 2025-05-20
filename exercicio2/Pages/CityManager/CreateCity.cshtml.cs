using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace exercicio2.Pages.CityManager;

public class CreateCityModel : PageModel
{
    public string? CityName { get; private set; }
    public bool IsSubmitted { get; private set; } = false;

    public void OnPost(string? cityName)
    {
        CityName = cityName;
        IsSubmitted = true;
    }
}