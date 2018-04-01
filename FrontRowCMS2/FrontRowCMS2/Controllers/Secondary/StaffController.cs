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
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Staff
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Persons.ToListAsync());
        }

        //GET: Staff/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Persons.SingleOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        //GET: Staff/Create
        [Authorize]
        public IActionResult Create()
        {
            SetPersonTypes();
            return View();
        }

        //POST: Staff/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Image", "Name", "Title1", "Title2", "Email", "Type")] Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(person);
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
            SetPersonTypes();
            return View(person);
        }

        //GET: Students/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Persons.SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            SetPersonTypes();
            return View(student);
        }

        //POST: Students/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ID", "Image", "Name", "Title1", "Title2", "Email", "Type")] Person person)
        {
            if (id != person.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(person.ID))
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
            SetPersonTypes();
            return View(person);
        }

        //GET: Staff/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Persons.SingleOrDefaultAsync(m => m.ID == id);
            if(staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        //POST: Staff/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Persons.SingleOrDefaultAsync(m => m.ID == id);
            _context.Persons.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Populates the ViewBag for PersonType Dropdown Selection in the View
        /// </summary>
        private void SetPersonTypes()
        {
            var personTypes = new List<SelectListItem>();
            personTypes.Add(new SelectListItem
            {
                Text = "Select",
                Value = ""
            });
            foreach (PersonType t in Enum.GetValues(typeof(PersonType)))
            {
                personTypes.Add(new SelectListItem { Text = Enum.GetName(typeof(PersonType), t), Value = t.ToString() });
            }
            ViewBag.PersonType = personTypes;
        }


        private bool StaffExists(int id)
        {
            return _context.Persons.Any(e => e.ID == id);
        }
    }
}