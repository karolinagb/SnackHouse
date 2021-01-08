using SnackHouse.Data;
using SnackHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackHouse.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SnackHouseDbContext _snackHouseDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(SnackHouseDbContext snackHouseDbContext, ShoppingCart shoppingCart)
        {
            _snackHouseDbContext = snackHouseDbContext;
            _shoppingCart = shoppingCart;
        }

        public void Insert(Order order)
        {
            order.SendDate = DateTime.Now;
            _snackHouseDbContext.Orders.Add(order);
            _snackHouseDbContext.SaveChanges();

            var shoppingCartItems = _snackHouseDbContext.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Quantity = item.Quantity,
                    SnackId = item.Snack.Id,
                    OrderId = order.Id,
                    Price = item.Snack.Price
                };

                _snackHouseDbContext.OrderDetails.Add(orderDetail);
            }

            _snackHouseDbContext.SaveChanges();
        }
    }
}
