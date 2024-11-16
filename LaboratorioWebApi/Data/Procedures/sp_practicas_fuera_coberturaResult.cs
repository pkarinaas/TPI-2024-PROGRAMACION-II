using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratorioWebApi.Data.Procedures
{
    public class sp_practicas_fuera_coberturaResult
    {
       
        [Column("nombre_paciente")]
        public string NombrePaciente { get; set; }
        [Column("nombre_practica")]
        public string NombrePractica { get; set; }
        [Column("obra_social")]
        public string ObraSocial { get; set; }
        [Column("monto_cobertura", TypeName = "decimal(38,2)")]
        public decimal MontoCobertura { get; set; }
        [Column("precio_derivacion", TypeName = "decimal(38,2)")]
        public decimal PrecioDerivacion { get; set; }
        [Column("estado_cobertura")]
        public string EstadoCobertura { get; set; }

    }

}
