﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LaboratorioWebApi.Data.Entities;

public partial class Pacientes
{
    public int CodPaciente { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Telefono { get; set; }

    public int? CodOs { get; set; }

    public int? IdTipoDocumento { get; set; }

    public string NroDoc { get; set; }

    public string Email { get; set; }

    public string Calle { get; set; }

    public string Altura { get; set; }

    public int? CodBarrio { get; set; }

    public virtual Barrios CodBarrioNavigation { get; set; }

    public virtual Convenios CodOsNavigation { get; set; }

    public virtual ICollection<Facturas> Facturas { get; set; } = new List<Facturas>();

    public virtual TiposDocumentos IdTipoDocumentoNavigation { get; set; }

    public virtual ICollection<Muestras> Muestras { get; set; } = new List<Muestras>();
}