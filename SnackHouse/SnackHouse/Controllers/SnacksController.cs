using Microsoft.AspNetCore.Mvc;
using SnackHouse.Repositories;

namespace SnackHouse.Controllers
{
    public class SnacksController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SnacksController(ISnackRepository snackRepository, ICategoryRepository categoryRepository)
        {
            _snackRepository = snackRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult FindAll()
        {
            var snacks = _snackRepository.FindAll();
            return View(snacks);
        }
    }
}
