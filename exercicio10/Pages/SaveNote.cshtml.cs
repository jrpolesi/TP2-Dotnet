using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace exercicio10.Pages;

public class SaveNoteModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; }

    public string FileName { get; set; }

    public void OnPost()
    {
        if (!ModelState.IsValid)
            return;

        var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        var fileName = $"note-{timestamp}.txt";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", fileName);
        var directoryPath = Path.GetDirectoryName(filePath);

        if (directoryPath == null)
        {
            return;
        }
        
        Directory.CreateDirectory(directoryPath);
        System.IO.File.WriteAllText(filePath, Input.Content);

        FileName = fileName;
    }
    
    public class InputModel
    {
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Content { get; set; }
    }
}