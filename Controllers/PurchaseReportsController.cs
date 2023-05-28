using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS_011.Data;
using EMS_011.Models;

namespace EMS_011.Controllers
{
    public class PurchaseReportsController : Controller
    {
        private readonly EMS_011Context _context;

        public PurchaseReportsController(EMS_011Context context)
        {
            _context = context;
        }

        // GET: PurchaseReports
        public async Task<IActionResult> Index()
        {
              return _context.PurchaseReports != null ? 
                          View(await _context.PurchaseReports.ToListAsync()) :
                          Problem("Entity set 'EMS_011Context.PurchaseReports'  is null.");
        }

        // GET: PurchaseReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PurchaseReports == null)
            {
                return NotFound();
            }

            var purchaseReports = await _context.PurchaseReports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseReports == null)
            {
                return NotFound();
            }

            return View(purchaseReports);
        }

        // GET: PurchaseReports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,ProductName,UnitPrice,Quantity,Subtotal,Total,Payee,Division,Remarks,ImageFile")] PurchaseReports purchaseReports)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseReports);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseReports);
        }

        // GET: PurchaseReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PurchaseReports == null)
            {
                return NotFound();
            }

            var purchaseReports = await _context.PurchaseReports.FindAsync(id);
            if (purchaseReports == null)
            {
                return NotFound();
            }
            return View(purchaseReports);
        }

        // POST: PurchaseReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,ProductName,UnitPrice,Quantity,Subtotal,Total,Payee,Division,Remarks,ImageFile")] PurchaseReports purchaseReports)
        {
            if (id != purchaseReports.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseReports);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseReportsExists(purchaseReports.Id))
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
            return View(purchaseReports);
        }

        // GET: PurchaseReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PurchaseReports == null)
            {
                return NotFound();
            }

            var purchaseReports = await _context.PurchaseReports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseReports == null)
            {
                return NotFound();
            }

            return View(purchaseReports);
        }

        // POST: PurchaseReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PurchaseReports == null)
            {
                return Problem("Entity set 'EMS_011Context.PurchaseReports'  is null.");
            }
            var purchaseReports = await _context.PurchaseReports.FindAsync(id);
            if (purchaseReports != null)
            {
                _context.PurchaseReports.Remove(purchaseReports);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseReportsExists(int id)
        {
          return (_context.PurchaseReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
