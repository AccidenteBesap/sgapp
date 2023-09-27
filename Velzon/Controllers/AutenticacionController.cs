using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Velzon.Controllers
{
    public class AutenticacionController : Controller
    {

        [ActionName("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [ActionName("Registro")]
        public IActionResult Registro()
        {
            return View();
        }

    }
}