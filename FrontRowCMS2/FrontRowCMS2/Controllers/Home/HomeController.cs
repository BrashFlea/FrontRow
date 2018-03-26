using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrontRowCMS2.Models;
using FrontRowCMS2.Models.Home;
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

        //GET: EditHeader
        public async Task<IActionResult> EditHeader()
        {
            var header = await _context.Header.FirstOrDefaultAsync();
            return View(header);
        }

        //POST: EditHeader
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHeader([Bind("ID", "TitleText", "PhoneNumber", "BackgroundImage")] Header header)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(header);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
                }
            }
            return View(header);
        }

        //GET: EditServices
        public async Task<IActionResult> EditServices()
        {
            var services = await _context.Services.FirstOrDefaultAsync();
            services.Service1 = await _context.LinkSubContent.Where(c => c.ID == 1).FirstAsync();
            services.Service2 = await _context.LinkSubContent.Where(c => c.ID == 2).FirstAsync();
            services.Service3 = await _context.LinkSubContent.Where(c => c.ID == 3).FirstAsync();
            return View(services);
        }

        //POST: EditSections
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditServices([Bind("ID", "MainText", "LinkSubContent")] FrontRowCMS2.Models.Home.Services services)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(services);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
                }
            }
            return View(services);
        }

        //GET: EditPurpose
        public async Task<IActionResult> EditPurpose()
        {
            var services = await _context.Purpose.FirstOrDefaultAsync();
            return View(services);
        }

        //POST: EditPurpose
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPurpose([Bind("ID", "BackgroundImage", "TextArea1", "TextArea2", "PartnerImage1", "PartnerImage2", "PartnerImage3", "PartnerImage4")] Purpose purpose)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purpose);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
                }
            }
            return View(purpose);
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
