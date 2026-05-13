using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentosWeb.ConsoleApp.Controllers;

public class HomeController : Controller
{
    // GET: HomeController
    public ActionResult Index()
    {

        return View();
    }
}
