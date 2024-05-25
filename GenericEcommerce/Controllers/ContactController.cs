using Microsoft.AspNetCore.Mvc;

namespace GenericEcommerce.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
