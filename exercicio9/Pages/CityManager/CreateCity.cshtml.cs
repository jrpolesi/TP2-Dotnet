using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace exercicio9.Pages.CityManager;

public class CreateCityModel : PageModel
{
    [BindProperty] public InputModel Input { get; set; }

    public static List<string> Cities { get; private set; } = ["Rio", "São Paulo", "Brasília"];

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            return;
        }

        Cities.Add(Input.CityName);

        ModelState.Remove("Input.CityName");
        Input.CityName = string.Empty;
    }

    public class InputModel
    {
        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome da cidade deve ter pelo menos 3 caracteres.")]
        public string CityName { get; set; }
    }
}