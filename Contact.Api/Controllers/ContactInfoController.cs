using Microsoft.AspNetCore.Mvc;

namespace Contact.Api.Controllers
{
    public class ContactInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
