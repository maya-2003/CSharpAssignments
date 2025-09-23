using Microsoft.AspNetCore.Mvc;

namespace MVCSession2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View(); //Return View With The Same Name Of Action (Index)
            //return View("Index"); //Return View With Specific Name
            //return View("Index", new Movie()); //Return View With Specific Name And Model
            return View();
        }
    }
}
