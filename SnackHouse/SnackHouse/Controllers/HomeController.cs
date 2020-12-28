using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SnackHouse.Models.ViewModels;
using SnackHouse.Repositories;

namespace SnackHouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISnackRepository _snackRepository;

        public HomeController(ILogger<HomeController> logger, ISnackRepository snackRepository)
        {
            _logger = logger;
            _snackRepository = snackRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferSnacks = _snackRepository.PreferSnacks()
            };
            return View(homeViewModel);
        }
    }
}
