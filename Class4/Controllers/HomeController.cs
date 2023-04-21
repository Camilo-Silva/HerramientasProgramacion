using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Class4.Models;
using Class4.Services;

namespace Class4.Controllers;

public class HomeController : Controller
{
   
// constructor
    public HomeController()
    {
       
    }
// action que devuelve una vista Index
    public IActionResult Index()
    {
        return View();
    }
// action que devuelve una vista Privacy
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
