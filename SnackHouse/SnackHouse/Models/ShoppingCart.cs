using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SnackHouse.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnackHouse.Models
{
    public class ShoppingCart
    {
        private readonly SnackHouseDbContext _snackHouseDbContext;

        public ShoppingCart()
        {

        }

        //injeta o contexto no construtor
        public ShoppingCart(SnackHouseDbContext snackHouseDbContext)
        {
            _snackHouseDbContext = snackHouseDbContext;
        }

        //Vamos Utilizar o Guid
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            //define uma sessão acessando o contexto atual ()
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto 
            var context = services.GetService<SnackHouseDbContext>();

            //obtem ou gera o Id do carrinho
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessão
            session.SetString("CartId", cartId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId
            };
        }

        public void AddCartItem(Snack snack)
        {
            var shoppingCartItem =
                _snackHouseDbContext.ShoppingCartItems.SingleOrDefault(
                    item => item.Snack.Id == snack.Id && item.ShoppingCartId == ShoppingCartId);

            //Verifica se o carrinho existe, se não existir cria um
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Snack = snack
                    //Quantity = quantity
                };
                _snackHouseDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else //se existir o carrinho com o item então incrementa a quantidade
            {
                //shoppingCartItem.Quantity += quantity;
            }
            _snackHouseDbContext.SaveChanges();
        }

        public int RemoveCartItem(Snack snack)
        {
            var shoppingCartItem =
                _snackHouseDbContext.ShoppingCartItems.SingleOrDefault(item => item.Snack.Id == snack.Id && item.ShoppingCartId == ShoppingCartId);

            var localQuantity = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localQuantity = shoppingCartItem.Quantity;
                }
                else
                {
                    _snackHouseDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _snackHouseDbContext.SaveChanges();

            return localQuantity;
        }

        public List<ShoppingCartItem> GetShoppingCartItem()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _snackHouseDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId)
                           .Include(snack => snack.Snack)
                           .ToList());
        }

        public void CleanShoppingCart()
        {
            var shoppingCartItems = _snackHouseDbContext.ShoppingCartItems
                                 .Where(shoppingCart => shoppingCart.ShoppingCartId == ShoppingCartId);

            _snackHouseDbContext.ShoppingCartItems.RemoveRange(shoppingCartItems);
            _snackHouseDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotalValue()
        {
            var totalValue = _snackHouseDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId)
                .Select(cart => cart.Snack.Price * cart.Quantity).Sum();
            return totalValue;
        }
    }
}
