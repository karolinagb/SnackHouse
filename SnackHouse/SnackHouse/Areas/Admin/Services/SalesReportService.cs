using Microsoft.EntityFrameworkCore;
using SnackHouse.Data;
using SnackHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackHouse.Areas.Admin.Services
{
    public class SalesReportService
    {
        private readonly SnackHouseDbContext _snackHouseDbContext;

        public SalesReportService(SnackHouseDbContext snackHouseDbContext)
        {
            _snackHouseDbContext = snackHouseDbContext;
        }

        public async Task<List<Order>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _snackHouseDbContext.Orders select obj;

            if (minDate.HasValue)
            {
                result = result.Where(X => X.SendDate >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.SendDate <= maxDate.Value);
            }

            return await result
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Snack)
                .OrderByDescending(x => x.SendDate)
                .ToListAsync();
        }
    }
}
