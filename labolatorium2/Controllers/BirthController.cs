using Microsoft.AspNetCore.Mvc;

namespace labolatorium2.Controllers
{
    public class BirthController : Controller
    {

        public IActionResult BirthForm()
        {
            return View();
        }
    }
}
