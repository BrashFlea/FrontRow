using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FrontRowCMS.Controllers
{
    public class SecondaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}