using SnackHouse.Models;

namespace SnackHouse.Repositories
{
    public interface IOrderRepository
    {
        void Insert(Order order);
    }
}
