using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Class4.Models;
using Class4.Services;

namespace Class4.Controllers;

public class MovieController : Controller
{

    // constructor
    public MovieController()
    {

    }
    // action que devuelve una vista Index
    public IActionResult Index()
    {
        var model = new List<Movie>();
        model = MovieService.GetAll();

        return View(model);
    }
    // action que devuelve el detalle de las peliculas
    // Se recibe por parametro un codigo
    // Y por servicio traemos nuestro elemento que luego va a la vista
    public IActionResult Detail(string id)
    {
        var model = MovieService.Get(id);

        return View(model);
    }


    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Create(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }

        MovieService.Add(movie);

        return RedirectToAction("Index");

    }

    public IActionResult Delete()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Delete(string code)
    {
       if (!ModelState.IsValid)
        {
            return RedirectToAction("Delete");
        }

        MovieService.Delete(code);

        return RedirectToAction("Index");
    }
}
