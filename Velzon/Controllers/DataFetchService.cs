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

namespace Velzon.Services
{
    public class DataFetchService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;

        public DataFetchService(IWebHostEnvironment env, ApplicationDbContext context)
        {
            _env = env;
            _context = context;
        }

        public CompositeModel GetCompositeModel()
        {
            var jsonFilePath = Path.Combine(_env.WebRootPath, "assets", "json", "chile-data.json");

            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var chileData = JsonSerializer.Deserialize<ChileDataModel>(jsonData, serializerOptions);

                var mutuals = _context.mutual.ToList();
                var empresas = _context.empresa.ToList();
                var empresas_filiales = _context.empresa_filial.ToList();
                var centros_trabajos = _context.centro_trabajo.ToList();
                var cargos = _context.cargo.ToList();
                var regimen_trabajos = _context.regimen_contrato.ToList();
                var contratos = _context.contrato.ToList();
                var trabajadores = _context.trabajadores.ToList();

                var compositeModel = new CompositeModel
                {
                    Mutuals = mutuals,
                    ChileData = chileData,
                    Empresas = empresas,
                    Empresas_Filiales = empresas_filiales,
                    Centros_Trabajos = centros_trabajos,
                    Cargos = cargos,
                    Regimen_Trabajos = regimen_trabajos,
                    Contratos = contratos,
                    Trabajadores = trabajadores,
                };

                return compositeModel;
            }
            catch (Exception ex)
            {
                // Handle exceptions here as needed.
                // You can log the error and return a default model or an error view.
                // Logging and error handling should be adjusted to your application's requirements.
                throw; // Rethrow the exception for now; you may want to handle it differently.
            }
        }

        public void AddEmpresa(Empresa newEmpresa)
        {
            try
            {
                // Add the newEmpresa object to the DbContext
                _context.empresa.Add(newEmpresa);

                // Save the changes to the database
                _context.SaveChanges();

                Log.Information("Added row to empresa table");
            }
            catch (Exception ex)
            {
                // Handle exceptions here as needed.
                // You can log the error and return a default model or an error view.
                // Logging and error handling should be adjusted to your application's requirements.
                throw; // Rethrow the exception for now; you may want to handle it differently.
            }
        }

        public Empresa GetEmpresaByRut(string rut)
        {
            // Query the empresa table based on the Rut
            return _context.empresa.FirstOrDefault(e => e.Rut == rut);
        }

        public void AddEmpresaFilial(EmpresaFilial newEmpresaFilial)
        {
            try
            {
                // Add the newEmpresa object to the DbContext
                _context.empresa_filial.Add(newEmpresaFilial);

                // Save the changes to the database
                _context.SaveChanges();

                Log.Information("Added row to empresa_filial table");
            }
            catch (Exception ex)
            {
                // Handle exceptions here as needed.
                // You can log the error and return a default model or an error view.
                // Logging and error handling should be adjusted to your application's requirements.
                throw; // Rethrow the exception for now; you may want to handle it differently.
            }
        }

        public void AddMutual(Mutual newMutual)
        {
            try
            {
                // Add the newEmpresa object to the DbContext
                _context.mutual.Add(newMutual);

                // Save the changes to the database
                _context.SaveChanges();

                Log.Information("Added row to mutual table");
            }
            catch (Exception ex)
            {
                // Handle exceptions here as needed.
                // You can log the error and return a default model or an error view.
                // Logging and error handling should be adjusted to your application's requirements.
                throw; // Rethrow the exception for now; you may want to handle it differently.
            }
        }

        public void AddCentroTrabajo(CentroTrabajo newCentroTrabajo)
        {
            try
            {
                // Add the newEmpresa object to the DbContext
                _context.centro_trabajo.Add(newCentroTrabajo);

                // Save the changes to the database
                _context.SaveChanges();

                Log.Information("Added row to centro_trabajo table");
            }
            catch (Exception ex)
            {
                // Handle exceptions here as needed.
                // You can log the error and return a default model or an error view.
                // Logging and error handling should be adjusted to your application's requirements.
                throw; // Rethrow the exception for now; you may want to handle it differently.
            }
        }

        public void AddTrabajador(Trabajador newTrabajador)
        {
            try
            {
                // Add the newEmpresa object to the DbContext
                _context.trabajadores.Add(newTrabajador);

                // Save the changes to the database
                _context.SaveChanges();

                Log.Information("Added row to trabajadores table");
            }
            catch (Exception ex)
            {
                // Handle exceptions here as needed.
                // You can log the error and return a default model or an error view.
                // Logging and error handling should be adjusted to your application's requirements.
                throw; // Rethrow the exception for now; you may want to handle it differently.
            }
        }

        public IEnumerable<Trabajador> GetTrabajadoresByRut(string rut)
        {
            // Query the trabajadores table based on the Rut
            var trabajadores = _context.trabajadores.Where(t => t.Rut_Empresa == rut).ToList();

            return trabajadores;
        }

        public Trabajador GetTrabajadorById(int id)
        {
            // Query the trabajadores table based on the Id
            return _context.trabajadores.FirstOrDefault(t => t.Id == id);
        }

        public void AddContrato(Contrato newContrato)
        {
            try
            {
                // Add the newEmpresa object to the DbContext
                _context.contrato.Add(newContrato);

                // Save the changes to the database
                _context.SaveChanges();

                Log.Information("Added row to contrato table");
            }
            catch (Exception ex)
            {
                // Handle exceptions here as needed.
                // You can log the error and return a default model or an error view.
                // Logging and error handling should be adjusted to your application's requirements.
                throw; // Rethrow the exception for now; you may want to handle it differently.
            }
        }

        public void AddCargo(Cargo newCargo)
        {
            try
            {
                // Add the newEmpresa object to the DbContext
                _context.cargo.Add(newCargo);

                // Save the changes to the database
                _context.SaveChanges();

                Log.Information("Added row to cargo table");
            }
            catch (Exception ex)
            {
                // Handle exceptions here as needed.
                // You can log the error and return a default model or an error view.
                // Logging and error handling should be adjusted to your application's requirements.
                throw; // Rethrow the exception for now; you may want to handle it differently.
            }
        }

        public void AddRegimenTrabajo(RegimenTrabajo newRegimenTrabajo)
        {
            try
            {
                // Add the newEmpresa object to the DbContext
                _context.regimen_contrato.Add(newRegimenTrabajo);

                // Save the changes to the database
                _context.SaveChanges();

                Log.Information("Added row to regimen_contrato table");
            }
            catch (Exception ex)
            {
                // Handle exceptions here as needed.
                // You can log the error and return a default model or an error view.
                // Logging and error handling should be adjusted to your application's requirements.
                throw; // Rethrow the exception for now; you may want to handle it differently.
            }
        }

        public void AddAccidente(Accidente newAccidente)
        {
            try
            {
                // Add the newEmpresa object to the DbContext
                _context.accidentes.Add(newAccidente);

                // Save the changes to the database
                _context.SaveChanges();

                Log.Information("Added row to accidentes table");
            }
            catch (Exception ex)
            {
                // Handle exceptions here as needed.
                // You can log the error and return a default model or an error view.
                // Logging and error handling should be adjusted to your application's requirements.
                throw; // Rethrow the exception for now; you may want to handle it differently.
            }
        }
    }
}
