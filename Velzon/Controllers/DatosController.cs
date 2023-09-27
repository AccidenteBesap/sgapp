using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Velzon.Models;
using Velzon.Services;

namespace Velzon.Controllers
{
    public class DatosController : Controller
    {
        private readonly DataFetchService _dataFetchService;

        public DatosController(DataFetchService dataFetchService)
        {
            _dataFetchService = dataFetchService;
        }

        [ActionName("Empresa")]
        public IActionResult Empresa()
        {
            var compositeModel = _dataFetchService.GetCompositeModel();
            return View(compositeModel);
        }

        [HttpPost]
        public IActionResult InsertEmpresa(
    string Rut,
    string Razon_Social,
    string Giro,
    string Direccion,
    string Region,
    string Comuna,
    string Ciudad,
    string Mail,
    string Telefono,
    string Organizacion_Preventiva,
    string Representante_Legal,
    string Rut_Representante_Legal,
    int Cantidad_Trabajadores,
    string MutualAndId,
    string Nombre_Responsable,
    string Rut_Representante,
    string Mail_Responsable,
    string Telefono_Responsable,
    bool Activo)
        {
            Console.WriteLine($"MutualAndId: {MutualAndId}");

            try
            {
                // Split the MutualAndId value to get Id and Razon_Social
                string[] parts = MutualAndId.Split('-');

                if (parts.Length == 2)
                {
                    int idMutual = int.Parse(parts[0]); // Parse the Id as an integer
                    string razonSocialMutual = parts[1]; // Get the Razon_Social

                    // Create a new Empresa object with the data from the form
                    var newEmpresa = new Empresa
                    {
                        Rut = Rut,
                        Razon_Social = Razon_Social,
                        Giro = Giro,
                        Direccion = Direccion,
                        Region = Region,
                        Ciudad = Ciudad,
                        Comuna = Comuna,
                        Mail = Mail,
                        Telefono = Telefono,
                        Organizacion_Preventiva = Organizacion_Preventiva,
                        Representante_Legal = Representante_Legal,
                        Rut_Representante_Legal = Rut_Representante_Legal,
                        Cantidad_Trabajadores = Cantidad_Trabajadores,
                        Id_Mutual = idMutual, // Assign Id_Mutual
                        Mutual = razonSocialMutual, // Assign Mutual
                        Nombre_Responsable = Nombre_Responsable,
                        Rut_Representante = Rut_Representante,
                        Mail_Responsable = Mail_Responsable,
                        Telefono_Responsable = Telefono_Responsable,
                        Activo = Activo
                    };

                    // Add the new Empresa object to the DbContext
                    _dataFetchService.AddEmpresa(newEmpresa);

                    Log.Information("Added row to empresa table");

                    // Redirect to a success page or perform any desired action
                    return RedirectToAction("Empresa", "Datos"); // Redirect to Datos/Empresa
                }
                else
                {
                    // Handle the case where the value is not in the expected format
                    return BadRequest("Invalid MutualAndId format");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding data to the database: {ex.Message}");
            }
        }


        [ActionName("EmpresaFilial")]
        public IActionResult EmpresaFilial()
        {
            var compositeModel = _dataFetchService.GetCompositeModel();
            return View(compositeModel);
        }

        [HttpPost]
        public IActionResult InsertEmpresaFilial(string Rut, string selectEmpresaPrincipalFilial, string Rut_Filial, string Razon_Social_Filial, string Representante_Legal_Filial, string Rut_Representante_Legal_Filial)
        {
            try
            {
                // Create a new Empresa object with the data from the form
                var newEmpresaFilial = new EmpresaFilial
                {
                    Rut = Rut,
                    Razon_Social_Empresa = selectEmpresaPrincipalFilial,
                    Rut_Filial = Rut_Filial,
                    Razon_Social_Filial = Razon_Social_Filial,
                    Representante_Legal_Filial = Representante_Legal_Filial,
                    Rut_Representante_legal_Filial = Rut_Representante_Legal_Filial
                };

                // Add the new Empresa object to the DbContext
                _dataFetchService.AddEmpresaFilial(newEmpresaFilial);

                Log.Information("Added row to empresa_filial table");

                // Redirect to a success page or perform any desired action
                return RedirectToAction("EmpresaFilial", "Datos"); // Redirect to Datos/Empresa
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding data to the database: {ex.Message}");
            }
        }

        [ActionName("Mutual")]
        public IActionResult Mutual()
        {
            var compositeModel = _dataFetchService.GetCompositeModel();
            return View(compositeModel);
        }

        [HttpPost]
        public IActionResult InsertMutual(string crearRutMutual, string crearRazonSocial, string crearGiro, string crearDirecciónMutual, string selectRegionMutual, string selectComunaMutual, string selectCiudadMutual, string crearTelefonoMutual)
        {
            try
            {
                // Create a new Mutual object with the data from the form
                var newMutual = new Mutual
                {
                    Rut = crearRutMutual,
                    Razon_Social = crearRazonSocial,
                    Giro = crearGiro,
                    Direccion = crearDirecciónMutual,
                    Region = selectRegionMutual,
                    Ciudad = selectCiudadMutual,
                    Comuna = selectComunaMutual,
                    Telefono = crearTelefonoMutual
                };

                // Add the new Mutual object to the DbContext
                _dataFetchService.AddMutual(newMutual);

                Log.Information("Added row to mutual table");

                // Redirect to a success page or perform any desired action
                return RedirectToAction("Mutual", "Datos"); // Redirect to Datos/Mutual
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding data to the database: {ex.Message}");
            }
        }

        [ActionName("CentroTrabajo")]
        public IActionResult CentroTrabajo()
        {
            var compositeModel = _dataFetchService.GetCompositeModel();
            return View(compositeModel);
        }

        [HttpPost]
        public IActionResult InsertCentroTrabajo(string crearCentro, string EmpresaAndId)
        {
            try
            {
                // Split the MutualAndId value to get Id and Razon_Social
                string[] parts = EmpresaAndId.Split('-');

                if (parts.Length == 2)
                {
                    int idEmpresa = int.Parse(parts[0]); // Parse the Id as an integer
                    string razonSocialEmpresa = parts[1]; // Get the Razon_Social

                    // Create a new Empresa object with the data from the form
                    var newCentroTrabajo = new CentroTrabajo
                    {
                        Centro_Trabajo = crearCentro,
                        Empresa_Id = idEmpresa,
                        Razon_Social_Empresa = razonSocialEmpresa
                    };

                    // Add the new Empresa object to the DbContext
                    _dataFetchService.AddCentroTrabajo(newCentroTrabajo);

                    Log.Information("Added row to centro_trabajo table");

                    // Redirect to a success page or perform any desired action
                    return RedirectToAction("CentroTrabajo", "Datos"); // Redirect to Datos/Empresa
                }
                else
                {
                    // Handle the case where the value is not in the expected format
                    return BadRequest("Invalid MutualAndId format");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding data to the database: {ex.Message}");
            }
        }

        [ActionName("Trabajador")]
        public IActionResult Trabajador()
        {
            var compositeModel = _dataFetchService.GetCompositeModel();
            return View(compositeModel);
        }

        [HttpPost]
        public IActionResult InsertTrabajador(
string EmpresaAndRut,
string crearTrabajadorRut,
string crearNombresTrabajador,
string crearApellidoPaterno,
string crearApellidoMaterno,
string sexoRadio,
string crearNacionalidadTrabajador,
string crearDireccionTrabajador,
string crearCiudadTrabajador,
string crearEmailTrabajador,
string crearTelefonoTrabajador,
string ContratoAndId,
string CentroTrabajoAndId,
string CargoTrabajadorAndId,
string crearIncorporacionTrabajador,
string RegimenTrabajadorAndId)
        {
            try
            {
                // Split the EmpresaAndRut value to get Id and Rut
                string[] empresaParts = EmpresaAndRut.Split('/').Select(part => part.Trim()).ToArray();
                Console.WriteLine($"empresaParts: {empresaParts}");
                // Split the CentroTrabajoAndId value to get Id and Centro_Trabajo
                string[] centroTrabajoParts = CentroTrabajoAndId.Split('-').Select(part => part.Trim()).ToArray();
                Console.WriteLine($"centroTrabajoParts: {centroTrabajoParts}");
                // Split the CargoTrabajadorAndId value to get Id and Cargo
                string[] cargoTrabajadorParts = CargoTrabajadorAndId.Split('-').Select(part => part.Trim()).ToArray();
                Console.WriteLine($"cargoTrabajadorParts: {cargoTrabajadorParts}");
                // Split the RegimenTrabajadorAndId value to get Id and Regimen_Contrato
                string[] regimenTrabajadorParts = RegimenTrabajadorAndId.Split('-').Select(part => part.Trim()).ToArray();
                Console.WriteLine($"regimenTrabajadorParts: {regimenTrabajadorParts}");
                // Split the ContratoAndId value to get Id and Contrato
                string[] contratoTrabajadorParts = ContratoAndId.Split('-').Select(part => part.Trim()).ToArray();
                Console.WriteLine($"contratoTrabajadorParts: {contratoTrabajadorParts}");

                if (empresaParts.Length == 2 && centroTrabajoParts.Length == 2 && cargoTrabajadorParts.Length == 2 && regimenTrabajadorParts.Length == 2 && contratoTrabajadorParts.Length == 2)
                {

                    string rutEmpresa = empresaParts[1]; // Get the Rut

                    int idCentroTrabajo = int.Parse(centroTrabajoParts[0]); // Parse the Id as an integer
                    string centroTrabajo = centroTrabajoParts[1]; // Get the Centro_Trabajo

                    int idCargo = int.Parse(cargoTrabajadorParts[0]); // Parse the Id as an integer
                    string cargo = cargoTrabajadorParts[1]; // Get the Cargo

                    int idRegimenContrato = int.Parse(regimenTrabajadorParts[0]); // Parse the Id as an integer
                    string regimenContrato = regimenTrabajadorParts[1]; // Get the Regimen_Contrato

                    int idContrato = int.Parse(contratoTrabajadorParts[0]); // Parse the Id as an integer
                    string contrato = contratoTrabajadorParts[1]; // Get the Contrato

                    Console.WriteLine($"crearIncorporacionTrabajador: {crearIncorporacionTrabajador}");

                    // Parse the fechaIncorporacionTrabajador string into a DateTime
                    DateOnly fechaIncorporacion;
                    if (DateOnly.TryParse(crearIncorporacionTrabajador, out fechaIncorporacion))
                    {
                        // Create a new Trabajador object with the data from the form
                        var newTrabajador = new Trabajador
                        {
                            Rut_Empresa = rutEmpresa,
                            Rut_Trabajador = crearTrabajadorRut,
                            Nombres = crearNombresTrabajador,
                            Paterno = crearApellidoPaterno,
                            Materno = crearApellidoMaterno,
                            Sexo = sexoRadio,
                            Nacionalidad = crearNacionalidadTrabajador,
                            Mail = crearEmailTrabajador,
                            Direccion = crearDireccionTrabajador,
                            Ciudad = crearCiudadTrabajador,
                            Telefono = crearTelefonoTrabajador,
                            Id_Contrato = idContrato,
                            Contrato = contrato,
                            Id_Centro_Trabajo = idCentroTrabajo,
                            Centro_Trabajo = centroTrabajo,
                            Id_Cargo = idCargo,
                            Cargo = cargo,
                            Fecha_Incorporacion = fechaIncorporacion, // Assign the parsed DateTime
                            Id_Regimen_Contrato = idRegimenContrato,
                            Regimen_Contrato = regimenContrato
                        };

                        // Add the new Trabajador object to the DbContext
                        _dataFetchService.AddTrabajador(newTrabajador);

                        Log.Information("Added row to trabajadores table");

                        // Redirect to a success page or perform any desired action
                        return RedirectToAction("Trabajador", "Datos"); // Redirect to Datos/Trabajador
                    }
                    else
                    {
                        // Handle the case where the date string couldn't be parsed.
                        return BadRequest("Invalid date format for Fecha_Incorporacion");
                    }
                }
                else
                {
                    // Handle the case where the value is not in the expected format
                    return BadRequest("Invalid format");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding data to the database: {ex.Message}");
            }
        }

        [ActionName("Contrato")]
        public IActionResult Contrato()
        {
            var compositeModel = _dataFetchService.GetCompositeModel();
            return View(compositeModel);
        }

        [HttpPost]
        public IActionResult InsertContrato(string crearContrato)
        {
            try
            {
                // Create a new Contrato object with the data from the form
                var newContrato = new Contrato
                {
                    Descripcion = crearContrato,
                };

                // Add the new Contrato object to the DbContext
                _dataFetchService.AddContrato(newContrato);

                Log.Information("Added row to contrato table");

                // Redirect to a success page or perform any desired action
                return RedirectToAction("Contrato", "Datos"); // Redirect to Datos/Contrato
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding data to the database: {ex.Message}");
            }
        }

        [ActionName("Cargo")]
        public IActionResult Cargo()
        {
            var compositeModel = _dataFetchService.GetCompositeModel();
            return View(compositeModel);
        }

        [HttpPost]
        public IActionResult InsertCargo(string crearCargo)
        {
            try
            {
                // Create a new Empresa object with the data from the form
                var newCargo = new Cargo
                {
                    Descripcion = crearCargo,
                };

                // Add the new Empresa object to the DbContext
                _dataFetchService.AddCargo(newCargo);

                Log.Information("Added row to cargo table");

                // Redirect to a success page or perform any desired action
                return RedirectToAction("Cargo", "Datos"); // Redirect to Datos/Empresa
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding data to the database: {ex.Message}");
            }
        }

        [ActionName("RegimenTrabajo")]
        public IActionResult RegimenTrabajo()
        {
            var compositeModel = _dataFetchService.GetCompositeModel();
            return View(compositeModel);
        }

        [HttpPost]
        public IActionResult InsertRegimenTrabajo(string crearRegimen)
        {
            try
            {
                // Create a new Empresa object with the data from the form
                var newRegimenTrabajo = new RegimenTrabajo
                {
                    Descripcion = crearRegimen,
                };

                // Add the new Empresa object to the DbContext
                _dataFetchService.AddRegimenTrabajo(newRegimenTrabajo);

                Log.Information("Added row to regimen_contrato table");

                // Redirect to a success page or perform any desired action
                return RedirectToAction("RegimenTrabajo", "Datos"); // Redirect to Datos/Empresa
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding data to the database: {ex.Message}");
            }
        }
    }
}
