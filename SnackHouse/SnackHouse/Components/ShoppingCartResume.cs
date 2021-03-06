﻿using Microsoft.AspNetCore.Mvc;
using SnackHouse.Models;
using SnackHouse.Models.ViewModels;
using System.Collections.Generic;

namespace SnackHouse.Components
{
    public class ShoppingCartResume : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartResume(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItem();

            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                TotalValueShoppingCart = _shoppingCart.GetShoppingCartTotalValue()
            };

            return View(shoppingCartViewModel);
        }
    }
}
