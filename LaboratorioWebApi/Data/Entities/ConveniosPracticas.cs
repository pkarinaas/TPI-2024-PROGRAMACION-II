﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LaboratorioWebApi.Data.Entities;

public partial class ConveniosPracticas
{
    public int CodConvPractica { get; set; }

    public int CodOs { get; set; }

    public int CodNbu { get; set; }

    public virtual Practicas CodNbuNavigation { get; set; }

    public virtual Convenios CodOsNavigation { get; set; }
}