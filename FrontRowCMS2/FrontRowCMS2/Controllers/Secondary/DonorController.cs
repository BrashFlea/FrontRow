using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrontRowCMS2.Data;
using FrontRowCMS2.Models;
using Microsoft.EntityFrameworkCore;
using FrontRowCMS2.Models.Secondary;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace FrontRowCMS2.Controllers
{
    [Authorize]
    public class DonorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonorController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Donor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Donor.ToListAsync());
        }

        //GET: Donor/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donor.SingleOrDefaultAsync(m => m.ID == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        //GET: Donor/Create
        public IActionResult Create()
        {
            SetDonorTypes();
            return View();
        }

        //POST: Donor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Level", "Name", "Year")] Donor donor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(donor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error - uncomment ex variable and write a log
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
            }
            SetDonorTypes();
            return View(donor);
        }

        //GET: Donor/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donor.SingleOrDefaultAsync(m => m.ID == id);
            if (donor == null)
            {
                return NotFound();
            }
            SetDonorTypes();
            return View(donor);
        }

        //POST: Donor/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ID", "Level", "Name", "Year")] Donor donor)
        {
            if (id != donor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorExists(donor.ID))
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
            SetDonorTypes();
            return View(donor);
        }

        //GET: Donor/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donor.SingleOrDefaultAsync(m => m.ID == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        //POST: Donor/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donor = await _context.Donor.SingleOrDefaultAsync(m => m.ID == id);
            _context.Donor.Remove(donor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Populates the ViewBag for DonorType Dropdown Selection in the View
        /// </summary>
        private void SetDonorTypes()
        {
            var donorTypes = new List<SelectListItem>();
            donorTypes.Add(new SelectListItem
            {
                Text = "Select",
                Value = ""
            });
            foreach (DonorType t in Enum.GetValues(typeof(DonorType)))
            {
                donorTypes.Add(new SelectListItem { Text = Enum.GetName(typeof(DonorType), t), Value = t.ToString() });
            }
            ViewBag.DonorType = donorTypes;
        }


        private bool DonorExists(int id)
        {
            return _context.Donor.Any(e => e.ID == id);
        }
    }
}
