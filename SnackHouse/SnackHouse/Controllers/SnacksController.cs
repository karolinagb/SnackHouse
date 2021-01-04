using Microsoft.AspNetCore.Mvc;
using SnackHouse.Models;
using SnackHouse.Models.ViewModels;
using SnackHouse.Repositories;
using System;
using System.Collections.Generic;

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

        public IActionResult List(string categoryName)
        {
            try{
                string _categoryName = categoryName;
                IEnumerable<Snack> snacks;

                if (string.IsNullOrEmpty(_categoryName))
                {
                    snacks = _snackRepository.FindAll();
                    _categoryName = "Todos os lanches";
                }
                else
                {
                    snacks = _snackRepository.SnackByCategory(_categoryName);
                    _categoryName = categoryName;
                }

                var snackListViewModel = new SnackListViewModel();
                snackListViewModel.Snacks = snacks;
                snackListViewModel.Category = _categoryName;
                return View(snackListViewModel);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult Details(int id)
        {
            var snack = _snackRepository.GetById(id);
            if(snack == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(snack);
        }

        public IActionResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Snack> snacks;

            if (string.IsNullOrEmpty(_searchString))
            {
                snacks = _snackRepository.FindAll();
            }
            else
            {
                snacks = _snackRepository.GetByStringSearch(_searchString);
            }

            return View(snacks);
        }
    }
}
