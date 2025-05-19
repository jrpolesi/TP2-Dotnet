using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace exercicio8.Pages.CityManager;

public class CreateCityModel : PageModel
{
    [BindProperty] public InputModel Input { get; set; }

    public bool IsSubmitted { get; private set; } = false;
    public string SubmittedName { get; private set; }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            IsSubmitted = false;
            return;
        }

        SubmittedName = Input.CityName;
        IsSubmitted = true;
    }

    public class InputModel
    {
        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome da cidade deve ter pelo menos 3 caracteres.")]
        public string CityName { get; set; }
    }
}