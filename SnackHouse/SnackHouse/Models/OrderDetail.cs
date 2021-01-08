using System.ComponentModel.DataAnnotations.Schema;

namespace SnackHouse.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int OrderId { get; set; }
        public int SnackId { get; set; }
        public Order Order { get; set; }
        public Snack Snack { get; set; }
    }
}
