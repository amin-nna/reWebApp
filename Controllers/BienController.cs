using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using realEstateWebApp.Areas.Identity.Data;
using realEstateWebApp.Models;
using Microsoft.AspNet.Identity;

namespace realEstateWebApp.Controllers
{
    public class BienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BienModel
        public async Task<IActionResult> Index()
        {
              return _context.Biens != null ? 
                          View(await _context.Biens.ToListAsync()):
                          Problem("Entity set 'ApplicationDbContext.user'  is null.");
        }

        // GET: BienModel
        // Affiche les résultats de la recherche
        // Cherche le mot clé dans la description
        public async Task<IActionResult> IndexSearch(string search)
        {
            ViewData["CurrentFilter"] = search;
            var biens = from b in _context.Biens select b;
            if ( !String.IsNullOrEmpty(search))
            {
                biens = biens.Where(b => b.Description.Contains(search));
            }
            return View(biens);
        }

        

        // GET: BienModel
        // Affiche les résultats de la recherche
        //Filtre selon le type de bien terrain/maison/appartement
        public async Task<IActionResult> IndexType(string search )
        {


            return _context.Biens != null ?
                        View(await _context.Biens.Where( b => b.TypeDeBien.Equals(search)).ToListAsync()):
                        Problem("Entity set 'ApplicationDbContext.Bien'  is null.");
        }

        // GET: BienModel
        // Affiche les résultats de la recherche
        //Filtre selon le type de transaction vente/location
        public async Task<IActionResult> IndexTransaction(string search)
        {
            return _context.Biens != null ?
                        View(await _context.Biens.Where(b => b.TypeDeTransaction.Equals(search)).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Bien'  is null.");
        }


        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Biens == null)
            {
                return NotFound();
            }

            var BienModel = await _context.Biens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (BienModel == null)
            {
                return NotFound();
            }

            return View(BienModel);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeDeBien,ImageDeBien,TypeDeTransaction,Description,Superficie,Adresse,Prix")] BienModel BienModel)
        {
            if (ModelState.IsValid)
            {
                BienModel.IdUser = User.Identity.GetUserId();
                _context.Add(BienModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(BienModel);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Biens == null)
            {
                return NotFound();
            }

            var BienModel = await _context.Biens.FindAsync(id);
            if (BienModel == null)
            {
                return NotFound();
            }
            return View(BienModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeDeBien,ImageDeBien,TypeDeTransaction,Description,Superficie,Adresse,Prix")] BienModel BienModel)
        {
            if (id != BienModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(BienModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BienModelExists(BienModel.Id))
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
            return View(BienModel);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Biens == null)
            {
                return NotFound();
            }

            var BienModel = await _context.Biens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (BienModel == null)
            {
                return NotFound();
            }

            return View(BienModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Biens == null)
            {
                return Problem("Entity set 'ApplicationDbContext.user'  is null.");
            }
            var BienModel = await _context.Biens.FindAsync(id);
            if (BienModel != null)
            {
                _context.Biens.Remove(BienModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BienModelExists(int id)
        {
          return (_context.Biens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}