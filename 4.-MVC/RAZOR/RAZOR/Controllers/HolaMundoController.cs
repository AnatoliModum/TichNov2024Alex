using Microsoft.AspNetCore.Mvc;

namespace RAZOR.Controllers
{
    public class HolaMundoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HolaMundo() { 
            return View(); 
        }



    }
}
