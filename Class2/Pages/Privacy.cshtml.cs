using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase2.Pages;

public class PrivacyModel : PageModel
{
    
    private readonly ILogger<PrivacyModel> _logger;

    // Generamos data
    public Form Data { get; set; }

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        // Creamos Data con ner Form
        // Seteamos .Mail y .Password

        // buscar en la base de datos el formulario con iud que esta en el parametro
        // var formuilario = servicioFormulario.get(formulario)
        var parametro = Request.Query["parametrox"];
        Data = new Form();
        Data.Mail = "test@gmail.com";
        Data.Password = "12345";
    }

    public IActionResult OnPost(){
        if (!ModelState.IsValid)
        {
            return Page();
        }
        //guardamos en la bd, se envia la info, procesar la info, etc.
        var formValues = Data;

        return RedirectToPage("Index");
    }
}


