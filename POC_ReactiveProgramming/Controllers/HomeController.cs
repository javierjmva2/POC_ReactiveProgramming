using Microsoft.AspNetCore.Mvc;
using POC_ReactiveProgramming.Interface.Lichess;
using POC_ReactiveProgramming.Interface.Lichess.Observables;
using POC_ReactiveProgramming.Models;
using POC_ReactiveProgramming.Models.Lichess;
using System.Diagnostics;
using System.Reactive;

namespace POC_ReactiveProgramming.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IObservableLichessService _observableLichessService;

        public HomeController(ILogger<HomeController> logger, IObservableLichessService observableLichessService)
        {
            _logger = logger;
            _observableLichessService = observableLichessService;
        }

        public async Task<IActionResult> Index()
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
    }
}
