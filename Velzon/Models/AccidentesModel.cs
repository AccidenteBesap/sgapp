using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Accidente
{
    [Key] // Explicitly specify the primary key
    public int Id { get; set; }

    [Column("Empresa")]
    public string Empresa { get; set; }

    [Column("Trabajador")]
    public string Trabajador { get; set; }

    [Column("Trabajador_Id")]
    public int Trabajador_Id { get; set; }

    [Column("Rut")]
    public string Rut { get; set; }

    [Column("Cargo")]
    public string Cargo { get; set; }

    [Column("Centro_Trabajo")]
    public string Centro_Trabajo { get; set; }

    [Column("Fecha_Ingreso")]
    public DateOnly Fecha_Ingreso { get; set; }

    [Column("Supervisor")]
    public string Supervisor { get; set; }

    [Column("Tipo_Accidente")]
    public string Tipo_Accidente { get; set; }

    [Column("Fecha_Accidente")]
    public DateOnly Fecha_Accidente { get; set; }

    [Column("Hora_Accidente")]
    public TimeSpan Hora_Accidente { get; set; }

    [Column("Medidas_Adoptadas")]
    public string Medidas_Adoptadas { get; set; }

    [Column("Lugar_Accidente")]
    public string Lugar_Accidente { get; set; }

    [Column("Consecuencia_Accidente")]
    public string Consecuencia_Accidente { get; set; }

    [Column("Formulario_Notificacion")]
    public byte[] Formulario_Notificacion { get; set; }

    [Column("DIAT")]
    public byte[] DIAT { get; set; }

    [Column("Fecha_Defuncion")]
    public DateOnly? Fecha_Defuncion { get; set; }

    [Column("Hora_Defuncion")]
    public TimeSpan? Hora_Defuncion { get; set; }

    [Column("Lugar_Defuncion")]
    public string Lugar_Defuncion { get; set; }
}