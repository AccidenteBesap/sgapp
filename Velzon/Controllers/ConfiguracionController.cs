using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Velzon.Controllers
{
    public class ConfiguracionController : Controller
    {
        [ActionName("Datos")]
        public IActionResult Datos()
        {
            return View();
        }

        [ActionName("CrearUsuario")]
        public IActionResult CrearUsuario()
        {
            return View();
        }

        [ActionName("Perfil")]
        public IActionResult Perfil()
        {
            return View();
        }

        [ActionName("Test")]
        public IActionResult Test()
        {
            return View();
        }

        [ActionName("DIAT")]
        public IActionResult DIAT()
        {
            return View();
        }

        [ActionName("TiempoGraveFatal")]
        public IActionResult TiempoGraveFatal()
        {
            return View();
        }
    }
}
