﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LaboratorioWebApi.Data.Entities;

public partial class Facturas
{
    public int NroFactura { get; set; }

    public DateTime? Fecha { get; set; }

    public int CodPaciente { get; set; }

    public virtual Pacientes CodPacienteNavigation { get; set; }

    public virtual ICollection<DetallesFactura> DetallesFacturas { get; set; } = new List<DetallesFactura>();
}