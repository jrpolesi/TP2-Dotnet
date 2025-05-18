using System.ComponentModel.DataAnnotations;
using exercicio5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace exercicio5.Pages.CityManager;

public class CreateCountryModel : PageModel
{
    [BindProperty] public InputModel Input { get; set; }

    public Country SubmittedCountry { get; private set; }
    public bool IsSubmitted { get; private set; } = false;

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            IsSubmitted = false;
            return;
        }

        SubmittedCountry = new Country
        {
            CountryName = Input.CountryName,
            CountryCode = Input.CountryCode
        };

        IsSubmitted = true;
    }

    public class InputModel
    {
        [Required(ErrorMessage = "O nome do país é obrigatório.")]
        [Display(Name = "Nome do País")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "O código do país é obrigatório.")]
        [Display(Name = "Código do País")]
        public string CountryCode { get; set; }
    }
}