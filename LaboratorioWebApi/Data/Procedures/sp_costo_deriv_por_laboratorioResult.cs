using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratorioWebApi.Data.Procedures
{
    public partial class sp_costo_deriv_por_laboratorioResult
    {
        public string? LABORATORIO { get; set; }
        [Column("TOTAL DERIVACIONES POR LABORATORIO", TypeName = "decimal(38,2)")]
        public decimal? TOTALDERIVACIONESPORLABORATORIO { get; set; }
        public string? MES { get; set; }
        public int? ANIO { get; set; }
    }
}
