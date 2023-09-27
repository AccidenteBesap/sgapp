using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Velzon.Controllers
{
    public class PagesController : Controller
    {

        [ActionName("Starter")]
        public IActionResult Starter()
        {
            return View();
        }

        [ActionName("ProfileSimple")]
        public IActionResult ProfileSimple()
        {
            return View();
        }

        [ActionName("ProfileSettings")]
        public IActionResult ProfileSettings()
        {
            return View();
        }

        [ActionName("Team")]
        public IActionResult Team()
        {
            return View();
        }

        [ActionName("Timeline")]
        public IActionResult Timeline()
        {
            return View();
        }

        [ActionName("FAQs")]
        public IActionResult FAQs()
        {
            return View();
        }

        [ActionName("Pricing")]
        public IActionResult Pricing()
        {
            return View();
        }

        [ActionName("Gallery")]
        public IActionResult Gallery()
        {
            return View();
        }

        [ActionName("Maintenance")]
        public IActionResult Maintenance()
        {
            return View();
        }

        [ActionName("ComingSoon")]
        public IActionResult ComingSoon()
        {
            return View();
        }

        [ActionName("Sitemap")]
        public IActionResult Sitemap()
        {
            return View();
        }

        [ActionName("SearchResults")]
        public IActionResult SearchResults()
        {
            return View();
        }

        [ActionName("PrivacyPolicy")]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        [ActionName("TermConditions")]
        public IActionResult TermConditions()
        {
            return View();
        }

        [ActionName("Registro")]
        public IActionResult Registro()
        {
            return View();
        }

        [ActionName("Cuasi")]
        public IActionResult Cuasi()
        {
            return View();
        }

        [ActionName("AccidenteCTP")]
        public IActionResult AccidenteCTP()
        {
            return View();
        }

        [ActionName("AccidenteSTP")]
        public IActionResult AccidenteSTP()
        {
            return View();
        }

        [ActionName("AccidenteGrave")]
        public IActionResult AccidenteGrave()
        {
            return View();
        }

        [ActionName("AccidenteFatal")]
        public IActionResult AccidenteFatal()
        {
            return View();
        }

    }
}
