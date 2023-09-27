using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Mutual
{
    [Key] // Explicitly specify the primary key
    public int Id { get; set; }

    [Column("Rut")]
    public string Rut { get; set; }

    [Column("Razon_Social")]
    public string Razon_Social { get; set; }

    [Column("Giro")]
    public string Giro { get; set; }

    [Column("Direccion")]
    public string Direccion { get; set; }

    [Column("Region")]
    public string Region { get; set; }

    [Column("Ciudad")]
    public string Ciudad { get; set; }

    [Column("Comuna")]
    public string Comuna { get; set; }

    [Column("Telefono")]
    public string Telefono { get; set; }
}

public class Empresa
{
    [Key] // Explicitly specify the primary key
    public int Id { get; set; }

    [Column("Rut")]
    public string Rut { get; set; }

    [Column("Razon_Social")]
    public string Razon_Social { get; set; }

    [Column("Giro")]
    public string Giro { get; set; }

    [Column("Direccion")]
    public string Direccion { get; set; }

    [Column("Region")]
    public string Region { get; set; }

    [Column("Ciudad")]
    public string Ciudad { get; set; }

    [Column("Comuna")]
    public string Comuna { get; set; }

    [Column("Mail")]
    public string Mail { get; set; }

    [Column("Telefono")]
    public string Telefono { get; set; }

    [Column("Organizacion_Preventiva")]
    public string Organizacion_Preventiva { get; set; }

    [Column("Representante_Legal")]
    public string Representante_Legal { get; set; }

    [Column("Rut_Representante_Legal")]
    public string Rut_Representante_Legal { get; set; }

    [Column("Cantidad_Trabajadores")]
    public int Cantidad_Trabajadores { get; set; }

    [Column("Id_Mutual")]
    public int Id_Mutual { get; set; }

    [Column("Mutual")]
    public string Mutual { get; set; }

    [Column("Nombre_Responsable")]
    public string Nombre_Responsable { get; set; }

    [Column("Rut_Representante")]
    public string Rut_Representante { get; set; }

    [Column("Mail_Responsable")]
    public string Mail_Responsable { get; set; }

    [Column("Telefono_Responsable")]
    public string Telefono_Responsable { get; set; }

    [Column("Activo")]
    public bool Activo { get; set; }
}

public class EmpresaFilial
{
    [Key] // Explicitly specify the primary key
    public int Id { get; set; }

    [Column("Rut")]
    public string Rut { get; set; }

    [Column("Razon_Social_Empresa")]
    public string Razon_Social_Empresa { get; set; }

    [Column("Rut_Filial")]
    public string Rut_Filial { get; set; }

    [Column("Razon_Social_Filial")]
    public string Razon_Social_Filial { get; set; }

    [Column("Representante_Legal_Filial")]
    public string Representante_Legal_Filial { get; set; }

    [Column("Rut_Representante_legal_Filial")]
    public string Rut_Representante_legal_Filial { get; set; }
}

public class CentroTrabajo
{
    [Key] // Explicitly specify the primary key
    public int id { get; set; }

    [Column("Centro_Trabajo")]
    public string Centro_Trabajo { get; set; }

    [Column("Razon_Social_Empresa")]
    public string Razon_Social_Empresa { get; set; }

    // Navigation property to represent the relationship with Empresa
    [ForeignKey("Empresa_Id")]
    public int Empresa_Id { get; set; }
}

public class Cargo
{
    [Key] // Explicitly specify the primary key
    public int Id { get; set; }

    [Column("Descripcion")]
    public string Descripcion { get; set; }
}

public class RegimenTrabajo
{
    [Key] // Explicitly specify the primary key
    public int Id { get; set; }

    [Column("Descripcion")]
    public string Descripcion { get; set; }
}

public class Contrato
{
    [Key] // Explicitly specify the primary key
    public int Id { get; set; }

    [Column("Descripcion")]
    public string Descripcion { get; set; }
}

public class Trabajador
{
    [Key]
    public int Id { get; set; }

    [Column("Rut_Empresa")]
    public string Rut_Empresa { get; set; }

    [Column("Rut_Empresa_Filial")]
    public string Rut_Empresa_Filial { get; set; }

    [Column("Rut_Trabajador")]
    public string Rut_Trabajador { get; set; }

    [Column("Nombres")]
    public string Nombres { get; set; }

    [Column("Paterno")]
    public string Paterno { get; set; }

    [Column("Materno")]
    public string Materno { get; set; }

    [Column("Sexo")]
    public string Sexo { get; set; }

    [Column("Nacionalidad")]
    public string Nacionalidad { get; set; }

    [Column("Mail")]
    public string Mail { get; set; }

    [Column("Direccion")]
    public string Direccion { get; set; }

    [Column("Ciudad")]
    public string Ciudad { get; set; }

    [Column("Telefono")]
    public string Telefono { get; set; }

    [Column("Id_Contrato")]
    public int Id_Contrato { get; set; }

    [Column("Contrato")]
    public string Contrato { get; set; }

    [Column("Id_Centro_Trabajo")]
    public int Id_Centro_Trabajo { get; set; }

    [Column("Centro_Trabajo")]
    public string Centro_Trabajo { get; set; }

    [Column("Id_Cargo")]
    public int Id_Cargo { get; set; }

    [Column("Cargo")]
    public string Cargo { get; set; }

    [Column("Fecha_Incorporacion")]
    public DateOnly Fecha_Incorporacion { get; set; }

    [Column("Id_Regimen_Contrato")]
    public int Id_Regimen_Contrato { get; set; }

    [Column("Regimen_Contrato")]
    public string Regimen_Contrato { get; set; }
}