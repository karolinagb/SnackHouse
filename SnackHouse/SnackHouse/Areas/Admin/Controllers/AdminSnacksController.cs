using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SnackHouse.Data;
using SnackHouse.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SnackHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminSnacksController : Controller
    {
        private readonly SnackHouseDbContext _context;

        public AdminSnacksController(SnackHouseDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminSnacks
        //public async Task<IActionResult> Index()
        //{
        //    var snackHouseDbContext = _context.Snacks.Include(s => s.Category);
        //    return View(await snackHouseDbContext.ToListAsync());
        //}

        public async Task<ActionResult> Index(string filter, int pageindex = 1, string sort = "Name")
        {
            var result = _context.Snacks.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(p => p.Name.Contains(filter));
            }

            var model = await PagingList.CreateAsync(result, 5, pageindex, sort, "Name");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }

        // GET: Admin/AdminSnacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snack = await _context.Snacks
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snack == null)
            {
                return NotFound();
            }

            return View(snack);
        }

        // GET: Admin/AdminSnacks/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        // POST: Admin/AdminSnacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SmallDescription,LongDescription,Price,ImgUrl,ImgThumbnailUrl,IsPreferSnack,InStock,CategoryId")] Snack snack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", snack.CategoryId);
            return View(snack);
        }

        // GET: Admin/AdminSnacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snack = await _context.Snacks.FindAsync(id);
            if (snack == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", snack.CategoryId);
            return View(snack);
        }

        // POST: Admin/AdminSnacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SmallDescription,LongDescription,Price,ImgUrl,ImgThumbnailUrl,IsPreferSnack,InStock,CategoryId")] Snack snack)
        {
            if (id != snack.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnackExists(snack.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", snack.CategoryId);
            return View(snack);
        }

        // GET: Admin/AdminSnacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snack = await _context.Snacks
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snack == null)
            {
                return NotFound();
            }

            return View(snack);
        }

        // POST: Admin/AdminSnacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snack = await _context.Snacks.FindAsync(id);
            _context.Snacks.Remove(snack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnackExists(int id)
        {
            return _context.Snacks.Any(e => e.Id == id);
        }
    }
}
