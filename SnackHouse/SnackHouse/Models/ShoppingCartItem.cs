using System.ComponentModel.DataAnnotations;

namespace SnackHouse.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Snack Snack { get; set; }
        public int Quantity { get; set; }

        [StringLength(200)]
        public string ShoppingCartId { get; set; }

        public ShoppingCartItem()
        {

        }

    }
}
