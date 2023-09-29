using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Mutual> mutual { get; set; }

    public DbSet<Empresa> empresa { get; set; }

    public DbSet<EmpresaFilial> empresa_filial { get; set; }

    public DbSet<CentroTrabajo> centro_trabajo { get; set; }

    public DbSet<Cargo> cargo { get; set; }

    public DbSet<RegimenTrabajo> regimen_contrato { get; set; }

    public DbSet<Contrato> contrato { get; set; }

    public DbSet<Trabajador> trabajadores { get; set; }

    public DbSet<Accidente> accidentes { get; set; }
}
