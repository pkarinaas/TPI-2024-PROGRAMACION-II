﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LaboratorioWebApi.Data.Entities;

public partial class Ciudades
{
    public int CodCiudad { get; set; }

    public string Ciudad { get; set; }

    public int CodProvincia { get; set; }

    public virtual ICollection<Barrios> Barrios { get; set; } = new List<Barrios>();

    public virtual Provincias CodProvinciaNavigation { get; set; }

    public virtual ICollection<LabDerivaciones> LabDerivaciones { get; set; } = new List<LabDerivaciones>();
}