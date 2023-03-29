using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Class3.Models;
using Class3.Services;

namespace Class3.Pages;

public class IndexModel : PageModel
{
    public List<Movie> MovieList { get; set; }

    //Mapeapos
    [BindProperty]

    //Crear propieda de tipo Movie para que mapee con el cshtml.cs
    public Movie NewMovie { get; set; }

    public IndexModel()
    {
        // Constructor
    }

    public void OnGet()
    {
        MovieList = MovieService.GetAll();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return RedirectToPage("/Error");
        }
        MovieService.Add(NewMovie);

        return RedirectToAction("get");

    }
}
