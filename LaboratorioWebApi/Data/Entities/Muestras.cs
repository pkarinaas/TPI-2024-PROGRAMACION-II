﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LaboratorioWebApi.Data.Entities;

public partial class Muestras
{
    public int IdMuestra { get; set; }

    public int? CodPaciente { get; set; }

    public DateTime? FechaRecoleccion { get; set; }

    public int IdTipoEstado { get; set; }
    [JsonIgnore]
    public virtual Pacientes CodPacienteNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<DetallesMuestras> DetallesMuestras { get; set; } = new List<DetallesMuestras>();
    [JsonIgnore]
    public virtual TiposEstados IdTipoEstadoNavigation { get; set; }
}