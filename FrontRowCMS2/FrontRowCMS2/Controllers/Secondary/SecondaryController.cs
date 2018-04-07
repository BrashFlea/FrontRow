﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrontRowCMS2.Models;
using FrontRowCMS2.Data;
using FrontRowCMS2.Models.Secondary;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FrontRowCMS2.Controllers
{
    public class SecondaryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public SecondaryController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public async Task<IActionResult> Index()
        {
            Page Page = new Page();

            Page.Footer = await _context.Footer.FirstOrDefaultAsync();
            Page.SecondaryPage = new SecondaryPage();
            Page.SecondaryPage.SecondaryHeader = await _context.SecondaryHeader.FirstOrDefaultAsync();
            Page.SecondaryPage.History = await _context.History.FirstOrDefaultAsync();
            Page.SecondaryPage.Outreach = await _context.Outreach.FirstOrDefaultAsync();
            Page.SecondaryPage.Directors = await _context.Persons.Where(p => p.Type != PersonType.Staff).ToListAsync();
            Page.SecondaryPage.Staff = await _context.Persons.Where(p => p.Type != PersonType.Director).ToListAsync();
            Page.SecondaryPage.MediaEvent = await _context.MediaEvent.FirstOrDefaultAsync();
            Page.SecondaryPage.PlatinumDonors = await _context.Donor.Where(p => p.Level == DonorType.Platinum).ToListAsync();
            Page.SecondaryPage.GoldDonors = await _context.Donor.Where(p => p.Level == DonorType.Gold).ToListAsync();
            Page.SecondaryPage.SilverDonors = await _context.Donor.Where(p => p.Level == DonorType.Silver).ToListAsync();
            Page.SecondaryPage.BronzeDonors = await _context.Donor.Where(p => p.Level == DonorType.Bronze).ToListAsync();
            Page.SecondaryPage.Operation = await _context.Operation.FirstOrDefaultAsync();
            Page.SecondaryPage.Operation.Operation1 = await _context.TextSubContent.Where(c => c.ID == 1).FirstAsync();
            Page.SecondaryPage.Operation.Operation2 = await _context.TextSubContent.Where(c => c.ID == 2).FirstAsync();
            Page.SecondaryPage.Operation.Operation3 = await _context.TextSubContent.Where(c => c.ID == 3).FirstAsync();
            Page.SecondaryPage.Donate = await _context.Donate.FirstOrDefaultAsync();
            Page.SecondaryPage.Donate.Donate1 = await _context.TextSubContent.Where(c => c.ID == 4).FirstAsync();
            Page.SecondaryPage.Donate.Donate2 = await _context.TextSubContent.Where(c => c.ID == 5).FirstAsync();
            Page.SecondaryPage.Donate.Donate3 = await _context.TextSubContent.Where(c => c.ID == 6).FirstAsync();

            Page.SecondaryPage.ListOfNeeds = await _context.Needs.FirstOrDefaultAsync();
            Page.SecondaryPage.ContactInfo = await _context.ContactInfo.FirstOrDefaultAsync();

            return View(Page);
        }

        //GET: EditHeader
        public async Task<IActionResult> EditHeader()
        {
            var header = await _context.SecondaryHeader.FirstOrDefaultAsync();
            GetImages();
            return View(header);
        }

        //POST: EditHeader
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHeader([Bind("ID,TitleText,PhoneNumber,BackgroundImage,ImageText1,ImageText2")] SecondaryHeader header)
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

        //GET: EditOperation
        public async Task<IActionResult> EditOperation()
        {
            var operation = await _context.Operation.FirstOrDefaultAsync();
            operation.Operation1 = await _context.TextSubContent.Where(c => c.ID == 1).FirstAsync();
            operation.Operation2 = await _context.TextSubContent.Where(c => c.ID == 2).FirstAsync();
            operation.Operation3 = await _context.TextSubContent.Where(c => c.ID == 3).FirstAsync();
            GetImages();
            return View(operation);
        }

        //POST: EditOperation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOperation([Bind("ID,TextArea1,TextArea2,Operation1,Operation2,Operation3")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
                }
            }
            return View(operation);
        }

        //GET: EditHistory
        public async Task<IActionResult> EditHistory()
        {
            var history = await _context.History.FirstOrDefaultAsync();
            GetImages();
            return View(history);
        }

        //POST: EditHistory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHistory([Bind("ID,TextArea1,TextArea2,Image1,Image2,Image3,Caption1,Caption2,Caption3")] History history)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
                }
            }
            return View(history);
        }

        //GET: EditOutreach
        public async Task<IActionResult> EditOutreach()
        {
            var outreach = await _context.Outreach.FirstOrDefaultAsync();
            GetImages();
            return View(outreach);
        }

        //POST: EditOutreach
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOutreach([Bind("ID,Image,TextArea")] Outreach outreach)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(outreach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
                }
            }
            return View(outreach);
        }

        //GET: EditNeeds
        public async Task<IActionResult> EditNeeds()
        {
            var needs = await _context.Needs.FirstOrDefaultAsync();
            GetImages();
            return View(needs);
        }

        //POST: EditNeeds
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNeeds([Bind("ID,TextArea")] Needs needs)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(needs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
                }
            }
            return View(needs);
        }

        //GET: EditMediaEvent
        public async Task<IActionResult> EditMediaEvent()
        {
            var mediaEvent = await _context.MediaEvent.FirstOrDefaultAsync();
            GetImages();
            return View(mediaEvent);
        }

        //POST: EditMediaEvent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMediaEvent([Bind("ID,Title,Time,Image,Image_Title,Caption,Description1,Description2")] MediaEvent mediaEvent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
                }
            }
            return View(mediaEvent);
        }

        //GET: EditDonate
        public async Task<IActionResult> EditDonate()
        {
            var donate = await _context.Donate.FirstOrDefaultAsync();
            donate.Donate1 = await _context.TextSubContent.Where(c => c.ID == 4).FirstAsync();
            donate.Donate2 = await _context.TextSubContent.Where(c => c.ID == 5).FirstAsync();
            donate.Donate3 = await _context.TextSubContent.Where(c => c.ID == 6).FirstAsync();
            GetImages();
            return View(donate);
        }

        //POST: EditDonate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDonate([Bind("ID,TextArea1,TextArea2,Donate1,Donate2,Donate3")] Donate donate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
                }
            }
            return View(donate);
        }

        //GET: EditContactInfo
        public async Task<IActionResult> EditContactInfo()
        {
            var contactInfo = await _context.ContactInfo.FirstOrDefaultAsync();
            GetImages();
            return View(contactInfo);
        }

        //POST: EditContactInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContactInfo([Bind("ID,Header1,PhoneNumber,Header2,AddressLine1,AddressLine2")] ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persister " +
                    "see your system administrator for assitance.");
                }
            }
            return View(contactInfo);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void GetImages()
        {
            var webRoot = _env.WebRootPath;
            var appData = Path.Combine(webRoot, "images");
            var images = new List<SelectListItem>();
            images.Add(new SelectListItem
            {
                Text = "Select",
                Value = ""
            });
            foreach (string file in Directory.EnumerateFiles(appData, "*", SearchOption.AllDirectories))
            {
                images.Add(new SelectListItem { Text = file.Substring(file.LastIndexOf("\\") + 1), Value = file.Substring(file.LastIndexOf("\\") + 1) });
            }
            ViewBag.image = images;
        }
    }
}