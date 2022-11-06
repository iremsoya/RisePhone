using Microsoft.AspNetCore.Mvc;

namespace Contact.Api.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
