using Microsoft.AspNetCore.Mvc;
using SnackHouse.Models.ViewModels;
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
            //var snacks = _snackRepository.FindAll();
            //return View(snacks);

            var snackListViewModel = new SnackListViewModel();
            snackListViewModel.Snacks = _snackRepository.FindAll();
            snackListViewModel.Category = "Categoria";
            return View(snackListViewModel);
        }
    }
}
