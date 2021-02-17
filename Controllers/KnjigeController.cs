using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidencijaKnjiga.Data;
using EvidencijaKnjiga.Models;
using Microsoft.AspNetCore.Authorization;

namespace EvidencijaKnjiga.Controllers
{
    public class KnjigeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KnjigeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Knjige
        public async Task<IActionResult> Index(string search)
        {
            var applicationDbContext = _context.Knjiga.Include(k => k.Autor);
            if (!String.IsNullOrEmpty(search))
            {

                var knjige = from knjiga in _context.Knjiga.Include(k => k.Autor)
                             select knjiga;
                knjige = knjige.Where(knjiga => knjiga.Naziv.Contains(search));
                return View(knjige.ToList());
            }
           

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Knjige/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjiga
                .Include(k => k.Autor)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (knjiga == null)
            {
                return NotFound();
            }

            return View(knjiga);
        }

        // GET: Knjige/Create
        public IActionResult Create()
        {
            ViewData["AutorID"] = new SelectList(_context.Autor, "ID", "Ime");
            return View();
        }

        // POST: Knjige/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naziv,GodinaIzdanja,AutorID")] Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(knjiga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorID"] = new SelectList(_context.Autor, "ID", "Ime", knjiga.AutorID);
            return View(knjiga);
        }

        // GET: Knjige/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjiga.FindAsync(id);
            if (knjiga == null)
            {
                return NotFound();
            }
            ViewData["AutorID"] = new SelectList(_context.Autor, "ID", "Ime", knjiga.AutorID);
            return View(knjiga);
        }

        // POST: Knjige/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naziv,GodinaIzdanja,AutorID")] Knjiga knjiga)
        {
            if (id != knjiga.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knjiga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnjigaExists(knjiga.ID))
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
            ViewData["AutorID"] = new SelectList(_context.Autor, "ID", "Ime", knjiga.AutorID);
            return View(knjiga);
        }

        // GET: Knjige/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjiga
                .Include(k => k.Autor)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (knjiga == null)
            {
                return NotFound();
            }

            return View(knjiga);
        }

        // POST: Knjige/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var knjiga = await _context.Knjiga.FindAsync(id);
            _context.Knjiga.Remove(knjiga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnjigaExists(int id)
        {
            return _context.Knjiga.Any(e => e.ID == id);
        }
    }
}
