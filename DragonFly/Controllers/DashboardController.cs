using Microsoft.AspNetCore.Mvc;

namespace DragonFly.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
