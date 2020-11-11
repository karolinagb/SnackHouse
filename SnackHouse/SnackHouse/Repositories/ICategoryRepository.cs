using SnackHouse.Models;
using System.Collections.Generic;

namespace SnackHouse.Repositories
{
    public interface ICategoryRepository
    {
        ICollection<Category> FindAll();
    }
}
