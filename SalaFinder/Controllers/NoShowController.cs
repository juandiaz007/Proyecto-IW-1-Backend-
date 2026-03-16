using Microsoft.AspNetCore.Mvc;

namespace SalaFinder.Interfaces
{
    public class NoShowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
