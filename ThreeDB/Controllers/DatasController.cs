using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThreeDB.Models;

namespace ThreeDB.Controllers
{
    public class DatasController : Controller
    {
        private readonly ThreeDBContext _context;

        public DatasController(ThreeDBContext context)
        {
            _context = context;    
        }

        // GET: Datas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Datas.ToListAsync());
        }

        // GET: Datas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _context.Datas
                .SingleOrDefaultAsync(m => m.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // GET: Datas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Datas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email")] Data data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        // GET: Datas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _context.Datas.SingleOrDefaultAsync(m => m.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        // POST: Datas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] Data data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataExists(data.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(data);
        }

        // GET: Datas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _context.Datas
                .SingleOrDefaultAsync(m => m.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // POST: Datas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _context.Datas.SingleOrDefaultAsync(m => m.Id == id);
            _context.Datas.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DataExists(int id)
        {
            return _context.Datas.Any(e => e.Id == id);
        }
    }
}
