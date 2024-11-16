using LaboratorioWebApi.Data.Entities;
using LaboratorioWebApi.Data.Extensions;
using LaboratorioWebApi.Data.Procedures;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioWebApi.Data.Repositories
{

    public partial class LaboratorioDbContextProceduresRepository : ILaboratorioDbContextProceduresRepository
    {
        private readonly LaboratorioDbContext _context;

        public LaboratorioDbContextProceduresRepository(LaboratorioDbContext context)
        {
            _context = context;
        }

        public async Task<List<sp_practicas_fuera_coberturaResult>> GetPracticasFueraCoberturaAsync()
        {
            return await _context.Set<sp_practicas_fuera_coberturaResult>()
            .FromSqlRaw("EXEC sp_practicas_fuera_cobertura")
            .ToListAsync();
        }

        public virtual async Task<List<sp_costo_deriv_por_laboratorioResult>> sp_costo_deriv_por_laboratorioAsync
            (DateTime? fechaDesde, DateTime? fechaHasta, OutputParameter<int>?
            returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "fechaDesde",
                    Value = fechaDesde ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "fechaHasta",
                    Value = fechaHasta ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                parameterreturnValue,
            };
            var result = await _context.SqlQueryAsync<sp_costo_deriv_por_laboratorioResult>
                ("EXEC @returnValue = [dbo].[sp_costo_deriv_por_laboratorio] @fechaDesde = " +
                "@fechaDesde, @fechaHasta = @fechaHasta", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return result;
        }

        public virtual async Task<List<sp_costo_total_derivacionesResult>>
            sp_costo_total_derivacionesAsync(DateTime? fechaDesde, DateTime? fechaHasta,
            OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "fechaDesde",
                    Value = fechaDesde ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "fechaHasta",
                    Value = fechaHasta ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                parameterreturnValue,
            };
            var result = await _context.SqlQueryAsync<sp_costo_total_derivacionesResult>
                ("EXEC @returnValue = [dbo].[sp_costo_total_derivaciones] @fechaDesde = @fechaDesde," +
                " @fechaHasta = @fechaHasta", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return result;
        }

        public async Task<List<sp_estado_muestrasResult>> sp_estado_muestrasAsync
            (string estado, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            {                
                var parameterReturnValue = new SqlParameter
                {
                    ParameterName = "returnValue",
                    Direction = System.Data.ParameterDirection.Output,
                    SqlDbType = System.Data.SqlDbType.Int,
                };

                var sqlParameters = new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "estado",
                        Value = estado ?? (object)DBNull.Value,
                        SqlDbType = System.Data.SqlDbType.NVarChar
                    },
                    parameterReturnValue
                };

                var results = await _context.SpEstadoMuestrasResults
                    .FromSqlRaw("EXEC @returnValue = dbo.sp_estado_muestras @estado = @estado", sqlParameters)
                    .ToListAsync(cancellationToken);

                returnValue?.SetValue(parameterReturnValue.Value);

                return results;
            }
        }

        public async Task<List<sp_muestras_para_informarResult>> sp_muestras_para_informarAsync
            (OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterReturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[] { parameterReturnValue };

            var results = await _context.SpMuestrasParaInformarResults
                .FromSqlRaw("EXEC @returnValue = dbo.sp_muestras_para_informar", sqlParameters)
                .ToListAsync(cancellationToken);

            returnValue?.SetValue(parameterReturnValue.Value);

            return results;
        }
    }

}


