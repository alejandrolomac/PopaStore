using Microsoft.AspNetCore.Mvc;

namespace PopaStore.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}