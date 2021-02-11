using System.Collections.Generic;

namespace SnackHouse.Models.ViewModels
{
    public class OrderSnackViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
