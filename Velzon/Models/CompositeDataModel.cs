using System.Collections.Generic;

namespace Velzon.Models
{
    public class CompositeModel
    {
        public List<Mutual> Mutuals { get; set; }
        public ChileDataModel ChileData { get; set; }
        public List<Empresa> Empresas { get; set; }
        public List<EmpresaFilial> Empresas_Filiales { get; set; }
        public List<CentroTrabajo> Centros_Trabajos { get; set; }
        public List<Cargo> Cargos { get; set; }
        public List<RegimenTrabajo> Regimen_Trabajos { get; set; }
        public List<Contrato> Contratos { get; set; }
        public List<Trabajador> Trabajadores { get; set; }

        // Expose Regions directly from ChileData
        public List<RegionModel> Regions => ChileData?.Regions;
    }
}
