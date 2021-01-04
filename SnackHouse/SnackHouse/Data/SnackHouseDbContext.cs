using Microsoft.EntityFrameworkCore;
using SnackHouse.Models;

namespace SnackHouse.Data
{
    public class SnackHouseDbContext : DbContext
    {
        //Classe DbContext representa uma sessão com o BD
        public SnackHouseDbContext(DbContextOptions<SnackHouseDbContext> options) : base(options)
        {

        }

        //Mapeando as tabelas
        public DbSet<Snack> Snacks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
