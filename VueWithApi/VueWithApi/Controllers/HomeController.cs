using Microsoft.AspNetCore.Mvc;

namespace VueWithApi.Controllers
{
    public class HomeController : Controller
    {    
        // The SPA fallback page. Must not have a route attribute.
        public IActionResult Index()
        {
            return View();
        }
    }
}
