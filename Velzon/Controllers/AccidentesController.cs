using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Velzon.Models;
using Velzon.Services;

namespace Velzon.Controllers
{
    public class AccidentesController : Controller
    {
        private readonly DataFetchService _dataFetchService;

        public AccidentesController(DataFetchService dataFetchService)
        {
            _dataFetchService = dataFetchService;
        }

        [HttpGet]
        public IActionResult GetTrabajadores(string rut)
        {
            // Call your service method to get the trabajadores for the selected Rut
            var trabajadores = _dataFetchService.GetTrabajadoresByRut(rut);

            // Convert trabajadores to a format that can be easily serialized to JSON
            var trabajadoresList = trabajadores.Select(t => new { value = t.Id, text = $"{t.Nombres} {t.Paterno} {t.Materno}" }).ToList();

            return Json(trabajadoresList);
        }

        [ActionName("IngresarAccidente")]
        public IActionResult Accidente()
        {
            var compositeModel = _dataFetchService.GetCompositeModel();
            return View(compositeModel);
        }

        [HttpPost]
        public IActionResult InsertAccidente(
            string TrabajadorEmpresa,
            int TrabajadorId,
            string TrabajadorNombre,
            string TrabajadorRut,
            string TrabajadorCargo,
            string TrabajadorCentroTrabajo,
            DateOnly TrabajadorFechaIngreso,
            string supervisorTextArea,
            string TrabajadorTipoAccidente,
            DateOnly TrabajadorAccidenteFecha,
            TimeSpan TrabajadorAccidenteHora,
            string medidasTextArea,
            string lugarTextArea,
            string consecuenciaTextArea
            )
        {
            try
            {
                // Create a new Mutual object with the data from the form
                var newAccidente = new Accidente
                {
                    Empresa = TrabajadorEmpresa,
                    Trabajador = TrabajadorNombre,
                    Trabajador_Id = TrabajadorId,
                    Rut = TrabajadorRut,
                    Cargo = TrabajadorCargo,
                    Centro_Trabajo = TrabajadorCentroTrabajo,
                    Fecha_Ingreso = TrabajadorFechaIngreso,
                    Supervisor = supervisorTextArea,
                    Tipo_Accidente = TrabajadorTipoAccidente,
                    Fecha_Accidente = TrabajadorAccidenteFecha,
                    Hora_Accidente = TrabajadorAccidenteHora,
                    Medidas_Adoptadas = medidasTextArea,
                    Lugar_Accidente = lugarTextArea,
                    Consecuencia_Accidente = consecuenciaTextArea,
                    Formulario_Notificacion = null, // byte array, can be set to null
                    DIAT = null, // byte array, can be set to null
                    Fecha_Defuncion = null, // DateTime, can be set to null
                    Hora_Defuncion = null, // TimeSpan, can be set to null
                    Lugar_Defuncion = string.Empty
                };

                // Add the new Mutual object to the DbContext
                _dataFetchService.AddAccidente(newAccidente);

                Log.Information("Added row to accidentes table");

                // Redirect to a success page or perform any desired action
                return RedirectToAction("IngresarAccidente", "Accidentes"); // Redirect to Datos/Mutual
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding data to the database: {ex.Message}");
            }
        }

        [ActionName("Resumen")]
        public IActionResult Reporte()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoadPartialView(string selectedValue, string selectedEmpresa, int selectedTrabajador, string selectedAccidente)
        {
            // Based on the selected values, fetch the necessary data from the database
            // For example, you can use Entity Framework to query your database
            var empresaData = _dataFetchService.GetEmpresaByRut(selectedEmpresa);
            var trabajadorData = _dataFetchService.GetTrabajadorById(selectedTrabajador);

            // Create an instance of ArbolCausasViewModel and populate it
            var viewModel = new ArbolCausasViewModel
            {
                TrabajadorEmpresa = empresaData?.Razon_Social ?? string.Empty,
                TrabajadorId = trabajadorData.Id,
                TrabajadorNombre = trabajadorData?.Nombres ?? string.Empty,
                TrabajadorApellidoPaterno = trabajadorData?.Paterno ?? string.Empty,
                TrabajadorApellidoMaterno = trabajadorData?.Materno ?? string.Empty,
                TrabajadorRut = trabajadorData?.Rut_Trabajador ?? string.Empty,
                TrabajadorCargo = trabajadorData?.Cargo ?? string.Empty,
                TrabajadorCentroTrabajo = trabajadorData?.Centro_Trabajo ?? string.Empty,
                TrabajadorFechaIngreso = trabajadorData?.Fecha_Incorporacion.ToString(),
                TrabajadorTipoAccidente = selectedAccidente
                // Populate other properties based on your requirements
            };

            // Based on the selected value, return the corresponding partial view
            switch (selectedValue)
            {
                case "_ModeloCausalidad":
                    return PartialView("_ModeloCausalidad", viewModel);
                case "_CincoPorques":
                    return PartialView("_CincoPorques", viewModel);
                case "_ArbolCausas":
                    return PartialView("_ArbolCausas", viewModel);
                case "_Libre":
                    return PartialView("_Libre", viewModel);
                case "_Cuasi":
                    return PartialView("_Cuasi", viewModel);
                default:
                    return Content(""); // Handle the default case or return an empty content
            }
        }
    }
}