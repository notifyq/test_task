using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Controllers
{
    public class ModelsController : Controller
    {
        private readonly TestTaskContext _context;

        public ModelsController(TestTaskContext context)
        {
            _context = context;
        }

        // GET: Models
        public async Task<IActionResult> Index()
        {
            var testTaskContext = _context.Models.Include(m => m.ModelBrand);
            return View(await testTaskContext.ToListAsync());
        }

        // GET: Models/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Models == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .Include(m => m.ModelBrand)
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Models/Create
        public IActionResult Create()
        {
            ViewBag.Brands = _context.Brands.ToList();
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModelName,ModelBrandId,ModelActive")] Model model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Models/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Models == null)
            {
                return NotFound();
            }

            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            ViewBag.Brands = _context.Brands.ToList();
            return View(model);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModelId,ModelName,ModelBrandId,ModelActive")] Model model)
        {
            if (id != model.ModelId)
            {
                return NotFound();
            }

           
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(model.ModelId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            ViewBag.Brands = _context.Brands.ToList();
            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Models == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .Include(m => m.ModelBrand)
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Models == null)
            {
                return Problem("Entity set 'TestTaskContext.Models'  is null.");
            }
            var model = await _context.Models.FindAsync(id);
            if (model != null)
            {
                _context.Models.Remove(model);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(int id)
        {
          return (_context.Models?.Any(e => e.ModelId == id)).GetValueOrDefault();
        }
    }
}
