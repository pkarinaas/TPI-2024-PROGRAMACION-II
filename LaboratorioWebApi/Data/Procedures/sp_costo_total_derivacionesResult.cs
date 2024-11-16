using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratorioWebApi.Data.Procedures
{
    public partial class sp_costo_total_derivacionesResult
    {
        [Column("TOTAL DERIVACIONES MENSUAL", TypeName = "decimal(38,2)")]
        public decimal? TOTALDERIVACIONESMENSUAL { get; set; }
        public string? MES { get; set; }
        public int? ANIO { get; set; }
    }
}
