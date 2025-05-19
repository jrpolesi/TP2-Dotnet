using System.ComponentModel.DataAnnotations;
using exercicio7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace exercicio7.Pages.CityManager;

public class CreateCountryModel : PageModel
{
    [BindProperty] public List<InputModel> Countries { get; set; } = [];
    public List<Country> SubmittedCountries { get; private set; } = [];
    public bool IsSubmitted { get; private set; } = false;

    public void OnGet()
    {
        for (var i = 0; i < 5; i++)
            Countries.Add(new InputModel());
    }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            return;
        }

        SubmittedCountries = Countries
            .Select(c => new Country
            {
                CountryName = c.CountryName,
                CountryCode = c.CountryCode
            }).ToList();
        IsSubmitted = true;
    }

    public class InputModel
    {
        [Required(ErrorMessage = "O nome do país é obrigatório.")]
        [Display(Name = "Nome do País")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "O código do país é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O código do país deve conter exatamente 2 letras.")]
        [Display(Name = "Código do País")]
        public string CountryCode { get; set; }
    }
}