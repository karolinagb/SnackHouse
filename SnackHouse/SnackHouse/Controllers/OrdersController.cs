using Microsoft.AspNetCore.Mvc;
using SnackHouse.Data;
using SnackHouse.Models;
using SnackHouse.Repositories;
using System;

namespace SnackHouse.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            try
            {
                var items = _shoppingCart.GetShoppingCartItem();
                _shoppingCart.ShoppingCartItems = items;

                if (_shoppingCart.ShoppingCartItems.Count == 0)
                {
                    ModelState.AddModelError("", "Seu carrinho está vazio, inclua um lanche!");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _orderRepository.Insert(order);

                        ViewBag.CompletCheckoutMessage = "Obrigado pelo seu pedido :) ";
                        ViewBag.OrderTotal = _shoppingCart.GetShoppingCartTotalValue();

                        _shoppingCart.CleanShoppingCart();
                        return View("~/Views/Orders/CompletCheckout.cshtml", order);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            

            return View(order);
        }

        //public ActionResult CompletCheckout()
        //{
            //ViewBag.Customer = TempData["Customer"];
            //ViewBag.OrderDate = TempData["OrderDate"];
            //ViewBag.OrderNumber = TempData["OrderNumber"];
            //ViewBag.OrderTotal = TempData["OrderTotal"];
            //ViewBag.CompletCheckoutMessage = "Obrigado pelo seu pedido :) ";
            //return View();
        //}
    }
}
