using System.Collections.Generic;

namespace SnackHouse.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal TotalValueShoppingCart { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
