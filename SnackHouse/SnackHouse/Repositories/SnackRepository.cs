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

        ICollection<Snack> ISnackRepository.FindAll()
        {
            return _snackHouseDbContext.Snacks.Include(snack => snack.Category).ToList();
        }

        Snack ISnackRepository.GetById(int snackId)
        {
            return _snackHouseDbContext.Snacks.FirstOrDefault(Snack => Snack.Id == snackId);
        }

        ICollection<Snack> ISnackRepository.PreferSnacks()
        {
            return _snackHouseDbContext.Snacks.Where(snack => snack.IsPreferSnack == true).ToList();
        }
    }
}
