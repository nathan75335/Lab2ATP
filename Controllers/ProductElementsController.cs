using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab2ATP;
using Lab2ATP.Models;

namespace Lab2ATP.Controllers
{
    public class ProductElementsController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductElementsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ProductElements
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ProductElements.Include(p => p.Element).Include(p => p.Product);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ProductElements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductElements == null)
            {
                return NotFound();
            }

            var productElements = await _context.ProductElements
                .Include(p => p.Element)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productElements == null)
            {
                return NotFound();
            }

            return View(productElements);
        }

        // GET: ProductElements/Create
        public IActionResult Create()
        {
            ViewData["ElementId"] = new SelectList(_context.Elements, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ProductElements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ElementId,ProductId,Number")] ProductElements productElements)
        {
                _context.Add(productElements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
         
            ViewData["ElementId"] = new SelectList(_context.Elements, "Id", "Id", productElements.ElementId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productElements.ProductId);
            return View(productElements);
        }

        // GET: ProductElements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductElements == null)
            {
                return NotFound();
            }

            var productElements = await _context.ProductElements.FindAsync(id);
            if (productElements == null)
            {
                return NotFound();
            }
            ViewData["ElementId"] = new SelectList(_context.Elements, "Id", "Id", productElements.ElementId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productElements.ProductId);
            return View(productElements);
        }

        // POST: ProductElements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ElementId,ProductId,Number")] ProductElements productElements)
        {
            if (id != productElements.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productElements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductElementsExists(productElements.Id))
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
            ViewData["ElementId"] = new SelectList(_context.Elements, "Id", "Id", productElements.ElementId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productElements.ProductId);
            return View(productElements);
        }

        // GET: ProductElements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductElements == null)
            {
                return NotFound();
            }

            var productElements = await _context.ProductElements
                .Include(p => p.Element)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productElements == null)
            {
                return NotFound();
            }

            return View(productElements);
        }

        // POST: ProductElements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductElements == null)
            {
                return Problem("Entity set 'ApplicationContext.ProductElements'  is null.");
            }
            var productElements = await _context.ProductElements.FindAsync(id);
            if (productElements != null)
            {
                _context.ProductElements.Remove(productElements);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductElementsExists(int id)
        {
          return (_context.ProductElements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
