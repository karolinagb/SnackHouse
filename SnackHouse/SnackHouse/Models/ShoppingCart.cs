using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SnackHouse.Data;
using System;
using System.Collections.Generic;

namespace SnackHouse.Models
{
    public class ShoppingCart
    {
        private readonly SnackHouseDbContext _snackHouseDbContext;

        //injeta o contexto no construtor
        public ShoppingCart(SnackHouseDbContext snackHouseDbContext)
        {
            _snackHouseDbContext = snackHouseDbContext;
        }

        //Vamos Utilizar o Guid
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
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
    }
}
