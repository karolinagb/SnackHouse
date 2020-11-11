using Microsoft.EntityFrameworkCore;
using SnackHouse.Data;
using SnackHouse.Models;
using System.Collections.Generic;
using System.Linq;

namespace SnackHouse.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SnackHouseDbContext _snackHouseDbContext;

        //Referencia ao EF Core ou classe Context
        public CategoryRepository(SnackHouseDbContext snackHouseDbContext)
        {
            _snackHouseDbContext = snackHouseDbContext;
        }

        ICollection<Category> ICategoryRepository.FindAll()
        {
            return _snackHouseDbContext.Categories.ToList();
        }
    }
}
