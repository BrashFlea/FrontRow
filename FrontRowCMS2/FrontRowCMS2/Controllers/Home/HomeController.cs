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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.Session.SetString("isEditable", "true");
            }
            else
            {
                HttpContext.Session.SetString("isEditable", "false");
            }

            Page page = new Page();
            page.Footer = await _context.Footer.FirstOrDefaultAsync();
            page.HomePage = new HomePage();
            page.HomePage.Header = await _context.Header.FirstOrDefaultAsync();
            page.HomePage.Purpose = await _context.Purpose.FirstOrDefaultAsync();
            page.HomePage.Services = await _context.Services.FirstOrDefaultAsync();
            page.HomePage.Services.Service1 = await _context.LinkSubContent.Where(c => c.ID == 1).FirstAsync();
            page.HomePage.Services.Service2 = await _context.LinkSubContent.Where(c => c.ID == 2).FirstAsync();
            page.HomePage.Services.Service3 = await _context.LinkSubContent.Where(c => c.ID == 3).FirstAsync();
            page.HomePage.BottomHomePage = await _context.BottomHomePage.FirstOrDefaultAsync();
            page.HomePage.BottomHomePage.Service1 = await _context.LinkSubContent.Where(c => c.ID == 4).FirstAsync();
            page.HomePage.BottomHomePage.Service2 = await _context.LinkSubContent.Where(c => c.ID == 5).FirstAsync();
            page.HomePage.BottomHomePage.Service3 = await _context.LinkSubContent.Where(c => c.ID == 6).FirstAsync();
            return View(page);
        }

        //GET: EditHeader
        [Authorize]
        public async Task<IActionResult> EditHeader()
        {
            var header = await _context.Header.FirstOrDefaultAsync();
            return View(header);
        }

        //POST: EditHeader
        [HttpPost]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditServices([Bind("ID", "MainText", "Service1", "Service2", "Service3")] FrontRowCMS2.Models.Home.Services services)
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
        [Authorize]
        public async Task<IActionResult> EditPurpose()
        {
            var purpose = await _context.Purpose.FirstOrDefaultAsync();
            return View(purpose);
        }

        //POST: EditPurpose
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPurpose([Bind("ID", "BackgroundImage", "TextArea1", "TextArea2", "PartnerImage1", "PartnerImage2", "PartnerImage3")] Purpose purpose)
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

        [Authorize]
        public async Task<IActionResult> EditBottomHomePage()
        {
            var bottomHomePage = await _context.BottomHomePage.FirstOrDefaultAsync();
            bottomHomePage.Service1 = await _context.LinkSubContent.Where(c => c.ID == 4).FirstAsync();
            bottomHomePage.Service2 = await _context.LinkSubContent.Where(c => c.ID == 5).FirstAsync();
            bottomHomePage.Service3 = await _context.LinkSubContent.Where(c => c.ID == 6).FirstAsync();
            return View(bottomHomePage);
        }

        //POST: EditPurpose
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBottomHomePage([Bind("ID", "Service1", "Service2", "Service3")] BottomHomePage bottomHomePage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bottomHomePage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
                }
            }
            return View(bottomHomePage);
        }

        //GET: EditFooter
        [Authorize]
        public async Task<IActionResult> EditFooter()
        {
            var footer = await _context.Footer.FirstOrDefaultAsync();
            return View(footer);
        }

        //POST: EditFooter
        [HttpPost]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
