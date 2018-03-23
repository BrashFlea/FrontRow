using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrontRowCMS2.Models;
using Microsoft.AspNetCore.Http;
using FrontRowCMS2.Data;
using Microsoft.EntityFrameworkCore;

namespace FrontRowCMS2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var footer = await _context.Footer.FirstOrDefaultAsync();
            return View(footer);
        }

        //GET: EditFooter
        public async Task<IActionResult> EditFooter()
        {
            var footer = await _context.Footer.FirstOrDefaultAsync();
            return View(footer);
        }

        //POST: EditFooter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFooter([Bind("ID", "ContactEmail", "ContactPhone", "MailingAddressLine1", "MailingAddressLine2", "ShelterAddressLine1", "ShelterAddressLine2", "HomeImage", "InstagramLink", "TwitterLink", "TumblrLink", "FacebookLink")] Footer footer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
                }
            }
            return View(footer);
        }

        public IActionResult Login()
        {
            HttpContext.Session.SetString("isEditable", "true");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("isEditable", "false");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
