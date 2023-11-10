using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using odev1.Models;

namespace odev1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(Repository.Yazokuls);
    }

    public IActionResult About()
    {
        return View();
    }

   
}
