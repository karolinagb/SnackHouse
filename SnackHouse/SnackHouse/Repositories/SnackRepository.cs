using Microsoft.EntityFrameworkCore;
using SnackHouse.Data;
using SnackHouse.Models;
using System.Collections.Generic;
using System.Linq;

namespace SnackHouse.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly SnackHouseDbContext _snackHouseDbContext;

        public SnackRepository(SnackHouseDbContext snackHouseDbContext)
        {
            _snackHouseDbContext = snackHouseDbContext;
        }

        IEnumerable<Snack> ISnackRepository.FindAll()
        {
            return _snackHouseDbContext.Snacks.Include(snack => snack.Category).ToList();
        }

        IEnumerable<Snack> ISnackRepository.SnackByCategory(string categoryName)
        {
            return _snackHouseDbContext.Snacks.Where(s => s.Category.CategoryName.Equals(categoryName)).ToList();
        }

        Snack ISnackRepository.GetById(int snackId)
        {
            return _snackHouseDbContext.Snacks.FirstOrDefault(Snack => Snack.Id == snackId);
        }

        IEnumerable<Snack> ISnackRepository.PreferSnacks()
        {
            return _snackHouseDbContext.Snacks.Where(snackP =>
            snackP.IsPreferSnack == true).Include(snackP => snackP.Category).ToList();
        }
    }
}
