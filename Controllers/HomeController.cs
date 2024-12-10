using Microsoft.AspNetCore.Mvc;
using CasoPractico2.Models;
using CasoPractico2.Services;
using System.Diagnostics;

namespace CasoPractico2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITrasientServices _trasient;
        private readonly IScopedServices _scoped;
        private readonly ISingeltonServices _singelton;


        public HomeController(ILogger<HomeController> logger, ITrasientServices trasient, IScopedServices scoped, ISingeltonServices singelton)
        {
            _logger = logger;
            _trasient = trasient;
            _scoped = scoped;
            _singelton = singelton;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ListaServicios([FromServices] ITrasientServices trasient2, [FromServices] IScopedServices scoped2, [FromServices] ISingeltonServices singelton2) 
        {
            ViewData["trasient"] = _trasient.ObtenerID();
            ViewData["scoped"] = _scoped.ObtenerID();
            ViewData["singelton"] = _singelton.ObtenerID();

            ViewBag.trasient2 = trasient2.ObtenerID();
            ViewBag.scoped2 = scoped2.ObtenerID();
            ViewBag.singelton2 = singelton2.ObtenerID();

            return View();
        }
    }
}
