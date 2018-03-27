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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FrontRowCMS2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public HomeController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            Page page = new Page();
            page.Footer = await _context.Footer.FirstOrDefaultAsync();
            return View(page);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadImage(string returnurl, IFormFile imageFile)
        {
            if(imageFile != null && imageFile.Length > 0)
            {
                var filePath = Path.Combine(Path.Combine(_env.WebRootPath, "images"), imageFile.FileName);
                FileInfo checkFile = new FileInfo(filePath);
                if (checkFile.Exists)
                {
                    return Redirect("~/errors/fileExists.html");
                }
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
            }

            return Redirect(returnurl);
            //return RedirectToAction(nameof(ReturnUrl));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteImage(string returnurl, string filename)
        {
            if(filename != null && filename != "")
            {
                string filePath = Path.Combine(Path.Combine(_env.WebRootPath, "images"), filename);
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }
            }
            return Redirect(returnurl);
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
