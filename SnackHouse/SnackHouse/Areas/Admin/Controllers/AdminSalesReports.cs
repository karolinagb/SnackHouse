using Microsoft.AspNetCore.Mvc;
using SnackHouse.Areas.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSalesReports : Controller
    {
        private readonly SalesReportService _salesReportService;

        public AdminSalesReports(SalesReportService salesReportService)
        {
            _salesReportService = salesReportService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> SimpleSalesReport(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesReportService.FindByDateAsync(minDate, maxDate);

            return View(result);
        }
    }
}
