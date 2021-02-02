using Microsoft.AspNetCore.Mvc;

namespace SnackHouse.Controllers
{
    public class ContactsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
