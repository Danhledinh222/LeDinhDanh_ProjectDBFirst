using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBFirst.Models;

namespace DBFirst.Controllers
{
    public class ThietBisController : Controller
    {
        private readonly QuanLyThietBiContext _context;

        public ThietBisController(QuanLyThietBiContext context)
        {
            _context = context;
        }

        // GET: ThietBis
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThietBis.ToListAsync());
        }

        // GET: ThietBis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thietBi = await _context.ThietBis
                .FirstOrDefaultAsync(m => m.Mathietbi == id);
            if (thietBi == null)
            {
                return NotFound();
            }

            return View(thietBi);
        }

        // GET: ThietBis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThietBis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mathietbi,Tenthietbi,Soluong,Dongia,Manhom")] ThietBi thietBi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thietBi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thietBi);
        }

        // GET: ThietBis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thietBi = await _context.ThietBis.FindAsync(id);
            if (thietBi == null)
            {
                return NotFound();
            }
            return View(thietBi);
        }

        // POST: ThietBis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mathietbi,Tenthietbi,Soluong,Dongia,Manhom")] ThietBi thietBi)
        {
            if (id != thietBi.Mathietbi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thietBi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThietBiExists(thietBi.Mathietbi))
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
            return View(thietBi);
        }

        // GET: ThietBis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thietBi = await _context.ThietBis
                .FirstOrDefaultAsync(m => m.Mathietbi == id);
            if (thietBi == null)
            {
                return NotFound();
            }

            return View(thietBi);
        }

        // POST: ThietBis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thietBi = await _context.ThietBis.FindAsync(id);
            if (thietBi != null)
            {
                _context.ThietBis.Remove(thietBi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThietBiExists(int id)
        {
            return _context.ThietBis.Any(e => e.Mathietbi == id);
        }
    }
}
