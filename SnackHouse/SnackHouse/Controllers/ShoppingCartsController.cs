﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SnackHouse.Models;
using SnackHouse.Models.ViewModels;
using SnackHouse.Repositories;

namespace SnackHouse.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartsController(ISnackRepository snackRepository, ICategoryRepository categoryRepository, ShoppingCart shoppingCart)
        {
            _snackRepository = snackRepository;
            _categoryRepository = categoryRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var itens = _shoppingCart.GetShoppingCartItem();
            _shoppingCart.ShoppingCartItems = itens;

            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                TotalValueShoppingCart = _shoppingCart.GetShoppingCartTotalValue(),
                Categories = _categoryRepository.FindAll()
            };

            return View(shoppingCartViewModel);
        }

        [Authorize]
        public IActionResult AddItem(int snackId)
        {
            var selectedSnack = _snackRepository.GetById(snackId);

            if(selectedSnack != null)
            {
                _shoppingCart.AddCartItem(selectedSnack);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoveItem(int snackId)
        {
            var selectedSnack = _snackRepository.GetById(snackId);
            if(selectedSnack != null)
            {
                _shoppingCart.RemoveCartItem(selectedSnack);
            }
            return RedirectToAction("Index");
        }
    }
}
