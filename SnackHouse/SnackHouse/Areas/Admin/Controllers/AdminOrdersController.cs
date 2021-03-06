﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SnackHouse.Data;
using SnackHouse.Models;
using SnackHouse.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SnackHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly SnackHouseDbContext _context;

        public AdminOrdersController(SnackHouseDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminOrders
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Orders.ToListAsync());
        //}

        public async Task<ActionResult> Index(string filter, int pageindex = 1, string sort = "Name")
        {
            var result = _context.Orders.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(p => p.Name.Contains(filter));
            }

            var model = await PagingList.CreateAsync(result, 5, pageindex, sort, "Name");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }

        // GET: Admin/AdminOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Admin/AdminOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CustomerSurname,Address,AddressComplement,CEP,State,City,Telephone,Email,SendDate,DeliveryDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Admin/AdminOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Admin/AdminOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CustomerSurname,Address,AddressComplement,CEP,State,City,Telephone,Email,SendDate,DeliveryDate")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Admin/AdminOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Admin/AdminOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }

        public ActionResult OrderSnack(int? id)
        {
            var order = _context.Orders.Include(x => x.OrderDetails).ThenInclude(x => x.Snack)
                .FirstOrDefault(x => x.Id == id);

            if(order == null)
            {
                Response.StatusCode = 404;
                return View("OrderNotFound", id.Value);
            }

            OrderSnackViewModel orderSnackViewModel = new OrderSnackViewModel()
            {
                Order = order,
                OrderDetails = order.OrderDetails,
            };

            return View(orderSnackViewModel);
        }
    }
}
