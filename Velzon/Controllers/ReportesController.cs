using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Velzon.Controllers
{
    public class ReportesController : Controller
    {
        [ActionName("Informes")]
        public IActionResult Informes()
        {
            return View();
        }

        [ActionName("Estadisticas")]
        public IActionResult Estadisticas()
        {
            return View();
        }

    }
}