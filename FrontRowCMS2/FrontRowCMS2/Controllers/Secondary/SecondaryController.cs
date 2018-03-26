using System;
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
            return View(await _context.Footer.FirstOrDefaultAsync());
        }

        public IActionResult Edit()
        {
            return View();
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void GetImages()
        {
            var webRoot = _env.WebRootPath;
            var appData = System.IO.Path.Combine(webRoot, "images");
            var images = new List<SelectListItem>();
            images.Add(new SelectListItem
            {
                Text = "Select",
                Value = ""
            });
            foreach (string file in Directory.EnumerateFiles(appData, "*", SearchOption.AllDirectories))
            {
                images.Add(new SelectListItem { Text = file.Substring(file.LastIndexOf("\\")+1), Value = file.Substring(file.LastIndexOf("\\")+1) });
            }
            ViewBag.image = images;
        }
    }
}