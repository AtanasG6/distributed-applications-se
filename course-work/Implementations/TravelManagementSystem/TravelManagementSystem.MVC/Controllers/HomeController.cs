using Microsoft.AspNetCore.Mvc;

namespace TravelManagementSystem.MVC.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
