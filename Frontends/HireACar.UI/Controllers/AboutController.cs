using Microsoft.AspNetCore.Mvc;

namespace HireACar.UI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
