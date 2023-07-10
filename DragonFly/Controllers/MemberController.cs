using Microsoft.AspNetCore.Mvc;

namespace DragonFly.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult MemberDetails()
        {
            return View();
        }
    }
}
